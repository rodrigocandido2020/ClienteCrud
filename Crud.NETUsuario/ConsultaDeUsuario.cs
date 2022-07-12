using Crud.Infra;
using Crud.Dominio;
using FluentValidation;

namespace Crud.NetUsuario
{
    public partial class ConsultaDeUsuario : Form
    {        
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private IValidator<Usuario> _Validador;


        public ConsultaDeUsuario(IUsuarioRepositorio usuarioRepositorio,IValidator<Usuario> validador)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _Validador = validador;
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
                var message = $"{ex.Message}{ex.InnerException?.Message}";
                MessageBox.Show(message);
            }
        }

        public void AoClicarEmAdicionar(object sender, EventArgs e)
        {
            try
            {
                var usuarioNovo = (int)decimal.Zero;
                var cadastroDeUsuario = new CadastroDeUsuario(usuarioNovo, _usuarioRepositorio , _Validador);
                var resultado = cadastroDeUsuario.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    _usuarioRepositorio.AdicionarUsuario(cadastroDeUsuario.usuario);
                }
                CarregarDados();
            }
            catch (Exception ex)
            {
                var message = $"{ex.Message}{ex.InnerException?.Message}";
                MessageBox.Show(message);
            }
        }

        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            try
            { 
                if (listaClienteGrid.CurrentCell == null)
                {
                    throw new Exception("Nenhuma linha foi selecionada");
                }
                var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex;
                var usuarioSelecionado = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario ??
                    throw new Exception ("Usuario pode ser nulo");
                var cadastroDeUsuario = new CadastroDeUsuario(usuarioSelecionado.Id, _usuarioRepositorio , _Validador);

                var resultado = cadastroDeUsuario.ShowDialog(this);
                if (resultado == DialogResult.OK)
                {
                    _usuarioRepositorio.AtualizarUsuario(cadastroDeUsuario.usuario);
                }
                CarregarDados();
            }
            catch (Exception ex)
            {
                var message = $"{ex.Message}{ex.InnerException?.Message}";
                MessageBox.Show(message);
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
                var message = $"{ex.Message}{ex.InnerException?.Message}";
                MessageBox.Show(message);
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
                var message = $"{ex.Message}{ex.InnerException?.Message}";
                MessageBox.Show(message);
            }
        }

        private void AoClicarEmRemover(object sender, EventArgs e)
        {
            try
            {
                if (listaClienteGrid.CurrentCell == null)
                {
                    throw new Exception("Nenhuma linha foi selecionada");
                }
                var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex;
                var linhaSelecionada = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario ??
                    throw new Exception ("Linha selecionada não pode ser nula");
                if (DeveRemoverUusario())
                {
                    _usuarioRepositorio.RemoverUsuario(linhaSelecionada.Id);
                }
                CarregarDados();          
            }
            catch (Exception ex)
            {
                var message = $"{ex.Message}{ex.InnerException?.Message}";
                MessageBox.Show(message);
            }
        }

        private bool DeveRemoverUusario ()
        {
           return MessageBox.Show("Tem certeza que deseja remover o Usuario selecionado?", "Apagar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }
    } 
}
