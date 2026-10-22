using ProjetoExemploCerto.Models;
using ProjetoExemploCerto.Services;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoExemploCerto.Controllers
{
    //Classe para controlar as ações do usuario
    //Vulgo regras de negocio
    //Importar a camada de modelo
    //using Nome_Porjeto.Models;
    public class UsuarioController
    {
        //Variavel local e privada que faz o acesso ao
        //banco de dados e executa os comandos.
        //Importar camada de serviço
        //using Nome_Porjeto.Services;
        DataBaseSqlServer dataBase = new DataBaseSqlServer();

        //Importar as bibliotecas
        //using System.Data;
        //using System.Data.SqlClient;

        //Método puliboc que insere na tabela de clientes
        //um novo registro. Os dados que serão inseridos
        //são passados no parametro atraves de um objeto
        //do tipo Cliente. Os dados foram preenchidos pelo
        //usuário na tela de cadastro de clientes.
        public int Inserir(Usuario usuario)
        {
            //Criando o comando SQL para inserir
            //um novo registro na tabela de clientes
            string query =
                "INSERT INTO Usuario (Nome, Email, Senha) " +
                "VALUES (@Nome, @Email, @Senha)";

            SqlCommand command = new SqlCommand(query);
            //Definindo os valores dos parametros
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Email", usuario.Email);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            //Executando o comando SQL e retornando
            //a quantidade de linhas afetadas
            return dataBase.ExecuteSQL(command);
        }

        //Método publico par alterar o registro
        public int Alterar(Usuario usuario)
        {
            //Criando o comando SQL para alterar
            //um registro na tabela de clientes
            string query =
                "UPDATE Usuario SET " +
                "Nome = @Nome, " +
                "Email = @Email, " +
                "Senha = @Senha " +
                "WHERE usuario_id = @UsuarioId";

            SqlCommand command = new SqlCommand(query);
            //Definindo os valores dos parametros
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Email", usuario.Email);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            command.Parameters.AddWithValue("@UsuarioId", usuario.UsuarioId);
            //Executando o comando SQL e retornando
            //a quantidade de linhas afetadas
            return dataBase.ExecuteSQL(command);
        }

        //Método publico para excluir um registro
        public int Excluir(int usuarioId)
        {
            //Criando o comando SQL para excluir
            //um registro na tabela de clientes
            string query =
                "DELETE FROM Usuario " +
                "WHERE usuario_id = @UsuarioId";
            SqlCommand command = new SqlCommand(query);
            //Definindo os valores dos parametros
            command.Parameters.AddWithValue("@UsuarioId", usuarioId);
            //Executando o comando SQL e retornando
            //a quantidade de linhas afetadas
            return dataBase.ExecuteSQL(command);
        }

        //Método publico que retorna um objeto do tipo Usuario
        public Usuario GetById(int usuarioId)
        {
            //Criando o comando SQL para selecionar
            //um registro na tabela de clientes
            string query =
                "SELECT * " +
                "FROM Usuario " +
                "WHERE usuario_id = @UsuarioId " +
                "ORDER BY nome";
            SqlCommand command = new SqlCommand(query);
            //Definindo os valores dos parametros
            command.Parameters.AddWithValue("@UsuarioId", usuarioId);
            //Executando o comando SQL e armazenando o resultado
            //em um objeto do tipo DataTable
            DataTable dataTable = dataBase.GetDataTable(command);

            if (dataTable.Rows.Count > 0)
            {
                //Criando um novo objeto do tipo Usuario
                Usuario usuario = new Usuario();
                // Agora vou indetificar o valor da linha na coluna
                //e atribuir ao objeto
                //Todo dado precisa ser convertido
                //do SQL Server para C#
                usuario.UsuarioId = (int)dataTable.Rows[0]["usuario_id"];
                usuario.Nome = (string)dataTable.Rows[0]["nome"];
                usuario.Email = (string)dataTable.Rows[0]["email"];
                usuario.Senha = (string)dataTable.Rows[0]["senha"];

                return usuario;
            }
            else
                return null;

        }

        //Método publico que retorna uma coleção de Usuarios com filtro
        //Adicionado opção de filtro apenas para não ter q repetir código
        public UsuarioColletion GetByFilter(string filtro = "")
        {
            //Criando o comando SQL para selecionar
            //todos os registros na tabela de clientes
            string query = "SELECT * FROM Usuario ";

            //Validar se o filtro foi passado no parametro
            //Se sim iremos adiciona-lo na nossa query
            if (filtro != "")
                query += " WHERE " + filtro;

            query += " ORDER BY nome";

            SqlCommand command = new SqlCommand(query);

            //Executando o comando SQL e armazenando o resultado
            //em um objeto do tipo DataTable
            DataTable dataTable = dataBase.GetDataTable(command);
            //Criando um novo objeto do tipo UsuarioColletion
            UsuarioColletion usuarios = new UsuarioColletion();
            //Percorrendo todas as linhas retornadas no DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                //Criando um novo objeto do tipo Usuario
                Usuario usuario = new Usuario();
                //Agora vou indetificar o valor da linha na coluna
                //e atribuir ao objeto
                //Todo dado precisa ser convertido
                //do SQL Server para C#
                usuario.UsuarioId = (int)row["usuario_id"];
                usuario.Nome = (string)row["nome"];
                usuario.Email = (string)row["email"];
                usuario.Senha = (string)row["senha"];
                //Adicionando o objeto usuario na coleção
                usuarios.Add(usuario);
            }
            return usuarios;
        }

        //Método publico que retorna uma coleção de Usuarios
        public UsuarioColletion GetAll()
        {
            return GetByFilter();
        }

        //Método para consultar po nome
        //Aplicando o filtro diretamente no método
        //Onde é preciso definir o campo e o valor do filtro
        public UsuarioColletion GetByName(string value)
        {
            return GetByFilter("nome LIKE '%" + value + "%'");
        }

        //Método para consultar por email
        public UsuarioColletion GetByEmail(string value)
        {
            return GetByFilter("email = " + value);
        }
    }
}
