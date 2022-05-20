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
            CadastroDeUsuario form2 = new CadastroDeUsuario(null);

            DialogResult resultado = form2.ShowDialog(this);
            // se resultado foi OK (foi salvo)

            //salvar no datasource grind



            if (resultado == DialogResult.OK)
            {
                if(Usuarios.Count == 0)
                {
                    form2.Usuario.Id = 1;
                    
                }
                else
                {
                    //pegar o valor 1 e adicionar mais 1 , assim cria o ID 2
              

                    //criar vaviavel que pega ultimo valor add 

                }

                Usuarios.Add(form2.Usuario);
                listaClienteGrid.DataSource = null;
                listaClienteGrid.DataSource = Usuarios;
            }

            
        }

        private void Llb_Editar_Click(object sender, EventArgs e)
        {
            CadastroDeUsuario form2 = new CadastroDeUsuario(null);
            form2.Show();
        }

        private void Lbl_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    } 
}
