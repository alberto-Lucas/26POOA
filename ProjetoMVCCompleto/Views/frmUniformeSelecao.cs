using ProjetoExemploCerto.Controllers;
using ProjetoExemploCerto.Models;
using System.Windows.Forms;

namespace ProjetoExemploCerto.Views
{
    public partial class frmUniformeSelecao : Form
    {
        public Uniforme uniformeSelecao;
        UniformeController uniformeController = new UniformeController();
        public frmUniformeSelecao(bool ExibirBotaoSelecionar = false)
        {
            InitializeComponent();
            btnSelecionar.Visible = ExibirBotaoSelecionar;
        }

        void AtualizarGrid()
        {
            dgvRegistros.DataSource = null;
            dgvRegistros.DataSource = uniformeController.GetByDescricao(txtDescricao.Text);
            lblRegistros.Text = "Registros encontrados: " + dgvRegistros.RowCount.ToString();
        }

        private void btnAdicionar_Click(object sender, System.EventArgs e)
        {
            frmUniformeCadastro frm = new frmUniformeCadastro();
            if (frm.ShowDialog() == DialogResult.OK)
                AtualizarGrid();
        }

        Uniforme GetUniforme()
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum uniforme selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            else
                return (dgvRegistros.SelectedRows[0].DataBoundItem as Uniforme);

        }

        private void btnAlterar_Click(object sender, System.EventArgs e)
        {
            frmUniformeCadastro frm = new frmUniformeCadastro(2, GetUniforme());
            if (frm.ShowDialog() == DialogResult.OK)
                AtualizarGrid();
        }

        private void btnExcluir_Click(object sender, System.EventArgs e)
        {
            Uniforme uniformeSelecionado = GetUniforme();

            if (uniformeSelecionado == null)
                return;

            if (MessageBox.Show(
                    "Deseja realmente excluir o registro?",
                    "Confirmação!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (uniformeController.Excluir(uniformeSelecionado.UniformeId) > 0)
                {
                    MessageBox.Show(
                        "Cadastro excluido com sucesso!",
                        "Informação!", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    AtualizarGrid();
                }
                else
                    MessageBox.Show(
                        "Falha ao excluir o cadastro!",
                        "Atenção!", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
            }
        }

        private void btnVisualizar_Click(object sender, System.EventArgs e)
        {
            frmUniformeCadastro frm = new frmUniformeCadastro(3, GetUniforme());
            frm.ShowDialog();
        }

        private void btnPesquisar_Click(object sender, System.EventArgs e)
        {
            AtualizarGrid();
        }

        private void btnSelecionar_Click(object sender, System.EventArgs e)
        {
            Selecionar();
        }
        private void Selecionar()
        {
            uniformeSelecao = GetUniforme();
            if (uniformeSelecao != null)
                this.DialogResult = DialogResult.OK;
        }
    }
}
