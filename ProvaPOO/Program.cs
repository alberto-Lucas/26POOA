using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProvaPOO.Views;

namespace ProvaPOO
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Impostar a camada Views
            //using NomeProjeto.Views;

            //Alterar a tela que sera exibida
            //de Form1 para frmPrincipal
            //Application.Run(new Form1());
            Application.Run(new frmPrincipal());
        }
    }
}
