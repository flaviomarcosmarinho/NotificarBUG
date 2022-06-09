namespace NotificarBUG
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnConsultarBUG = new System.Windows.Forms.Button();
            this.dataSet = new NotificarBUG.DataSet();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataSet_Compact = new NotificarBUG.DataSet_Compact();
            this.trackBarTempoConsulta = new System.Windows.Forms.TrackBar();
            this.lblTempoConsulta = new System.Windows.Forms.Label();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.btnEditReport = new System.Windows.Forms.Button();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFim = new System.Windows.Forms.DateTimePicker();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.lblDataFim = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnReportSolicitacao = new System.Windows.Forms.Button();
            this.btnEditReportSolicitacao = new System.Windows.Forms.Button();
            this.groupBoxReport = new System.Windows.Forms.GroupBox();
            this.btnVisaoDados = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageBUG = new System.Windows.Forms.TabPage();
            this.tabPageSolicitacao = new System.Windows.Forms.TabPage();
            this.btnVDSolicitacao = new System.Windows.Forms.Button();
            this.groupBoxSolicitacao = new System.Windows.Forms.GroupBox();
            this.lblVersao = new System.Windows.Forms.Label();
            this.cmbVersao = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Compact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTempoConsulta)).BeginInit();
            this.groupBoxReport.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageBUG.SuspendLayout();
            this.tabPageSolicitacao.SuspendLayout();
            this.groupBoxSolicitacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(467, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Teste";
            this.toolTip.SetToolTip(this.button1, "Somente teste de notificação");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.DarkOrange;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(532, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Teste";
            this.toolTip.SetToolTip(this.button2, "Somente teste de notificação");
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.DarkRed;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(597, 163);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 28);
            this.button3.TabIndex = 6;
            this.button3.Text = "Teste";
            this.toolTip.SetToolTip(this.button3, "Somente teste de notificação");
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.RoyalBlue;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(662, 163);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(59, 28);
            this.button4.TabIndex = 7;
            this.button4.Text = "Teste";
            this.toolTip.SetToolTip(this.button4, "Somente teste de notificação");
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Notificação de BUG";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // btnConsultarBUG
            // 
            this.btnConsultarBUG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultarBUG.Location = new System.Drawing.Point(586, 16);
            this.btnConsultarBUG.Name = "btnConsultarBUG";
            this.btnConsultarBUG.Size = new System.Drawing.Size(135, 43);
            this.btnConsultarBUG.TabIndex = 2;
            this.btnConsultarBUG.Text = "Consulta BUG";
            this.toolTip.SetToolTip(this.btnConsultarBUG, "Consultar novos BUG`s abertos no GR.");
            this.btnConsultarBUG.UseVisualStyleBackColor = true;
            this.btnConsultarBUG.Click += new System.EventHandler(this.Button5_Click);
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // dataSet_Compact
            // 
            this.dataSet_Compact.DataSetName = "DataSet_Compact";
            this.dataSet_Compact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // trackBarTempoConsulta
            // 
            this.trackBarTempoConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBarTempoConsulta.Location = new System.Drawing.Point(24, 146);
            this.trackBarTempoConsulta.Maximum = 60;
            this.trackBarTempoConsulta.Minimum = 1;
            this.trackBarTempoConsulta.Name = "trackBarTempoConsulta";
            this.trackBarTempoConsulta.Size = new System.Drawing.Size(301, 45);
            this.trackBarTempoConsulta.TabIndex = 3;
            this.toolTip.SetToolTip(this.trackBarTempoConsulta, "Configurar tempo para consulta automática no banco de dados.");
            this.trackBarTempoConsulta.Value = 10;
            this.trackBarTempoConsulta.Scroll += new System.EventHandler(this.TrackBarTempoConsulta_Scroll);
            // 
            // lblTempoConsulta
            // 
            this.lblTempoConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTempoConsulta.AutoSize = true;
            this.lblTempoConsulta.ForeColor = System.Drawing.Color.Blue;
            this.lblTempoConsulta.Location = new System.Drawing.Point(30, 124);
            this.lblTempoConsulta.Name = "lblTempoConsulta";
            this.lblTempoConsulta.Size = new System.Drawing.Size(0, 21);
            this.lblTempoConsulta.TabIndex = 8;
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackgroundImage = global::NotificarBUG.Properties.Resources.print;
            this.btnPrintReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrintReport.Location = new System.Drawing.Point(389, 40);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(40, 43);
            this.btnPrintReport.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnPrintReport, "Visualizar relatório");
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // btnEditReport
            // 
            this.btnEditReport.BackgroundImage = global::NotificarBUG.Properties.Resources.edit_eport_px;
            this.btnEditReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditReport.Location = new System.Drawing.Point(343, 40);
            this.btnEditReport.Name = "btnEditReport";
            this.btnEditReport.Size = new System.Drawing.Size(40, 43);
            this.btnEditReport.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnEditReport, "Editar relatório");
            this.btnEditReport.UseVisualStyleBackColor = true;
            this.btnEditReport.Click += new System.EventHandler(this.btnEditReport_Click);
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(18, 56);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(126, 27);
            this.dateTimePickerInicio.TabIndex = 0;
            // 
            // dateTimePickerFim
            // 
            this.dateTimePickerFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFim.Location = new System.Drawing.Point(150, 56);
            this.dateTimePickerFim.Name = "dateTimePickerFim";
            this.dateTimePickerFim.Size = new System.Drawing.Size(126, 27);
            this.dateTimePickerFim.TabIndex = 1;
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Location = new System.Drawing.Point(15, 32);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(100, 21);
            this.lblDataInicio.TabIndex = 4;
            this.lblDataInicio.Text = "Data Inicial";
            // 
            // lblDataFim
            // 
            this.lblDataFim.AutoSize = true;
            this.lblDataFim.Location = new System.Drawing.Point(146, 32);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(90, 21);
            this.lblDataFim.TabIndex = 5;
            this.lblDataFim.Text = "Data Final";
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 1000;
            // 
            // btnReportSolicitacao
            // 
            this.btnReportSolicitacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportSolicitacao.BackgroundImage = global::NotificarBUG.Properties.Resources.print;
            this.btnReportSolicitacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReportSolicitacao.Location = new System.Drawing.Point(687, 51);
            this.btnReportSolicitacao.Name = "btnReportSolicitacao";
            this.btnReportSolicitacao.Size = new System.Drawing.Size(40, 43);
            this.btnReportSolicitacao.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnReportSolicitacao, "Visualizar relatório");
            this.btnReportSolicitacao.UseVisualStyleBackColor = true;
            this.btnReportSolicitacao.Click += new System.EventHandler(this.btnReportSolicitacao_Click);
            // 
            // btnEditReportSolicitacao
            // 
            this.btnEditReportSolicitacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditReportSolicitacao.BackgroundImage = global::NotificarBUG.Properties.Resources.edit_eport_px;
            this.btnEditReportSolicitacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditReportSolicitacao.Location = new System.Drawing.Point(641, 51);
            this.btnEditReportSolicitacao.Name = "btnEditReportSolicitacao";
            this.btnEditReportSolicitacao.Size = new System.Drawing.Size(40, 43);
            this.btnEditReportSolicitacao.TabIndex = 7;
            this.toolTip.SetToolTip(this.btnEditReportSolicitacao, "Editar relatório");
            this.btnEditReportSolicitacao.UseVisualStyleBackColor = true;
            this.btnEditReportSolicitacao.Click += new System.EventHandler(this.btnEditReportSolicitacao_Click);
            // 
            // groupBoxReport
            // 
            this.groupBoxReport.Controls.Add(this.lblDataInicio);
            this.groupBoxReport.Controls.Add(this.lblDataFim);
            this.groupBoxReport.Controls.Add(this.btnEditReport);
            this.groupBoxReport.Controls.Add(this.btnPrintReport);
            this.groupBoxReport.Controls.Add(this.dateTimePickerFim);
            this.groupBoxReport.Controls.Add(this.dateTimePickerInicio);
            this.groupBoxReport.Location = new System.Drawing.Point(6, 6);
            this.groupBoxReport.Name = "groupBoxReport";
            this.groupBoxReport.Size = new System.Drawing.Size(447, 100);
            this.groupBoxReport.TabIndex = 0;
            this.groupBoxReport.TabStop = false;
            this.groupBoxReport.Text = "Relatório";
            // 
            // btnVisaoDados
            // 
            this.btnVisaoDados.Location = new System.Drawing.Point(459, 17);
            this.btnVisaoDados.Name = "btnVisaoDados";
            this.btnVisaoDados.Size = new System.Drawing.Size(119, 42);
            this.btnVisaoDados.TabIndex = 1;
            this.btnVisaoDados.Text = "Visão Dados";
            this.btnVisaoDados.UseVisualStyleBackColor = true;
            this.btnVisaoDados.Click += new System.EventHandler(this.btnVisaoDados_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageBUG);
            this.tabControl.Controls.Add(this.tabPageSolicitacao);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(744, 267);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageBUG
            // 
            this.tabPageBUG.Controls.Add(this.btnConsultarBUG);
            this.tabPageBUG.Controls.Add(this.btnVisaoDados);
            this.tabPageBUG.Controls.Add(this.button1);
            this.tabPageBUG.Controls.Add(this.groupBoxReport);
            this.tabPageBUG.Controls.Add(this.lblTempoConsulta);
            this.tabPageBUG.Controls.Add(this.button2);
            this.tabPageBUG.Controls.Add(this.trackBarTempoConsulta);
            this.tabPageBUG.Controls.Add(this.button3);
            this.tabPageBUG.Controls.Add(this.button4);
            this.tabPageBUG.Location = new System.Drawing.Point(4, 30);
            this.tabPageBUG.Name = "tabPageBUG";
            this.tabPageBUG.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBUG.Size = new System.Drawing.Size(736, 233);
            this.tabPageBUG.TabIndex = 0;
            this.tabPageBUG.Text = "BUG";
            this.tabPageBUG.UseVisualStyleBackColor = true;
            // 
            // tabPageSolicitacao
            // 
            this.tabPageSolicitacao.Controls.Add(this.btnVDSolicitacao);
            this.tabPageSolicitacao.Controls.Add(this.groupBoxSolicitacao);
            this.tabPageSolicitacao.Location = new System.Drawing.Point(4, 22);
            this.tabPageSolicitacao.Name = "tabPageSolicitacao";
            this.tabPageSolicitacao.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSolicitacao.Size = new System.Drawing.Size(736, 241);
            this.tabPageSolicitacao.TabIndex = 1;
            this.tabPageSolicitacao.Text = "Solicitações";
            this.tabPageSolicitacao.UseVisualStyleBackColor = true;
            // 
            // btnVDSolicitacao
            // 
            this.btnVDSolicitacao.Location = new System.Drawing.Point(8, 113);
            this.btnVDSolicitacao.Name = "btnVDSolicitacao";
            this.btnVDSolicitacao.Size = new System.Drawing.Size(119, 35);
            this.btnVDSolicitacao.TabIndex = 1;
            this.btnVDSolicitacao.Text = "Visão Dados";
            this.btnVDSolicitacao.UseVisualStyleBackColor = true;
            this.btnVDSolicitacao.Click += new System.EventHandler(this.btnVDSolicitacao_Click);
            // 
            // groupBoxSolicitacao
            // 
            this.groupBoxSolicitacao.Controls.Add(this.btnEditReportSolicitacao);
            this.groupBoxSolicitacao.Controls.Add(this.lblVersao);
            this.groupBoxSolicitacao.Controls.Add(this.cmbVersao);
            this.groupBoxSolicitacao.Controls.Add(this.btnReportSolicitacao);
            this.groupBoxSolicitacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSolicitacao.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSolicitacao.Name = "groupBoxSolicitacao";
            this.groupBoxSolicitacao.Size = new System.Drawing.Size(730, 100);
            this.groupBoxSolicitacao.TabIndex = 0;
            this.groupBoxSolicitacao.TabStop = false;
            this.groupBoxSolicitacao.Text = "Relatório";
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(6, 41);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(63, 21);
            this.lblVersao.TabIndex = 6;
            this.lblVersao.Text = "Versão";
            // 
            // cmbVersao
            // 
            this.cmbVersao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVersao.FormattingEnabled = true;
            this.cmbVersao.Location = new System.Drawing.Point(6, 65);
            this.cmbVersao.Name = "cmbVersao";
            this.cmbVersao.Size = new System.Drawing.Size(382, 29);
            this.cmbVersao.TabIndex = 5;
            // 
            // FormPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(744, 267);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notificação de BUG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.FormPrincipal_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Compact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTempoConsulta)).EndInit();
            this.groupBoxReport.ResumeLayout(false);
            this.groupBoxReport.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageBUG.ResumeLayout(false);
            this.tabPageBUG.PerformLayout();
            this.tabPageSolicitacao.ResumeLayout(false);
            this.groupBoxSolicitacao.ResumeLayout(false);
            this.groupBoxSolicitacao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnConsultarBUG;
        private DataSet dataSet;
        private System.Windows.Forms.Timer timer1;
        private DataSet_Compact dataSet_Compact;
        private System.Windows.Forms.TrackBar trackBarTempoConsulta;
        private System.Windows.Forms.Label lblTempoConsulta;
        private System.Windows.Forms.Button btnEditReport;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFim;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.Label lblDataFim;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBoxReport;
        private System.Windows.Forms.Button btnVisaoDados;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageBUG;
        private System.Windows.Forms.TabPage tabPageSolicitacao;
        private System.Windows.Forms.GroupBox groupBoxSolicitacao;
        private System.Windows.Forms.Button btnVDSolicitacao;
        private System.Windows.Forms.Button btnReportSolicitacao;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.ComboBox cmbVersao;
        private System.Windows.Forms.Button btnEditReportSolicitacao;
    }
}

