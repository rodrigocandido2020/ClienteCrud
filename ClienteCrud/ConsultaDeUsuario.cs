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
            try
            {
                var cadastroDeUsuario = new CadastroDeUsuario(null);
                var resultado = cadastroDeUsuario.ShowDialog(this);
                var UsuarioId = cadastroDeUsuario.Usuario.Id + 1;

                if (resultado == DialogResult.OK)
                {
                    if (ListaDeUsuario.Instancia.Count == 0)
                    {
                        cadastroDeUsuario.Usuario.Id = UsuarioId;

                    }
                    else
                    {
                        var promixoId = ListaDeUsuario.Instancia.Last().Id + 1;
                        cadastroDeUsuario.Usuario.Id = promixoId;
                    }
                    ListaDeUsuario.Instancia.Add(cadastroDeUsuario.Usuario);
                    listaClienteGrid.DataSource = null;
                    listaClienteGrid.DataSource = ListaDeUsuario.Instancia;
                    listaClienteGrid.Columns["Senha"].Visible = false;
                }
            }
            catch (Exception)
            {
                MostraMensagem("Erro inesperado entrar em contato com administrador do sistema");
                return;
            }                        
        }
        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            try
            {
                if (ListaDeUsuario.Instancia.Count == 0)
                {
                    MostraMensagem("Não existe Usuario criado para Editar");
                }
                else
                { 
                    var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario;
                    var cadastroDeUsuario = new CadastroDeUsuario(usuarioSelecionado);
                    var resultado = cadastroDeUsuario.ShowDialog(this);
                }
            }
            catch (Exception)
            {
                MostraMensagem("Erro inesperado entrar em contato com administrador do sistema");
                return;
            }
            listaClienteGrid.DataSource = null;
            listaClienteGrid.DataSource = ListaDeUsuario.Instancia;
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
            try
            {
                if (ListaDeUsuario.Instancia.Count == 0)
                {
                    MostraMensagem("Não existe Usuario criado para excluir");
                }
                else
                {
                    var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario;
                    if (DeveRemoverUusario())
                    {
                        ListaDeUsuario.Instancia.Remove(usuarioSelecionado);
                    }
                    listaClienteGrid.DataSource = null;
                    listaClienteGrid.DataSource = ListaDeUsuario.Instancia;
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
