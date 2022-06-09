using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace NotificarBUG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {               
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
            Application.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            
            // Nome do processo atual
            string nomeProcesso = Process.GetCurrentProcess().ProcessName;

            // Obtém todos os processos com o nome do atual
            Process[] processes = Process.GetProcessesByName(nomeProcesso);

            // Maior do que 1, porque a instância atual também conta
            if (processes.Length > 1)
            {
                MessageBox.Show("Já existe uma instancia do programa em execução!");
                return;
            }
            else
            {
                //Carregamento do arquivo environment ".env" contido na pasta "bin/Degug"
                var root = Directory.GetCurrentDirectory();
                var dotenv = Path.Combine(root, ".env");               
                DotNetEnv.Env.Load(dotenv); 
                
                Application.Run(new FormPrincipal());
            }        
        }
    }
}
