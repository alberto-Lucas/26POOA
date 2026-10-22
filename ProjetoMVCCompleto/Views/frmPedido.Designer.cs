namespace ProjetoExemploCerto.Views
{
    partial class frmPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbDadosUsuario = new System.Windows.Forms.GroupBox();
            this.txtUsuarioId = new System.Windows.Forms.TextBox();
            this.btnPesquisarUsuario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeUsuario = new System.Windows.Forms.TextBox();
            this.grbDadosPedido = new System.Windows.Forms.GroupBox();
            this.txtDataHora = new System.Windows.Forms.TextBox();
            this.txtPedidoId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grbItensPedido = new System.Windows.Forms.GroupBox();
            this.btnRemoverItem = new System.Windows.Forms.Button();
            this.dgvPedidoItens = new System.Windows.Forms.DataGridView();
            this.IdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantidadeItem = new System.Windows.Forms.TextBox();
            this.txtUniformeId = new System.Windows.Forms.TextBox();
            this.btnPesquisarUniforme = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnCancelarVenda = new System.Windows.Forms.Button();
            this.btnFinalizarVenda = new System.Windows.Forms.Button();
            this.btnFecharTela = new System.Windows.Forms.Button();
            this.grbDadosUsuario.SuspendLayout();
            this.grbDadosPedido.SuspendLayout();
            this.grbItensPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoItens)).BeginInit();
            this.SuspendLayout();
            // 
            // grbDadosUsuario
            // 
            this.grbDadosUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDadosUsuario.Controls.Add(this.txtUsuarioId);
            this.grbDadosUsuario.Controls.Add(this.btnPesquisarUsuario);
            this.grbDadosUsuario.Controls.Add(this.label1);
            this.grbDadosUsuario.Controls.Add(this.txtNomeUsuario);
            this.grbDadosUsuario.Location = new System.Drawing.Point(13, 109);
            this.grbDadosUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbDadosUsuario.Name = "grbDadosUsuario";
            this.grbDadosUsuario.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbDadosUsuario.Size = new System.Drawing.Size(807, 100);
            this.grbDadosUsuario.TabIndex = 6;
            this.grbDadosUsuario.TabStop = false;
            this.grbDadosUsuario.Text = "Dados do Usuário";
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
            // btnPesquisarUsuario
            // 
            this.btnPesquisarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPesquisarUsuario.Location = new System.Drawing.Point(753, 48);
            this.btnPesquisarUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPesquisarUsuario.Name = "btnPesquisarUsuario";
            this.btnPesquisarUsuario.Size = new System.Drawing.Size(42, 29);
            this.btnPesquisarUsuario.TabIndex = 3;
            this.btnPesquisarUsuario.Text = "...";
            this.btnPesquisarUsuario.UseVisualStyleBackColor = true;
            this.btnPesquisarUsuario.Click += new System.EventHandler(this.btnPesquisarUsuario_Click);
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
            this.txtNomeUsuario.Size = new System.Drawing.Size(669, 20);
            this.txtNomeUsuario.TabIndex = 2;
            this.txtNomeUsuario.TabStop = false;
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
            this.grbDadosPedido.Size = new System.Drawing.Size(807, 85);
            this.grbDadosPedido.TabIndex = 8;
            this.grbDadosPedido.TabStop = false;
            this.grbDadosPedido.Text = "Dados do Pedido";
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
            // grbItensPedido
            // 
            this.grbItensPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbItensPedido.Controls.Add(this.btnRemoverItem);
            this.grbItensPedido.Controls.Add(this.dgvPedidoItens);
            this.grbItensPedido.Controls.Add(this.btnAdicionarItem);
            this.grbItensPedido.Controls.Add(this.label2);
            this.grbItensPedido.Controls.Add(this.txtQuantidadeItem);
            this.grbItensPedido.Controls.Add(this.txtUniformeId);
            this.grbItensPedido.Controls.Add(this.btnPesquisarUniforme);
            this.grbItensPedido.Controls.Add(this.label3);
            this.grbItensPedido.Controls.Add(this.txtDescricao);
            this.grbItensPedido.Location = new System.Drawing.Point(13, 219);
            this.grbItensPedido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbItensPedido.Name = "grbItensPedido";
            this.grbItensPedido.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbItensPedido.Size = new System.Drawing.Size(807, 431);
            this.grbItensPedido.TabIndex = 9;
            this.grbItensPedido.TabStop = false;
            this.grbItensPedido.Text = "Itens do pedido";
            // 
            // btnRemoverItem
            // 
            this.btnRemoverItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverItem.Location = new System.Drawing.Point(684, 383);
            this.btnRemoverItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemoverItem.Name = "btnRemoverItem";
            this.btnRemoverItem.Size = new System.Drawing.Size(112, 35);
            this.btnRemoverItem.TabIndex = 10;
            this.btnRemoverItem.Text = "Remover";
            this.btnRemoverItem.UseVisualStyleBackColor = true;
            this.btnRemoverItem.Click += new System.EventHandler(this.btnRemoverItem_Click);
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
            this.dgvPedidoItens.Location = new System.Drawing.Point(9, 91);
            this.dgvPedidoItens.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvPedidoItens.MultiSelect = false;
            this.dgvPedidoItens.Name = "dgvPedidoItens";
            this.dgvPedidoItens.RowHeadersVisible = false;
            this.dgvPedidoItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidoItens.Size = new System.Drawing.Size(789, 282);
            this.dgvPedidoItens.TabIndex = 7;
            this.dgvPedidoItens.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPedidoItens_CellFormatting);
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
            // Quantidade
            // 
            this.Quantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.Quantidade.DefaultCellStyle = dataGridViewCellStyle2;
            this.Quantidade.HeaderText = "Qtd.";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.Width = 70;
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionarItem.Location = new System.Drawing.Point(697, 49);
            this.btnAdicionarItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(100, 29);
            this.btnAdicionarItem.TabIndex = 6;
            this.btnAdicionarItem.Text = "Adicionar";
            this.btnAdicionarItem.UseVisualStyleBackColor = true;
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(595, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantidade";
            // 
            // txtQuantidadeItem
            // 
            this.txtQuantidadeItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantidadeItem.Location = new System.Drawing.Point(600, 51);
            this.txtQuantidadeItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtQuantidadeItem.MaxLength = 2;
            this.txtQuantidadeItem.Name = "txtQuantidadeItem";
            this.txtQuantidadeItem.Size = new System.Drawing.Size(86, 20);
            this.txtQuantidadeItem.TabIndex = 5;
            this.txtQuantidadeItem.Text = "1";
            // 
            // txtUniformeId
            // 
            this.txtUniformeId.Location = new System.Drawing.Point(14, 51);
            this.txtUniformeId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUniformeId.Name = "txtUniformeId";
            this.txtUniformeId.ReadOnly = true;
            this.txtUniformeId.Size = new System.Drawing.Size(56, 20);
            this.txtUniformeId.TabIndex = 1;
            this.txtUniformeId.TabStop = false;
            // 
            // btnPesquisarUniforme
            // 
            this.btnPesquisarUniforme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPesquisarUniforme.Location = new System.Drawing.Point(551, 49);
            this.btnPesquisarUniforme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPesquisarUniforme.Name = "btnPesquisarUniforme";
            this.btnPesquisarUniforme.Size = new System.Drawing.Size(42, 29);
            this.btnPesquisarUniforme.TabIndex = 3;
            this.btnPesquisarUniforme.Text = "...";
            this.btnPesquisarUniforme.UseVisualStyleBackColor = true;
            this.btnPesquisarUniforme.Click += new System.EventHandler(this.btnPesquisarUniforme_Click);
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
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Location = new System.Drawing.Point(78, 51);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(466, 20);
            this.txtDescricao.TabIndex = 2;
            this.txtDescricao.TabStop = false;
            // 
            // btnCancelarVenda
            // 
            this.btnCancelarVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelarVenda.Location = new System.Drawing.Point(13, 660);
            this.btnCancelarVenda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelarVenda.Name = "btnCancelarVenda";
            this.btnCancelarVenda.Size = new System.Drawing.Size(170, 35);
            this.btnCancelarVenda.TabIndex = 12;
            this.btnCancelarVenda.Text = "Cancelar Pedido";
            this.btnCancelarVenda.UseVisualStyleBackColor = true;
            this.btnCancelarVenda.Click += new System.EventHandler(this.btnCancelarVenda_Click);
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizarVenda.Location = new System.Drawing.Point(518, 660);
            this.btnFinalizarVenda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(170, 35);
            this.btnFinalizarVenda.TabIndex = 10;
            this.btnFinalizarVenda.Text = "Finalizar Pedido";
            this.btnFinalizarVenda.UseVisualStyleBackColor = true;
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click);
            // 
            // btnFecharTela
            // 
            this.btnFecharTela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFecharTela.Location = new System.Drawing.Point(697, 660);
            this.btnFecharTela.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFecharTela.Name = "btnFecharTela";
            this.btnFecharTela.Size = new System.Drawing.Size(123, 35);
            this.btnFecharTela.TabIndex = 11;
            this.btnFecharTela.Text = "Fechar tela";
            this.btnFecharTela.UseVisualStyleBackColor = true;
            this.btnFecharTela.Click += new System.EventHandler(this.btnFecharTela_Click);
            // 
            // frmPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 709);
            this.Controls.Add(this.btnCancelarVenda);
            this.Controls.Add(this.btnFinalizarVenda);
            this.Controls.Add(this.btnFecharTela);
            this.Controls.Add(this.grbItensPedido);
            this.Controls.Add(this.grbDadosPedido);
            this.Controls.Add(this.grbDadosUsuario);
            this.Name = "frmPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitação de Uniformes";
            this.grbDadosUsuario.ResumeLayout(false);
            this.grbDadosUsuario.PerformLayout();
            this.grbDadosPedido.ResumeLayout(false);
            this.grbDadosPedido.PerformLayout();
            this.grbItensPedido.ResumeLayout(false);
            this.grbItensPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoItens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDadosUsuario;
        private System.Windows.Forms.TextBox txtUsuarioId;
        private System.Windows.Forms.Button btnPesquisarUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeUsuario;
        private System.Windows.Forms.GroupBox grbDadosPedido;
        private System.Windows.Forms.TextBox txtDataHora;
        private System.Windows.Forms.TextBox txtPedidoId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grbItensPedido;
        private System.Windows.Forms.Button btnRemoverItem;
        private System.Windows.Forms.DataGridView dgvPedidoItens;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantidadeItem;
        private System.Windows.Forms.TextBox txtUniformeId;
        private System.Windows.Forms.Button btnPesquisarUniforme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btnCancelarVenda;
        private System.Windows.Forms.Button btnFinalizarVenda;
        private System.Windows.Forms.Button btnFecharTela;
    }
}