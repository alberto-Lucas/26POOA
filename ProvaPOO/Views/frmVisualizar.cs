using System.Windows.Forms;
using ProvaPOO.Models;

namespace ProvaPOO.Views
{
    //Importar a camada models e controllers
    //using NomeProjeto.Models;
    public partial class frmVisualizar : Form
    {
        //Adicionar parametro no construtor para receber o objeto a ser exebido
        public frmVisualizar(Livro objeto)
        {
            InitializeComponent();
            //Chamar método para exibir os dados do objeto
            ExibirDados(objeto);
        }

        void ExibirDados(Livro objeto)
        {
            txtFornecedor.Text = objeto.Fornecedor.CNPJNome;
            txtEditora.Text = objeto.Editora.CNPJNome;

            txtDescricao.Text = objeto.Descricao;
            txtCodBarras.Text = objeto.CodBarras;
            txtPreco.Text = objeto.Preco.ToString();

            txtTitulo.Text = objeto.Titulo;
            txtEdicao.Text = objeto.Edicao.ToString();
            txtGenero.Text = objeto.Genero;
            txtAno.Text = objeto.AnoPublicacao.ToString();
            txtClassificacao.Text = objeto.Classificacao;
            txtAutor.Text = objeto.Autor;
            txtNumPaginas.Text = objeto.NumPaginas.ToString();
        }
    }
}
