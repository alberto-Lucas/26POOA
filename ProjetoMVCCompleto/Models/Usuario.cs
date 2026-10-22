using System.Collections.Generic;

namespace ProjetoExemploCerto.Models
{
    //Classe para o objeto Usuario que ira representar a
    //tabela Usuario no banco de dados
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
    //Agora iremos criar uma nova classe com a lista de usuarios
    //Sim podemos ter mais de uma classe em um unico arquivo
    //importar a biblioteca
    //using System.Collections.Generic;
    public class UsuarioColletion : List<Usuario> { }
}
