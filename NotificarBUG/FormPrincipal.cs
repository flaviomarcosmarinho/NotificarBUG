using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace NotificarBUG
{
    public partial class FormPrincipal : Form
    {
        #region Atributos

        private const int TEMPO = 60000;//1 minuto configurados em milisegundos.
        private int minutosParaPesquisa = 10;
        private ConexaoBancoDados conexao = new ConexaoBancoDados();

        #endregion

        #region Contrutor

        public FormPrincipal()
        {
            InitializeComponent();
        }

        #endregion
        
        #region Eventos

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

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
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

            string comando = @"
SELECT id, Versão 
FROM Versoes (NOLOCK)
WHERE YEAR(Digitação) >= (YEAR(GETDATE()) - 1)
ORDER BY Id Desc
";
            using (DataSet dstResultado = conexao.SelecionarDadosSqlGR(comando))
            {
                if (dstResultado.Tables.Count > 0 && dstResultado.Tables.Contains("Table") && dstResultado.Tables["Table"].Rows.Count > 0)
                {
                    cmbVersao.Items.AddRange(dstResultado.Tables["Table"].AsEnumerable().Select(x => x.Field<string>("Versão")).ToArray<string>());                    
                }
            }
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

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "Deseja realmente fechar o programa?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnVisaoDados_Click(object sender, EventArgs e)
        {
            FormAnalitico form = new FormAnalitico(dateTimePickerInicio.Value, dateTimePickerFim.Value);
            form.ShowDialog();
        }

        private void btnVDSolicitacao_Click(object sender, EventArgs e)
        {
            if (cmbVersao.SelectedItem != null && cmbVersao.SelectedItem.ToString().Length > 0)
            {
                VisaoDadosSolicitacao form = new VisaoDadosSolicitacao(cmbVersao.SelectedItem.ToString());
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Selecione a versão!", "Versão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbVersao.Focus();
            }
        }

        private void btnReportSolicitacao_Click(object sender, EventArgs e)
        {
            this.EmitirRelatorioAnaliseSolicitacao();
        }

        private void btnEditReportSolicitacao_Click(object sender, EventArgs e)
        {
            this.EditarRelatorioAnaliseSolicitacao();
        }

        #endregion

        #region Metodos

        public void Alert(string serie, int numero, string detalhe, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(serie, numero, detalhe, type, minutosParaPesquisa);
        }

        private void ConsultarNovosBUGs()
        {
            dataSet.Clear();

            string comando = @"
SELECT TOP 20 LTRIM(RTRIM(UPPER(Série))) As Série, Número, Solicitação
FROM Solicitacoes (NOLOCK)
WHERE LTRIM(RTRIM(UPPER(Série))) = 'BUG'
	AND DataDoCancelamento is null
	AND year(Data) >= 2021
ORDER BY Número DESC";

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

SELECT CASE WHEN LTRIM(RTRIM(Versoes.Versão)) = 'BUG FALSO' 
				THEN LTRIM(RTRIM(Versoes.Versão))
			WHEN Solicitacoes.DataDoCancelamento is not null
				THEN 'BUG CANCELADO'
            WHEN LTRIM(RTRIM(UPPER(ISNULL(Versoes.Versão, 'À Definir')))) = 'À Definir'
				THEN 'BUG EM CORREÇÂO'
			ELSE Roteiros.Roteiro END Roteiro,
	Solicitacoes.Número, SUM(IsNull(EtapaSolicitacao.Tempo_Real,0)) As Tempo
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
    LEFT JOIN Versoes (NOLOCK) ON 
		Solicitacoes.Versão_Id = Versoes.Id
WHERE (Etapas.Etapa IS NULL OR  Etapas.Etapa like '%Desenvolvimento%')
	AND Solicitacoes.Data BETWEEN @dataInicial AND @dataFinal
    AND LTRIM(RTRIM(UPPER(Série))) = 'BUG'	
GROUP BY Solicitacoes.Número, Roteiros.Roteiro, Versoes.Versão,
         Solicitacoes.DataDoCancelamento

/************  Intervalo Análise em Dias********/
SELECT CONVERT(VARCHAR, @dataInicial ,103) 'Data Inicial', CONVERT(VARCHAR, @dataFinal ,103) 'Data Final', DATEDIFF(DAY, @dataInicial, @dataFinal) 'Dias Analisados'
/***********************************************/

/************  Quantitativo BUGs****************/
SELECT Roteiro,	COUNT(Número) As 'Qtde Bugs',
	dbo.FN_CONVERTER_FORMATO_HORAS(Sum(tempo)) Horas
FROM #QtdeBugs
GROUP BY Roteiro
ORDER BY Count(Número) desc
/***********************************************/

/************  Lstagem Conferência *************/
SELECT CASE WHEN LTRIM(RTRIM(Versoes.Versão)) = 'BUG FALSO' 
				THEN LTRIM(RTRIM(Versoes.Versão))
			WHEN Solicitacoes.DataDoCancelamento is not null
				THEN 'BUG CANCELADO'
			ELSE Roteiros.Roteiro END Roteiro,
    CASE WHEN Solicitacoes.DataDoCancelamento is not null 
			THEN 'BUG CANCELADO'		
		 ELSE ISNULL(Versoes.Versão,'À Definir') END Versão,
    Solicitacoes.Número, Solicitacoes.Solicitação, 
	Etapas.Etapa, Responsaveis.Responsável, QuemAbriu.Responsável As QuemAbriu,
	SUM(EtapaSolicitacao.Tempo_Real) As TempoMinutos,
	dbo.FN_CONVERTER_FORMATO_HORAS(Sum(EtapaSolicitacao.Tempo_Real)) As Horas
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
    LEFT JOIN Responsaveis QuemAbriu (NOLOCK) ON 
		Solicitacoes.Responsável_Id = QuemAbriu.Id
	LEFT JOIN Etapas (NOLOCK) ON  
		Etapas.Id = EtapaSolicitacao.Etapa_Id
	LEFT JOIN Responsaveis (NOLOCK) ON 
		Responsaveis.Id = EtapaSolicitacao.Executor_Id
WHERE (Etapas.Etapa is null OR  Etapas.Etapa like '%Desenvolvimento%')
	AND Solicitacoes.Data BETWEEN @dataInicial AND @dataFinal
    AND LTRIM(RTRIM(UPPER(Série))) = 'BUG'	
GROUP BY Roteiros.Roteiro, Solicitacoes.Número, Versoes.Versão, Solicitacoes.Solicitação, 
	     Etapas.Etapa, Responsaveis.Responsável, QuemAbriu.Responsável, Solicitacoes.DataDoCancelamento
ORDER BY Solicitacoes.Número
	
SELECT TOP 10 Roteiro, Número, Versão, Solicitação, Etapa, Horas 
FROM #Conferencia 
ORDER BY TempoMinutos DESC

SELECT * FROM #Conferencia

/************  Quantitativo BUGs que cada Desenvolvedor corrigiu ****************/
SELECT Responsável, COUNT(Número) As 'Qtde Bugs', 
	ISNULL(dbo.FN_CONVERTER_FORMATO_HORAS(Sum(TempoMinutos)), 0) As Horas
FROM #Conferencia
Where LTRIM(RTRIM(UPPER(Responsável))) != 'A DEFINIR'
GROUP BY Responsável
ORDER BY COUNT(Número) Desc

/************  Quem abriu BUGs Falso ****************/
/*
SELECT QuemAbriu, COUNT(Número) As 'Qtde Bugs' 
FROM #Conferencia
Where LTRIM(RTRIM(UPPER(Versão))) = 'BUG FALSO'
GROUP BY QuemAbriu
ORDER BY COUNT(Número) Desc
*/

SELECT distinct Solicitacoes.Número,
	 QuemAbriu.Responsável As QuemAbriu
Into #QuemAbriuBUGFalso
FROM Solicitacoes (NOLOCK)		
	LEFT JOIN Versoes (NOLOCK) ON 
		Solicitacoes.Versão_Id = Versoes.Id
	LEFT JOIN Etapas_da_Solicitacao EtapaSolicitacao (NOLOCK) ON 
		EtapaSolicitacao.Solicitacao_Id = Solicitacoes.Id
    LEFT JOIN Responsaveis QuemAbriu (NOLOCK) ON 
		Solicitacoes.Responsável_Id = QuemAbriu.Id
	LEFT JOIN Etapas (NOLOCK) ON  
		Etapas.Id = EtapaSolicitacao.Etapa_Id
	LEFT JOIN Responsaveis (NOLOCK) ON 
		Responsaveis.Id = EtapaSolicitacao.Executor_Id
WHERE (Etapas.Etapa is null OR  Etapas.Etapa like '%Desenvolvimento%')
	AND Solicitacoes.Data BETWEEN @dataInicial AND @dataFinal
    AND LTRIM(RTRIM(UPPER(Série))) = 'BUG'
	AND LTRIM(RTRIM(Versoes.Versão)) = 'BUG FALSO'
GROUP BY QuemAbriu.Responsável, Etapas.Etapa, Solicitacoes.Número

Select Count(Número) As 'Qtde Bugs', QuemAbriu	
From #QuemAbriuBUGFalso
GROUP BY QuemAbriu
ORDER BY Count(Número) Desc

/*****************  Quem gerou BUG de origem DSV ******************/
SELECT CASE WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM JONATHAS%' 
				THEN 'Jonathas'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM JBATISTA%'
				THEN 'Jonathas' 
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM ISAAC%' 
				THEN 'Isaac'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM IRODRIGUES%'
				THEN 'Isaac'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM FLAVIO%' 
				THEN 'Flávio Marinho'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM FLÁVIO%' 
				THEN 'Flávio Marinho'			
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM FMARINHO%'
				THEN 'Flávio Marinho'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM JEFERSON%' 
				THEN 'Jeferson'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM JSILVEIRA%'
				THEN 'Jeferson'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM DOUGLAS%' 
				THEN 'Douglas'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM DLIMA%'
				THEN 'Douglas'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM PAULA CRISTINA%' 
				THEN 'Paula Carvalho'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM PAULA CARVALHO%'
				THEN 'Paula Carvalho'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM PCARVALHO%'
				THEN 'Paula Carvalho'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM PAULA LUIZA%' 
				THEN 'Paula Luiza'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM PLUIZA%'
				THEN 'Paula Luiza'            
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM LUCIANO%' 
				THEN 'Luciano'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM LMAIA%'
				THEN 'Luciano'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM LUCIANA%' 
				THEN 'Luciana de Faria'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM FABIANO%' 
				THEN 'Fabiano'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM FRATES%'
				THEN 'Fabiano'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM JULIANA%' 
				THEN 'Juliana Machado'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM JMACHADO%'
				THEN 'Juliana Machado'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM IGOR%' 
				THEN 'Igor Samuel Rates' 
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM IRATES%'
				THEN 'Igor Samuel Rates'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM RAMON%' 
				THEN 'Ramon Cardoso'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM RCARDOSO%'
				THEN 'Ramon Cardoso'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM GUSTAVO%' 
				THEN 'Gustavo Gontijo'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM GANTUNES%'
				THEN 'Gustavo Gontijo'
			WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM JULIO%' 
				THEN 'Júlio'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM JÚLIO%' 
				THEN 'Júlio'			
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM JSANTOS%'
				THEN 'Júlio'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM PATRICIA%'
				THEN 'Patricia Angelica'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM PATRÍCIA%'
				THEN 'Patricia Angelica'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM JADER%'
				THEN 'Jader Resende'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM MARCOS PAULO%'
				THEN 'Marcos Paulo Silva'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM LUIZ%'
				THEN 'Luiz Antonio'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM LUIS%'
				THEN 'Luis Henrique Valadares'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM LAÍSA%'
				THEN 'Laísa'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM LAISA%'
				THEN 'Laísa'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM PEDRO%'
				THEN 'Pedro Eduardo'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM ANDRESSA%'
				THEN 'Andressa'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM TARCIEL%'
				THEN 'Tarciel'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM GLAUCUS%'
				THEN 'Glaucus'
            WHEN UPPER(EtapaSolicitacao.detalhes) like '%#ORIGEM BRUNO%'
				THEN 'Bruno César' 
			ELSE 'Não Identificado' END Responsavel,
	Count(1) As Quantidade
Into #BUG_DSV
FROM Solicitacoes (NOLOCK)
	INNER JOIN Roteiros (NOLOCK) ON 
		Roteiros.Id = Solicitacoes.Roteiro_Id	
	LEFT JOIN Requisitos (NOLOCK) ON 
		Requisitos.Solicitação_Id = Solicitacoes.Id
	LEFT JOIN Etapas_da_Solicitacao EtapaSolicitacao (NOLOCK) ON 
		EtapaSolicitacao.Solicitacao_Id = Solicitacoes.Id
	LEFT JOIN Etapas (NOLOCK) ON  
		Etapas.Id = EtapaSolicitacao.Etapa_Id
    LEFT JOIN Versoes (NOLOCK) ON 
		Solicitacoes.Versão_Id = Versoes.Id
WHERE Etapas.Etapa like '%Desenvolvimento%'
	AND Solicitacoes.Data BETWEEN @dataInicial AND @dataFinal
    AND LTRIM(RTRIM(UPPER(Série))) = 'BUG'
	AND LTRIM(RTRIM(UPPER(Roteiros.Roteiro))) = 'BUG - ORIGEM DSV'
Group by EtapaSolicitacao.detalhes

Select Responsavel, Count(Quantidade) As Quantidade
From #BUG_DSV
Where Responsavel != 'Não Identificado'
Group by Responsavel
Order by Count(Quantidade) desc

DROP TABLE #QtdeBugs, #Conferencia, #QuemAbriuBUGFalso, #BUG_DSV

/* Caso queira conferir algum BUG que esta sem o responsável por gerar o BUG, é só olhar pelo comando abaixo
SELECT Count(1) As Quantidade, Solicitacoes.Número
FROM Solicitacoes (NOLOCK)
	INNER JOIN Roteiros (NOLOCK) ON 
		Roteiros.Id = Solicitacoes.Roteiro_Id	
	LEFT JOIN Requisitos (NOLOCK) ON 
		Requisitos.Solicitação_Id = Solicitacoes.Id
	LEFT JOIN Etapas_da_Solicitacao EtapaSolicitacao (NOLOCK) ON 
		EtapaSolicitacao.Solicitacao_Id = Solicitacoes.Id
	LEFT JOIN Etapas (NOLOCK) ON  
		Etapas.Id = EtapaSolicitacao.Etapa_Id
    LEFT JOIN Versoes (NOLOCK) ON 
		Solicitacoes.Versão_Id = Versoes.Id
WHERE Etapas.Etapa like '%Desenvolvimento%'
	AND Solicitacoes.Data BETWEEN @dataInicial AND @dataFinal
    AND LTRIM(RTRIM(UPPER(Série))) = 'BUG'
	AND LTRIM(RTRIM(UPPER(Roteiros.Roteiro))) = 'BUG - ORIGEM DSV'
Group by EtapaSolicitacao.detalhes, Solicitacoes.Número
*/";

            return comando;
        }

        private void EmitirRelatorioAnalise()
        {
            if (this.ValidarCamposObrigatorios())
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
                    this.PrepararDados(dstResultado);

                    ReportVisualizerBase reportVisualizerBase = new ReportVisualizerBase(this.Name, dstResultado, paramters, reports);
                    //reportVisualizerBase.Disposed += reportVisualizerBase_Disposed;
                    reportVisualizerBase.Show(this);
                }
            }
        }       

        private void EditarRelatorioAnalise()
        {
            if (this.ValidarCamposObrigatorios())
            {
                string comando = RetornarConsultaRelatorio(dateTimePickerInicio.Value, dateTimePickerFim.Value);

                using (DataSet dstResultado = conexao.SelecionarDadosSqlGR(comando))
                {
                    this.PrepararDados(dstResultado);

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
        }

        private void PrepararDados(DataSet dstResultado)
        {
            DateTime inicio = dateTimePickerInicio.Value;
            DateTime fim = dateTimePickerFim.Value;
            int quantidadeDiasUteis = 0;

            while (inicio.Date <= fim.Date)
            {
                if (inicio.DayOfWeek != DayOfWeek.Saturday && inicio.DayOfWeek != DayOfWeek.Sunday)
                {
                    quantidadeDiasUteis++;
                }

                inicio = inicio.AddDays(1);
            }            
            
            if(dstResultado.Tables.Count > 0 && dstResultado.Tables.Contains("Table") &&
               dstResultado.Tables["Table"].Rows.Count > 0)
            {
                dstResultado.Tables["Table"].Rows[0].SetField<string>("Dias Analisados", quantidadeDiasUteis.ToString());
            }
        }

        private bool ValidarCamposObrigatorios()
        {
            bool resultado = true;

            if (dateTimePickerInicio.Value == DateTime.MinValue)
            {
                MessageBox.Show(this, "Informe a data inicial!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePickerInicio.Focus();
                resultado = false;
            }

            if (dateTimePickerFim.Value == DateTime.MinValue)
            {
                MessageBox.Show(this, "Informe a data final!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePickerFim.Focus();
                resultado = false;
            }
            return resultado;
        }                

        private void EmitirRelatorioAnaliseSolicitacao()
        {
            if (cmbVersao.SelectedItem != null && cmbVersao.SelectedItem.ToString().Length > 0)
            {
                string comando = RetornarConsultaRelatorioSolicitacao();

                List<StiReport> reports = new List<StiReport>();
                string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string path = Path.Combine(StartupPath, "Relatorio_solicitacao.mrt");

                StiReport relatorio = new StiReport();
                relatorio.Load(path);
                reports.Add(relatorio);

                Dictionary<string, object> paramters = new Dictionary<string, object>();

                using (DataSet dstResultado = conexao.SelecionarDadosSqlGR(comando))
                {
                    ReportVisualizerBase reportVisualizerBase = new ReportVisualizerBase(this.Name, dstResultado, paramters, reports);
                    reportVisualizerBase.Show(this);
                }
            }
            else
            {
                MessageBox.Show(this, "Selecione a versão!", "Versão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbVersao.Focus();
            }
        }

        private void EditarRelatorioAnaliseSolicitacao()
        {
            if (cmbVersao.SelectedItem != null && cmbVersao.SelectedItem.ToString().Length > 0)
            {
                string comando = RetornarConsultaRelatorioSolicitacao();

                using (DataSet dstResultado = conexao.SelecionarDadosSqlGR(comando))
                {
                    string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string path = Path.Combine(StartupPath, "Relatorio_solicitacao.mrt");

                    StiReport relatorio = new StiReport();
                    relatorio.Load(path);

                    Dictionary<string, object> paramters = new Dictionary<string, object>();
                    ReportDesignerBase reportDesignerBase = new ReportDesignerBase(this.Name, dstResultado, paramters, relatorio, path);
                    reportDesignerBase.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show(this, "Selecione a versão!", "Versão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbVersao.Focus();
            }
        }

        private string RetornarConsultaRelatorioSolicitacao()
        {
            string comando = @"
SELECT DISTINCT
	Solicitacoes.Id as idSolicitacao,
	Versoes.Versão AS versao,
	CASE WHEN LEN(LTRIM(RTRIM(Solicitacoes.Série))) > 0
	THEN LTRIM(RTRIM(UPPER(Solicitacoes.Série))) + '-' + CAST(Solicitacoes.Número as varchar)
	ELSE CAST(Solicitacoes.Número as varchar) END AS solicitacao,
	Solicitacoes.Solicitação AS descricao,	
	Solicitantes.Solicitante AS solicitante, 
	QuemAbriu.Responsável AS responsavel,
	Classes.Classe AS classe,
	ISNULL(CAST(Requisitos.Id as varchar), 'Sem ID definido!') As idRequisito,
	ISNULL(VersoesRequisito.Versão, 'À Definir') As versaoRequisito,
	ISNULL(Desenvolvedor.Responsável, '') As desenvolvedor,
	ISNULL(Etapas_do_Requisito.Tempo_Real, 0) As tempoReal,
	CASE WHEN ISNULL(Etapas_do_Requisito.Tempo_Real, 0) >= 0
	Then ISNULL(dbo.FN_CONVERTER_FORMATO_HORAS(ISNULL(Etapas_do_Requisito.Tempo_Real, 0)), '00:00:00') 
	Else '00:00:00' END As horas
Into #Solicitacoes
FROM Solicitacoes (NOLOCK)
	LEFT JOIN Requisitos (NOLOCK) ON 
		Requisitos.Solicitação_Id = Solicitacoes.Id
	LEFT JOIN Versoes (NOLOCK) ON 
		Solicitacoes.Versão_Id = Versoes.Id
	LEFT JOIN Etapas_da_Solicitacao EtapaSolicitacao (NOLOCK) ON 
		EtapaSolicitacao.Solicitacao_Id = Solicitacoes.Id
    LEFT JOIN Responsaveis QuemAbriu (NOLOCK) ON 
		Solicitacoes.Responsável_Id = QuemAbriu.Id
	LEFT JOIN Responsaveis (NOLOCK) ON 
		EtapaSolicitacao.Executor_Id = Responsaveis.Id
	LEFT JOIN Solicitantes (NOLOCK) ON 
		Solicitacoes.Solicitante_Id = Solicitantes.Id
	LEFT JOIN Classes (NOLOCK) ON 
		Solicitacoes.Classe_Id = Classes.Id
	LEFT JOIN Etapas_do_Requisito (NOLOCK) ON 
		Requisitos.Id = Etapas_do_Requisito.Requisito_Id
	LEFT JOIN Etapas (NOLOCK) ON 
		Etapas_do_Requisito.Etapa_Id = Etapas.Id
	LEFT JOIN Responsaveis Desenvolvedor (NOLOCK) ON 
		Etapas_do_Requisito.Executor_Id = Desenvolvedor.Id
	LEFT JOIN Versoes VersoesRequisito (NOLOCK) ON 
		Requisitos.Versão_Id = VersoesRequisito.Id
WHERE Versoes.Versão like '%" + cmbVersao.SelectedItem.ToString().Trim() + @"%'
	AND (Etapas.Etapa is null OR  Etapas.Etapa = 'Desenvolvimento da O.S')
	AND LTRIM(RTRIM(UPPER(Série))) <> 'BUG' 
    AND LTRIM(RTRIM(UPPER(Série))) <> 'NC'
    AND LTRIM(RTRIM(UPPER(Série))) <> 'RAC'

SELECT Distinct
	solicitacao,
	descricao,
	versao,
	solicitante, 
	responsavel,
	classe,
	idSolicitacao
INTO #Solicitacoes_temp
FROM #Solicitacoes
ORDER BY solicitacao

SELECT Distinct
	solicitacao,
	idRequisito,
	versaoRequisito AS versaoLiberacao,
	desenvolvedor,
	tempoReal,
	horas,
	idSolicitacao
INTO #Desenvolvedores
FROM #Solicitacoes
ORDER BY solicitacao

SELECT solicitacao,
	descricao,
	versao,
	solicitante, 
	responsavel,
	classe,
	idSolicitacao,
	CASE WHEN (Select Count(1)
	 From #Desenvolvedores
	 Where idSolicitacao = #Solicitacoes_temp.idSolicitacao
		   AND (idRequisito = 'Sem ID definido!'
				OR LTRIM(RTRIM(desenvolvedor)) = ''
				OR LTRIM(RTRIM(desenvolvedor)) = 'A Definir'
				OR LTRIM(RTRIM(versaoLiberacao)) = 'À Definir'
				OR tempoReal = 0)) > 0 THEN 'Em Aberto'
	ELSE 'Concluida' END As statusSolicitacao
INTO #Solicitacoes_temp1
FROM #Solicitacoes_temp

SELECT * FROM #Solicitacoes_temp1

SELECT solicitacao,
	idRequisito,
	versaoLiberacao,
	desenvolvedor,
	tempoReal,
	horas,
	idSolicitacao,		
	CASE LTRIM(RTRIM(desenvolvedor)) WHEN 'A Definir' THEN 'Em Aberto'
		WHEN '' THEN 'Em Aberto'
	ELSE
	CASE WHEN tempoReal = 0 THEN 'Em Desenvolvimento' 
	ELSE 'Concluida' 
		END
	END As status
FROM #Desenvolvedores
WHERE LTRIM(RTRIM(idRequisito)) <> '0'
	AND LTRIM(RTRIM(idRequisito)) <> 'Sem ID definido!'
	AND LTRIM(RTRIM(UPPER(ISNULL(desenvolvedor, '')))) <> 'À DEFINIR' 
	AND LTRIM(RTRIM(UPPER(ISNULL(desenvolvedor, '')))) <> 'A DEFINIR'

Select statusSolicitacao,
	COUNT(1) As Qtd_status
INTO #Grafico
From #Solicitacoes_temp1
Group by statusSolicitacao

SELECT statusSolicitacao,
	((Qtd_status * 100) / (SELECT SUM(Qtd_status) FROM #Grafico)) As percentual_status
FROM #Grafico

DROP TABLE #Solicitacoes, #Solicitacoes_temp, #Desenvolvedores, #Solicitacoes_temp1, #Grafico";

            return comando;
        }

        #endregion
    }
}
