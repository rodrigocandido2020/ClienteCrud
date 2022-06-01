using System;
using System.Linq;
using System.Windows.Forms;

namespace ClienteCrud
{
    public partial class ConsultaDePessoa : Form
    {
        public ConsultaDePessoa()
        {
            InitializeComponent();
        }
        public void AoClicarEmAdicionar(object sender, EventArgs e)
        {
            var repositorio = new UsuarioRepositorio();

            try
            {
                var cadastroDeUsuario = new CadastroDeUsuario(null);
                var resultado = cadastroDeUsuario.ShowDialog();
                var listaDeUsuarios = ListaDeUsuario.Instancia();
                if(resultado == DialogResult.OK)
                {
                    repositorio.AdicionarUsuario(cadastroDeUsuario.Usuario);
                }
                listaClienteGrid.DataSource = null;
                listaClienteGrid.DataSource = repositorio.ObterTodos();
                listaClienteGrid.Columns["Senha"].Visible = false;
            }
            catch (Exception)
            {
                MostraMensagem("Erro inesperado entrar em contato com administrador do sistema");
                return;
            }                        
        }
        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            var repositorio = new UsuarioRepositorio();
            try
            {
                if (repositorio.ObterTodos().Count == 0)
                {
                    MostraMensagem("Não existe Usuario criado para Editar");
                }
                else
                { 
                    var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario;
                    var usuario = repositorio.ObterPorId(usuarioSelecionado.Id);
                    var cadastroDeUsuario = new CadastroDeUsuario(usuario);
                    repositorio.editarUsuario(cadastroDeUsuario.Usuario);
                    cadastroDeUsuario.ShowDialog(this);
                }
            }
            catch (Exception)
            {
                MostraMensagem("Erro inesperado entrar em contato com administrador do sistema");
                return;
            }
            listaClienteGrid.DataSource = null;
            listaClienteGrid.DataSource = ListaDeUsuario.Instancia();
            listaClienteGrid.Columns["Senha"].Visible = false;
        }
        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            try
            {
                if (DeveSairDoSistema())
                {
                    this.Close();
                }

            }
            catch (Exception)
            {
                MostraMensagem("Erro inesperado entrar em contato com administrador do sistema");
                return;
            }                
        }

        private bool DeveSairDoSistema()
        {
            return MessageBox.Show("Tem certeza que deseja sair da aplicação?", "Sair", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes;
        }
        private void AoClicarEmOk(object sender, EventArgs e)
        {
            try
            {
                if (DeveSairDoSistema())
                {
                    this.Close();
                }
            }
            catch (Exception)
            {
                MostraMensagem("Erro inesperado entrar em contato com administrador do sistema");
                return;
            }        
        }
        private void AoClicarEmRemover(object sender, EventArgs e)
        {
            var repositorio = new UsuarioRepositorio();

            try
            {
                if (ListaDeUsuario.Instancia().Count == 0)
                {
                    MostraMensagem("Não existe Usuario criado para excluir");
                }
                else
                {
                    var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario;
                    if (DeveRemoverUusario())
                    {
                        repositorio.RemoverUsuario(usuarioSelecionado);
                    }
                    listaClienteGrid.DataSource = null;
                    listaClienteGrid.DataSource = repositorio.ObterTodos();
                    listaClienteGrid.Columns["Senha"].Visible = false;
                }               
            }
            catch (Exception ex)
            {
                MostraMensagem($"Erro inesperado entrar em contato com administrador do sistema \n {ex.Message}");
            }
        }
        private bool DeveRemoverUusario ()
        {
           return MessageBox.Show("Tem certeza que deseja remover o Usuario selecionado?", "Apagar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;

        }
        private void MostraMensagem(string mensagem)
        {
          MessageBox.Show(mensagem);
        }
    } 
}
