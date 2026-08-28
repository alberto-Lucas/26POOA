namespace CadastroPOO
{
    //Realizado a herança com a classe Pessoa
    //Usuario tem acesso a tudo que estiver publico
    //na classe Pessoa
    public class Usuario : Pessoa
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public string CPFNomeEmail
        {
            get
            {
                return CPFNome + " - " + Email;
            }
        }
    }
}
