using System.Collections.Generic;

namespace ProjetoCRUD.Models
{
    public class Usuario
    {
        //Vamos criar os atributos conforme os campos da tabela
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }

    //Criar uma nova classe para ser a coleção de objeto
    //Ou seja uma loista de objeto usuario
    //Para isso é preciso importar a biblioteca de coleção
    //using System.Collections.Generic;
    public class UsuarioColletion : List<Usuario> { }
}
