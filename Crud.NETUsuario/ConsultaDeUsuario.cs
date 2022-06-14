using Crud.Infra;
using Crud.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Crud.NetUsuario
{
    public partial class ConsultaDeUsuario : Form
    {        
        public ConsultaDeUsuario()
        {
            InitializeComponent();
            CarregarDados();
            
        }
        public void CarregarDados()
        {
            var repositorioComBanco = new UsuarioRepositorioComBanco();
            try
            {
                listaClienteGrid.DataSource = null;
                listaClienteGrid.DataSource = repositorioComBanco.ObterTodos();
                listaClienteGrid.Columns["SENHA"].Visible = false;
                listaClienteGrid.Columns["NOME"].HeaderText = "Nome";
                listaClienteGrid.Columns["EMAIL"].HeaderText = "Email";
                listaClienteGrid.Columns["DATACRIACAO"].HeaderText = "Data criação";
                listaClienteGrid.Columns["DATANASCIMENTO"].HeaderText = "Data Nascimento";
                listaClienteGrid.Columns["Id"].Width = 25;
                listaClienteGrid.Columns["Nome"].Width = 150;
                listaClienteGrid.Columns["Email"].Width = 200;
                listaClienteGrid.Columns["DataNascimento"].Width = 130;
                listaClienteGrid.Columns["DataCriacao"].Width = 140;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AoClicarEmAdicionar(object sender, EventArgs e)
        {
            var repositorio = new UsuarioRepositorioComBanco();

            try
            {
                var cadastroDeUsuario = new CadastroDeUsuario(null);
                var resultado = cadastroDeUsuario.ShowDialog();
                if(resultado == DialogResult.OK)
                {
                    repositorio.AdicionarUsuario(cadastroDeUsuario.Usuario);
                }
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            var repositorio = new UsuarioRepositorioComBanco();
            try
            { 
                var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex; 
                if (indexSelecionado == decimal.MinusOne)
                {
                    throw new Exception("Nenhuma linha foi selecionada");
                }

                var linhaSelecionada = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario;
                var cadastroDeUsuario = new CadastroDeUsuario(linhaSelecionada);

                var resultado = cadastroDeUsuario.ShowDialog(this);
                if (resultado == DialogResult.OK)
                {
                    repositorio.EditarUsuario(linhaSelecionada);
                }
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AoClicarEmRemover(object sender, EventArgs e)
        {
            var repositorio = new UsuarioRepositorioComBanco(); 
            try
            {
                var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex;
                if (indexSelecionado == decimal.MinusOne)
                {
                    throw new Exception("Nenhuma linha foi selecionada");
                } 

                var linhaSelecionada = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario;
                if (DeveRemoverUusario())
                {
                    repositorio.RemoverUsuario(linhaSelecionada.Id);
                }
                CarregarDados();          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool DeveRemoverUusario ()
        {
           return MessageBox.Show("Tem certeza que deseja remover o Usuario selecionado?", "Apagar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }
    } 
}
