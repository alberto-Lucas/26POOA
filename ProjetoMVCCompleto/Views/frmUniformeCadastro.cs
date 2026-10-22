using ProjetoExemploCerto.Controllers;
using ProjetoExemploCerto.Models;
using System;
using System.Windows.Forms;

namespace ProjetoExemploCerto.Views
{
    public partial class frmUniformeCadastro : Form
    {
        UniformeController uniformeController = new UniformeController();

        public frmUniformeCadastro(int Acao = 1, Uniforme uniforme = null)
        {
            InitializeComponent();

            if (uniforme == null)
                Acao = 1;

            if (Acao != 1)
            {
                CarregarDados(uniforme);

                if (Acao == 3)
                {
                    DesativarCampos();
                    this.Text = "Visualizar Uniforme";
                }
                else
                    this.Text = "Alterar Uniforme";
            }
        }

        void DesativarCampos()
        {
            txtDescricao.ReadOnly = true;
            txtCor.ReadOnly = true;
            txtCategoria.ReadOnly = true;
            cbxTamanho.Enabled = false;

            btnSalvar.Visible = false;
            btnCancelar.Text = "OK";
        }

        void CarregarDados(Uniforme uniforme)
        {
            txtId.Text = uniforme.UniformeId.ToString();
            txtDescricao.Text = uniforme.Descricao;
            txtCor.Text = uniforme.Cor;
            txtCategoria.Text = uniforme.Categoria;
            cbxTamanho.Text = uniforme.Tamanho;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnSalvar.Visible == false)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (MessageBox.Show(
                    "Deseja realmente sair?" + Environment.NewLine + Environment.NewLine +
                    "Ao Sair os dados alterados serão descartados!",
                    "Confirmação!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Uniforme uniforme = new Uniforme();

            uniforme.Descricao = txtDescricao.Text;
            uniforme.Cor = txtCor.Text;
            uniforme.Categoria = txtCategoria.Text;
            uniforme.Tamanho = cbxTamanho.Text;

            int retorno = 0;
            if (txtId.Text == "")
                retorno = uniformeController.Inserir(uniforme);
            else
            {
                uniforme.UniformeId = int.Parse(txtId.Text);
                retorno = uniformeController.Alterar(uniforme);
            }

            if (retorno > 0)
            {
                MessageBox.Show(
                    "Cadastro salvo com sucesso!",
                    "Informação!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show(
                    "Falha ao salvar o cadastro!",
                    "Atenção!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }
    }
}
