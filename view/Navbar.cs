using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using emag;

namespace view
{
    public class Navbar : Panel
    {
        
        private Label lblGenius;
        private Label lblOferte;
        private ComboBox cmbProducts;
        private ControllerProducts control;
        public event EventHandler cmbChange;


        public Navbar(Form par)
        {
            control = new ControllerProducts();


            this.Parent = par;
            par.Controls.Add(this);

            this.Height = 40;
            this.Width = par.Width;
            this.Location = new Point(0, 59);

            lblOferte = new Label();
            lblGenius = new Label();
            cmbProducts = new ComboBox();

            lblGenius.Parent = this;
            lblOferte.Parent = this;
            cmbProducts.Parent = this;

            lblGenius.AutoSize = true;
            lblGenius.Location = new Point(412, 11);
            lblGenius.Text = "eMAG Genius";
            lblGenius.Font = new Font("Open Sans Light", 10);
            lblGenius.BackColor = Color.Transparent;
            lblGenius.ForeColor = Color.White;
            lblGenius.BringToFront();
            lblGenius.Cursor = Cursors.Hand;

            lblOferte.AutoSize = true;
            lblOferte.Location = new Point(543, 11);
            lblOferte.Text = "Ofertele momentului";
            lblOferte.Font = new Font("Open Sans Light", 10);
            lblOferte.BackColor = Color.Transparent;
            lblOferte.ForeColor = Color.White;
            lblOferte.BringToFront();
            lblOferte.Cursor = Cursors.Hand;

            cmbProducts.Location = new Point(266, 5);
            cmbProducts.Text = "Produse";
            cmbProducts.Font = new Font("Open Sans", 12);
            cmbProducts.Size = new Size(105, 31);
            cmbProducts.Cursor = Cursors.Hand;

            
            populateCmb();

            this.cmbProducts.Click += new EventHandler(cmbProducts_Click);
            this.cmbProducts.KeyPress += new KeyPressEventHandler(cmbProducts_KeyPress);
            this.cmbProducts.SelectedIndexChanged += new EventHandler(cmbProducts_SelectedIndexChanged);
     
            this.Paint += new PaintEventHandler(this.Navbar_Paint);

           

        }
        private void Navbar_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(96, 155, 173), 1);

            Rectangle area = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.Red, Color.FromArgb(0,128,255), LinearGradientMode.Horizontal);
            

            graph.FillRectangle(lgb, area);
            graph.DrawRectangle(pen, area);
        }

        private void cmbProducts_KeyPress(object sender,KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbProducts_Click(object sender, EventArgs e)
        {
            cmbProducts.SelectionStart = 0;
            cmbProducts.SelectionLength = 0;
        }

        private void populateCmb()
        {

            List<String> categ = control.getCategories();

            cmbProducts.Items.Add("Produse");

            foreach(String cat in categ)
            {
                cmbProducts.Items.Add(cat);
               
            }

        }

        
        private void cmbProducts_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (cmbChange != null)
            {
                cmbChange(this, null);
            }

        }

        public String getCmbText()
        {
            return this.cmbProducts.Text;
        }



    }
}
