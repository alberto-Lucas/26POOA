using ProjetoExemploCerto.Models;
using ProjetoExemploCerto.Services;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoExemploCerto.Controllers
{
    public class PedidoController
    {
        DataBaseSqlServer dataBase = new DataBaseSqlServer();

        public int Inserir(Pedido pedido)
        {
            string query = 
                "INSERT INTO pedido (data_hora, usuario_id, status) " +
                "VALUES (@DataHora, @UsuarioId, @Status);" +
                "SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@DataHora", pedido.DtHora);
            command.Parameters.AddWithValue("@UsuarioId", pedido.Usuario.UsuarioId);
            command.Parameters.AddWithValue("@Status", pedido.Status);

            //Precisamo retornar o ID do pedido no banco de dados
            //devido a gravação da tabela pedido_item
            // ExecuteScalar retorna o valor do SCOPE_IDENTITY() (último ID inserido)
            object retorno = dataBase.ExecuteScalar(command);

            // Converte o retorno para int (ou zero, se nulo)
            if (retorno != null)
                return Convert.ToInt32(retorno);
            else
                return 0;
        }

        public int Alterar(Pedido pedido)
        {
            string query = 
                "UPDATE pedido SET +" +
                "data_hora = @DataHora, " +
                "usuario_id = @UsuarioId, " +
                "status = @Status " +
                "WHERE pedido_id = @PedidoId";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@PedidoId", pedido.PedidoId);
            command.Parameters.AddWithValue("@DataHora", pedido.DtHora);
            command.Parameters.AddWithValue("@UsuarioId", pedido.Usuario.UsuarioId);
            command.Parameters.AddWithValue("@Status", pedido.Status);
            return dataBase.ExecuteSQL(command);
        }

        public int AlterarStatus(int pedidoId, char status)
        {
            string query = 
                "UPDATE pedido SET " +
                "status = @Status " +
                "WHERE pedido_id = @PedidoId";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@PedidoId", pedidoId);
            command.Parameters.AddWithValue("@Status", status);
            return dataBase.ExecuteSQL(command);
        }

        public int Excluir(int pedidoId)
        {
            string query = "DELETE FROM pedido WHERE pedido_id = @PedidoId";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@PedidoId", pedidoId);
            return dataBase.ExecuteSQL(command);
        }

        public Pedido GetById(int pedidoId)
        {
            string query = "SELECT * FROM pedido WHERE pedido_id = @PedidoId";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@PedidoId", pedidoId);
            DataTable dataTable = dataBase.GetDataTable(command);
            UsuarioController usuarioController = new UsuarioController();

            if (dataTable.Rows.Count > 0)
            {
                Pedido pedido = new Pedido();
                pedido.PedidoId = Convert.ToInt32(dataTable.Rows[0]["pedido_id"]);
                pedido.DtHora = Convert.ToDateTime(dataTable.Rows[0]["data_hora"]);
                pedido.Usuario = usuarioController.GetById(Convert.ToInt32(dataTable.Rows[0]["usuario_id"]));
                pedido.Status = Convert.ToChar(dataTable.Rows[0]["status"]);

                return pedido;
            }
            else
                return null;
        }

        private PedidoCollection GetByFilter(string filtro = "")
        {
            string query = "SELECT * FROM pedido ";

            if (filtro != "")
                query += " WHERE " + filtro;

            query += " ORDER BY data_hora";

            SqlCommand command = new SqlCommand(query);

            DataTable dataTable = dataBase.GetDataTable(command);
            PedidoCollection pedidos = new PedidoCollection();
            UsuarioController usuarioController = new UsuarioController();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Pedido pedido = new Pedido();
                pedido.PedidoId = Convert.ToInt32(dataRow["pedido_id"]);
                pedido.DtHora = Convert.ToDateTime(dataRow["data_hora"]);
                pedido.Usuario = usuarioController.GetById(Convert.ToInt32(dataRow["usuario_id"]));
                pedido.Status = Convert.ToChar(dataRow["status"]);

                pedidos.Add(pedido);
            }
            return pedidos;
        }

        public PedidoCollection GetAll()
        {
            return GetByFilter();
        }

        public PedidoCollection GetByPeriodo(DateTime dtInicial, DateTime dtFinal)
        {
            //É preciso ajustar o horario para a Consulta
            //Ao pegar o valor direto do DateTimePicker irá retornar a hora atual da seleção dos valores
            //Por é precisa ajustar somente os valores de horas para a consulta
            //Pois para consultar os registros de um dia completo é preciso
            //que a hora inicial seja 00:00:00
            //e a hora final seja 23:59:59
            //Caso contrario o banco de dados poderá não retornar todos os dados daquela data selecionada

            DateTime dtInicialZeroHoras = dtInicial.Date;
            DateTime dtFinalUltimaHora = new DateTime(dtFinal.Year, dtFinal.Month, dtFinal.Day, 23, 59, 59);

            string where =
                "data_hora " +
                "BETWEEN '" + dtInicialZeroHoras + "' " +
                "AND '" + dtFinalUltimaHora + "' ";

            return GetByFilter(where);
        }

        public PedidoCollection GetByUsuario(int usuarioId)
        {
            return GetByFilter("usuario_id = " + usuarioId);
        }

        public PedidoCollection GetByStatus(string status)
        {
            return GetByFilter("status = '" + status + "'");
        }

        public PedidoCollection GetByPedidoId(int pedidoId)
        {
            PedidoCollection pedidoCollection = new PedidoCollection();
            pedidoCollection.Add(GetById(pedidoId));
            return pedidoCollection;
        }

        public PedidoCollection GetByCampo(string campo, string valor)
        {
            return GetByFilter(campo + " = '" + valor + "'");
        }
    }
}
