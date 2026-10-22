using ProjetoExemploCerto.Models;
using ProjetoExemploCerto.Services;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoExemploCerto.Controllers
{
    public class UniformeController
    {
        DataBaseSqlServer dataBase = new DataBaseSqlServer();

        public int Inserir(Uniforme uniforme)
        {
            string query =
                "INSERT INTO Uniforme (descricao, cor, tamanho, categoria) " +
                "VALUES (@Descricao, @Cor, @Tamanho, @Categoria)";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@Descricao", uniforme.Descricao);
            command.Parameters.AddWithValue("@Cor", uniforme.Cor);
            command.Parameters.AddWithValue("@Tamanho", uniforme.Tamanho);
            command.Parameters.AddWithValue("@Categoria", uniforme.Categoria);
            return dataBase.ExecuteSQL(command);
        }
        public int Alterar(Uniforme uniforme)
        {
            string query =
                "UPDATE Uniforme SET " +
                "descricao = @Descricao, " +
                "cor = @Cor, " +
                "tamanho = @Tamanho, " +
                "categoria = @Categoria " +
                "WHERE uniforme_id = @UniformeId";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@Descricao", uniforme.Descricao);
            command.Parameters.AddWithValue("@Cor", uniforme.Cor);
            command.Parameters.AddWithValue("@Tamanho", uniforme.Tamanho);
            command.Parameters.AddWithValue("@Categoria", uniforme.Categoria);
            command.Parameters.AddWithValue("@UniformeId", uniforme.UniformeId);
            return dataBase.ExecuteSQL(command);
        }

        public int Excluir(int uniformeId)
        {
            string query =
                "DELETE FROM Uniforme " +
                "WHERE uniforme_id = @UniformeId";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@UniformeId", uniformeId);
            return dataBase.ExecuteSQL(command);
        }

        public Uniforme GetById(int uniformeId)
        {
            string query =
                "SELECT * " +
                "FROM Uniforme " +
                "WHERE uniforme_id = @UniformeId " +
                "ORDER BY descricao";
            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@UniformeId", uniformeId);
            DataTable dataTable = dataBase.GetDataTable(command);

            if (dataTable.Rows.Count > 0)
            {
                Uniforme uniforme = new Uniforme();

                uniforme.UniformeId = (int)dataTable.Rows[0]["uniforme_id"];
                uniforme.Descricao = (string)dataTable.Rows[0]["descricao"];
                uniforme.Cor = (string)dataTable.Rows[0]["cor"];
                uniforme.Tamanho = (string)dataTable.Rows[0]["tamanho"];
                uniforme.Categoria = (string)dataTable.Rows[0]["categoria"];

                return uniforme;
            }
            else
                return null;
        }

        private UniformeColletion GetByFilter(string filtro = "")
        {
            string query = "SELECT * FROM Uniforme ";

            if (filtro != "")
                query += " WHERE " + filtro;

            query += " ORDER BY descricao";

            SqlCommand command = new SqlCommand(query);

            DataTable dataTable = dataBase.GetDataTable(command);
            UniformeColletion uniformes = new UniformeColletion();

            foreach (DataRow row in dataTable.Rows)
            {
                Uniforme uniforme = new Uniforme();

                uniforme.UniformeId = (int)row["uniforme_id"];
                uniforme.Descricao = (string)row["descricao"];
                uniforme.Cor = (string)row["cor"];
                uniforme.Tamanho = (string)row["tamanho"];
                uniforme.Categoria = (string)row["categoria"];

                uniformes.Add(uniforme);
            }
            return uniformes;
        }

        public UniformeColletion GetAll()
        {
            return GetByFilter();
        }

        public UniformeColletion GetByDescricao(string value)
        {
            return GetByFilter("descricao LIKE '%" + value + "%'");
        }
    }
}
