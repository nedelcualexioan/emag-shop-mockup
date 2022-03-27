using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using emag;

namespace view
{
    public class ViewHome : Panel
    {
        private PictureBox pctAd;
        private Timer timer;

        private ControllerProducts control;
        private List<Panel> cards = new List<Panel>();
        private Panel containerCards;
        private Label lblProd;

        private int pctNr;

        private Product lastClick;

        public event EventHandler ProdClick;

        public ViewHome(Form par)
        {

            control = new ControllerProducts();

            this.Parent = par;
            this.Location = new Point(0, 98);
            this.Width = par.Width;
            this.Height = 750;
            this.BackColor = SystemColors.Control;

            this.AutoScroll = false;
            this.HorizontalScroll.Enabled = false;
            this.HorizontalScroll.Visible = false;
            this.HorizontalScroll.Maximum = 0;
            this.AutoScroll = true;

            pctNr = 1;

            containerCards = new Panel();
            pctAd = new PictureBox();
            timer = new Timer();
            lblProd = new Label();
            

            populatePanel();

            containerCards.AutoScroll = false;
            containerCards.VerticalScroll.Enabled = false;
            containerCards.VerticalScroll.Visible = false;
            containerCards.VerticalScroll.Maximum = 0;
            containerCards.AutoScroll = true;

            containerCards.Parent = this;
            containerCards.Width = this.Width;
            containerCards.Height = 332;
            containerCards.Location = new Point(0, 327);

            lblProd.Parent = this;
            lblProd.AutoSize = true;
            lblProd.Location = new Point(12, 277);
            lblProd.Font = new Font("Open Sans", 25);
            lblProd.Text = "Produse";
            lblProd.ForeColor = SystemColors.ControlText;

            

            pctAd.Parent = this;

            pctAd.ImageLocation = Application.StartupPath + @"\images\1.png";
            pctAd.Location = new Point(618, 0);
            pctAd.Size = new Size(661, 300);
            pctAd.SizeMode = PictureBoxSizeMode.StretchImage;

            timer.Enabled = true;
            timer.Interval = 3000;

            timer.Tick += new EventHandler(timer_Tick);

        }

        
        public void populateCategory(String category)
        {
            int x = 0, y = 14;

            for (int i = 0; i < control.getCount(); i++)
            {
                Product prod = control.getProduct(i);
                if (prod.getCategory() == category)
                {
                    createCard(prod, new Point(x, y));
                    x += cards[0].Size.Width + 8;
                }

                
            }
        }

        public void populatePanel()
        {
            int x = 0, y = 14;

            for(int i = 0; i < control.getCount(); i++)
            {
                createCard(control.getProduct(i), new Point(x, y));

                x += cards[0].Size.Width + 8;

                cards[i].Click += new EventHandler(card_Click);
            }

            
        }

        private void createCard(Product product, Point point)
        {

            lastClick = new Product();

            Panel card = new Panel();

            card.Parent = containerCards;

            card.Location = point;  
            card.Size = new Size(192, 303);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.Fixed3D;
            card.Cursor = Cursors.Hand;

            PictureBox pctProd = new PictureBox();
            pctProd.Parent = card;
            pctProd.Location = new Point(27, 17);
            pctProd.ImageLocation = Application.StartupPath + String.Format(@"\images\{0}", product.getPicture());
            pctProd.SizeMode = PictureBoxSizeMode.StretchImage;
            pctProd.Size = new Size(137, 137);
            pctProd.SendToBack();

            Label lblProd = new Label();
            lblProd.AutoSize = false;
            lblProd.Parent = card;
            lblProd.Location = new Point(0, 204);
            lblProd.Width = lblProd.Parent.Width;
            lblProd.Height = 50;
            lblProd.TextAlign = ContentAlignment.MiddleCenter;
            lblProd.Text = product.getName();
            lblProd.Font = new Font("Open Sans", 12);
            lblProd.ForeColor = SystemColors.ControlText;

            Label lblPret = new Label();

            lblPret.AutoSize = false;
            lblPret.Parent = card;
            lblPret.Location = new Point(0, 267);
            lblPret.Width = lblPret.Parent.Width;
            lblPret.Height = 36;
            lblPret.TextAlign = ContentAlignment.MiddleCenter;
            lblPret.Text = product.getPrice().ToString() + " Lei";
            lblPret.Font = new Font("Open Sans", 14);
            lblPret.ForeColor = Color.Red;

            foreach(Control c in card.Controls)
            {
                c.Click += new EventHandler(card_Click);
            }

            this.cards.Add(card);
        }

        private void LoadNextImage()
        {
            if (pctNr == 4)
                pctNr = 1;

            pctAd.ImageLocation = Application.StartupPath + String.Format(@"\images\{0}.png", pctNr);
            pctNr++;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        public void setProdTxt(String text)
        {
            lblProd.Text = text;
        }

        public void emptyList()
        {
            this.cards.Clear();
        }

        public void clearCards()
        {
            containerCards.Controls.Clear();
        }

        public void card_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            
            if(c is Panel)
            {
                lastClick = getProduct(c);
                
            }
            else
            {
                lastClick = getProduct(c.Parent);
            }

            if (ProdClick != null)
            {
                ProdClick(this, null);
            }
        }

        private Product getProduct(Control p)
        {
            String text;

            foreach(Control c in p.Controls)
            {
                text = c.Text;
                if (control.getProduct(text) != null)
                {
                    return control.getProduct(text);
                }
            }

            return null;    
        }

        public Product getLastProd()
        {
            return this.lastClick;
        }



    }
}
