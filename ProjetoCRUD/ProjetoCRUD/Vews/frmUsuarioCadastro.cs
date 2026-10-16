using System.Windows.Forms;
using ProjetoCRUD.Controllers;
using ProjetoCRUD.Models;

namespace ProjetoCRUD.Views
{
    public partial class frmUsuarioCadastro : Form
    {
        //Importar as camdas de modelo e controle
        //using NomeProjeto.Controllers;
        //usgin NomeProjeto.Models;

        //Criar a instanciar com a camada de controle
        UsuarioController usuarioController = new UsuarioController();
        public frmUsuarioCadastro()
        {
            InitializeComponent();
        }

        //Criar o método salvar para realizar o cadastro
        void Salvar()
        {
            //Mapear os dados da tela em um objeto
            //Instanciando o objeto Usuario
            Usuario usuario = new Usuario();

            //Mapear as informações
            usuario.Nome = txtNome.Text;
            usuario.CPF = txtCPF.Text;

            //Executar a rotina de cadastro
            //da camada de controle
            //Ou seja vamos chamar o método Inserir
            //e passar o objeto via parametro
            //e validar o retorno
            //0 = Falha na execução
            //1 = Cadastro realizado com sucesso
            if(usuarioController.Inserir(usuario) > 0)
            {
                MessageBox.Show("Usuário cadastrado com sucesso!");

                //Retornar para a tela anterior
                //que deu tudo certo 
                //Ou seja retornamos um OK
                DialogResult = DialogResult.OK;
            }
            else
            {
                //Caso o retorno for 0 de falha
                //Notificamos o usuario
                MessageBox.Show("Falha ao realizar o cadastro.");

                //Awui não definimos nenhum retorno (ok ou cancel)
                //Pois o usuario pode tentar novamente
            }
        }

        void Cancelar()
        {
            //Validar se o usuário realmente deseja
            //Cancelar a rotina
            
            //Apresentar um mensagem de Sim ou Não
            //para o usuário confirmar
            if(MessageBox.Show("Deseja cancelar o cadastro?",
                               "Confirmação",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) 
                == DialogResult.Yes)
            {
                //Se o usuário clicou em SIM
                //Vamos fechar a tela e retornar o Cancel
                DialogResult = DialogResult.Cancel;
            }


        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            Salvar();
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Cancelar();
        }
    }
}
