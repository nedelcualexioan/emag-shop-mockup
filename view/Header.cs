using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FontAwesome.Sharp;

namespace view
{
    public class Header:Panel
    {

        private PictureBox pctLogo;
        private TextBox txtSearch;
        private PictureBox pctSearch;
        private IconPictureBox pctUserIcon;
        private Label lblAccount;
        private IconPictureBox pctFavorite;
        private Label lblFavorite;
        private IconPictureBox pctCart;
        private Label lblCart;

        public event EventHandler userClick;
        public event EventHandler logoClick;
        public event EventHandler searchClick;
        public event EventHandler cartClick;
        public event EventHandler favClick;

        public Header(Form par)
        {
            this.AutoSize = false;
            par.Controls.Add(this);
            this.Parent = par;
            this.Location = new Point(0, 0);
            this.Width = par.Width;
            this.Height = 60;
            this.BackColor = Color.White;

            

            pctLogo = new PictureBox();
            txtSearch = new TextBox();
            pctSearch = new IconPictureBox();
            pctUserIcon = new IconPictureBox();
            lblAccount = new Label();
            pctFavorite = new IconPictureBox();
            lblFavorite = new Label();
            pctCart = new IconPictureBox();
            lblCart = new Label();

            pctLogo.Parent = this;
            txtSearch.Parent = this;
            pctSearch.Parent = this;
            pctUserIcon.Parent = this;
            lblAccount.Parent = this;
            pctFavorite.Parent = this;
            lblFavorite.Parent = this;
            pctCart.Parent = this;
            lblCart.Parent = this;

            pctLogo.ImageLocation = Application.StartupPath + @"\images\Logo_Color.png";
            pctLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pctLogo.Width = 105;
            pctLogo.Height = 60;
            pctLogo.Location = new Point(266, 3);
            pctLogo.Cursor = Cursors.Hand;

            txtSearch.Location = new Point(397, 16);
            txtSearch.Width = 561;
            txtSearch.Height = 29;
            txtSearch.Text = "Ai libertatea să alegi ce vrei";
            txtSearch.Font = new Font("Open Sans", 14);
            txtSearch.ForeColor = SystemColors.WindowFrame;

            pctSearch.ImageLocation = Application.StartupPath + @"\images\search.png";
            pctSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            pctSearch.Location = new Point(964, 16);
            pctSearch.Size = new Size(30, 29);
            pctSearch.Cursor = Cursors.Hand;

            pctUserIcon.IconChar = IconChar.User;
            pctUserIcon.Location = new Point(1138, 21);
            pctUserIcon.Size = new Size(28,26);
            pctUserIcon.Cursor = Cursors.Hand;
            pctUserIcon.SendToBack();

            lblAccount.Font = new Font("Open Sans", 14);
            lblAccount.Location = new Point(1162, 19);
            lblAccount.Text = "Contul meu";
            lblAccount.Size = new Size(117, 27);
            lblAccount.Cursor = Cursors.Hand;

            pctFavorite.IconChar = IconChar.Heart;
            pctFavorite.IconSize = 33;
            pctFavorite.Location = new Point(1319, 20);
            pctFavorite.Cursor = Cursors.Hand;

            lblFavorite.AutoSize = true;
            lblFavorite.Font = new Font("Open Sans", 14);
            lblFavorite.Location = new Point(1348, 19);
            lblFavorite.Text = "Favorite";
            lblFavorite.Cursor = Cursors.Hand;

            pctCart.IconChar = IconChar.ShoppingCart;
            pctCart.IconSize = 34;
            pctCart.Location = new Point(1460, 19);
            pctCart.Size = new Size(35, 33);
            pctCart.Cursor = Cursors.Hand;
            pctCart.SendToBack();

            lblCart.AutoSize = true;
            lblCart.Font = new Font("Open Sans", 14);
            lblCart.Location = new Point(1490, 19);
            lblCart.Text = "Cosul meu";
            lblCart.Cursor = Cursors.Hand;




            this.txtSearch.Click += new EventHandler(this.txtSearch_Click);


            this.pctSearch.MouseHover += new EventHandler(this.pctSearch_MouseHover);
            this.pctSearch.MouseLeave += new EventHandler(this.pctSearch_MouseLeave);
            this.pctSearch.Click += new EventHandler(this.pctSearch_Click);

            this.pctUserIcon.Click += new EventHandler(this.pctUserIcon_Click);

            this.lblAccount.Click += new EventHandler(this.lblAccount_Click);
            this.pctLogo.Click += new EventHandler(this.pctLogo_Click);

            this.pctCart.Click += new EventHandler(this.cart_Click);
            this.lblCart.Click += new EventHandler(this.cart_Click);

            this.lblFavorite.Click += new EventHandler(this.lblFavorite_Click);
            this.pctFavorite.Click += new EventHandler(this.lblFavorite_Click);

        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = String.Empty;
        }

        private void pctSearch_MouseHover(object sender, EventArgs e)
        {
            pctSearch.BackColor = SystemColors.ActiveCaption;
        }

        private void pctSearch_MouseLeave(object sender,EventArgs e)
        {
            pctSearch.BackColor = Color.White;
        }

        private void pctUserIcon_Click(object sender, EventArgs e)
        {
            if (userClick != null)
            {
                userClick(this, null);
            }
        }

        private void lblAccount_Click(object sender, EventArgs e)
        {
            if (userClick != null)
            {
                userClick(this, null);
            }
        }

        private void pctLogo_Click(object sender,EventArgs e)
        {
            if (logoClick != null)
            {
                logoClick(this, null);
            }
        }

        private void pctSearch_Click(object sender,EventArgs e)
        {
            if (searchClick != null)
            {
                searchClick(this, null);
            }   
        }

        public String getSearch()
        {
            return this.txtSearch.Text;
        }

        public bool isNull()
        {
            return String.IsNullOrWhiteSpace(txtSearch.Text);
        }

        private void cart_Click(object sender,EventArgs e)
        {
            if (cartClick != null)
            {
                cartClick(this, null);
            }
        }

        private void lblFavorite_Click(object sender,EventArgs e)
        {
            if(favClick != null)
            {
                favClick(this, null);
            }
        }

        
    }
}
