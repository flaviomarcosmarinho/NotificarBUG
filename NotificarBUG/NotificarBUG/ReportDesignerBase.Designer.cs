namespace NotificarBUG
{
    partial class ReportDesignerBase
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
            this.designerControl = new Stimulsoft.Report.Design.StiDesignerControl();
            this.SuspendLayout();
            // 
            // designerControl
            // 
            this.designerControl.AllowDrop = true;
            this.designerControl.BackColor = System.Drawing.Color.White;
            this.designerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designerControl.Location = new System.Drawing.Point(5, 154);
            this.designerControl.Name = "designerControl";
            this.designerControl.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.designerControl.Size = new System.Drawing.Size(790, 241);
            this.designerControl.TabIndex = 0;
            // 
            // ReportDesignerBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 448);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ReportDesignerBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private Stimulsoft.Report.Design.StiDesignerControl designerControl;
    }
}