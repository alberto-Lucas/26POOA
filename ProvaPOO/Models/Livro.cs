namespace ProvaPOO.Models
{
    public class Livro : Produto
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Classificacao { get; set; }
        public int Edicao { get; set; }
        public int AnoPublicacao { get; set; }
        public int NumPaginas { get; set; }
        public string Autor { get; set; }

        public Fornecedor Fornecedor { get; set; }
        public Editora Editora { get; set; }


        public string CodBarrasDescTituloGenero
        {
            get
            {
                return CodBarras + " - " + Titulo + " - " + Genero;
            }
        }

        public string CodBarrasDescTituloGeneroEditora
        {
            get
            {
                return CodBarrasDescTituloGenero + " - " + Editora.Nome;
            }
        }

        public string CodBarrasDescTituloGeneroEditoraEdicao
        {
            get
            {
                return CodBarrasDescTituloGeneroEditora + " - " + Edicao;
            }
        }

        public string CodBarrasDescTituloGeneroEditoraEdicaoFornecedor
        {
            get
            {
                return CodBarrasDescTituloGeneroEditoraEdicao + " - " + Fornecedor.Nome;
            }
        }

        public string CodBarrasDescTituloGeneroAutor
        {
            get
            {
                return CodBarrasDescTituloGenero + " - " + Autor;
            }
        }
    }
}
