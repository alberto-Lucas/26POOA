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

        //Para reutilizar a tela para as rotinas de 
        //Alterar e Visualizar
        //Precisamos adicionar 2 parametros na chamada da tela
        //um parametro para definir a ação
        //0 = Cadastrar
        //1 = Alterar
        //2 = Visualizar
        //Nosso segundo parametro ira receber o objeto 
        //selecionado a ser carregado na tela

        //Definir variaveis globais para salvar os
        //dados do parametros
        int acaoTela;
        Usuario usuarioSelecionado;
        public frmUsuarioCadastro(
            int acao, Usuario usuario)
        {
            InitializeComponent();

            //Carregar os parametros
            acaoTela = acao;
            usuarioSelecionado = usuario;

            //Personaizar a tela de acordo com a acao
            CarregarTela();
        }

        void CarregarTela()
        {
            //Validar a acao
            if (acaoTela == 0)
                this.Text = "Cadastrar Usuário";
            else
            {
                //Carregar os dados do objeto para tela
                CarregarDados();

                if (acaoTela == 1)
                    this.Text = "Alterar Usuário";
                else
                {
                    this.Text = "Visualizar Usuário";
                    //Como a ideia é só visualizar
                    //Precisamos desabilitar os campos
                    DesabilitarCampos();
                }
            }
        }

        //Método para carregar o objeto na tela
        void CarregarDados()
        {
            //Mapear o objeto
            txtCodigo.Text = usuarioSelecionado.Id.ToString();
            txtNome.Text = usuarioSelecionado.Nome;
            txtCPF.Text = usuarioSelecionado.CPF;
        }

        //Método para desabilitar os campos da tela
        void DesabilitarCampos()
        {
            //Transformar os campos de etxto em somente leitura
            txtNome.ReadOnly = true;
            txtCPF.ReadOnly = true;

            //Ocular os botão Salvar e Cancelar
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
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

            //Vamos adicionar a opção de alterar
            //Então faremos a validação
            //para Inserir ou Alterar
            //e para isso precisamos de uma variavel
            //para armazenar o retorno
            int retorno = 0;

            if (acaoTela == 0)
                retorno = usuarioController.Inserir(usuario);
            else
            {
                //Carregar o Codigo do usuaro no objeto
                //pois sera usado no WHERE do UPDATE
                usuario.Id = int.Parse(txtCodigo.Text);

                retorno = usuarioController.Alterar(usuario);
            }

            if (retorno > 0)
            {
                MessageBox.Show("Usuário salvo com sucesso!");

                //Retornar para a tela anterior
                //que deu tudo certo 
                //Ou seja retornamos um OK
                DialogResult = DialogResult.OK;
            }
            else
            {
                //Caso o retorno for 0 de falha
                //Notificamos o usuario
                MessageBox.Show("Falha ao salvar o registro.");

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
