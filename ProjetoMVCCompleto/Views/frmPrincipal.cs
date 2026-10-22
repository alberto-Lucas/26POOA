using System;
using System.Windows.Forms;

namespace ProjetoExemploCerto.Views
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarioSelecao frm = new frmUsuarioSelecao();
            frm.ShowDialog();
        }

        private void uniformesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUniformeSelecao frm = new frmUniformeSelecao();
            frm.ShowDialog();
        }

        private void históricoDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPedidoHistorico frm = new frmPedidoHistorico();
            frm.ShowDialog();
        }

        private void solicitarUniformesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPedido frm = new frmPedido();
            frm.ShowDialog();
        }
    }
}
