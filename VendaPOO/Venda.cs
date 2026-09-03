using System;
using System.Collections.Generic;

namespace VendaPOO
{
    public class Venda
    {
        public DateTime DataHora { get; set; }
        public string Vendedor { get; set; }
        public string Cliente { get; set; }

        //A classe produto se torna o tipo de
        //dado Produto e onde temos mais de um produto
        //temos uma lista de produto, ou seja
        //uma lista do tipo de dado produto
        //neste caso comparando a banco de dados
        //seria equivalente a FK da tabela
        public List<Produto> Itens { get; set; }

    }
}
