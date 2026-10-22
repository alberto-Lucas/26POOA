namespace ProjetoExemploCerto.Views
{
    partial class frmPrincipal
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uniformesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerencialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitarUniformesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.históricoDePedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 426);
            this.label1.TabIndex = 4;
            this.label1.Text = "MVC-System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.gerencialToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuáriosToolStripMenuItem,
            this.uniformesToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // usuáriosToolStripMenuItem
            // 
            this.usuáriosToolStripMenuItem.Name = "usuáriosToolStripMenuItem";
            this.usuáriosToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.usuáriosToolStripMenuItem.Text = "Usuários";
            this.usuáriosToolStripMenuItem.Click += new System.EventHandler(this.usuáriosToolStripMenuItem_Click);
            // 
            // uniformesToolStripMenuItem
            // 
            this.uniformesToolStripMenuItem.Name = "uniformesToolStripMenuItem";
            this.uniformesToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.uniformesToolStripMenuItem.Text = "Uniformes";
            this.uniformesToolStripMenuItem.Click += new System.EventHandler(this.uniformesToolStripMenuItem_Click);
            // 
            // gerencialToolStripMenuItem
            // 
            this.gerencialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solicitarUniformesToolStripMenuItem,
            this.históricoDePedidosToolStripMenuItem});
            this.gerencialToolStripMenuItem.Name = "gerencialToolStripMenuItem";
            this.gerencialToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.gerencialToolStripMenuItem.Text = "Gerencial";
            // 
            // solicitarUniformesToolStripMenuItem
            // 
            this.solicitarUniformesToolStripMenuItem.Name = "solicitarUniformesToolStripMenuItem";
            this.solicitarUniformesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.solicitarUniformesToolStripMenuItem.Text = "Solicitar Uniformes";
            this.solicitarUniformesToolStripMenuItem.Click += new System.EventHandler(this.solicitarUniformesToolStripMenuItem_Click);
            // 
            // históricoDePedidosToolStripMenuItem
            // 
            this.históricoDePedidosToolStripMenuItem.Name = "históricoDePedidosToolStripMenuItem";
            this.históricoDePedidosToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.históricoDePedidosToolStripMenuItem.Text = "Histórico de Pedidos";
            this.históricoDePedidosToolStripMenuItem.Click += new System.EventHandler(this.históricoDePedidosToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmPrincipal";
            this.Text = "MCV-System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uniformesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerencialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitarUniformesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem históricoDePedidosToolStripMenuItem;
    }
}