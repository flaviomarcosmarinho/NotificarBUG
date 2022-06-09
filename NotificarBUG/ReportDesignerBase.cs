using Stimulsoft.Report;
using Stimulsoft.Report.Design;
using Stimulsoft.Report.Design.Wizards;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NotificarBUG
{
    public partial class ReportDesignerBase : StiRibbonDesigner
    {
        DataSet dados;
        StiWizardReport stiWizardNewReport = StiWizardReport.NotWizardReport;
        string path = string.Empty;

        public ReportDesignerBase(string nameForm, DataSet dados, Dictionary<string, object> paramters, StiReport report, string path)
            : base(report)
        {
            //Dados da licença do Stimulsoft são carregados do arquivo environment ".env"
            Stimulsoft.Base.StiLicense.Key = Environment.GetEnvironmentVariable("STIMULSOFT_LICENSE_KEY");            
            StiOptions.Engine.GlobalEvents.SavingReportInDesigner += GlobalEvents_SavingReportInDesigner;
            InitializeComponent();
            this.Text = "Construtor de Relatórios (" + nameForm + ")";
            this.path = path;

            if (report != null)
            {
                this.Report = report;

                this.Report.RegData("Dados", dados);

                this.Report.Dictionary.Synchronize();
                this.dados = dados;
                SetVariablesReport(paramters, report);
            }
        }

        public ReportDesignerBase(string nameForm, DataSet dados, Dictionary<string, object> paramters, StiReport report, StiWizardReport stiWizardNewReport, string path) :
            this(nameForm, dados, paramters, report, path)
        {
            this.stiWizardNewReport = stiWizardNewReport;
        }

        private void SetVariablesReport(Dictionary<string, object> paramters, StiReport report)
        {
            foreach (var item in paramters)
            {
                Stimulsoft.Report.Dictionary.StiVariable newParameter = new Stimulsoft.Report.Dictionary.StiVariable(item.Key, item.Value != null ? item.Value.GetType() : typeof(object));
                newParameter.Alias = item.Key;
                newParameter.ValueObject = item.Value;
                report.Dictionary.Variables.Add(newParameter);
            }
        }

        private StiWizardService GetWizardNewReport()
        {
            StiWizardService result = null;
            switch (stiWizardNewReport)
            {
                case StiWizardReport.Chart:
                    result = new StiChartWizardService();
                    break;
                case StiWizardReport.Standard:
                    result = new StiStandardWizardService();
                    break;
                case StiWizardReport.CrossTab:
                    result = new StiCrossTabWizardService();
                    break;
                case StiWizardReport.MasterDetail:
                    result = new StiMasterDetailWizardService();
                    break;
                default:
                    result = new StiStandardWizardService();
                    break;
            }
            return result;
        }


        private void ReportDesignerBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dados != null)
            {
                dados.Dispose();
            }
        }

        private void ReportDesignerBase_Shown(object sender, EventArgs e)
        {
            if (this.Report.ReportName.ToUpper().Contains("NOVO"))
            {
                StiWizardService result = GetWizardNewReport();
                if (result != null)
                {
                    try
                    {
                        this.Report = result.CreateReport(this.Report);
                        if (this.Report == null)
                        {
                            this.Close();
                        }
                    }
                    catch
                    {
                        this.Close();
                    }
                }
            }
        }

        private void GlobalEvents_SavingReportInDesigner(object sender, Stimulsoft.Report.Design.StiSavingObjectEventArgs e)
        {
            if (this.Report != null)
            {
                this.Report.Save(path);               
                e.Processed = true;
            }
        }
    }

    public enum StiWizardReport
    {
        /// <summary>
        /// Not Wizard Report
        /// </summary>
        NotWizardReport,

        /// <summary>
        /// Chart
        /// </summary>
        Chart,

        /// <summary>
        /// Standard Report
        /// </summary>
        Standard,

        /// <summary>
        /// CrossTab Report
        /// </summary>
        CrossTab,

        /// <summary>
        /// Master-Detail Report
        /// </summary>
        MasterDetail
    }
}
