using ProvaPOO.Models;
using System.Collections.Generic;

namespace ProvaPOO.Controllers
{
    //Importar a camada Models
    //using NomeProjeto.Models;
    public class LivroController
    {
        //Criar a lista de objeto livro
        //A lista deve ser private pois não sera acessada de fora da classe LivroController
        //uso do underscore para identificar que a variavel global é privada
        private List<Livro> _listaLivros = new List<Livro>();

        //Criar método Adicionar/Remover/Listar

        //Adicionar e Remover recebem o proprio objeto via parametros
        public void Adicionar(Livro objeto)
        {
            _listaLivros.Add(objeto);
        }

        public void Remover(Livro objeto)
        {
            _listaLivros.Remove(objeto);
        }

        //Função lista ira retornar toda a lista de livro
        public List<Livro> ListarLivros()
        {
            return _listaLivros;
        }
    }
}
