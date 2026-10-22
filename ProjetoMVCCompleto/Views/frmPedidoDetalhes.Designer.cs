namespace ProjetoExemploCerto.Views
{
    partial class frmPedidoDetalhes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbItensPedido = new System.Windows.Forms.GroupBox();
            this.dgvPedidoItens = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataHora = new System.Windows.Forms.TextBox();
            this.txtPedidoId = new System.Windows.Forms.TextBox();
            this.grbDadosPedido = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuarioId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeUsuario = new System.Windows.Forms.TextBox();
            this.grbDadosUsuario = new System.Windows.Forms.GroupBox();
            this.grbItensPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoItens)).BeginInit();
            this.grbDadosPedido.SuspendLayout();
            this.grbDadosUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // Quantidade
            // 
            this.Quantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.Quantidade.DefaultCellStyle = dataGridViewCellStyle4;
            this.Quantidade.HeaderText = "Qtd.";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.Width = 70;
            // 
            // IdProduto
            // 
            this.IdProduto.DataPropertyName = "Uniforme.UniformeId";
            this.IdProduto.HeaderText = "Código";
            this.IdProduto.Name = "IdProduto";
            this.IdProduto.ReadOnly = true;
            this.IdProduto.Width = 80;
            // 
            // DescricaoProduto
            // 
            this.DescricaoProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DescricaoProduto.DataPropertyName = "Uniforme.Descricao";
            this.DescricaoProduto.HeaderText = "Descrição";
            this.DescricaoProduto.Name = "DescricaoProduto";
            this.DescricaoProduto.ReadOnly = true;
            // 
            // grbItensPedido
            // 
            this.grbItensPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbItensPedido.Controls.Add(this.dgvPedidoItens);
            this.grbItensPedido.Controls.Add(this.label3);
            this.grbItensPedido.Location = new System.Drawing.Point(13, 219);
            this.grbItensPedido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbItensPedido.Name = "grbItensPedido";
            this.grbItensPedido.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbItensPedido.Size = new System.Drawing.Size(622, 254);
            this.grbItensPedido.TabIndex = 15;
            this.grbItensPedido.TabStop = false;
            this.grbItensPedido.Text = "Itens do pedido";
            // 
            // dgvPedidoItens
            // 
            this.dgvPedidoItens.AllowUserToAddRows = false;
            this.dgvPedidoItens.AllowUserToDeleteRows = false;
            this.dgvPedidoItens.AllowUserToOrderColumns = true;
            this.dgvPedidoItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPedidoItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProduto,
            this.DescricaoProduto,
            this.Quantidade});
            this.dgvPedidoItens.Location = new System.Drawing.Point(9, 43);
            this.dgvPedidoItens.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvPedidoItens.MultiSelect = false;
            this.dgvPedidoItens.Name = "dgvPedidoItens";
            this.dgvPedidoItens.RowHeadersVisible = false;
            this.dgvPedidoItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidoItens.Size = new System.Drawing.Size(604, 201);
            this.dgvPedidoItens.TabIndex = 7;
            this.dgvPedidoItens.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPedidoItens_CellFormatting);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Uniforme";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "ID Pedido";
            // 
            // txtDataHora
            // 
            this.txtDataHora.Location = new System.Drawing.Point(117, 48);
            this.txtDataHora.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDataHora.Name = "txtDataHora";
            this.txtDataHora.ReadOnly = true;
            this.txtDataHora.Size = new System.Drawing.Size(176, 20);
            this.txtDataHora.TabIndex = 7;
            this.txtDataHora.TabStop = false;
            // 
            // txtPedidoId
            // 
            this.txtPedidoId.Location = new System.Drawing.Point(14, 48);
            this.txtPedidoId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPedidoId.Name = "txtPedidoId";
            this.txtPedidoId.ReadOnly = true;
            this.txtPedidoId.Size = new System.Drawing.Size(92, 20);
            this.txtPedidoId.TabIndex = 5;
            this.txtPedidoId.TabStop = false;
            // 
            // grbDadosPedido
            // 
            this.grbDadosPedido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDadosPedido.Controls.Add(this.txtDataHora);
            this.grbDadosPedido.Controls.Add(this.txtPedidoId);
            this.grbDadosPedido.Controls.Add(this.label4);
            this.grbDadosPedido.Controls.Add(this.label5);
            this.grbDadosPedido.Location = new System.Drawing.Point(13, 14);
            this.grbDadosPedido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbDadosPedido.Name = "grbDadosPedido";
            this.grbDadosPedido.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbDadosPedido.Size = new System.Drawing.Size(622, 85);
            this.grbDadosPedido.TabIndex = 14;
            this.grbDadosPedido.TabStop = false;
            this.grbDadosPedido.Text = "Dados do Pedido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data/Hora";
            // 
            // txtUsuarioId
            // 
            this.txtUsuarioId.Location = new System.Drawing.Point(14, 48);
            this.txtUsuarioId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuarioId.Name = "txtUsuarioId";
            this.txtUsuarioId.ReadOnly = true;
            this.txtUsuarioId.Size = new System.Drawing.Size(52, 20);
            this.txtUsuarioId.TabIndex = 1;
            this.txtUsuarioId.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuário";
            // 
            // txtNomeUsuario
            // 
            this.txtNomeUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeUsuario.Location = new System.Drawing.Point(76, 48);
            this.txtNomeUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNomeUsuario.Name = "txtNomeUsuario";
            this.txtNomeUsuario.ReadOnly = true;
            this.txtNomeUsuario.Size = new System.Drawing.Size(537, 20);
            this.txtNomeUsuario.TabIndex = 2;
            this.txtNomeUsuario.TabStop = false;
            // 
            // grbDadosUsuario
            // 
            this.grbDadosUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDadosUsuario.Controls.Add(this.txtUsuarioId);
            this.grbDadosUsuario.Controls.Add(this.label1);
            this.grbDadosUsuario.Controls.Add(this.txtNomeUsuario);
            this.grbDadosUsuario.Location = new System.Drawing.Point(13, 109);
            this.grbDadosUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbDadosUsuario.Name = "grbDadosUsuario";
            this.grbDadosUsuario.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbDadosUsuario.Size = new System.Drawing.Size(622, 100);
            this.grbDadosUsuario.TabIndex = 13;
            this.grbDadosUsuario.TabStop = false;
            this.grbDadosUsuario.Text = "Dados do Usuário";
            // 
            // frmPedidoDetalhes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 487);
            this.Controls.Add(this.grbItensPedido);
            this.Controls.Add(this.grbDadosPedido);
            this.Controls.Add(this.grbDadosUsuario);
            this.Name = "frmPedidoDetalhes";
            this.Text = "frmPedidoDetalhes";
            this.Load += new System.EventHandler(this.frmPedidoDetalhes_Load);
            this.grbItensPedido.ResumeLayout(false);
            this.grbItensPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoItens)).EndInit();
            this.grbDadosPedido.ResumeLayout(false);
            this.grbDadosPedido.PerformLayout();
            this.grbDadosUsuario.ResumeLayout(false);
            this.grbDadosUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoProduto;
        private System.Windows.Forms.GroupBox grbItensPedido;
        private System.Windows.Forms.DataGridView dgvPedidoItens;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataHora;
        private System.Windows.Forms.TextBox txtPedidoId;
        private System.Windows.Forms.GroupBox grbDadosPedido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuarioId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeUsuario;
        private System.Windows.Forms.GroupBox grbDadosUsuario;
    }
}