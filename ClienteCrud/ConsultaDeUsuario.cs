using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteCrud
{
    public partial class ConsultaDePessoa : Form
    {
        //inicar uma coleção de objetos
        public List<Usuario> listaUsuarios { get; set; }
        public ConsultaDePessoa()
        {
            InitializeComponent();
            //objeto esta inicinado dentro da lista
            listaUsuarios = new List<Usuario>();
            this.listaClienteGrid.Columns["senha"].Visible = false;
        }

        public void Lbl_Adicionar_Click(object sender, EventArgs e)
        {
            CadastroDeUsuario cadastroDeUsuario = new CadastroDeUsuario(null);
            DialogResult resultado = cadastroDeUsuario.ShowDialog(this);


            var UsuarioId = cadastroDeUsuario.Usuario.Id +1;           

            if (resultado == DialogResult.OK)
            {
                if (listaUsuarios.Count == 0)
                {
                    cadastroDeUsuario.Usuario.Id = UsuarioId;

                }
                
                else
                {                    
                    var promixoId = listaUsuarios.Last().Id +1;
                    cadastroDeUsuario.Usuario.Id = promixoId;
                }

                listaUsuarios.Add(cadastroDeUsuario.Usuario);
                listaClienteGrid.DataSource = null;
                listaClienteGrid.DataSource = listaUsuarios;
            }

            
        }

        private void Llb_Editar_Click(object sender, EventArgs e)
        {

            try
            {
                if (listaUsuarios.Count == 0)
                {
                    MessageBox.Show("Não existe Usuario criado para Editar");
                }
                else
                { 
                    var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario;

                    var cadastroDeUsuario = new CadastroDeUsuario(usuarioSelecionado);
                    DialogResult resultado = cadastroDeUsuario.ShowDialog(this);
                }
            }
            catch (Exception)
            {

                throw;
            }
            listaClienteGrid.DataSource = null;
            listaClienteGrid.DataSource = listaUsuarios;
        }

        private void Lbl_Cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair da aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }           

        }

        private void listaClienteGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Lbl_Ok_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair da aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void Lbl_Remover_Click(object sender, EventArgs e)
        {

            try
            {
                if (listaUsuarios.Count == 0)
                {
                    MessageBox.Show("Não existe Usuario criado para excluir");
                }
                else
                {
                    var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario;


                    if (MessageBox.Show("Tem certeza que deseja remover o Usuario selecionado?", "Apagar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        listaUsuarios.Remove(usuarioSelecionado);
                    }

                    listaClienteGrid.DataSource = null;
                    listaClienteGrid.DataSource = listaUsuarios;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    } 
}
