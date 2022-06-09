using Stimulsoft.Report;
using Stimulsoft.Report.Viewer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NotificarBUG
{
    public partial class ReportVisualizerBase : Form
    {
        bool showRibbon = true;

        public ReportVisualizerBase(string nameForm, DataSet dados, Dictionary<string, object> paramters, List<StiReport> report)
        {
            //Dados da licença do Stimulsoft são carregados do arquivo environment ".env"
            Stimulsoft.Base.StiLicense.Key = Environment.GetEnvironmentVariable("STIMULSOFT_LICENSE_KEY");
            InitializeComponent();
            this.Text = "Relatórios (" + nameForm + ")";
            CreateTabPages(dados, paramters, report);
        }

        public ReportVisualizerBase(string nameForm, DataSet dados, Dictionary<string, object> paramters, List<StiReport> report, bool visibleBars) : this(nameForm, dados, paramters, report)
        {           
            this.showRibbon = visibleBars;           
        }

        private void CreateTabPages(DataSet dados, Dictionary<string, object> paramters, List<StiReport> report)
        {
            foreach (StiReport item in report)
            {
                TabPage tabPage = new TabPage();
                tabPage.Text = item.ReportName;
                if (showRibbon)
                {
                    StiRibbonViewerControl newstiRibbonViewerControl = new StiRibbonViewerControl();
                    newstiRibbonViewerControl.ShowCloseButton = false;
                    newstiRibbonViewerControl.ShowOpen = false;
                    newstiRibbonViewerControl.Dock = DockStyle.Fill;
                    newstiRibbonViewerControl.Report = item;
                    newstiRibbonViewerControl.Report.RegData("Dados", dados);
                    SetVariablesReport(paramters, newstiRibbonViewerControl.Report);
                    newstiRibbonViewerControl.Report.Render(false);
                    newstiRibbonViewerControl.Report.Dictionary.Synchronize();
                    tabPage.Controls.Add(newstiRibbonViewerControl);

                    newstiRibbonViewerControl.Zoom = 0.90;
                    newstiRibbonViewerControl.Zoom = 1;


                    newstiRibbonViewerControl.ShowPageDelete = false;
                    newstiRibbonViewerControl.ShowPageDesign = false;
                    newstiRibbonViewerControl.ShowPageNew = false;
                    newstiRibbonViewerControl.ShowPageNew = false;
                    newstiRibbonViewerControl.Close += newstiRibbonViewerControl_Close;
                }
                else
                {
                    StiViewerControl stiViewerControl = new StiViewerControl();
                    stiViewerControl.ShowBookmarksPanel = false;
                    stiViewerControl.ShowContextMenu = false;
                    stiViewerControl.ShowDotMatrixModeButton = false;
                    stiViewerControl.ShowEditor = false;
                    stiViewerControl.ShowFind = false;
                    stiViewerControl.ShowFullScreen = false;
                    stiViewerControl.ShowHorScrollBar = false;
                    stiViewerControl.ShowLastPage = false;
                    stiViewerControl.ShowNextPage = false;
                    stiViewerControl.ShowPageControl = false;
                    stiViewerControl.ShowPageDelete = false;
                    stiViewerControl.ShowPageDesign = false;
                    stiViewerControl.ShowPageNew = false;
                    stiViewerControl.ShowPageSize = false;
                    stiViewerControl.ShowPageViewMode = false;
                    stiViewerControl.ShowPreviousPage = false;
                    stiViewerControl.ShowPrint = false;
                    stiViewerControl.ShowSave = false;
                    stiViewerControl.ShowSaveDocumentFile = false;
                    stiViewerControl.ShowSendEMail = false;
                    stiViewerControl.ShowSendEMailDocumentFile = false;
                    stiViewerControl.ShowSliderZoom = false;
                    stiViewerControl.ShowStatusBar = false;
                    stiViewerControl.ShowThumbsPanel = false;
                    stiViewerControl.ShowToolbar = false;
                    stiViewerControl.ShowVertScrollBar = false;
                    stiViewerControl.ShowViewModeContinuous = false;
                    stiViewerControl.ShowViewModeMultiplePages = false;
                    stiViewerControl.ShowViewModeSinglePage = false;
                    stiViewerControl.ShowZoom = false;
                    stiViewerControl.ShowZoomMultiplePages = false;
                    stiViewerControl.ShowZoomOnePage = false;
                    stiViewerControl.ShowZoomPageWidth = false;
                    stiViewerControl.ShowZoomTwoPages = false;

                    stiViewerControl.Dock = DockStyle.Fill;
                    stiViewerControl.Report = item;
                    stiViewerControl.Report.RegData("Dados", dados);
                    SetVariablesReport(paramters, stiViewerControl.Report);
                    stiViewerControl.Report.Render(false);
                    stiViewerControl.Report.Dictionary.Synchronize();
                    tabPage.Controls.Add(stiViewerControl);
                }
                tabControl1.TabPages.Add(tabPage);

            }
        }

        void newstiRibbonViewerControl_Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetVariablesReport(Dictionary<string, object> paramters, StiReport report)
        {
            foreach (var item in paramters)
            {
                Type type = typeof(object);

                if (item.Value != null)
                {
                    type = item.Value.GetType();
                }

                Stimulsoft.Report.Dictionary.StiVariable newParameter = new Stimulsoft.Report.Dictionary.StiVariable(item.Key, type);
                newParameter.Alias = item.Key;
                newParameter.ValueObject = item.Value;
                report.Dictionary.Variables.Add(newParameter);
            }
        }
    }
}
