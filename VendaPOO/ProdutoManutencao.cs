using System.Collections.Generic;

namespace VendaPOO
{
    public class ProdutoManutencao
    {
        //Lista de Produtos
        private List<Produto> listaProdutos =
            new List<Produto>();

        public void Adicionar(Produto objeto)
        {
            listaProdutos.Add(objeto);
        }

        public void Remover(Produto objeto)
        {
            listaProdutos.Remove(objeto);
        }

        public List<Produto> ListarProdutos()
        {
            return listaProdutos;
        }

        //Função para calcular o valor total
        //da somatória de todos os produtos
        public float TotalProdutos()
        {
            //Realizaremos um loop para 
            //percorrer produtoa produtos da lista
            //e somar os seus totais
            float total = 0;

            for (int i = 0; i < listaProdutos.Count; i++)
                total += listaProdutos[i].Total;

            return total;
        }
    }
}
