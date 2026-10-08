using ProjetoCRUD.Models;
using ProjetoCRUD.Services;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoCRUD.Controllers
{
    //Classe de controle com as regras de negocios
    //para manipular o cadastro de Usuarios
    //Ou seja é aqui que vamos
    //converter o objeto em comando de banco de dados

    //Importar as camdas Models e Services
    //using NomeProjeto.Models;
    //using NomeProjeto.Services;

    //Importar as bibliotecas do SQLServer
    //using System.Data;
    //using System.Data.SqlClient;
    public class UsuarioController
    {
        //Variavel privada global para armazenar a instancia
        //da camada de serviço
        DataBaseService _database = new DataBaseService();

        //Desenvolver os métodos Adicionar, Atualizar,
        //Excluir e Consultar

        //Função publica que insere na tabela usuario
        //um novo registro
        //Os dados que serão inseridos são passados
        //via parametro de comando atraves do objeto
        //Ou seja são recuperado da tela
        //mapeado para o objeto usuario
        //e será convertido para comando de SQL
        public int Inserir(Usuario usuario)
        {
            //São divididos em 4 partes
            //Criçãção da query (comando)
            //Instancia do objeto comando
            //A conversao de C# para SQL
            //Execução do comando no banco

            //Crir o comando SQL que será executado
            //informar campo a campo, como executado
            //direto no banco
            //Os parametros são determinado usando @
            //ou seja ire repetir o nome do campo
            //com o @ ex: @Nome, @Cpf
            string query =
                "INSERT INTO usuario (nome, cpf) " +
                "VALUES (@Nome, @Cpf)";

            //Instanciar o nosso comando com a query
            SqlCommand command = new SqlCommand(query);

            //Definir os valores que serão colocado 
            //em cada parametro
            //Aqui ocorre a conversão do objeto para SQL
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Cpf", usuario.CPF);

            //Executar o comando detro da camada de serviço
            //e teremos o retorno de linhas afetadas
            //0 - Não executou corretamente
            //1 - Executou com sucesso
            return _database.ExecuteSql(command);
        }

        //Função publica para atualizar o registro
        public int Alterar(Usuario usuario)
        {
            //Seguir o mesmo padrão de 4 etapas do inserir

            //Criar o comando SQL para o UPDATE
            string query =
                "UPDATE usuario SET " +
                "nome = @Nome, " +
                "cpf = @Cpf " +
                "WHERE id = @Id";

            //Instanciar o comando
            SqlCommand command = new SqlCommand(query);

            //Definir os parametros
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Cpf", usuario.CPF);
            command.Parameters.AddWithValue("@Id", usuario.Id);

            //Executar o comando
            return _database.ExecuteSql(command);
        }

        //Função public para excluir o registro
        public int Excluir(int id)
        {
            //Criar comando SQL para DELETE
            string query =
                "DELETE FROM usuario " +
                "WHERE id = @Id";

            //Instancia o comando
            SqlCommand command = new SqlCommand(query);

            //Definir os parametros
            command.Parameters.AddWithValue("@Id", id);

            //Executar o comando
            return _database.ExecuteSql(command);
        }

        //Encerramos as funções de manutenção
        //INSERT, UPDATE e DELET
        //E agora vamos para as funções de consulta SELECT

        //Função publica para consultar por ID
        //portante ira retornar um objeto Usuario
        public Usuario GetById(int id)
        {
            //Diferente dos métodos de manutenação
            //aqui teremos 5 etapas
            //as 4 etapas ja conhecidas
            //mais a quinta etapa que é converter
            //SQL para Objeto
            //Ou seja convertemos Objeto para SQL
            //e depois SQL para Objeto

            //Criar o comando SELECT
            string query =
                "SELECT * FROM usuario " +
                "WHERE id = @Id";

            //Instanciar o comando
            SqlCommand command = new SqlCommand(query);

            //Definir os parametros
            command.Parameters.AddWithValue("@Id", id);

            //Instanciar e executar a consultra de
            //tabela de dados (formato que o sql retorna)
            //Em função de consulta nãp usamos mais o 
            //ExecuteSql
            //Agora precisamos do GetDataTable para manipular
            //as informações retornadas
            DataTable dataTable = _database.GetDataTable(command);

            //Iremos converter os dados SQL em um objeto Usuario
        }
    }
}
