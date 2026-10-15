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
    }
}
