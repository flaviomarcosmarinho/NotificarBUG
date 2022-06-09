using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace NotificarBUG
{
    //System.Timers.Timer timerConsulta; //declarar como variavel global

    public partial class FormPrincipal : Form
    {
		private const int TEMPO = 60000;//1 minuto configurados em milisegundos.
        private int minutosParaPesquisa = 1;
        private ConexaoBancoDados conexao = new ConexaoBancoDados();      

        public FormPrincipal()
        {
			InitializeComponent();
		}		

		public void Alert(string serie, int numero, string detalhe, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(serie, numero, detalhe, type, minutosParaPesquisa);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Alert(string.Empty, 0, "BUG Fechado", Form_Alert.enmType.Success);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Alert(string.Empty, 0, "BUG Alterado", Form_Alert.enmType.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Alert(string.Empty, 0, "BUG Aberto", Form_Alert.enmType.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Alert(string.Empty, 0, "Info Alert", Form_Alert.enmType.Info);
        }

		private void Button5_Click(object sender, EventArgs e)
        {
            this.ConsultarNovosBUGs();            
        }

        private void ConsultarNovosBUGs()
        {
			dataSet.Clear();

            string comando = @"
SELECT TOP 10 Série, Número, Solicitação
FROM Solicitacoes (NOLOCK)
WHERE LTRIM(RTRIM(UPPER(Série))) = 'BUG' 
	AND Versão_Id = 4196 
	AND DataDoCancelamento is null
	AND year(Data) >= 2021
/*ORDER BY Número DESC*/";

            string comandoLocal = @"
SELECT Serie, Numero
FROM Verificado
WHERE LTRIM(RTRIM(UPPER(Serie))) = '{0}' 
	AND Numero = {1}";

            using (DataSet dstResultado = conexao.SelecionarDadosSqlGR(comando))
            {
                foreach (DataTable tabela in dstResultado.Tables)
                {
                    dataSet.Clear();

                    if (tabela.Rows.Count > 0)
                    {
                        dataSet.Solicitacoes.Merge(tabela);

                        foreach (DataSet.SolicitacoesRow bugRow in dataSet.Solicitacoes.Rows)
                        {
							string serie = ((bugRow.IsSérieNull()) ? string.Empty : bugRow.Série.Trim());
							int numero = ((bugRow.IsNúmeroNull()) ? 0 : bugRow.Número);

                            using (DataSet dstResultadoLocal = conexao.SelecionarDadosSqlLocal(string.Format(comandoLocal, serie, numero)))
                            {
                                foreach (DataTable tabelaLocal in dstResultadoLocal.Tables)
                                {
                                    dataSet_Compact.Clear();
                                    if (tabelaLocal.Rows.Count > 0)
                                    {
                                        dataSet_Compact.Verificado.Merge(tabelaLocal);
                                    }                                   
                                }

                                if (dataSet_Compact.Verificado.Rows.Count == 0)
                                {
                                    this.Alert(serie, numero, (bugRow.IsSolicitaçãoNull() ? string.Empty : bugRow.Solicitação.Trim()), Form_Alert.enmType.Error);
                                }
                            }
                        }
                    }
                }
            }
        }

        private string RetornarConsultaRelatorio(DateTime inicio, DateTime fim)
        {
            string comando = @"
DECLARE @dataInicial datetime, @dataFinal datetime
SET @dataInicial = '" + inicio.ToString("yyyyMMdd") + @"'
SET @dataFinal = '" + fim.ToString("yyyyMMdd") + @"'

SELECT Roteiros.Roteiro, Solicitacoes.Número,
	SUM(IsNull(EtapaSolicitacao.Tempo_Real,0)) Tempo
INTO #QtdeBugs
FROM Solicitacoes (NOLOCK)
	INNER JOIN Roteiros (NOLOCK) ON 
		Roteiros.Id = Solicitacoes.Roteiro_Id	
	LEFT JOIN Requisitos (NOLOCK) ON 
		Requisitos.Solicitação_Id = Solicitacoes.Id
	LEFT JOIN Etapas_da_Solicitacao EtapaSolicitacao (NOLOCK) ON 
		EtapaSolicitacao.Solicitacao_Id = Solicitacoes.Id
	LEFT JOIN Etapas (NOLOCK) ON  
		Etapas.Id = EtapaSolicitacao.Etapa_Id
WHERE Solicitacoes.Roteiro_Id IN (1014,1019,1020,1021,1022,1022,1023,1024,1026,1029)
	AND (Etapas.Etapa IS NULL OR  Etapas.Etapa like '%Desenvolvimento%')
	AND Solicitacoes.Data BETWEEN @dataInicial AND @dataFinal
	/*AND Solicitacoes.Número >= 2269 and Solicitacoes.Número <= 2469*/
GROUP BY Solicitacoes.Número, Roteiros.Roteiro

/************  Intervalo Análise em Dias********/
SELECT CONVERT(VARCHAR, @dataInicial ,103) 'Data Inicial', CONVERT(VARCHAR, @dataFinal ,103) 'Data Final', DATEDIFF(DAY, @dataInicial, @dataFinal) 'Dias Analisados'
/***********************************************/

/************  Quantitativo BUGs****************/
SELECT CASE WHEN Roteiro = 'BUG' THEN 'BUG FALSO' ELSE Roteiro END Roteiro,
	COUNT(Número) 'Qtde Bugs',
	dbo.FN_CONVERTER_FORMATO_HORAS(Sum(tempo)) Horas
FROM #QtdeBugs
GROUP BY Roteiro
ORDER BY Count(Número) desc
/***********************************************/

/************  Lstagem Conferência *************/
SELECT Roteiros.Roteiro, Solicitacoes.Número, Versoes.Versão, Solicitacoes.Solicitação, 
	/*EtapaSolicitacao.Id,*/ Etapas.Etapa,/* Responsaveis.Responsável,*/
	SUM(EtapaSolicitacao.Tempo_Real) TempoMinutos,
	dbo.FN_CONVERTER_FORMATO_HORAS(Sum(EtapaSolicitacao.Tempo_Real)) Horas
INTO #Conferencia
FROM Solicitacoes (NOLOCK)
	INNER JOIn Roteiros (NOLOCK) ON 
		Roteiros.Id = Solicitacoes.Roteiro_Id
	LEFT JOIN Requisitos (NOLOCK) ON 
		Requisitos.Solicitação_Id = Solicitacoes.Id
	LEFT JOIN Versoes (NOLOCK) ON 
		Solicitacoes.Versão_Id = Versoes.Id
	LEFT JOIN Etapas_da_Solicitacao EtapaSolicitacao (NOLOCK) ON 
		EtapaSolicitacao.Solicitacao_Id = Solicitacoes.Id
	LEFT JOIN Etapas (NOLOCK) ON  
		Etapas.Id = EtapaSolicitacao.Etapa_Id
	LEFT JOIN Responsaveis (NOLOCK) ON 
		Responsaveis.Id = EtapaSolicitacao.Executor_Id
WHERE Solicitacoes.Roteiro_Id in(1014,1019,1020,1021,1022,1022,1023,1024,1026,1029)
	AND (Etapas.Etapa is null OR  Etapas.Etapa like '%Desenvolvimento%')
	AND Solicitacoes.Data BETWEEN @dataInicial AND @dataFinal
	/*AND Solicitacoes.Número >= 2269 and Solicitacoes.Número <= 2469*/
GROUP BY Roteiros.Roteiro, Solicitacoes.Número, Versoes.Versão, Solicitacoes.Solicitação, 
	/*EtapaSolicitacao.Id, */Etapas.Etapa
ORDER BY Solicitacoes.Número
	
SELECT TOP 10 Roteiro, Número, Versão, Solicitação, Etapa, Horas 
FROM #Conferencia 
ORDER BY TempoMinutos DESC

SELECT * 
FROM #Conferencia 

DROP TABLE #QtdeBugs, #Conferencia";

            return comando;
        }

        private void EmitirRelatorioAnalise()
        {
            string comando = RetornarConsultaRelatorio(dateTimePickerInicio.Value, dateTimePickerFim.Value);

            List<StiReport> reports = new List<StiReport>();
            string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(StartupPath, "Relatorio.mrt");

            StiReport relatorio = new StiReport();
            relatorio.Load(path);
            reports.Add(relatorio);

            Dictionary<string, object> paramters = new Dictionary<string, object>();

            using (DataSet dstResultado = conexao.SelecionarDadosSqlGR(comando))
            {
                ReportVisualizerBase reportVisualizerBase = new ReportVisualizerBase(this.Name, dstResultado, paramters, reports);
                //reportVisualizerBase.Disposed += reportVisualizerBase_Disposed;
                reportVisualizerBase.Show(this);
            }
        }

        private void EditarRelatorioAnalise()
        {
            string comando = RetornarConsultaRelatorio(dateTimePickerInicio.Value, dateTimePickerFim.Value);

            using (DataSet dstResultado = conexao.SelecionarDadosSqlGR(comando))
            {
                string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string path = Path.Combine(StartupPath, "Relatorio.mrt");

                StiReport relatorio = new StiReport();
                relatorio.Load(path);

                Dictionary<string, object> paramters = new Dictionary<string, object>();
                ReportDesignerBase reportDesignerBase = new ReportDesignerBase(this.Name, dstResultado, paramters, relatorio, path);
                //reportDesignerBase.saveReport += SaveReport;
                reportDesignerBase.ShowDialog(this);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
				ShowInTaskbar = false;
				ShowIcon = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            ShowIcon = true;
			ShowInTaskbar = true;
			WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipText = "Notificação de BUG minimizada.";
            notifyIcon1.BalloonTipTitle = "Notificação de BUG";
        }		

        private void FormPrincipal_Shown(object sender, EventArgs e)
        {
            lblTempoConsulta.Text = minutosParaPesquisa.ToString() + ((minutosParaPesquisa > 1) ? " Minutos" : " Minuto");
            timer1.Interval = minutosParaPesquisa * TEMPO;
			timer1.Start();

            dateTimePickerInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePickerFim.Value = DateTime.Now;

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
			timer1.Stop();

			//Lógica que deve ser executada, start e stop para evitar que a mesma lógica rode em paralelo;
			ConsultarNovosBUGs();
			
			timer1.Start();
		}

        private void TrackBarTempoConsulta_Scroll(object sender, EventArgs e)
        {
            minutosParaPesquisa = trackBarTempoConsulta.Value;
            lblTempoConsulta.Text = minutosParaPesquisa.ToString() + ((minutosParaPesquisa > 1) ? " Minutos" : " Minuto");
            timer1.Interval = minutosParaPesquisa * TEMPO;
        }

        private void btnEditReport_Click(object sender, EventArgs e)
        {
            this.EditarRelatorioAnalise();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            this.EmitirRelatorioAnalise();
        }
    }
}
