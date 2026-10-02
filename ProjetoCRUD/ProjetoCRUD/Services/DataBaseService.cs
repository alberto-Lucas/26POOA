using System.Data;
using System.Data.SqlClient;

namespace ProjetoCRUD.Services
{
    //Importar as bibliotecas do SQLSERVER
    //o C# possui as bibliotecas nativamente
    //ou seja, não precisamos instalar nada
    //é somente importa-las
    //using System.Data;
    //using System.Data.SqlClient;
    public class DataBaseService
    {
        //Função privada que cria uma nova conexão com o banco
        private SqlConnection GetConnection()
        {
            //Variavel do tipo connecton para 
            //armazenar  ainstancia da conexao
            SqlConnection connection = new SqlConnection();

            //Definir a string de conexão
            //Ou seja os dados para conectar no banco
            //Constituida em 3 partes
            //DataSource = Host do banco (nome da maquina ou ip)
            //Catalog = Nome do Banco
            //Autenticação = Usuario e Senha ou Usuario do Windows
            //OBS a barra invertida sozinha é um operadar matematico
            //paa converte-la em texto coloca duas junto \\
            //OBS: Colocar igual aparece no SqlServer Manegment Studio
            connection.ConnectionString =
                "Data Source=.\\SQLEXPRESS;" + //Host
                "Initial Catalog=ProjetoCRUD;" + //Nome Banco
                "Integrated Security=SSPI;"; //Autenticação do Windows

            //Abrir a conexão com o banco
            connection.Open();

            //Retornar a conexão aberta
            return connection;
        }

        //Métodos publicos responsaveis pela execução dos 
        //comandos no banco de dados

        //Função de execução de manutenção
        //INSERT, UPDATE e DELETE
        //Está execução retorna a quantidade de linhas afetadas
        public int ExecuteSql(SqlCommand command)
        {
            //Command é comando a ser executado
            //INSERT, UPDATE ou DELETE

            //Antes de executar é preciso conectar no banco
            command.Connection = GetConnection();

            //Executar o comando dentro do banco de dados
            //NonQuery significa que nao possui retorno
            //de sql
            //A função não realizar nenhum tipo de SELECT
            //Executo o comando no banco e retorno
            //a quantidade de linhas afetadas
            return command.ExecuteNonQuery();
        }

        //Função publica para executar comandos de consulta(SELECT)
        //Retorna uma tabela de dados com todas
        //as linhas e colunas da consulta
        public DataTable GetDataTable(SqlCommand command)
        {
            //Conectar com o banco de dados
            command.Connection = GetConnection();

            //Instanciar um objeto DataTable
            DataTable dataTable = new DataTable();

            //Instanciar o objeto que ira executar o comando
            //no banco de dados
            //Ou seja é precio passar o comando(SELECT) via parametro
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            //Aqui o select ja foi executado
            //Recuperar os dados retornados e popular o dataTable
            adapter.Fill(dataTable);

            //Retorn o dataTable
            return dataTable;
        }
    }
}
