using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProvaPOO.Controllers;
using ProvaPOO.Models;

namespace ProvaPOO.Views
{
    public partial class frmCadastro : Form
    {
        //using NomeProjeto.Models;
        //using NomeProjeto.Controllers;

        //Criar a instancia global para a camada de negocios
        private LivroController _controller = new LivroController();
        public frmCadastro()
        {
            InitializeComponent();
        }

        //Método para atualizar a lista de registro
        void AtualizarListaRegistros()
        {
            //Limpar a base de dados da lista
            lstRegistros.DataSource = null;
            //Consulta a lista de registros atualizada
            lstRegistros.DataSource = _controller.ListarLivros();
            //Definir qual atributo ou propriedade sera usado para exibir os dados
            lstRegistros.DisplayMember = "CodBarrasDescTituloGeneroAutor";
        }

        //Função para recuperar registro selecionado na lista
        //Como é um função e vai retorna um livro 
        //o tipo de dados será Livro
        //Sera usado para a rotina remover e visualizar
        Livro RegistroSelecionado()
        {
            //Usado o as para converter o registro do tipo item para o tipo objeto
            //neste caso de tipo item para brinquedo
            return lstRegistros.SelectedItem as Livro;
        }

        //Método para limpars os campos da tela
        void LimparCmapos()
        {
            txtCnpjFornecedor.Clear();
            txtNomeFornecedor.Clear();
            txtCnpjEditora.Clear();
            txtNomeEditora.Clear();
            txtCodBarras.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            txtTitulo.Clear();
            txtGenero.Clear();
            txtClassificacao.Clear();
            txtEdicao.Clear();
            txtAno.Clear();
            txtAutor.Clear();
            txtNumPaginas.Clear();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //Criar e instanciar o objeto livro, fornecedor e editora
            Livro livro = new Livro();
            Fornecedor fornecedor = new Fornecedor();
            Editora editora = new Editora();

            //Mapear o objeto com os dados da tela
            fornecedor.CNPJ = txtCnpjFornecedor.Text;
            fornecedor.Nome = txtNomeFornecedor.Text;

            editora.CNPJ = txtCnpjEditora.Text;
            editora.Nome = txtNomeEditora.Text;

            livro.Fornecedor = fornecedor;
            livro.Editora = editora;

            livro.CodBarras = txtCodBarras.Text;
            livro.Descricao = txtDescricao.Text;
            livro.Preco = decimal.Parse(txtPreco.Text);

            livro.Titulo = txtTitulo.Text;
            livro.Edicao = int.Parse(txtEdicao.Text);
            livro.Genero = txtGenero.Text;
            livro.AnoPublicacao = int.Parse(txtAno.Text);
            livro.Autor = txtAutor.Text;
            livro.Classificacao = txtClassificacao.Text;
            livro.NumPaginas = int.Parse(txtNumPaginas.Text);

            //Chamar o método adicionar para salvar o objeto 
            _controller.Adicionar(livro);

            AtualizarListaRegistros();

            LimparCmapos();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            //Chama o método remover da camada de negocios
            //e passa o registro selecionado via aprametro
            _controller.Remover(RegistroSelecionado());

            AtualizarListaRegistros();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            //Chamar tela de visualização passando o registro a ser exibido via parametro
            frmVisualizar frm = new frmVisualizar(RegistroSelecionado());
            frm.ShowDialog();
        }
    }
}
