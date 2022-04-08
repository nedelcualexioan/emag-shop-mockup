using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using emag;

namespace view
{
    public class FavCard : Panel
    {


        private PictureBox pctProd;
        private Label lblProd;
        private Label lblSepa;
        private Label lblStock;
        private Label lblEmag;
        private Label lblPrice;
        private PictureBox pctAdd;
        private Label lblDel;

        public event EventHandler addClick;
        public event EventHandler delClick;

        public FavCard(Panel par, Product prod, Point p)
        {
            this.Parent = par;
            this.BackColor = Color.White;
            this.Location = p;
            this.Size = new Size(par.Width - 4, 222);

            init();

            pctProd.Size = new Size(167, 167);
            pctProd.Location = new Point(28, 25);
            pctProd.SizeMode = PictureBoxSizeMode.Zoom;
            pctProd.ImageLocation = Application.StartupPath + @"\images\" + prod.getPicture();

            lblProd.AutoSize = true;
            lblProd.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblProd.Text = prod.getName();
            lblProd.Location = new Point(249, 30);

            lblSepa.AutoSize = false;
            lblSepa.Text = String.Empty;
            lblSepa.Size = new Size(1, 167);
            lblSepa.Location = new Point(209, 25);
            lblSepa.BorderStyle = BorderStyle.FixedSingle;

            lblStock.AutoSize = true;
            lblStock.Font = new Font("Open Sans", 8.25f, FontStyle.Regular);

            if (prod.getStock() == true)
            {
                lblStock.Text = "in stoc";
                lblStock.ForeColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                lblStock.Text = "stoc epuizat";
                lblStock.ForeColor = Color.Red;
            }

            lblStock.Location = new Point(250, 64);

            lblEmag.AutoSize = true;
            lblEmag.Font = new Font("Open Sans", 8.25f, FontStyle.Regular);
            lblEmag.Text = "vandut de: eMAG";
            lblEmag.Location = new Point(250, 79);

            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Open Sans", 14.25f, FontStyle.Regular);
            lblPrice.Text = prod.getPrice() + " Lei";
            lblPrice.Location = new Point(248, 103);
            lblPrice.ForeColor = Color.Red;

            pctAdd.ImageLocation = Application.StartupPath + @"\images\add.png";
            pctAdd.SizeMode = PictureBoxSizeMode.AutoSize;
            pctAdd.Location = new Point(251, 135);
            pctAdd.Cursor = Cursors.Hand;

            lblDel.AutoSize = true;
            lblDel.Font = new Font("Open Sans", 8.25f, FontStyle.Regular);
            lblDel.Text = "Sterge";
            lblDel.Location = new Point(253, 170);
            lblDel.Cursor = Cursors.Hand;
            lblDel.ForeColor = SystemColors.Highlight;

            pctAdd.Click += new EventHandler(this.pctAdd_Click);
            lblDel.Click += new EventHandler(lblDel_Click);
        }

        private void init()
        {
            pctProd = new PictureBox();
            lblProd = new Label();
            lblSepa = new Label();
            lblStock = new Label();
            lblEmag = new Label();
            lblPrice = new Label();
            pctAdd = new PictureBox();
            lblDel = new Label();

            pctProd.Parent = this;
            lblProd.Parent = this;
            lblSepa.Parent = this;
            lblStock.Parent = this;
            lblEmag.Parent = this;
            lblPrice.Parent = this;
            pctAdd.Parent = this;
            lblDel.Parent = this;
        }

        public String getName()
        {
            return this.lblProd.Text;
        }

        private void pctAdd_Click(object sender,EventArgs e)
        {
            if (addClick != null)
            {
                addClick(this, null);
            }
        }

        public bool isStock()
        {
            if (lblStock.Text.Contains("epuizat"))
            {
                return false;
            }

            return true;
        }

        private void lblDel_Click(object sender,EventArgs e)
        {
            if (delClick != null)
            {
                delClick(this, null);
            }
        }

        public String getProd()
        {
            return this.lblProd.Text;
        }
    }
}
