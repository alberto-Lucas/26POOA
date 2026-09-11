using TesteMVC.Models;
using System.Collections.Generic;

namespace TesteMVC.Controllers
{
    //Clase padrão de manutenção
    public class PessoaController
    {
        //Para acessar as classes de objeto
        //é preciso adicionar a camada Model
        //usando o using
        //Ex: using NomeProjeto.NomeCamada
        //Ex: using TesteMVC.Models;
        //Criar a lista de objetos
        List<Pessoa> listaPessoas =
            new List<Pessoa>();

        public void Adicionar(Pessoa pessoa)
        {
            listaPessoas.Add(pessoa);
        }

        public void Remover(Pessoa pessoa)
        {
            listaPessoas.Remove(pessoa);
        }

        public List<Pessoa> ListarPessoas()
        {
            return listaPessoas;
        }
    }
}
