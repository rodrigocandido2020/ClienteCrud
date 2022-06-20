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
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public ConsultaDeUsuario(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            InitializeComponent();
            CarregarDados();           
        }

        public void CarregarDados()
        {
            try
            {
                listaClienteGrid.DataSource = null;
                listaClienteGrid.DataSource = _usuarioRepositorio.ObterTodos();
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
            //var repositorio = new UsuarioRepositorioComBanco();

            try
            {
                var usuarioNovo = (int)decimal.Zero;
                var cadastroDeUsuario = new CadastroDeUsuario(usuarioNovo, _usuarioRepositorio);
                var resultado = cadastroDeUsuario.ShowDialog();
                if(resultado == DialogResult.OK)
                {
                    _usuarioRepositorio.AdicionarUsuario(cadastroDeUsuario.usuario);
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
            //var repositorio = new UsuarioRepositorioComBanco();
            try
            { 
                if (listaClienteGrid.CurrentCell == null)
                {
                    throw new Exception("Nenhuma linha foi selecionada");
                }
                var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex;
                var usuarioSelecionado = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario;
                var cadastroDeUsuario = new CadastroDeUsuario(usuarioSelecionado.Id, _usuarioRepositorio);

                var resultado = cadastroDeUsuario.ShowDialog(this);
                if (resultado == DialogResult.OK)
                {
                    //Quando a gente pega um usuario/Objeto de outra tela a gente tem que usar o formulario (cadastro de usuario.usuario)
                   //sakeeeei 
                   //kkkk deixa só eu vou outra coisa aqui
                    _usuarioRepositorio.AtualizarUsuario(cadastroDeUsuario.usuario);
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
                   MessageBoxIcon.Question) == DialogResult.Yes;
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
                    _usuarioRepositorio.RemoverUsuario(linhaSelecionada.Id);
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
