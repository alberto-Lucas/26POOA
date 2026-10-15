using System;
using System.Windows.Forms;
using ProjetoCRUD.Views;

namespace ProjetoCRUD
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //A linha que chama a primeira tela a ser exibida
            //Para abrir a frmPrincipal
            //precisamos importar a camada Views
            //using NomeProjeto.Views;
            //Agora só definiri a tela desejada
            Application.Run(new frmPrincipal());
        }
    }
}
