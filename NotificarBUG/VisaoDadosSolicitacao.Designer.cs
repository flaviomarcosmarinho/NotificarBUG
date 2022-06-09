
namespace NotificarBUG
{
    partial class VisaoDadosSolicitacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsolicitacao1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidRequisito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colversaoLiberacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldesenvolvedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltempoReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colhoras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidSolicitacao1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new NotificarBUG.DataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsolicitacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colversao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsolicitante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colresponsavel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colclasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidSolicitacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatusSolicitacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblVersao = new System.Windows.Forms.Label();
            this.cmbVersao = new System.Windows.Forms.ComboBox();
            this.btnRecarregar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsolicitacao1,
            this.colidRequisito,
            this.colversaoLiberacao,
            this.coldesenvolvedor,
            this.coltempoReal,
            this.colhoras,
            this.colidSolicitacao1,
            this.colstatus});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            // 
            // colsolicitacao1
            // 
            this.colsolicitacao1.Caption = "Solicitação";
            this.colsolicitacao1.FieldName = "solicitacao";
            this.colsolicitacao1.Name = "colsolicitacao1";
            this.colsolicitacao1.Visible = true;
            this.colsolicitacao1.VisibleIndex = 0;
            // 
            // colidRequisito
            // 
            this.colidRequisito.Caption = "Id do Requisito";
            this.colidRequisito.FieldName = "idRequisito";
            this.colidRequisito.Name = "colidRequisito";
            this.colidRequisito.Visible = true;
            this.colidRequisito.VisibleIndex = 1;
            // 
            // colversaoLiberacao
            // 
            this.colversaoLiberacao.Caption = "Versão de Liberação";
            this.colversaoLiberacao.FieldName = "versaoLiberacao";
            this.colversaoLiberacao.Name = "colversaoLiberacao";
            this.colversaoLiberacao.Visible = true;
            this.colversaoLiberacao.VisibleIndex = 2;
            // 
            // coldesenvolvedor
            // 
            this.coldesenvolvedor.Caption = "Desenvolvedor";
            this.coldesenvolvedor.FieldName = "desenvolvedor";
            this.coldesenvolvedor.Name = "coldesenvolvedor";
            this.coldesenvolvedor.Visible = true;
            this.coldesenvolvedor.VisibleIndex = 3;
            // 
            // coltempoReal
            // 
            this.coltempoReal.Caption = "Tempo Gasto (em minutos)";
            this.coltempoReal.FieldName = "tempoReal";
            this.coltempoReal.Name = "coltempoReal";
            this.coltempoReal.Visible = true;
            this.coltempoReal.VisibleIndex = 4;
            // 
            // colhoras
            // 
            this.colhoras.Caption = "Tempo Gasto (em horas)";
            this.colhoras.FieldName = "horas";
            this.colhoras.Name = "colhoras";
            this.colhoras.Visible = true;
            this.colhoras.VisibleIndex = 5;
            // 
            // colidSolicitacao1
            // 
            this.colidSolicitacao1.FieldName = "idSolicitacao";
            this.colidSolicitacao1.Name = "colidSolicitacao1";
            // 
            // colstatus
            // 
            this.colstatus.Caption = "Status";
            this.colstatus.FieldName = "status";
            this.colstatus.Name = "colstatus";
            this.colstatus.Visible = true;
            this.colstatus.VisibleIndex = 6;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "VisaoDadosSolicitacao_VisaoDadosSolicitacaoDesenvolvedores";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1376, 493);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // bindingSource
            // 
            this.bindingSource.DataMember = "VisaoDadosSolicitacao";
            this.bindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsolicitacao,
            this.coldescricao,
            this.colversao,
            this.colsolicitante,
            this.colresponsavel,
            this.colclasse,
            this.colidSolicitacao,
            this.colstatusSolicitacao});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            // 
            // colsolicitacao
            // 
            this.colsolicitacao.Caption = "Solicitação";
            this.colsolicitacao.FieldName = "solicitacao";
            this.colsolicitacao.Name = "colsolicitacao";
            this.colsolicitacao.Visible = true;
            this.colsolicitacao.VisibleIndex = 0;
            // 
            // coldescricao
            // 
            this.coldescricao.Caption = "Descrição";
            this.coldescricao.FieldName = "descricao";
            this.coldescricao.Name = "coldescricao";
            this.coldescricao.Visible = true;
            this.coldescricao.VisibleIndex = 1;
            // 
            // colversao
            // 
            this.colversao.Caption = "Versão";
            this.colversao.FieldName = "versao";
            this.colversao.Name = "colversao";
            this.colversao.Visible = true;
            this.colversao.VisibleIndex = 2;
            // 
            // colsolicitante
            // 
            this.colsolicitante.Caption = "Solicitante";
            this.colsolicitante.FieldName = "solicitante";
            this.colsolicitante.Name = "colsolicitante";
            this.colsolicitante.Visible = true;
            this.colsolicitante.VisibleIndex = 3;
            // 
            // colresponsavel
            // 
            this.colresponsavel.Caption = "Responsável";
            this.colresponsavel.FieldName = "responsavel";
            this.colresponsavel.Name = "colresponsavel";
            this.colresponsavel.Visible = true;
            this.colresponsavel.VisibleIndex = 4;
            // 
            // colclasse
            // 
            this.colclasse.Caption = "Classe da Solicitação";
            this.colclasse.FieldName = "classe";
            this.colclasse.Name = "colclasse";
            this.colclasse.Visible = true;
            this.colclasse.VisibleIndex = 5;
            // 
            // colidSolicitacao
            // 
            this.colidSolicitacao.FieldName = "idSolicitacao";
            this.colidSolicitacao.Name = "colidSolicitacao";
            // 
            // colstatusSolicitacao
            // 
            this.colstatusSolicitacao.Caption = "Status da Solicitação";
            this.colstatusSolicitacao.FieldName = "statusSolicitacao";
            this.colstatusSolicitacao.Name = "colstatusSolicitacao";
            this.colstatusSolicitacao.Visible = true;
            this.colstatusSolicitacao.VisibleIndex = 6;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.ReadOnly = true;
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblVersao);
            this.pnlTop.Controls.Add(this.cmbVersao);
            this.pnlTop.Controls.Add(this.btnRecarregar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1376, 44);
            this.pnlTop.TabIndex = 0;
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(82, 6);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(40, 13);
            this.lblVersao.TabIndex = 3;
            this.lblVersao.Text = "Versão";
            // 
            // cmbVersao
            // 
            this.cmbVersao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVersao.FormattingEnabled = true;
            this.cmbVersao.Location = new System.Drawing.Point(82, 21);
            this.cmbVersao.Name = "cmbVersao";
            this.cmbVersao.Size = new System.Drawing.Size(293, 21);
            this.cmbVersao.TabIndex = 1;
            this.cmbVersao.SelectedIndexChanged += new System.EventHandler(this.cmbVersao_SelectedIndexChanged);
            // 
            // btnRecarregar
            // 
            this.btnRecarregar.BackgroundImage = global::NotificarBUG.Properties.Resources.refresh;
            this.btnRecarregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecarregar.Location = new System.Drawing.Point(0, 0);
            this.btnRecarregar.Name = "btnRecarregar";
            this.btnRecarregar.Size = new System.Drawing.Size(76, 44);
            this.btnRecarregar.TabIndex = 0;
            this.btnRecarregar.UseVisualStyleBackColor = true;
            this.btnRecarregar.Click += new System.EventHandler(this.btnRecarregar_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 537);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1376, 23);
            this.panel1.TabIndex = 3;
            // 
            // VisaoDadosSolicitacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 560);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTop);
            this.Name = "VisaoDadosSolicitacao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUGs listados no período.";
            this.Shown += new System.EventHandler(this.FormAnalitico_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button btnRecarregar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.ComboBox cmbVersao;
        private DevExpress.XtraGrid.Columns.GridColumn colsolicitacao;
        private DevExpress.XtraGrid.Columns.GridColumn coldescricao;
        private DevExpress.XtraGrid.Columns.GridColumn colversao;
        private DevExpress.XtraGrid.Columns.GridColumn colsolicitante;
        private DevExpress.XtraGrid.Columns.GridColumn colresponsavel;
        private DevExpress.XtraGrid.Columns.GridColumn colclasse;
        private DevExpress.XtraGrid.Columns.GridColumn colidSolicitacao;
        private DevExpress.XtraGrid.Columns.GridColumn colstatusSolicitacao;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colsolicitacao1;
        private DevExpress.XtraGrid.Columns.GridColumn colidRequisito;
        private DevExpress.XtraGrid.Columns.GridColumn colversaoLiberacao;
        private DevExpress.XtraGrid.Columns.GridColumn coldesenvolvedor;
        private DevExpress.XtraGrid.Columns.GridColumn coltempoReal;
        private DevExpress.XtraGrid.Columns.GridColumn colhoras;
        private DevExpress.XtraGrid.Columns.GridColumn colidSolicitacao1;
        private DevExpress.XtraGrid.Columns.GridColumn colstatus;
    }
}