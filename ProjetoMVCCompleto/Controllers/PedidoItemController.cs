using ProjetoExemploCerto.Models;
using ProjetoExemploCerto.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoExemploCerto.Controllers
{
    public class PedidoItemController
    {
        DataBaseSqlServer dataBase = new DataBaseSqlServer();

        public int Inserir(PedidoItem pedidoItem)
        {
            string query =
                "INSERT INTO pedido_item (pedido_id, uniforme_id, quantidade) " +
                "VALUES (@PedidoId, @UniformeId, @Quantidade);";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@PedidoId", pedidoItem.Pedido.PedidoId);
            command.Parameters.AddWithValue("@UniformeId", pedidoItem.Uniforme.UniformeId);
            command.Parameters.AddWithValue("@Quantidade", pedidoItem.Quantidade);
            return dataBase.ExecuteSQL(command);
        }

        public int Alterar(PedidoItem pedidoItem)
        {
            string query = 
                "UPDATE pedido_item SET " +
                "uniforme_id = @UniformeId, " +
                "quantidade = @Quantidade " +
                "WHERE pedido_id = @PedidoId " +
                "AND pedido_item_id = @PedidoItemId";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@UniformeId", pedidoItem.Uniforme.UniformeId);
            command.Parameters.AddWithValue("@PedidoId", pedidoItem.Pedido.PedidoId);
            command.Parameters.AddWithValue("@PedidoItemId", pedidoItem.PedidoItemId);
            return dataBase.ExecuteSQL(command);
        }

        public int Excluir(int PedidoId, int PedidoItemId)
        {
            string query = 
                "DELETE FROM pedido_item " +
                "WHERE pedido_id = @PedidoId " +
                "AND pedido_item_id = @PedidoItemId";

            SqlCommand command = new SqlCommand(query);

            command.Parameters.AddWithValue("@PedidoId", PedidoId);
            command.Parameters.AddWithValue("@PedidoItemId", PedidoItemId);
            return dataBase.ExecuteSQL(command);
        }

        private PedidoItemCollection GetByFilter(string filtro = "")
        {
            string query = "SELECT * FROM pedido_item ";

            if (filtro != "")
                query += " WHERE " + filtro;

            SqlCommand command = new SqlCommand(query);

            DataTable dataTable = dataBase.GetDataTable(command);
            PedidoItemCollection pedidoItens = new PedidoItemCollection();
            UniformeController uniformeController = new UniformeController();
            PedidoController pedidoController = new PedidoController();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                PedidoItem pedidoItem = new PedidoItem();
                pedidoItem.PedidoItemId = Convert.ToInt32(dataRow["pedido_item_id"]);
                pedidoItem.Pedido = pedidoController.GetById(Convert.ToInt32(dataRow["pedido_id"]));
                pedidoItem.Uniforme = uniformeController.GetById(Convert.ToInt32(dataRow["uniforme_id"]));
                pedidoItem.Quantidade = Convert.ToInt32(dataRow["quantidade"]);

                pedidoItens.Add(pedidoItem);
            }
            return pedidoItens;
        }

        public PedidoItemCollection GetByPedido(int pedidoId)
        {
            return GetByFilter("pedido_id = " + pedidoId);
        }
    }
}
