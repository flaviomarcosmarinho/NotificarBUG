using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NotificarBUG
{
    public partial class VisaoDadosSolicitacao : Form
    {
        #region Atributos

        private ConexaoBancoDados conexao = new ConexaoBancoDados();
        private string versao = string.Empty;

        #endregion

        #region Contrutor

        public VisaoDadosSolicitacao(string versao)
        {
            InitializeComponent();
            this.versao = versao;
        }

        #endregion

        #region Eventos

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            DataSet.VisaoDadosSolicitacaoRow linha = ((DataSet.VisaoDadosSolicitacaoRow)gridView1.GetDataRow(e.RowHandle));

            if (linha != null && !linha.IsstatusSolicitacaoNull())
            {
                e.HighPriority = true; //Aplica a cor tambem na linha selecionada.

                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.White;

                switch (linha.statusSolicitacao.Trim().ToUpper())
                {
                    case "CONCLUIDA":
						e.Appearance.BackColor = Color.LimeGreen;
						break;                    
                }
            }
        }

        private void FormAnalitico_Shown(object sender, EventArgs e)
        {
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

			cmbVersao.SelectedItem = this.versao;

			this.CarregarDados();
        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
			if (cmbVersao.SelectedItem != null && cmbVersao.SelectedItem.ToString().Length > 0)
			{
				this.CarregarDados();
			}
			else
			{
				MessageBox.Show(this, "Selecione a versão!", "Versão", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cmbVersao.Focus();
			}			
        }

		private void cmbVersao_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.versao = cmbVersao.SelectedItem.ToString();
		}

		#endregion

		#region Metodos

		private string RetornarConsultaVisaoDados(string versao)
        {
            string comando = @"
SELECT DISTINCT
	Solicitacoes.Id as idSolicitacao,
	Versoes.Versão AS versao,
	LTRIM(RTRIM(UPPER(Solicitacoes.Série))) + '-' + CAST(Solicitacoes.Número as varchar) AS solicitacao,
	Solicitacoes.Solicitação AS descricao,	
	Solicitantes.Solicitante AS solicitante, 
	QuemAbriu.Responsável AS responsavel,
	Classes.Classe AS classe,
	ISNULL(CAST(Requisitos.Id as varchar), 'Sem ID difinido!') As idRequisito,
	ISNULL(VersoesRequisito.Versão, 'À Definir') As versaoRequisito,
	ISNULL(Desenvolvedor.Responsável, '') As desenvolvedor,
	ISNULL(Etapas_do_Requisito.Tempo_Real, 0) As tempoReal,
	ISNULL(dbo.FN_CONVERTER_FORMATO_HORAS(Etapas_do_Requisito.Tempo_Real), 0) As horas
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
WHERE Versoes.Versão like '%" + versao.Trim() + @"%'
	AND (Etapas.Etapa is null OR  Etapas.Etapa = 'Desenvolvimento da O.S')
	AND LTRIM(RTRIM(UPPER(Série))) <> 'BUG'

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
		   AND (idRequisito = 'Sem ID difinido!'
				OR LTRIM(RTRIM(desenvolvedor)) = ''
				OR LTRIM(RTRIM(desenvolvedor)) = 'A Definir'
				OR LTRIM(RTRIM(versaoLiberacao)) = 'À Definir'
				OR tempoReal = 0)) > 0 THEN 'Em Aberto'
	ELSE 'Concluida' END As statusSolicitacao
FROM #Solicitacoes_temp	

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

DROP TABLE #Solicitacoes, #Solicitacoes_temp, #Desenvolvedores";

            return comando;
        }

        private void CarregarDados()
        {
            string comando = RetornarConsultaVisaoDados(this.versao);
            dataSet.VisaoDadosSolicitacao.Clear();
			dataSet.VisaoDadosSolicitacaoDesenvolvedores.Clear();

			using (DataSet dstResultado = conexao.SelecionarDadosSqlGR(comando))
            {
                dataSet.VisaoDadosSolicitacao.Merge(dstResultado.Tables["Table"]);
				dataSet.VisaoDadosSolicitacaoDesenvolvedores.Merge(dstResultado.Tables["Table1"]);
			}
        }

        #endregion
    }
}
