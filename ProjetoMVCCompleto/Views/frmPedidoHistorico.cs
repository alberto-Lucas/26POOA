using ProjetoExemploCerto.Controllers;
using ProjetoExemploCerto.Models;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ProjetoExemploCerto.Views
{
    public partial class frmPedidoHistorico : Form
    {
        public frmPedidoHistorico()
        {
            InitializeComponent();
            dgvRegistros.AutoGenerateColumns = false;
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

        private void dgvRegistros_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //Tratamento especial para exibir as propriedades que estão dentro de outras propriedades.
                //É esse evento que chama o método "CarregarPropriedade", mas somente se a propriedade
                //possuir o ponto final.
                if ((dgvRegistros.Rows[e.RowIndex].DataBoundItem != null) &&
                    (dgvRegistros.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
                {
                    e.Value = CarregarPropriedade(dgvRegistros.Rows[e.RowIndex].DataBoundItem,
                        dgvRegistros.Columns[e.ColumnIndex].DataPropertyName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void Pesquisar()
        {
            int id = 0;

            PedidoController pedidoController = new PedidoController();
            PedidoCollection pedidoCollection = new PedidoCollection();

            dgvRegistros.DataSource = null;

            switch (cbxFiltro.SelectedIndex)
            {
                case 0:
                    pedidoCollection = pedidoController.GetByPeriodo(dtpInicial.Value, dtpFinal.Value);
                    break;
                case 1:
                    {
                        if (int.TryParse(txtCodigo.Text, out id))
                            pedidoCollection = pedidoController.GetByUsuario(id);
                    }
                    break;
                case 2:
                    {
                        if (int.TryParse(txtCodigo.Text, out id))
                            pedidoCollection = pedidoController.GetByPedidoId(id);
                    }
                    break;
                case 3:
                    {
                        string status = "";
                        switch (cbxStatus.SelectedIndex)
                        {
                            case 0:
                                status = "F";
                                break;
                            case 1:
                                status = "P";
                                break;
                            case 2:
                                status = "C";
                                break;
                        }

                        pedidoCollection = pedidoController.GetByStatus(status);
                    }
                    break;
                case 4:
                    pedidoCollection = pedidoController.GetAll();
                    break;
            }

            dgvRegistros.DataSource = pedidoCollection;
            dgvRegistros.Update();
            dgvRegistros.Refresh();
        }

        private Pedido GetRegistro()
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum registro selecionado.", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            else
            {
                return dgvRegistros.SelectedRows[0].DataBoundItem as Pedido;
            }
        }

        private void ChamarTelaVisualizacao()
        {
            Pedido pedidoSelecionado = GetRegistro();
            if (pedidoSelecionado != null)
            {
                frmPedidoDetalhes frm = new frmPedidoDetalhes(pedidoSelecionado);
                frm.ShowDialog();
            }
        }

        private void AlterarStatus(bool IsFinalizar)
        {
            Pedido pedidoSelecionado = GetRegistro();

            string statusTratado = IsFinalizar ? "Finalizar" : "Cancelar";
            string statusRetorno = IsFinalizar ? "Finalizado" : "Cancelado";
            char status = IsFinalizar ? 'F' : 'C';

            if (pedidoSelecionado != null)
            {
                if (pedidoSelecionado.Status != 'P')
                    MessageBox.Show("Não é possível "+ statusTratado + " um registro "+ statusTratado + ".", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    PedidoController pedidoController = new PedidoController();

                    if (MessageBox.Show("Deseja realmente "+ statusTratado + " este pedido?", "Confirmação...",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        if (pedidoController.AlterarStatus(pedidoSelecionado.PedidoId, status) > 0)
                        {
                            MessageBox.Show("Pedido "+ statusTratado + " com sucesso.", "Informação...",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Pesquisar();
                        }
                        else
                            MessageBox.Show("O Pedido não foi encontrado no banco de dados.", "Atenção...",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void Excluir()
        {
            Pedido pedidoSelecionado = GetRegistro();

            if (pedidoSelecionado != null)
            {
                if (pedidoSelecionado.Status != 'P')
                    MessageBox.Show("Não é possível excluir um registro "+pedidoSelecionado.StatusTratado+".", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (MessageBox.Show("Deseja realmente excluir o registro?", "Confirmação",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        PedidoController pedidoController = new PedidoController();

                        if (pedidoController.Excluir(pedidoSelecionado.PedidoId) > 0)
                        {
                            MessageBox.Show("Registro excluído com sucesso.", "Informação",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Pesquisar();
                        }
                        else
                            MessageBox.Show("Não foi possível excluir o regsitro.", "Atenção",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void cbxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AjustarFiltros();
        }

        private void OcultarFiltroTodos()
        {
            pnlPeriodo.Visible = false;
            cbxStatus.Visible = false;
            txtCodigo.Visible = false;
            lblFiltro.Visible = false;
        }

        private void AjustarFiltros()
        {
            OcultarFiltroTodos();

            lblFiltro.Visible = true;
            switch (cbxFiltro.SelectedIndex)
            {
                case 0:
                    {
                        lblFiltro.Text = "Período";
                        pnlPeriodo.Visible = true;
                    }
                    break;
                case 1:
                case 2:
                    {
                        lblFiltro.Text = "Código";
                        txtCodigo.Visible = true;
                    }
                    break;
                case 3:
                    {
                        lblFiltro.Text = "Status";
                        cbxStatus.Visible = true;
                    }
                    break;
                case 4:
                    lblFiltro.Visible = false;
                    break;
            }
        }

        private void frmPedidoHistorico_Load(object sender, EventArgs e)
        {
            Pesquisar();
            OcultarFiltroTodos();
            cbxFiltro.SelectedIndex = 4;
            cbxStatus.SelectedIndex = 1;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            AlterarStatus(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AlterarStatus(false);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            ChamarTelaVisualizacao();
        }
    }
}
