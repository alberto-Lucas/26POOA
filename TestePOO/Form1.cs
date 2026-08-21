using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestePOO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            //Precisamos acesso a nossa classe Pessoa
            //primeiro precisamos instanciar a classe 
            //para trasnformar em objeto
            //o processo é dividido em 5 partes
            //1 - Nome da classe (tipo de dado)
            //2 - Nome do objeto (variavel)
            //3 - Operador de atribuição (=)
            //4 - Palavra reservada new
            //5 - Chamada do construtor da classe
            //Repete o nome da classe e adiciona parenteses
            //Ex: Pessoa()
            Pessoa pessoa = new Pessoa();
            //Para acessar os atributos da classe Pessoa,
            //usamos o operador ponto (.)
            //Ex: pessoa.Nome
            //agora iremos realizar o mapeamento da tela
            //preencher os atributos da classe
            //com os valores digitados na tela
            pessoa.Nome = txtNome.Text;
            pessoa.CPF = txtCPF.Text;
            pessoa.DtNascimento = dtpDtNascimento.Value;

            //Chamar o método exibir dados
            //e passar o objeto criado como parametro
            ExibirObjeto(pessoa);
        }

        //Criar um objeto para fazer o mapeamento reverso
        //recuperando o conteudo do objeto e
        //preenchendo os campos da tela
        //Ira receber o objeto como parametro
        //ao inves de passar os valores individualmente
        void ExibirObjeto(Pessoa pessoa)
        {
            //Mapeamento reverso
            txtNomeObj.Text = pessoa.Nome;
            txtCPFObj.Text = pessoa.CPF;
            txtDtNascimentoObj.Text = 
                pessoa.DtNascimento.ToShortDateString();

            lblBemVindo.Text = pessoa.BoasVindas();
            lblTexto.Text = pessoa.NomeCPF;
        }
    }
}
