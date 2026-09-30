namespace ProvaPOO.Models
{
    public class Editora
    {
        public string CNPJ { get; set; }
        public string Nome { get; set; }

        public string CNPJNome
        {
            get
            {
                return CNPJ + " - " + Nome;
            }
        }
    }
}
