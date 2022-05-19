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
        public List<Usuario> Usuarios { get; set; }

        public ConsultaDePessoa()
        {
            InitializeComponent();

            Usuarios = new List<Usuario>();
        }

        private void Lbl_Adicionar_Click(object sender, EventArgs e)
        {
            CadastroDePessoa form2 = new CadastroDePessoa(null);

            DialogResult resultado = form2.ShowDialog(this);
            // se resultado foi OK (foi salvo)

            //salvar no datasource grind

            if(resultado == DialogResult.OK)
            {
                Usuarios.Add(form2.Usuario);
                listaClienteGrid.DataSource = null;
                listaClienteGrid.DataSource = Usuarios;
            }

            
        }

        private void Llb_Editar_Click(object sender, EventArgs e)
        {
            CadastroDePessoa form2 = new CadastroDePessoa(null);
            form2.Show();
        }

        private void Lbl_Cancelar_Click(object sender, EventArgs e)
        {

            this.Close();


        }

    } 
}
