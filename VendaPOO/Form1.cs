using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendaPOO
{
    public partial class Form1 : Form
    {
        //Instanciar as classe de manutencao
        ProdutoManutencao produtoManutencao = 
            new ProdutoManutencao();

        VendaManutencao vendaManutencao = 
            new VendaManutencao();

        public Form1()
        {
            InitializeComponent();
        }

        //Exibir e atualizar as informações
        //de produto na tela
        void AtualizarRegistros()
        {
            //Limpar a lista de registros
            lstRegistros.DataSource = null;

            //Carregar a fonte de dados da listabox
            //com a lista de objetos produto
            lstRegistros.DataSource =
                produtoManutencao.ListarProdutos();

            //Atribuir o atributo a ser exibido
            //OBS: Digitar o nome do atributo
            //exatamento igual ao criado
            //dentro da classe
            lstRegistros.DisplayMember = "Informacao";

            //Atualizar a label com o Valor total de venda
            lblTotalVenda.Text =
                "R$ " + produtoManutencao.
                    TotalProdutos().ToString("0.00");
        }

        void AdicionarProduto()
        {
            //Primeiro instanciamos a classe Produto
            Produto produto = new Produto();

            //Mapear o objeto com as
            //informações da tela
            produto.Descricao = txtDescricao.Text;
            produto.PrecoUnitario = 
                float.Parse(txtPrecoUnitario.Text);
            produto.Quantidade =
                int.Parse(txtQuantidade.Text);
            produto.Desconto =
                float.Parse(txtDesconto.Text);
            //OBS: Não estamos tratando os dados informados
            //pois não é o foco no momento
            //converter o texto direto em numero
            //pode gerar erro, se a informação
            //estiver errada

            //Adicionar o objeto a lista
            produtoManutencao.Adicionar(produto);

            //Atualizar a tela
            AtualizarRegistros();
        }

        void RemoverProduto()
        {
            //Para remover o produto é preciso
            //recuperar o objeto o registro
            //selecionada na lista box
            //para isso usaremos uma variavel auxiliar
            Produto produtoSelecionado;

            //recuperar o objeto da listabox
            //Quando adicionamos a lista de objeto
            //na listbox ele são convertidos de objeto
            //para o tipo item
            //como precisamo do objeto
            //usamos o AS para converter o tipo item
            //para o objeto produto novamente
            produtoSelecionado =
                lstRegistros.SelectedItem as Produto;

            //basta remover o produto selecionado
            produtoManutencao.Remover(produtoSelecionado);

            AtualizarRegistros();
        }

        void FinalizarVenda()
        {
            //Iremos cirar o objeto venda
            Venda venda = new Venda();

            //Mapear os dados da venda
            //DateTime.Now pega a data e hora
            //atual da maquina
            venda.DataHora = DateTime.Now;
            venda.Vendedor = txtVendedor.Text;
            venda.Cliente = txtCliente.Text;
            //Vincul a lista de produtos a venda
            venda.Itens =
                produtoManutencao.ListarProdutos();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarProduto();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            RemoverProduto();
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            FinalizarVenda();
        }
    }
}
