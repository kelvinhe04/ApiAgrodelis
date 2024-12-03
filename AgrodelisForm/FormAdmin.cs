using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgrodelisForm
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
















        //Nombres dentro del txt
        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre")
            {
                txtNombre.Text = "";
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre";
            }
        }



        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Email")
            {
                txtNombre.Text = "";
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Email";
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Contraseña")
            {
                txtNombre.Text = "";
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Contraseña";
            }
        }

    }
}
