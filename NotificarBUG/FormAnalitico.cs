using System;
using System.Drawing;
using System.Windows.Forms;

namespace NotificarBUG
{
    public partial class FormAnalitico : Form
    {
        #region Atributos

        private ConexaoBancoDados conexao = new ConexaoBancoDados();

        #endregion

        #region Contrutor

        public FormAnalitico(DateTime dataInicio, DateTime dataFim)
        {
            InitializeComponent();
            this.dateTimePickerInicio.Value = dataInicio;
            this.dateTimePickerFim.Value = dataFim;
        }

        #endregion

        #region Eventos

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            DataSet.VisaoDadosRow linha = ((DataSet.VisaoDadosRow)gridView1.GetDataRow(e.RowHandle));

            if (linha != null && !linha.IsVersãoNull())
            {
                e.HighPriority = true; //Aplica a cor tambem na linha selecionada.

                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.White;

                switch (linha.Versão.Trim().ToUpper())
                {
                    case "BUG FALSO":
                        e.Appearance.ForeColor = Color.Red;
                        e.Appearance.BackColor = Color.LimeGreen;
                        break;
                    case "BUG CANCELADO":
                        e.Appearance.BackColor = Color.Gray;
                        break;
                    case "À DEFINIR":
                        e.Appearance.BackColor = Color.Yellow;
                        break;
                    default:
                        e.Appearance.BackColor = Color.LimeGreen;
                        break;
                }
            }
        }

        private void FormAnalitico_Shown(object sender, EventArgs e)
        {
            this.CarregarDados();
        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            this.CarregarDados();
        }

        #endregion

        #region Metodos

        private string RetornarConsultaVisaoDados(DateTime inicio, DateTime fim)
        {
            string comando = @"
DECLARE @dataInicial datetime, @dataFinal datetime
SET @dataInicial = '" + inicio.ToString("yyyyMMdd") + @"'
SET @dataFinal = '" + fim.ToString("yyyyMMdd") + @"'

/************  Lstagem Conferência *************/
SELECT CASE WHEN LTRIM(RTRIM(Versoes.Versão)) = 'BUG FALSO' 
				THEN LTRIM(RTRIM(Versoes.Versão))
			WHEN Solicitacoes.DataDoCancelamento is not null
				THEN 'BUG CANCELADO'
			ELSE Roteiros.Roteiro END Roteiro,
    CASE WHEN Solicitacoes.DataDoCancelamento is not null 
			THEN 'BUG CANCELADO'		
		 ELSE ISNULL(Versoes.Versão, 'À Definir') END Versão,
    Solicitacoes.Número, Solicitacoes.Solicitação, 
	Etapas.Etapa, Responsaveis.Responsável, QuemAbriu.Responsável As QuemAbriu,
	SUM(EtapaSolicitacao.Tempo_Real) As TempoMinutos,
	dbo.FN_CONVERTER_FORMATO_HORAS(Sum(EtapaSolicitacao.Tempo_Real)) As Horas,
    Solicitacoes.Urgência
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
	     Etapas.Etapa, Responsaveis.Responsável, QuemAbriu.Responsável, Solicitacoes.DataDoCancelamento,
         Solicitacoes.Urgência
ORDER BY Solicitacoes.Número DESC";

            return comando;
        }

        private void CarregarDados()
        {
            string comando = RetornarConsultaVisaoDados(this.dateTimePickerInicio.Value, this.dateTimePickerFim.Value);
            dataSet.VisaoDados.Clear();

            using (DataSet dstResultado = conexao.SelecionarDadosSqlGR(comando))
            {
                dataSet.VisaoDados.Merge(dstResultado.Tables["Table"]);
            }
        }

        #endregion       
    }
}
