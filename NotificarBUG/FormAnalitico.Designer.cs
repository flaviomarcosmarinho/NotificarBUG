
namespace NotificarBUG
{
    partial class FormAnalitico
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.lblDataFim = new System.Windows.Forms.Label();
            this.dateTimePickerFim = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.btnRecarregar = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new NotificarBUG.DataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRoteiro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersão = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNúmero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSolicitação = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEtapa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsável = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuemAbriu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTempoMinutos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colUrgência = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblDataInicio);
            this.pnlTop.Controls.Add(this.lblDataFim);
            this.pnlTop.Controls.Add(this.dateTimePickerFim);
            this.pnlTop.Controls.Add(this.dateTimePickerInicio);
            this.pnlTop.Controls.Add(this.btnRecarregar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1376, 44);
            this.pnlTop.TabIndex = 0;
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Location = new System.Drawing.Point(80, 6);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(60, 13);
            this.lblDataInicio.TabIndex = 8;
            this.lblDataInicio.Text = "Data Inicial";
            // 
            // lblDataFim
            // 
            this.lblDataFim.AutoSize = true;
            this.lblDataFim.Location = new System.Drawing.Point(212, 5);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(55, 13);
            this.lblDataFim.TabIndex = 9;
            this.lblDataFim.Text = "Data Final";
            // 
            // dateTimePickerFim
            // 
            this.dateTimePickerFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFim.Location = new System.Drawing.Point(215, 21);
            this.dateTimePickerFim.Name = "dateTimePickerFim";
            this.dateTimePickerFim.Size = new System.Drawing.Size(126, 20);
            this.dateTimePickerFim.TabIndex = 7;
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(83, 21);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(126, 20);
            this.dateTimePickerInicio.TabIndex = 6;
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
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1376, 493);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bindingSource
            // 
            this.bindingSource.DataMember = "VisaoDados";
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
            this.colRoteiro,
            this.colVersão,
            this.colNúmero,
            this.colSolicitação,
            this.colUrgência,
            this.colEtapa,
            this.colResponsável,
            this.colQuemAbriu,
            this.colTempoMinutos,
            this.colHoras});
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
            // colRoteiro
            // 
            this.colRoteiro.FieldName = "Roteiro";
            this.colRoteiro.Name = "colRoteiro";
            this.colRoteiro.OptionsColumn.ReadOnly = true;
            this.colRoteiro.Visible = true;
            this.colRoteiro.VisibleIndex = 0;
            // 
            // colVersão
            // 
            this.colVersão.FieldName = "Versão";
            this.colVersão.Name = "colVersão";
            this.colVersão.OptionsColumn.ReadOnly = true;
            this.colVersão.Visible = true;
            this.colVersão.VisibleIndex = 1;
            // 
            // colNúmero
            // 
            this.colNúmero.AppearanceCell.Options.UseTextOptions = true;
            this.colNúmero.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNúmero.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNúmero.FieldName = "Número";
            this.colNúmero.Name = "colNúmero";
            this.colNúmero.OptionsColumn.ReadOnly = true;
            this.colNúmero.Visible = true;
            this.colNúmero.VisibleIndex = 2;
            // 
            // colSolicitação
            // 
            this.colSolicitação.FieldName = "Solicitação";
            this.colSolicitação.Name = "colSolicitação";
            this.colSolicitação.OptionsColumn.ReadOnly = true;
            this.colSolicitação.Visible = true;
            this.colSolicitação.VisibleIndex = 3;
            // 
            // colEtapa
            // 
            this.colEtapa.FieldName = "Etapa";
            this.colEtapa.Name = "colEtapa";
            this.colEtapa.OptionsColumn.ReadOnly = true;
            this.colEtapa.Visible = true;
            this.colEtapa.VisibleIndex = 5;
            // 
            // colResponsável
            // 
            this.colResponsável.FieldName = "Responsável";
            this.colResponsável.Name = "colResponsável";
            this.colResponsável.OptionsColumn.ReadOnly = true;
            this.colResponsável.Visible = true;
            this.colResponsável.VisibleIndex = 6;
            // 
            // colQuemAbriu
            // 
            this.colQuemAbriu.FieldName = "QuemAbriu";
            this.colQuemAbriu.Name = "colQuemAbriu";
            this.colQuemAbriu.OptionsColumn.ReadOnly = true;
            this.colQuemAbriu.Visible = true;
            this.colQuemAbriu.VisibleIndex = 7;
            // 
            // colTempoMinutos
            // 
            this.colTempoMinutos.FieldName = "TempoMinutos";
            this.colTempoMinutos.Name = "colTempoMinutos";
            this.colTempoMinutos.OptionsColumn.ReadOnly = true;
            this.colTempoMinutos.Visible = true;
            this.colTempoMinutos.VisibleIndex = 8;
            // 
            // colHoras
            // 
            this.colHoras.FieldName = "Horas";
            this.colHoras.Name = "colHoras";
            this.colHoras.OptionsColumn.ReadOnly = true;
            this.colHoras.Visible = true;
            this.colHoras.VisibleIndex = 9;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.ReadOnly = true;
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 537);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1376, 23);
            this.panel1.TabIndex = 3;
            // 
            // colUrgência
            // 
            this.colUrgência.Caption = "Urgência";
            this.colUrgência.FieldName = "Urgência";
            this.colUrgência.Name = "colUrgência";
            this.colUrgência.OptionsColumn.ReadOnly = true;
            this.colUrgência.Visible = true;
            this.colUrgência.VisibleIndex = 4;
            // 
            // FormAnalitico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 560);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTop);
            this.Name = "FormAnalitico";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUGs listados no período.";
            this.Shown += new System.EventHandler(this.FormAnalitico_Shown);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colRoteiro;
        private DevExpress.XtraGrid.Columns.GridColumn colVersão;
        private DevExpress.XtraGrid.Columns.GridColumn colNúmero;
        private DevExpress.XtraGrid.Columns.GridColumn colSolicitação;
        private DevExpress.XtraGrid.Columns.GridColumn colEtapa;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsável;
        private DevExpress.XtraGrid.Columns.GridColumn colQuemAbriu;
        private DevExpress.XtraGrid.Columns.GridColumn colTempoMinutos;
        private DevExpress.XtraGrid.Columns.GridColumn colHoras;
        private System.Windows.Forms.Button btnRecarregar;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.Label lblDataFim;
        private System.Windows.Forms.DateTimePicker dateTimePickerFim;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.Columns.GridColumn colUrgência;
    }
}