using System.Collections.Generic;

namespace CadastroPOO
{
    //Classe responsavel por manipular o cadastro de usuario
    public class UsuarioManutencao
    {
        //Criar um lista de Usuarios
        //Para armazenar o cadastro em memoria
        //Simulando uma "tabela" de banco de dados
        private List<Usuario> listaUsuarios =
            new List<Usuario>();

        //Método para adicionar objeto na lista
        public void Adicionar(Usuario usuario)
        {
            listaUsuarios.Add(usuario);
        }

        //Método para remover o objeto da lista
        public void Remover(Usuario usuario)
        {
            listaUsuarios.Remove(usuario);
        }

        //Função para retornar a lista de objetos
        public List<Usuario> ListarUsuarios()
        {
            return listaUsuarios;
        }

        //Funação para retornar a lista de obejtos
        //filtrada pelo nome
        public List<Usuario> Pesquisar(string nome)
        {
            //Precisamos criar uma nova lista
            //para armazenar os objetos encontrados
            List<Usuario> listaFiltrada = 
                new List<Usuario>();

            //Vamo aplicar um loop passando objeto por objeto
            //da lista e verificando se o atributo nome
            //conteudo o valor informado no parametro dá função
            //Ou seja será semelhante ao uso do LIKE no banco de dados
            //EX: SELECT * FROM usuario WHERE nome LIKE '%valor%';

            //Realizar um loop para validar os objetos
            //Count retorna a quantidade de itens na lista
            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                //Contains valida se o texto possui o valor desejado
                //ele seria o LIKE do SQL
                if (listaUsuarios[i].Nome.Contains(nome))
                {
                    //Se econtrado um objeto compativel
                    //a adicionar na lista filtrada
                    listaFiltrada.Add(listaUsuarios[i]);
                }
            }

            return listaFiltrada;
        }
    }
}
