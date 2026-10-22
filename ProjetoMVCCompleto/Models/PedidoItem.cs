using System.Collections.Generic;

namespace ProjetoExemploCerto.Models
{
    public class PedidoItem
    {
        public int PedidoItemId { get; set; }
        public Pedido Pedido { get; set; }
        public Uniforme Uniforme { get; set; }
        public int Quantidade { get; set; }
    }

    public class PedidoItemCollection : List<PedidoItem> { }
}
