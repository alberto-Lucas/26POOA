using ProjetoExemploCerto.Controllers;
using ProjetoExemploCerto.Models;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ProjetoExemploCerto.Views
{
    public partial class frmPedido : Form
    {
        //Os atributos abaixo irão armazenas os dados
        //selecionados pelo usuário.
        Usuario usuarioPedido;
        Uniforme uniformePedido;

        //Esse atributo irá armazenar os dados do pedido.
        Pedido pedido;

        //Intancias das classes de controle
        PedidoController pedidoController = new PedidoController();
        PedidoItemController pedidoItemController = new PedidoItemController();

        public frmPedido()
        {
            InitializeComponent();
            dgvPedidoItens.AutoGenerateColumns = false;
        }

        #region CarregarPropriedade
        //Esse método é necessário quando você precisar acessar
        //uma propriedade dentro de outra propriedade.
        //Por exemplo, para acessar a descrição do produto que 
        //está dentro do objeto de "pedidoItem", eu preciso
        //colocar "pedidoItem.Produto.Descricao". Nesses casos
        //é necessário fazer um tratamento especial para conseguir
        //chegar até a "Descricao".
        //É utilizada a classe de Reflection para recuperar
        //os dados da propriedade, e recursividade do método abaixo.
        //Preciso importar a biblioteca
        //using System.Reflection;
        private object CarregarPropriedade(object propriedade, string nomeDaPropriedade)
        {
            try
            {
                object retorno = "";

                //Olha se no parâmetro "nomeDaPropriedade" existe um ponto final.
                if (nomeDaPropriedade.Contains("."))
                {
                    PropertyInfo[] propertyInfoArray;
                    string propriedadeAntesDoPonto;

                    //O "Substring" irá recuperar o texto que existe antes do ponto final.
                    propriedadeAntesDoPonto = nomeDaPropriedade.Substring(0, nomeDaPropriedade.IndexOf("."));

                    if (propriedade != null)
                    {
                        //Retorna todas as informações das propriedades
                        //que o parâmetro "propriedade" possui.
                        propertyInfoArray = propriedade.GetType().GetProperties();

                        //Para cada informação retornada eu comparo se o nome
                        //da propriedade é igual ao que eu quero (que é o nome
                        //que está na variável "propriedadeAntesDoPonto").
                        foreach (PropertyInfo propertyInfo in propertyInfoArray)
                        {
                            if (propertyInfo.Name == propriedadeAntesDoPonto)
                            {
                                //Se for o nome que eu quero, eu carrego as propriedades
                                //do objeto que está depois do ponto final. Aqui é utilizada
                                //a recursividade para fazer esse trabalho.
                                retorno = CarregarPropriedade(propertyInfo.GetValue(propriedade, null),
                                    nomeDaPropriedade.Substring(nomeDaPropriedade.IndexOf(".") + 1));
                                break;
                            }
                        }
                    }
                }
                else //Quando o parâmetro "nomeDaPropriedade" não tiver mais um ponto final,
                {    //então eu cheguei até o último nível (que é o que me interessa).
                    Type typeProperty;
                    PropertyInfo propertyInfo;

                    if (propriedade != null)
                    {
                        //Com o Reflection eu recupero o valor da propriedade que quero.
                        typeProperty = propriedade.GetType();
                        propertyInfo = typeProperty.GetProperty(nomeDaPropriedade);
                        retorno = propertyInfo.GetValue(propriedade, null);
                    }
                }
                return retorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private void dgvPedidoItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //Tratamento especial para exibir as propriedades que estão dentro de outras propriedades.
                //É esse evento que chama o método "CarregarPropriedade", mas somente se a propriedade
                //possuir o ponto final.
                if ((dgvPedidoItens.Rows[e.RowIndex].DataBoundItem != null) &&
                    (dgvPedidoItens.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
                {
                    e.Value = CarregarPropriedade(dgvPedidoItens.Rows[e.RowIndex].DataBoundItem,
                        dgvPedidoItens.Columns[e.ColumnIndex].DataPropertyName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void PesquisarUsuario()
        {
            frmUsuarioSelecao frm = new frmUsuarioSelecao(true);
            DialogResult dialogResult = frm.ShowDialog();
            //Se o resultado da tela de seleção for "OK"
            //então o usuário clicou no botão "Selecionar".
            if (dialogResult == DialogResult.OK)
            {
                //Acesso o atributo público "usuarioSelecao" para recuperar o objeto
                usuarioPedido = frm.usuarioSelecao;

                //Exibidos os dados do Usuario na tela pelo objeto retornado
                txtUsuarioId.Text = usuarioPedido.UsuarioId.ToString();
                txtNomeUsuario.Text = usuarioPedido.Nome;
            }
        }

        private void PesquisarUniforme()
        {
            frmUniformeSelecao frm = new frmUniformeSelecao(true);
            DialogResult dialogResult = frm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                uniformePedido = frm.uniformeSelecao;

                txtUsuarioId.Text = uniformePedido.UniformeId.ToString();
                txtDescricao.Text = uniformePedido.Descricao;

                //Comando para colocar em campo em Foco
                //No caso após selecionar o Produto o campo Quantidade
                //irá receber o foco, para que o usuario informe a quantidade
                //sem precisar clicar no campo ou apertat TAB para chegar ao campo
                txtQuantidadeItem.Focus();
            }
        }

        private void AtualizarGrade(int pedidoId)
        {
            //Limpo os uniformes exibidos no DataGridView e
            //recupero todos os uniformes do pedido.
            //É preciso sempre carregar os produtos do banco de dados
            //para garantir que os uniformes apresentados em tela
            //foram realmente gravados do banco de dados.
            dgvPedidoItens.DataSource = null;
            dgvPedidoItens.DataSource = pedidoItemController.GetByPedido(pedidoId);
            dgvPedidoItens.Update();
            dgvPedidoItens.Refresh();
        }

        private void AdicionarItem()
        {
            //Se nenhum usuario foi selecionado, dá uma mensagem,
            //coloca o foco no botão de pesquisa de usuario e
            //para o fluxo (utilizando o "return").
            if (usuarioPedido == null)
            {
                MessageBox.Show("É necessário selecionar o usuário.", "Atenção...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnPesquisarUsuario.Focus();
                return;
            }

            if (uniformePedido == null)
            {
                MessageBox.Show("É necessário selecionar o uniforme.", "Atenção...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnPesquisarUniforme.Focus();
                return;
            }

            int quantidade = 0;
            //Só permite quantidade maior que zero e menor que 99.
            if (int.TryParse(txtQuantidadeItem.Text, out quantidade) && (quantidade > 0) && (quantidade <= 99))
            {
                //Se esse for o primeiro uniforme inserido, então
                //eu ainda não terei um pedido gravado. Portanto,
                //Eu crio um novo pedido e insiro no banco de dados.
                if (pedido == null)
                {
                    pedido = new Pedido();
                    pedido.Usuario = usuarioPedido;
                    pedido.DtHora = DateTime.Now;

                    //Defino o status do pedido como P de Pendente
                    pedido.Status = 'P';

                    //Insiro um registro inicial no banco de dados
                    //e recupero ID para apresentar na tela
                    pedido.PedidoId = pedidoController.Inserir(pedido);

                    txtPedidoId.Text = pedido.PedidoId.ToString();
                    txtDataHora.Text = pedido.DtHora.ToString();
                }

                //Crio e populo um novo pedidoItem.
                PedidoItem pedidoItem = new PedidoItem();
                pedidoItem.Pedido = pedido;
                pedidoItem.Uniforme = uniformePedido;
                pedidoItem.Quantidade = quantidade;

                //Insiro no banco de dados.
                //e valido se o registro foi inserido com sucesso

                if (pedidoItemController.Inserir(pedidoItem) > 0)
                {
                    AtualizarGrade(pedido.PedidoId);

                    //Limpo a variável do produto que eu havia selecionado
                    //e limpo os campos da tela.
                    uniformePedido = null;
                    txtUniformeId.Clear();
                    txtDescricao.Clear();
                    txtQuantidadeItem.Text = "1";
                }
                else
                {
                    MessageBox.Show("Falha ao inserir uniforme!", "Atenção...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnPesquisarUniforme.Focus();
                }

            }
            else
            {
                MessageBox.Show("A quantidade deve ser um número inteiro, maior que 0 (zero) e menor ou igual a 99.", "Atenção...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantidadeItem.Focus();
            }
        }

        PedidoItem GetPedidoItem()
        {
            if (dgvPedidoItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum registro selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            else
                return (dgvPedidoItens.SelectedRows[0].DataBoundItem as PedidoItem);

        }

        private void RemoverItem()
        {
            PedidoItem itemSelecionado = GetPedidoItem();

            if (itemSelecionado == null)
                return;

            if (MessageBox.Show("Deseja realmente remover este uniforme?", "Confirmação...",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //Recupero o ID do item do pedido diretamente do objeto guardado
                //no DataGridView e apago ele.
                pedidoItemController.Excluir(pedido.PedidoId, itemSelecionado.PedidoItemId);
                AtualizarGrade(pedido.PedidoId);
            }
        }

        private void FinalizarPedido()
        {
            if (pedido != null)
            {
                if (MessageBox.Show("Deseja realmente Finalizar este pedido?", "Confirmação...",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //Como todos os dados da Venda ja foram gravados no banco de dados
                    //Enquanto o pedido foi sendo montado.
                    //Eu apenos atualizo o status do pedido para F de Finalizado
                    if (pedidoController.AlterarStatus(pedido.PedidoId, 'F') > 0)
                    {
                        MessageBox.Show("Pedido finalizado com sucesso.", "Informação...",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Após finalizado com sucesso limpo todos os objetos e campos da tela.
                        LimparTela();
                    }
                    else
                        MessageBox.Show("O Pedido não foi encontrado no banco de dados.", "Atenção...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("Nenhum Pedido criado para ser Finalizado.", "Atenção...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CancelarPedido()
        {
            if (pedido != null)
            {
                if (MessageBox.Show("Deseja realmente Cancelar este pedido?", "Confirmação...",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (pedidoController.AlterarStatus(pedido.PedidoId, 'C') > 0)
                    {
                        MessageBox.Show("Pedido cancelado com sucesso.", "Informação...",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparTela();
                    }
                    else
                        MessageBox.Show("O Pedido não foi encontrado no banco de dados.", "Atenção...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("Nenhum Pedido criado para ser Cancelado.", "Atenção...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void LimparTela()
        {
            usuarioPedido = null;
            uniformePedido = null;
            pedido = null;

            txtUsuarioId.Clear();
            txtNomeUsuario.Clear();
            txtPedidoId.Clear();
            txtDataHora.Clear();
            txtUniformeId.Clear();
            txtDescricao.Clear();
            txtQuantidadeItem.Text = "1";
            dgvPedidoItens.DataSource = null;
            btnPesquisarUsuario.Focus();
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            AdicionarItem();
        }

        private void btnRemoverItem_Click(object sender, EventArgs e)
        {
            RemoverItem();
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            CancelarPedido();
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            FinalizarPedido();
        }

        private void btnFecharTela_Click(object sender, EventArgs e)
        {
            if (pedido == null)
                Close();
            else
                CancelarPedido();
        }

        private void btnPesquisarUsuario_Click(object sender, EventArgs e)
        {
            PesquisarUsuario();
        }

        private void btnPesquisarUniforme_Click(object sender, EventArgs e)
        {
            PesquisarUniforme();
        }
    }
}
