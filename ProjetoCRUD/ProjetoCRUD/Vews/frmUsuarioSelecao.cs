using System.Windows.Forms;
using ProjetoCRUD.Controllers;
using ProjetoCRUD.Models;

namespace ProjetoCRUD.Views
{
    public partial class frmUsuarioSelecao : Form
    {
        //Importar as camadas de modelo e controle
        //using NomeProjeto.Controllers;
        //using NomeProjeto.Models;

        //Criar a instancia com a camada de controle
        UsuarioController usuarioController = new UsuarioController();
        public frmUsuarioSelecao()
        {
            InitializeComponent();

            //Ao abrir a tela, ja ira pesquisar
            //Apresentar todos os registros cadastrados
            Pesquisar();
        }

        //Criar o método de pesquisa
        void Pesquisar()
        {
            //Primeiro é preciso limpar a grade atual
            dgvRegistros.DataSource = null;

            //Realizar as condicionais
            //Codigo, Nome ou todos se vazio
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                //No caso do GetById retorna apenas um unico registro
                //Então a função retorna um objeto Usuario
                //Porém a grade espera um fonte de dados
                //Ou seja espera uma lista de usuarios
                //Neste caso temos que usar o Usuario Collection
                //Portanto vamos adicionar o objeto retornado
                //a lista de usuarios e vincular a grade

                //Salvar o Usuario retornado na consulta
                Usuario retorno =
                    usuarioController.GetById(int.Parse(txtCodigo.Text));

                //Instanciar a lista de usuario
                UsuarioColletion listaUsuarios = new UsuarioColletion();

                //Adicionar o retorno a lista
                listaUsuarios.Add(retorno);

                //Vinculamos a lista a grade
                dgvRegistros.DataSource = listaUsuarios;
            }
            else
            if (!string.IsNullOrEmpty(txtNome.Text))
                dgvRegistros.DataSource =
                    usuarioController.GetByName(txtNome.Text);
            else
                dgvRegistros.DataSource = usuarioController.GetAll();
        }

        private void btnPesquisar_Click(object sender, System.EventArgs e)
        {
            Pesquisar();
        }

        private void btnAdicionar_Click(object sender, System.EventArgs e)
        {
            //Abrir a tela de cadastro
            frmUsuarioCadastro frm = new frmUsuarioCadastro(0, null);
            //Validar o retorno da tela de cadastro
            //Se retorno OK ou Cancel
            //OK - Cadastro realizado com sucesso
            //Cancel - Usuario fechou a tela ou cancelou a rotina
            if (frm.ShowDialog() == DialogResult.OK)
                Pesquisar(); //Atualizar a grade
        }

        //Função para identificar o registro selecionado
        //na grade e recuperar essa informação
        //transformando-o em objeto novamente
        //Esssa rotina sera nescessario para as ações
        //Excluir, Alterar e Visualizar
        Usuario GetUsuarioGrade()
        {
            //Validar se possui um registro selecionado
            if(dgvRegistros.SelectedRows.Count == 0)
            {
                //Notificar o usuario do sistema
                MessageBox.Show("Nenhum registro selecionado.");
                //Retornamos null
                return null;
            }
            else
            {
                //Retornar o registro selecionado ja convertido
                //em objeto usuario
                return
                    dgvRegistros.SelectedRows[0].
                        DataBoundItem as Usuario;
            }
        }

        //Método para realizar a exclusão do registro
        void Excluir()
        {
            //Recuperar o registro
            Usuario usuario = GetUsuarioGrade();

            //Validar se o usuario é null
            if (usuario == null)
                return; //Aborta a execução

            //Confirmação de exclusão
            if(MessageBox.Show(
                "Deseja realmente excluir o registro?",
                "Confirmação", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button2) 
                    == DialogResult.Yes)
            {
                //Chamar o Exlcuir da camada de controle
                //Confirmar o retorno da exclusão
                if (usuarioController.Excluir(usuario.Id) > 0)
                {
                    MessageBox.Show("Registro excluido com sucesso.");
                    //Atualizar a grade
                    Pesquisar();
                }
                else
                    MessageBox.Show("Não foi possível excluir o registro.");
            }

        }

        private void btnExcluir_Click(object sender, System.EventArgs e)
        {
            Excluir();
        }

        private void btnAlterar_Click(object sender, System.EventArgs e)
        {
            //Abrir a tela de cadastro no modo alterar
            frmUsuarioCadastro frm = 
                new frmUsuarioCadastro(1, GetUsuarioGrade());

            //Validar o retorno da tela de alteração
            //Se foi Ok ou Cancel
            if (frm.ShowDialog() == DialogResult.OK)
                Pesquisar(); //Atualziar a grade
        }

        private void btnVisualizar_Click(object sender, System.EventArgs e)
        {
            //Abrir a tela de cadastro no modo visualizar
            frmUsuarioCadastro frm =
                new frmUsuarioCadastro(2, GetUsuarioGrade());
            frm.ShowDialog();
        }
    }
}
