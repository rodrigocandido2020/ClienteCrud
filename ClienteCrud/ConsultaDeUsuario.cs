using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ClienteCrud
{
    public partial class ConsultaDePessoa : Form
    {        
        public ConsultaDePessoa()
        {
            InitializeComponent();
            CarregarDados();
            
        }
        public void CarregarDados()
        {
            var repositorioComBanco = new UsuarioRepositorioComBanco();
            try
            {
                listaClienteGrid.DataSource = repositorioComBanco.ConverterDataTableParaUsuario();
            }
            catch (Exception ex)
            {
                MostraMensagem(ex.Message);
            }
            listaClienteGrid.Columns["Senha"].Visible = false;
            listaClienteGrid.Columns["NOME"].HeaderText = "Nome";
            listaClienteGrid.Columns["EMAIL"].HeaderText = "Email";
            listaClienteGrid.Columns["DATACRIACAO"].HeaderText = "Data criação";
            listaClienteGrid.Columns["DATANASCIMENTO"].HeaderText = "Data nascimento";
        }

        public void AoClicarEmAdicionar(object sender, EventArgs e)
        {
            var repositorio = new UsuarioRepositorioComBanco();
            var repositorioLista = new UsuarioRepositorio();

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
                CarregarDados();
                //listaClienteGrid.Columns["Senha"].Visible = false;
            }
            catch (Exception)
            {
                MostraMensagem("Erro inesperado entrar em contato com administrador do sistema");
                return;
            }                        
        }
        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            var repositorio = new UsuarioRepositorioComBanco();
            var repositorioLista = new UsuarioRepositorio();
            try
            {
                if (repositorio.ConverterDataTableParaUsuario().Count == 0)
                {
                    MostraMensagem("Não existe Usuario criado para Editar");
                }
                else
                { 
                    var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex;
                    var linhaSelecionada = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario;
                    var cadastroDeUsuario = new CadastroDeUsuario(linhaSelecionada);

                    var resultado = cadastroDeUsuario.ShowDialog(this);
                    repositorio.EditarUsuario(linhaSelecionada);

                }
            }
            catch (Exception)
            {
                MostraMensagem("Erro inesperado entrar em contato com administrador do sistema");
                return;
            }
            CarregarDados();
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
            var repositorio = new UsuarioRepositorioComBanco();
            var repositorioLista = new UsuarioRepositorio();

            try
            {
                if (repositorio.ConverterDataTableParaUsuario().Count == 0)
                {
                    MostraMensagem("Não existe Usuario criado para excluir");
                }
                else
                {
                    var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex;
                    var linhaSelecionada = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario;
                    if (DeveRemoverUusario())
                    {
                        repositorio.RemoverUsuario(linhaSelecionada.Id);
                    }
                    CarregarDados();
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
