using System;
using System.Drawing;
using System.Windows.Forms;

namespace NotificarBUG
{
    public partial class Form_Alert : Form
    {
        private const int TEMPO = 60000; //1 minuto configurados em milisegundos
        private int minutosParaPesquisa = 1;
        private Form_Alert.enmAction action;
        private int x, y;
        private string serie = string.Empty;
        private int numero = 0;
        private string detalhe = string.Empty;
        private ConexaoBancoDados conexao = new ConexaoBancoDados();

        public Form_Alert()
        {
            InitializeComponent();
        }

        public string Mensagem
        {
            get
            {
                string bug = "(" + ((string.IsNullOrEmpty(serie) ? "" : serie.Trim() + "-") + ((numero == 0) ? "" : numero.ToString()) + ") - Aberto!");
                return (!string.IsNullOrEmpty(serie) && numero > 0 ? bug : string.Empty) + (string.IsNullOrEmpty(detalhe) ? "" : "Detalhe: " + detalhe.Trim());
            }
        }
       
        public void showAlert(string serie, int numero, string detalhe, enmType type, int minutosParaPesquisa)
        {
            this.serie = serie;
            this.numero = numero;
            this.detalhe = detalhe;
            this.minutosParaPesquisa = minutosParaPesquisa;

            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 30; i++)
            {
                fname = "alert" + i.ToString();
                Form_Alert frm = (Form_Alert)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Success:
                    //this.pictureBox1.Image = Resources.success;
                    this.BackColor = Color.SeaGreen;
                    break;
                case enmType.Error:
                    //this.pictureBox1.Image = Resources.error;
                    this.BackColor = Color.DarkRed;
                    break;
                case enmType.Info:
                    //this.pictureBox1.Image = Resources.info;
                    this.BackColor = Color.RoyalBlue;
                    break;
                case enmType.Warning:
                    //this.pictureBox1.Image = Resources.warning;
                    this.BackColor = Color.DarkOrange;
                    break;
            }

            this.lblMsg.Text = this.Mensagem;
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = minutosParaPesquisa * TEMPO;
                    action = enmAction.close;
                    break;
                case Form_Alert.enmAction.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = Form_Alert.enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        public enum enmAction
        {
            wait,
            start,
            close
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;

            string comando = @"INSERT INTO Verificado (Serie, Numero) VALUES ('{0}', {1})";
            conexao.mExecutarNonQuerySqlCompact(string.Format(comando, serie, numero));
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }
    }   
}
