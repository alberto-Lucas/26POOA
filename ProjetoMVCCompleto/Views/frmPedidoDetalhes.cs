using ProjetoExemploCerto.Controllers;
using ProjetoExemploCerto.Models;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ProjetoExemploCerto.Views
{
    public partial class frmPedidoDetalhes : Form
    {
        Pedido pedidoSelecionado;
        PedidoItemController pedidoItemController = new PedidoItemController();

        public frmPedidoDetalhes(Pedido pedido)
        {
            InitializeComponent();
            dgvPedidoItens.AutoGenerateColumns = false;

            pedidoSelecionado = pedido;
        }

        private void frmPedidoDetalhes_Load(object sender, System.EventArgs e)
        {
            CarregarDadosPedidos();
            CarregarItens();
        }
        #region CarregarPropriedade
        private object CarregarPropriedade(object propriedade, string nomeDaPropriedade)
        {
            try
            {
                object retorno = "";

                if (nomeDaPropriedade.Contains("."))
                {
                    PropertyInfo[] propertyInfoArray;
                    string propriedadeAntesDoPonto;

                    propriedadeAntesDoPonto = nomeDaPropriedade.Substring(0, nomeDaPropriedade.IndexOf("."));

                    if (propriedade != null)
                    {
                        propertyInfoArray = propriedade.GetType().GetProperties();

                        foreach (PropertyInfo propertyInfo in propertyInfoArray)
                        {
                            if (propertyInfo.Name == propriedadeAntesDoPonto)
                            {
                                retorno = CarregarPropriedade(propertyInfo.GetValue(propriedade, null),
                                    nomeDaPropriedade.Substring(nomeDaPropriedade.IndexOf(".") + 1));
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Type typeProperty;
                    PropertyInfo propertyInfo;

                    if (propriedade != null)
                    {
                        typeProperty = propriedade.GetType();
                        propertyInfo = typeProperty.GetProperty(nomeDaPropriedade);
                        retorno = propertyInfo.GetValue(propriedade, null);
                    }
                }
                return retorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private void dgvPedidoItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((dgvPedidoItens.Rows[e.RowIndex].DataBoundItem != null) &&
                    (dgvPedidoItens.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
                {
                    e.Value = CarregarPropriedade(dgvPedidoItens.Rows[e.RowIndex].DataBoundItem,
                        dgvPedidoItens.Columns[e.ColumnIndex].DataPropertyName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void CarregarDadosPedidos()
        {
            txtUsuarioId.Text = pedidoSelecionado.Usuario.UsuarioId.ToString();
            txtNomeUsuario.Text = pedidoSelecionado.Usuario.Nome;
            txtPedidoId.Text = pedidoSelecionado.PedidoId.ToString();
            txtDataHora.Text = pedidoSelecionado.DtHora.ToShortDateString();
        }

        private void CarregarItens()
        {
            dgvPedidoItens.DataSource = null;
            dgvPedidoItens.DataSource = pedidoItemController.GetByPedido(pedidoSelecionado.PedidoId);
            dgvPedidoItens.Update();
            dgvPedidoItens.Refresh();
        }

    }
}
