namespace VendaPOO
{
    public class Produto
    {
        public string Descricao { get; set; }
        public float PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public float Desconto { get; set; }

        //Propriedade que o total calculado do produto
        //(quantidade * precoUnitario) - desconto
        public float Total
        {
            get
            {
                return 
                (Quantidade * PrecoUnitario) - Desconto;
            }
        }

        //Propriedade para concatena as informações
        //do produto
        public string Informacao
        {
            get
            {
                //Ex: Descricao - 2 x 10,00 = 20,00 -
                //Desconto: 5,00 Total: 15,00

                //ToString() serve para converter
                //numeros em texto
                //ToString("0.00") serve para formatar
                //o numero em formato moeda 2 -> 2,00
                return
                    Descricao + " - " +
                    Quantidade.ToString() + " x " +
                    PrecoUnitario.ToString("0.00") + " = " +
                    (Quantidade * PrecoUnitario).ToString("0.00") + 
                    " Desconto: R$ " + Desconto.ToString("0.00") + 
                    " Total: R$ " + Total.ToString("0.00");
            }
        }
    }
}
