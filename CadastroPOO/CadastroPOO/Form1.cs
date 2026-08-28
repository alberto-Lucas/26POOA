using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroPOO
{
    public partial class Form1 : Form
    {
        //Instanciar a classe de manutenção
        //E a deixaremos global para ser acessada
        //de qualquer método ou função desta tela
        UsuarioManutencao manutencao = new UsuarioManutencao();

        public Form1()
        {
            InitializeComponent();
        }

        //Método para atualizar a lista de usuário na tela
        void AtualizarListaUsuarios()
        {
            //Limpar a lista atual
            lstRegistros.DataSource = null;
            //Popular com os registros novos
            lstRegistros.DataSource =
                manutencao.ListarUsuarios();
            //Definir qual atributo será exibido na tela
            //OBS: Digitar o nome do atributo corretamente
            lstRegistros.DisplayMember = "CPFNomeEmail";
        }

        //Método para adicionar um novo cadastro
        void AdicionarCadastro()
        {
            //Instanciar o nosso objeto usuario
            Usuario usuario = new Usuario();

            //Mapeamos o objeto com as informações da tela
            usuario.Nome = txtNome.Text;
            usuario.CPF = txtCPF.Text;
            usuario.DtNascimento = dtpDtNascimento.Value;
            usuario.Email = txtEmail.Text;
            usuario.Senha = txtSenha.Text;

            //Chamar o método adicionar da manutenção
            manutencao.Adicionar(usuario);

            //Atualizamos a tela
            AtualizarListaUsuarios();

            //Limpar os campos
            txtNome.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            dtpDtNascimento.Value = DateTime.Now;
        }

        //Função para recuperar o registro selecionado na tela
        Usuario RecuperarUsuarioSelecionado()
        {
            //Qunando preenchemos a listBox
            //os nossos objtos são convertidos
            //para o tipo de Item
            //usado na listaBox
            //Por tanto é converter novamente
            //de item para objeto
            //assim poderemos manipular o cadastro
            //direto do objeto
            //SelectedItem é item selecionado
            //as é para converte de item para objeto desejado
            return lstRegistros.SelectedItem as Usuario;
        }

        //Método para remover o usuário selecionado
        void RemoverUsuario()
        {
            //Chamar o método remover da manutenção
            //e o método recuperar para remover
            //o registro selecionado
            manutencao.Remover(RecuperarUsuarioSelecionado());
        }

        //Méto para exibir os dados do usuário selecionado
        void ExibirUsuario()
        {
            //Varial auxiliar do tipo usuario
            //que sera populada com o usuario selecionado
            Usuario usuario = RecuperarUsuarioSelecionado();

            //Mapear a tela com os dados do objeto
            txtExibirUsuario.Text = usuario.CPFNome;
            txtExibirIdade.Text = usuario.Idade.ToString();
            txtExibirEmail.Text = usuario.Email;
            txtExibirSenha.Text = usuario.Senha;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarCadastro();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            RemoverUsuario();
            AtualizarListaUsuarios();
        }

        private void lstRegistros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ExibirUsuario();
        }
    }
}
