using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using emag;

namespace view
{
    public class ProductPage : Panel
    {

        private Label lblCategory;
        private Label lblProduct;
        private PictureBox pctProduct;
        private Label lblPrice;
        private PictureBox pctStock;
        private PictureBox pctAdd;
        private PictureBox pctFav;
        private Label lblColor;

        private Panel containerCards;

        public event EventHandler addClick;

        public ProductPage(Form par, Product p)
        {
            this.Parent = par;
            this.Location = new Point(0, 98);
            this.Width = par.Width;
            this.Height = par.Height - 98;
            this.BackColor = Color.White;

            lblCategory = new Label();
            lblProduct = new Label();
            pctProduct = new PictureBox();
            lblPrice = new Label();
            pctStock = new PictureBox();
            pctAdd = new PictureBox();
            pctFav = new PictureBox();
            lblColor = new Label();
            containerCards = new Panel();

            

            containerCards.Size = new Size(355, 280);
            containerCards.Location = new Point(900, 231);
            containerCards.Parent = this;

            lblCategory.Parent = this;
            lblProduct.Parent = this;
            pctProduct.Parent = this;
            lblPrice.Parent = this;
            pctStock.Parent = this;
            pctAdd.Parent = this;
            pctFav.Parent = this;
            

            lblCategory.Location = new Point(436, 100);
            lblCategory.Font = new Font("Open Sans", 10);
            lblCategory.ForeColor = Color.FromArgb(0, 94, 184);
            lblCategory.Text = p.getCategory();

            lblProduct.Location = new Point(436, 131);
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Open Sans", 18);
            lblProduct.Text = p.getName();

            pctProduct.Location = new Point(436, 183);
            pctProduct.ImageLocation = Application.StartupPath + String.Format(@"\images\{0}", p.getPicture());
            pctProduct.Size = new Size(370, 362);
            pctProduct.SizeMode = PictureBoxSizeMode.StretchImage;

            lblPrice.Location = new Point(1393, 201);
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Open Sans", 16);
            lblPrice.ForeColor = Color.Red;
            lblPrice.Text = p.getPrice().ToString() + " Lei";

            if (p.getStock() == true)
            {
                pctStock.Location = new Point(1494, 201);
                pctStock.ImageLocation = Application.StartupPath + @"\images\inStock.png";
                pctStock.Size = new Size(126, 31);
            }
            else
            {
                pctStock.Location = new Point(1483, 171);
                pctStock.ImageLocation = Application.StartupPath + @"\images\outStock.png";
                pctStock.Size = new Size(151, 101);
            }
            pctStock.SizeMode = PictureBoxSizeMode.StretchImage;
            pctStock.SendToBack();

            pctAdd.Location = new Point(1319, 258);
            pctAdd.ImageLocation = Application.StartupPath + @"\images\addButton.png";
            pctAdd.Size = new Size(378, 128);
            pctAdd.SizeMode = PictureBoxSizeMode.StretchImage;
            pctAdd.BringToFront();
            pctAdd.Cursor = Cursors.Hand;

            pctFav.Location = new Point(1389, 259);
            pctFav.ImageLocation = Application.StartupPath + @"\images\addFavorites.png";
            pctFav.Size = new Size(244, 307);
            pctFav.SizeMode = PictureBoxSizeMode.StretchImage;
            pctFav.SendToBack();
            pctFav.Cursor = Cursors.Hand;



            lblColor.Parent = containerCards;
            lblColor.Location = new Point(0,0);
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblColor.Text = "Alege Culoare";

            populateCards(p);

            pctAdd.Click += new EventHandler(pctAdd_Click);
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
            if (pctStock.ImageLocation == Application.StartupPath + @"\images\inStock.png")
                return true;

            return false;
        }

        public String getName()
        {
            return this.lblProduct.Text;
        }

        private void populateCards(Product p)
        {
            String[] files = Directory.GetFiles(Application.StartupPath + String.Format(@"\images\products\{0}\", p.getName()));

            int x = 9, y = 34;

            for (int i = 0; i < files.Count(); i++)
            {

                if (i % 3 == 0 && i != 0)
                {
                    x = 9;
                    y = 160;
                }

                createCard(files[i], new Point(x, y));
                
                

                x += 88;
            }
        }

        private void createCard(String path, Point p)
        {

            PictureBox card = new PictureBox();

            card.Parent = containerCards;

            card.Size = new Size(82, 92);
            card.Location = p;

            card.ImageLocation = path;
            card.SizeMode = PictureBoxSizeMode.CenterImage;

            card.BorderStyle = BorderStyle.FixedSingle;
            card.Cursor = Cursors.Hand;

            Label cardInfo = new Label();

            cardInfo.Parent = containerCards;
            cardInfo.Top = card.Top + 95;
            cardInfo.Left = card.Left;
            cardInfo.AutoSize = false;
            cardInfo.Width = card.Width;
            cardInfo.Font = new Font("Open Sans", 8.25f, FontStyle.Regular);
            cardInfo.Text = Path.GetFileNameWithoutExtension(path);
            cardInfo.TextAlign = ContentAlignment.MiddleCenter;

            card.MouseHover += new EventHandler(this.card_MouseHover);
        }

        private void card_MouseHover(object sender,EventArgs e)
        {





        }

    }
}
