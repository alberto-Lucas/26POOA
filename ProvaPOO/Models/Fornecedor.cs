namespace ProvaPOO.Models
{
    //Primeira coisa é deixar a classe publica
    public class Fornecedor
    {
        //Criar os atributos
        //atalho prop + TAB
        public string CNPJ { get; set; }
        public string Nome { get; set; }

        //Propriedade para retornar concactenacao
        public string CNPJNome
        {
            get
            {
                return CNPJ + " - " + Nome;
            }
        }
    }
}
