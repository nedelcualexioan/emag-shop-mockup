using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using emag;

namespace view
{
    public class ViewFavorite : Panel
    {
        private Panel pnlFav;
        private Label lblFav;
        private Label lblCount;
        private Label lblSep;

        private List<FavCard> cards = new List<FavCard>();

        private int y = 56;

        private PictureBox pctEmpty;
        private Label lblEmpty;
        private Button btnProds;

        public event EventHandler btnClick;

        public event EventHandler addClick;
        public ViewFavorite(Form par)
        {

            this.Parent = par;
            this.Location = new Point(0, 98);
            this.Size = new Size(par.Width, par.Height - 98);
            this.BackColor = Color.FromArgb(242, 242, 247);

            pnlFav = new Panel();
            lblFav = new Label();
            lblCount = new Label();
            lblSep = new Label();
            pctEmpty = new PictureBox();
            lblEmpty = new Label();
            btnProds = new Button();

            pnlFav.Parent = this;
            lblFav.Parent = pnlFav;
            lblCount.Parent = pnlFav;
            lblSep.Parent = pnlFav;
            pctEmpty.Parent = pnlFav;
            lblEmpty.Parent = pnlFav;
            btnProds.Parent = pnlFav;


            pnlFav.Size = new Size(670, 700);
            pnlFav.BorderStyle = BorderStyle.Fixed3D;
            pnlFav.Left = (pnlFav.Parent.Width - pnlFav.Width) / 2;
            pnlFav.Top = 15;
            pnlFav.BackColor = Color.White;


            pnlFav.HorizontalScroll.Enabled = false;
            pnlFav.HorizontalScroll.Visible = false;
            pnlFav.HorizontalScroll.Maximum = 0;
            pnlFav.AutoScroll = true;
            

            lblFav.AutoSize = true;
            lblFav.Font = new Font("Open Sans", 18, FontStyle.Regular);
            lblFav.Text = "Favorite";
            lblFav.Location = new Point(13, 9);

            lblCount.AutoSize = true;
            lblCount.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblCount.Text = "(0 produse in lista)";
            lblCount.Location = new Point(115, 19);

            lblSep.AutoSize = false;
            lblSep.Size = new Size(633, 1);
            lblSep.Text = String.Empty;
            lblSep.Location = new Point(19, 47);
            lblSep.BorderStyle = BorderStyle.FixedSingle;


            pctEmpty.ImageLocation = Application.StartupPath + @"\images\emptyFav.png";
            pctEmpty.SizeMode = PictureBoxSizeMode.AutoSize;
            pctEmpty.Size = new Size(192, 189);
            pctEmpty.Top = 140;
            pctEmpty.Left = (pnlFav.Width - pctEmpty.Width) / 2;

            lblEmpty.AutoSize = false;
            lblEmpty.Font = new Font("Open Sans", 14.25f, FontStyle.Regular);
            lblEmpty.Text = "Hmm, niciun produs in lista ta.\nUite niste recomandari care te-ar putea inspira.";
            lblEmpty.Location = new Point(0, 350);
            lblEmpty.Size = new Size(pnlFav.Width, 59);
            lblEmpty.TextAlign = ContentAlignment.MiddleCenter;

            btnProds.Size = new Size(109, 36);
            btnProds.Location = new Point((btnProds.Parent.Width - btnProds.Width) / 2, 420);
            btnProds.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            btnProds.BackColor = Color.FromArgb(0, 94, 184);
            btnProds.ForeColor = Color.White;
            btnProds.Text = "Vezi produse";
            btnProds.Cursor = Cursors.Hand;

            btnProds.Click += new EventHandler(btnProds_Click);
            
        }

        public void add(Product p)
        {
            FavCard card = new FavCard(pnlFav, p, new Point(0, y));
            card.BorderStyle = BorderStyle.Fixed3D;

            y = card.Top + card.Height;

            this.cards.Add(card);

            if (lblCount.Text.Contains("0"))
            {
                lblCount.Text = "(1 produs in lista)";

                pctEmpty.Hide();
                lblEmpty.Hide();
                btnProds.Hide();
            }
            else
            {
                lblCount.Text = "(" + (int.Parse(Regex.Replace(lblCount.Text, @"[^0-9]+", String.Empty)) + 1).ToString() + " produse in lista)";
            }

            card.addClick += btnAdd_Click;
            card.delClick += lblDel_Click;
        }

        public bool isFav(Product p)
        {
            foreach(Control c in pnlFav.Controls)
            {
                FavCard card = c as FavCard;

                if (card != null)
                {
                    if (card.getName().Equals(p.getName()))
                        return true;
                }
            }

            return false;
        }

        public void btnProds_Click(object sender,EventArgs e)
        {
            if (btnClick != null)
            {
                btnClick(this, null);
            }
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            if (addClick != null)
            {
                addClick(sender, null);
            }
        }

        private void lblDel_Click(object sender,EventArgs e)
        {
            int poz = 0;

            int dim = 0;

            foreach(Control c in pnlFav.Controls)
            {
                FavCard card = c as FavCard;

                if (card != null)
                {
                    if (card.Equals(sender))
                    {
                        poz = pnlFav.Controls.IndexOf(card);

                        dim = card.Height;
                    }
                }
            }

            for(int i = pnlFav.Controls.Count - 1; i > poz; i--)
            {
                FavCard card = pnlFav.Controls[i] as FavCard;

                if (card != null)
                {
                    pnlFav.Controls[i].Top -= pnlFav.Controls[i].Height;
                }
            }

            pnlFav.Controls.RemoveAt(poz);

            if (int.Parse(Regex.Replace(lblCount.Text, @"[^0-9]+", String.Empty)) - 1 == 1)
            {
                lblCount.Text = "(1 produs in lista)";
            }
            else if(int.Parse(Regex.Replace(lblCount.Text, @"[^0-9]+", String.Empty)) - 1 == 0)
            {
                lblCount.Text = "(0 produse in lista)";

                pctEmpty.Show();
                lblEmpty.Show();
                btnProds.Show();
            }
            else
            {
                lblCount.Text = "(" + (int.Parse(Regex.Replace(lblCount.Text, @"[^0-9]+", String.Empty)) - 1).ToString() + " produse in lista)";
            }

            y -= dim;
        }

    }
}
