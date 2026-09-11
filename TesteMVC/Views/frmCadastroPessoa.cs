using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteMVC.Models;
using TesteMVC.Controllers;

namespace TesteMVC.Views
{
    //Primeiro é preciso importar as camdas
    //usgin TesteMVC.Controllers;
    //using TesteMVC.Models;
    public partial class frmCadastroPessoa : Form
    {
        //Criando a instancia da
        //classe de manutenção
        PessoaController pessoaController =
            new PessoaController();

        public frmCadastroPessoa()
        {
            InitializeComponent();
        }

        void AtulizarLista()
        {
            //Limpa a lista box
            lstRegistros.DataSource = null;

            //Preenche a listBox com a
            //lista de objetos
            lstRegistros.DataSource =
                pessoaController.ListarPessoas();

            //Define o atributo que sera exibido
            lstRegistros.DisplayMember = "NomeCPF";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();

            pessoa.Nome = txtNome.Text;
            pessoa.CPF = txtCPF.Text;

            pessoaController.Adicionar(pessoa);

            AtulizarLista();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Pessoa pessoaSelecionada;

            pessoaSelecionada = 
                lstRegistros.SelectedItem as Pessoa;

            pessoaController.Remover(pessoaSelecionada);

            AtulizarLista();
        }
    }
}
