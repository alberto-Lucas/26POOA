using ProjetoExemploCerto.Controllers;
using ProjetoExemploCerto.Models;
using System;
using System.Windows.Forms;

namespace ProjetoExemploCerto.Views
{
    public partial class frmUsuarioSelecao : Form
    {
        //Importar camadas Models e Controllers
        //using Nome_Porjeto.Models;
        //using Nome_Porjeto.Controllers;

        //Cirar instancia com a controller
        UsuarioController usuarioController = new UsuarioController();

        //Atributo público necessário para retornar
        //o cliente selecionado quando o usuário clicar
        //no botão "Selecionar".
        public Usuario usuarioSelecao;

        //O parâmetro "ExibirBotaoSelecionar" é necessário
        //para sabermos se o botão "Selecionar" deve ser
        //exibido ou não. O valor padrão dele é "false",
        //portanto, se quem chamar o construtor não passar
        //o valor "true", o botão não será exibido.
        public frmUsuarioSelecao(bool ExibirBotaoSelecionar = false)
        {
            InitializeComponent();

            //Essa linha é necessária para que o DataGridView não
            //crie as colunas de forma automática, exibindo todas
            //as propriedades do objeto. A intenção é nós definirmos
            //somente algumas colunas para serem exibidas.
            //Para adicionar as colunas, clique no DataGridView e clique
            //na setinha preta que aparece no canto superior direito dele.
            //Clique em Edit Column e adicione as colunas que desejar.
            //Após adicionar as colunas (e ainda na tela de edição de coluna)
            //selecione uma coluna e na propriedade "DataPropertyName" coloque
            //o nome da propriedade que você quer exibir naquela coluna (Nome, Telefone...).
            //O nome da propriedade precisa ser igual ao que existe na camada Models.
            //Comando para evitar da grid gerar os campos automaticamente
            //dgvRegistros.AutoGenerateColumns = false;

            btnSelecionar.Visible = ExibirBotaoSelecionar;
        }

        //Método para realizar a pesquisa no banco de dados
        void AtualizarGrid()
        {
            dgvRegistros.DataSource = null;
            //Aqui podemos chamar a consulta para retornar todos
            //dgvRegistros.DataSource = usuarioController.GetAll();
            //Aqui podemos chamar a consulta com filtro por nome
            //Passando o campo vazio, será retornado todos os registro
            dgvRegistros.DataSource = usuarioController.GetByName(txtNome.Text);
            //Atualizo a contagem de registros
            //com a quantidade de itens na grade
            lblRegistros.Text = "Registros encontrados: " + dgvRegistros.RowCount.ToString();
        }

        private void btnAdicionar_Click(object sender, System.EventArgs e)
        {
            //Chamo a tela de cadastro
            //Não passo nada via parametro
            //pois a trativa está na propria tela de cadastro
            //se me retorno for OK
            //ou seja cadastro realizado com sucesso
            //atualizo a grade
            frmUsuarioCadastro frm = new frmUsuarioCadastro();
            if (frm.ShowDialog() == DialogResult.OK)
                AtualizarGrid();
        }

        private void btnPesquisar_Click(object sender, System.EventArgs e)
        {
            AtualizarGrid();
        }

        Usuario GetUsuario()
        {
            //Valido se possui registros selecionados
            //Se sim retorno o item selecionado
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum usuário selecionado.", "Informação...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            else
                //Converto o item da grade em objeto e retorno
                return (dgvRegistros.SelectedRows[0].DataBoundItem as Usuario);

        }

        private void btnAlterar_Click(object sender, System.EventArgs e)
        {
            //Chamo a tela de cadastro no modo alteração
            //passando o objeto a ser exibido via parametro
            //e valido o retorno para atualizar a grade
            frmUsuarioCadastro frm = new frmUsuarioCadastro(2, GetUsuario());
            if (frm.ShowDialog() == DialogResult.OK)
                AtualizarGrid();
        }

        private void btnVisualizar_Click(object sender, System.EventArgs e)
        {
            //Chamo a tela de cadastro no modo visualização
            //passando o objeto a ser exibido via parametro
            //não precio validar o retorno
            frmUsuarioCadastro frm = new frmUsuarioCadastro(3, GetUsuario());
            frm.ShowDialog();
        }

        private void btnExcluir_Click(object sender, System.EventArgs e)
        {
            //Recupero o usuario selecionado
            Usuario usuarioSelecionado = GetUsuario();
            //Valido se está null
            if (usuarioSelecionado == null)
                return;

            //Confirmação para exclusão do registro
            if (MessageBox.Show(
                    "Deseja realmente excluir o registro?",
                    "Confirmação!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (usuarioController.Excluir(usuarioSelecionado.UsuarioId) > 0)
                {
                    MessageBox.Show(
                        "Cadastro excluido com sucesso!",
                        "Informação!", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    AtualizarGrid();
                }
                else
                    MessageBox.Show(
                        "Falha ao excluir o cadastro!",
                        "Atenção!", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            Selecionar();
        }

        private void Selecionar()
        {
            usuarioSelecao = GetUsuario();
            if (usuarioSelecao != null)
                this.DialogResult = DialogResult.OK;
        }
    }
}
