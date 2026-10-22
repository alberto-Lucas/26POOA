using System.Collections.Generic;

namespace ProjetoExemploCerto.Models
{
    public class Uniforme
    {
        public int UniformeId { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public string Tamanho { get; set; }
        public string Categoria { get; set; }
    }

    public class UniformeColletion : List<Uniforme> { }
}
