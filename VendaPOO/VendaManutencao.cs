using System.Collections.Generic;

namespace VendaPOO
{
    public class VendaManutencao
    {
        //Seguir o mesmo padrao de
        //classe de manutencao
        //1 - Lista de Objeto
        //2 - Adicionar
        //3 - Remover
        //4 - Listar

        private List<Venda> listaVendas =
            new List<Venda>();

        public void Adicionar(Venda objeto)
        {
            listaVendas.Add(objeto);
        }

        public void Remover(Venda objeto)
        {
            listaVendas.Remove(objeto);
        }

        public List<Venda> ListarVendas()
        {
            return listaVendas;
        }
    }
}
