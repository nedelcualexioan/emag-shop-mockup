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
    public class ViewFavorite : Panel
    {
        private Panel pnlFav;
        private Label lblFav;
        private Label lblCount;
        private Label lblSep;

        private List<FavCard> cards = new List<FavCard>();

        private int y = 56;
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

            pnlFav.Parent = this;
            lblFav.Parent = pnlFav;
            lblCount.Parent = pnlFav;
            lblSep.Parent = pnlFav;


            pnlFav.Size = new Size(670, 700);
            pnlFav.BorderStyle = BorderStyle.Fixed3D;
            pnlFav.Left = (pnlFav.Parent.Width - pnlFav.Width) / 2;
            pnlFav.Top = 15;
            pnlFav.BackColor = Color.White;
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



        }

        public void add(Product p)
        {
            FavCard card = new FavCard(pnlFav, p, new Point(19, y));

            Label sep = new Label();
            sep.Parent = pnlFav;
            sep.AutoSize = false;
            sep.Size = new Size(pnlFav.Width, 1);
            sep.BringToFront();
            

            y = card.Top + card.Height;

            sep.Location = new Point(0, card.Top + card.Height - 5);
            sep.Text = String.Empty;
            sep.BorderStyle = BorderStyle.FixedSingle;

            this.cards.Add(card);
        }

    }
}
