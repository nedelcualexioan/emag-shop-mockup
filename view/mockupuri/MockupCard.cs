using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace view
{
    public partial class MockupCard : Form
    {
        public MockupCard()
        {
            
            InitializeComponent();

            this.BackColor = Color.White;

            lblProd.Left = (lblProd.Parent.Width - lblProd.Width) / 2;
            lblPret.Left = (lblPret.Parent.Width - lblPret.Width) / 2;

            

            lblProd.TextAlign = ContentAlignment.MiddleCenter;
            lblPret.TextAlign = ContentAlignment.MiddleCenter;
            panel1.BorderStyle = BorderStyle.Fixed3D;
        }

        private void MockupCard_Load(object sender, EventArgs e)
        {

        }

        private void lblProd_Click(object sender, EventArgs e)
        {

        }
    }
}
