using System.Data;
using System.Data.SqlClient;

namespace ProjetoExemploCerto.Services
{
    //Classe para gerenciar a conexão com o BD
    //Importar bibliotecas
    //using System.Data;
    //using System.Data.SqlClient;
    public class DataBaseSqlServer
    {
        //Método privado que cria nova conexão com o banco
        private SqlConnection GetConnection()
        {
            //Variavel q ira armazenar a conexão
            SqlConnection connection = new SqlConnection();

            //Definindo a string de conexão
            //Dados para conectar co o servidor
            //Precisamos do Host (Nome/IP)
            //Nome do banco de dados
            //Autenticação (Usuario e Senha ou Autenticação do Windows)
            connection.ConnectionString =
                "Data Source=.\\SQLEXPRESS;" +
                "Initial Catalog=ProjetoMVC;" +
                "Integrated Security=SSPI;";

            //Método para abrir a conexão
            connection.Open();
            //Retornando a conexão aberta
            return connection;
        }

        //Método pulico que executa comandos
        //INSERT, UPDATE e DELETE
        //Retorna a quantidade de linhas afetada
        public int ExecuteSQL(SqlCommand command)
        {
            command.Connection = GetConnection();
            //command.CommandType = System.Data.CommandType.Text;
            return command.ExecuteNonQuery();
        }

        //Método publico que executa comando SELECT no banco de dados
        //Retorna apenas a primeira coluna da primeira linha do banco
        //Utilizamos o tipo de dados object pois não sabemos o tipo
        //de dados que será retornado
        public object ExecuteScalar(SqlCommand command)
        {
            command.Connection = GetConnection();
            return command.ExecuteScalar();
        }

        //Método pulibo que executa comando SQL 
        //Retorna todas as linhas e colunas da consult
        public DataTable GetDataTable(SqlCommand command)
        {
            // Criando o objeto DataTable
            DataTable dataTable = new DataTable();

            // Definindo a conexão do comando SQL
            command.Connection = GetConnection();
            // Criando o objeto SqlDataAdapter e vinculando o comando
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);

            // Preenchendo o DataTable com os dados do banco
            sqlDataAdapter.Fill(dataTable);

            // Retornando o DataTable preenchido
            return dataTable;
        }
    }
}
