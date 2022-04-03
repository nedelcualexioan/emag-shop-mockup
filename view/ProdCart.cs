using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using emag;
using System.IO;

namespace view
{
    public class ProdCart : Panel
    {



        private PictureBox pctProd;
        private Label lblProd;
        private Label lblStock;
        private Label lblInfo;
        private TextBox txtQuant;
        private Label lblQuant;
        private Label lblPrice;
        private Label lblFav;
        private Label lblDelete;

        private int price;

        public event EventHandler priceCh = delegate { };

        public event EventHandler delClick = delegate { };

        public ProdCart(Product prod, String text, Point p, Panel par)
        {

            this.Parent = par;
            this.BackColor = Color.White;
            this.Location = p;
            this.Size = new Size(975, 304);
            this.BorderStyle = BorderStyle.Fixed3D;

            this.price = prod.getPrice();

            pctProd = new PictureBox();
            lblProd = new Label();
            lblStock = new Label();
            lblInfo = new Label();
            txtQuant = new TextBox();
            lblQuant = new Label();
            lblPrice = new Label();
            lblFav = new Label();
            lblDelete = new Label();

            pctProd.Parent = this;
            lblProd.Parent = this;
            lblStock.Parent = this;
            lblInfo.Parent = this;
            txtQuant.Parent = this;
            lblQuant.Parent = this;
            lblFav.Parent = this;
            lblDelete.Parent = this;
            lblPrice.Parent = this;

            this.pctProd.ImageLocation = Application.StartupPath + String.Format(@"\images\{0}", prod.getPicture());
            this.pctProd.Location = new Point(47, 28);
            this.pctProd.Size = new Size(241, 236);
            this.pctProd.SizeMode = PictureBoxSizeMode.StretchImage;

            this.lblProd.AutoSize = true;
            this.lblProd.Font = new Font("Open Sans", 12F, FontStyle.Bold);
            this.lblProd.Location = new Point(294, 80);

            if (Directory.EnumerateFiles(Application.StartupPath + @"\images\products\" + prod.getName()).Count() != 0)
            {
                this.lblProd.Text = prod.getName() + String.Format(" ({0})", text);
            }
            else
            {
                this.lblProd.Text = prod.getName();
            }

            this.lblProd.AutoSize = false;
            this.lblProd.Size = new Size(285, 55);


            this.lblStock.AutoSize = true;
            this.lblStock.Font = new Font("Open Sans", 9.75F, FontStyle.Regular);
            this.lblStock.Location = new Point(294, 135);
            this.lblStock.Size = new Size(141, 19);
            this.lblStock.Text = "Disponibilitate: In stoc";

            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new Font("Open Sans", 9.75F, FontStyle.Regular);
            this.lblInfo.Location = new Point(294, 154);
            this.lblInfo.Size = new Size(244, 38);
            this.lblInfo.Text = "Garantie inclusa:  Persoana fizica 24 luni\nPersoana juridica 12 luni";

            this.txtQuant.Font = new Font("Open Sans", 11.25F, FontStyle.Regular);
            this.txtQuant.Location = new Point(631, 79);
            this.txtQuant.Size = new Size(52, 24);
            this.txtQuant.Text = "1";

            this.lblQuant.AutoSize = true;
            this.lblQuant.Font = new Font("Open Sans", 9.75F, FontStyle.Bold);
            this.lblQuant.Location = new Point(689, 86);
            this.lblQuant.Size = new Size(34, 19);
            this.lblQuant.Text = "buc";

            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new Font("Open Sans", 15.75F, FontStyle.Bold);
            this.lblPrice.Location = new Point(838, 74);
            this.lblPrice.Text = prod.getPrice().ToString() + " Lei";

            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new Font("Open Sans", 9.75F, FontStyle.Regular);
            this.lblDelete.Location = new Point(911, 105);
            this.lblDelete.Size = new Size(47, 19);
            this.lblDelete.ForeColor = Color.FromArgb(139, 201, 235);
            this.lblDelete.Text = "Sterge";
            this.lblDelete.Cursor = Cursors.Hand;

            this.lblFav.AutoSize = true;
            this.lblFav.Font = new Font("Open Sans", 9.75F, FontStyle.Regular);
            this.lblFav.Location = new Point(800, 105);
            this.lblFav.Size = new Size(106, 19);
            this.lblFav.ForeColor = Color.FromArgb(139, 201, 235);
            this.lblFav.Text = "Muta in Favorite";
            this.lblFav.Cursor = Cursors.Hand;

            this.txtQuant.KeyPress += new KeyPressEventHandler(txtQuant_KeyPress);
            this.txtQuant.TextChanged += new EventHandler((s, e) => txtQuant_TextChanged(s, e, prod));

            this.lblDelete.Click += new EventHandler(lblDelete_Click);
        }

        public ProdCart()
        {

        }

        private void txtQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
            
        }

        public int getPrice()
        {
            return int.Parse(Regex.Replace(lblPrice.Text, "[^0-9]+", String.Empty));
        }
        public int getLast()
        {
            return this.price;
        }
        public String getName()
        {
            return this.lblProd.Text;
        }

        public int getQuant()
        {
            return int.Parse(this.txtQuant.Text);
        }

        public void setQuant(int quant)
        {
            this.txtQuant.Text = quant.ToString();
        }
        private void txtQuant_TextChanged(object sender, EventArgs e, Product p)
        {
            if (txtQuant.Text.Equals("0"))
            {
                txtQuant.Text = "1";
            }
            else if (String.IsNullOrEmpty(txtQuant.Text) == false && int.Parse(txtQuant.Text) > 4)
            {
                txtQuant.Text = "1";
            }

            if (String.IsNullOrEmpty(txtQuant.Text) == false)
            {
                lblPrice.Text = (p.getPrice() * int.Parse(txtQuant.Text)).ToString() + " Lei";
            }

           
            priceCh(this, null);
            

            this.price = int.Parse(Regex.Replace(lblPrice.Text, "[^0-9]+", String.Empty));
        }

        private void lblDelete_Click(object sender,EventArgs e)
        {
            delClick(this, null);
        }

        public String getProdName()
        {
            return this.lblProd.Text;
        }

        public void setImage(String path)
        {
            this.pctProd.ImageLocation = path;
        }

    }
}
