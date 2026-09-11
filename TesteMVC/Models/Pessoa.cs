namespace TesteMVC.Models
{
    //Classe tradiciona
    //Deixar publica 
    //Criar os atributos
    public class Pessoa
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public string NomeCPF
        {
            get
            {
                return Nome + " - " + CPF;
            }
        }
    }
}
