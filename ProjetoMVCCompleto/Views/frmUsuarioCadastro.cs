using System;
using System.Windows.Forms;
using ProjetoExemploCerto.Controllers;
using ProjetoExemploCerto.Models;

namespace ProjetoExemploCerto.Views
{
    public partial class frmUsuarioCadastro : Form
    {
        //Importar camadas Models e Controllers
        //using Nome_Porjeto.Models;
        //using Nome_Porjeto.Controllers;

        //Cirar instancia com a controller
        UsuarioController usuarioController = new UsuarioController();

        //Iremos aidionar parametros para definir a ação
        //1 = Cadastrar
        //2 = Alterar
        //3 = Visualizar

        //Definimos o valor padrão 1, pois caso 
        //não seja passado nada via parametro
        //ira utilizar o valor padrao
        //E iremos receber o objeto via parametro
        //para ser preenchido em tela
        public frmUsuarioCadastro(int Acao = 1, Usuario usuario = null)
        {
            InitializeComponent();

            //Se o usuario estiver nullo
            //Só podemos abrir no modo cadastro
            if (usuario == null)
                Acao = 1;

            if(Acao != 1)
            {
                CarregarDados(usuario);

                if (Acao == 3)
                {
                    DesativarCampos();
                    this.Text = "Visualizar Usuário";
                }
                else
                    this.Text = "Alterar Usuário";
            }
        }

        void DesativarCampos()
        {
            txtNome.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtSenha.ReadOnly = true;

            btnSalvar.Visible = false;
            btnCancelar.Text = "OK";
        }

        void CarregarDados(Usuario usuario)
        {
            //Iremos mapear o objeto com os campos em tela
            txtId.Text = usuario.UsuarioId.ToString();
            txtNome.Text = usuario.Nome.ToString();
            txtEmail.Text = usuario.Email.ToString();
            txtSenha.Text = usuario.Senha.ToString();
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            //Se o botao salvar estiver oculto
            //é que a tela está no modo visualização
            //portanto podemos dar o result e fechar a tela
            if (btnSalvar.Visible == false)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //Validar se a tela poderá ser fechada
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
            //Primeiro preciamos instanciar o nosso objeto
            Usuario usuario = new Usuario();
            //Iremos mapear as informações com o objeto
            //OBS: nesse momento não iremos mapear
            //o campo ID, pois a nossa tabela é
            //IDENTITY
            usuario.Nome = txtNome.Text;
            usuario.Email = txtEmail.Text;
            usuario.Senha = txtSenha.Text;

            //Agora iremos salvar o cadastro
            //no banco de dados, via controller
            //E validamos o retorno se o cadastro
            //foi inserido com sucesso

            //Iremos validar se estamos no modo cadastro
            //ou alteração
            //Se o campo ID estiver preenchido, estamos no modo
            //alteração
            int retorno = 0;
            if (txtId.Text == "")
                retorno = usuarioController.Inserir(usuario);
            else
            {
                //nesse momento precisamo mapear o ID ao objeto
                usuario.UsuarioId = int.Parse(txtId.Text);
                retorno = usuarioController.Alterar(usuario);
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

        private void frmUsuarioCadastro_Load(object sender, EventArgs e)
        {

        }
    }
}
