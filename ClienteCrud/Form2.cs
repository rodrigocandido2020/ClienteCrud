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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            dateTimePicker1.Enabled = false;
            textBox7.Enabled = false;
        }

        private void Lbl_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
