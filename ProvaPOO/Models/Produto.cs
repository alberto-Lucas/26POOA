namespace ProvaPOO.Models
{
    public class Produto
    {
        public string CodBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public string BarrasDescricao
        {
            get
            {
                return CodBarras + " - " + Descricao;
            }
        }
    }
}
