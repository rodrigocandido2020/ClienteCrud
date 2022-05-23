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
        public List<Usuario> listaUsuarios { get; set; }
        public ConsultaDePessoa()
        {
            InitializeComponent();

            listaUsuarios = new List<Usuario>();
        }

        public void Lbl_Adicionar_Click(object sender, EventArgs e)
        {
            CadastroDeUsuario form2 = new CadastroDeUsuario(null);

            DialogResult resultado = form2.ShowDialog(this);


            var UsuarioId = form2.Usuario.Id +1;           

            if (resultado == DialogResult.OK)
            {
                if (listaUsuarios.Count == 0)
                {
                    form2.Usuario.Id = UsuarioId;

                }
                
                else
                {                    
                    var promixoId = listaUsuarios.Last().Id +1;
                    form2.Usuario.Id = promixoId;
                }

                listaUsuarios.Add(form2.Usuario);
                listaClienteGrid.DataSource = null;
                listaClienteGrid.DataSource = listaUsuarios;
            }

            
        }

        private void Llb_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                var indexSelecionado = listaClienteGrid.CurrentCell.RowIndex;
                var usuarioSelecionado = listaClienteGrid.Rows[indexSelecionado].DataBoundItem as Usuario;

                var cadastroDeUsuario = new CadastroDeUsuario(usuarioSelecionado);
                DialogResult resultado = cadastroDeUsuario.ShowDialog(this);
            }
            catch (Exception ex)
            {

                throw;
            }
            listaClienteGrid.DataSource = null;
            listaClienteGrid.DataSource = listaUsuarios;
        }

        private void Lbl_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void listaClienteGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    } 
}
