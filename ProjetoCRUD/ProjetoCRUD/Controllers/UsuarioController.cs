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

            //Validar se tives dados retornados
            //Ou seja validar a quantidade de linhas retornadas
            if (dataTable.Rows.Count > 0)
            {
                //Mapear o objeto Usuario

                //Instanciar o objeto Usuario
                Usuario usuario = new Usuario();

                //Vamos mapear o valor retornado de cada
                //coluna para cada atributo, para isso
                //é preciso ajustar os tipos de dados
                //(int, string, bool....)
                //Todo dado é preciso ser convertido
                //de SQL apra C#
                //OBS: Colocar o mesmo nome da coluna
                //retornada pelo banco
                usuario.Id      = (int)dataTable.Rows[0]["id"];
                usuario.Nome    = (string)dataTable.Rows[0]["nome"];
                usuario.CPF     = (string)dataTable.Rows[0]["cpf"];

                //Retornar o objeto mapeado
                return usuario;
            }
            else
                return null; //retornar um objeto null
        }

        //Função privada de consulta que ira retornar 
        //mais de um registro
        //Ou seja retonaremos um UsuarioCollectoin
        //A função sera privada pois sera usada
        //apenas dentro desta classe
        //a chamada dela sera por funções de apoio
        //A Função irá receber o filtro 
        //ou seja o campo e o falor a ser filtrado
        //Portante recebera via parametro
        //o filtro desejado
        //caso o filtro esteja vazio
        //significa q precisa retornar tudo
        //então iremos definir que o padrao dele
        //é vazio
        private UsuarioColletion 
            GetByFilters(string filtro = "")
        {
            //Criar o comando SELECT
            string query = "SELECT * FROM usuario ";

            //Vamos identificar se possui filtro
            //Se sim vamos adiciona-lo a query
            if (filtro != "")
                query += "WHERE @filtro";

            //por ultimo independene do filtro
            //iremos adicionar um ordenador por nome
            query += "ORDER BY nome";

            //Criar o comando com a query
            SqlCommand command = new SqlCommand(query);

            //Definir os parametros
            command.Parameters.AddWithValue("@filtro", filtro);

            //Executar o comando e recuperar a tabela de dados
            DataTable dataTable = _database.GetDataTable(command);

            //Instanciar o objeto UsuarioColletion
            UsuarioColletion usuarios = new UsuarioColletion();


            //Vamos aplicar um loop para recuperar a informação
            //linha a linha
            //Ou seja vamos passar pode cada linha da tabela dedados
            //adicionar em um instancia de usuario
            //e mapear os dados convertendo de SQL para C#
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                //Realizar o mapeamento a linha para o objeto
                //semelhante ao reaizad no GetById

                //Instanciar objto Usuario
                Usuario usuario = new Usuario();

                //Converter os dados da tabela
                usuario.Id      = (int)dataTable.Rows[i]["id"];
                usuario.Nome    = (string)dataTable.Rows[i]["nome"];
                usuario.CPF     = (string)dataTable.Rows[i]["cpf"];

                //Bata adicionar o objeto Usuario dentro da 
                //coleção de Usuário
                //usuariO = ao objeto (apenas um registro)
                //usuriOS = a coleção de usuario (mais de um registro)
                usuarios.Add(usuario);
            }

            //Retornando a cleção de usuariOS
            return usuarios;
        }

        //Criar funções intermediaris publicas
        //para chamar a função de consultrar 
        //definindo o filtro, assim a tela 
        //chma apenas a função intermediaria

        //Função para retornar todos os dados
        //ou seja sem filtro
        public UsuarioColletion GetAll()
        {
            //Não vamos passar nada por parametro
            //Semelhante ao SELECT * FROM usuario
            return GetByFilters();
        }

        //Função para retornar todos os dados
        //filtrando pelo nome
        public UsuarioColletion GetByName(string value)
        {
            //Vamos passar o filtro like via parametro
            //Semelhante ao:
            //SELECT & FROM usuario WHERE nome LIKE '%valor%'
            return GetByFilters("nome LIKE '%" + value + "%'");
        }
    }
}
