using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using emag;

namespace view
{
    public partial class ViewLoginEx : Form
    {

        private ControllerCustomers control;
        public ViewLoginEx(String email)
        {
            InitializeComponent();
            control = new ControllerCustomers();
            lblEmail.Text = email;

            lblEmail.Left = (lblEmail.Parent.Width - lblEmail.Width) / 2;
            pctIcon.Left = (pctIcon.Parent.Width - pctIcon.Width) / 2;
            pctLogo.Left = (pctLogo.Parent.Width - pctLogo.Width) / 2;
            lblHello.Left = (lblHello.Parent.Width - lblHello.Width) / 2;
            lblInfo.Left = (lblInfo.Parent.Width - lblInfo.Width) / 2;
            txtPass.Left = (txtPass.Parent.Width - txtPass.Width) / 2;
            btnNext.Left = (btnNext.Parent.Width - btnNext.Width) / 2;
        }

        private void ViewLoginEx_Load(object sender, EventArgs e)
        {
            


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (control.isPassword(lblEmail.Text, txtPass.Text))
            {
                ViewMain view = new ViewMain();
                view.ShowDialog();
            }
            else
                MessageBox.Show("Ai introdus greșit parola sau adresa de email. Te rugăm completează din nou.", "Logare esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
