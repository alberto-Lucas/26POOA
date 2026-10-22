using System;
using System.Collections.Generic;

namespace ProjetoExemploCerto.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime DtHora { get; set; }
        public Usuario Usuario { get; set; }
        public char Status { get; set; }
        public string StatusTratado
        {
            get
            {
                switch (Status)
                {
                    case 'P':
                        return "Pendente";
                        break;
                    case 'F':
                        return "Finalizado";
                        break;
                    case 'C':
                        return "Cancelado";
                        break;
                    default:
                        return "Desconhecido";
                        break;
                }
            }
        }
    }

    public class PedidoCollection : List<Pedido> { }
}
