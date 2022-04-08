using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using emag;

namespace view
{
    public class ViewUser : Panel
    {

        private Panel pnlAccount;
        private Label lblAcc;
        private IconPictureBox pctUser;
        private Label lblName;
        private Label lblEmail;
        private Label lblAddress;

        private Panel pnlActivity;
        private Label lblActivity;
        private IconPictureBox pctTags;
        private Label lblOrders;
        private IconPictureBox pctFav;
        private Label lblFav;

        private Panel containerOrders;

        private int x = 19;

        public ViewUser(Form par, Customer cust, int countOr, int countFav)
        {
            this.Parent = par;
            this.Location = new Point(0, 98);
            this.Size = new Size(par.Width, par.Height - 98);
            this.BackColor = Color.FromArgb(250, 250, 250);
            this.AutoScroll = true;

            init();

            pnlAccount.Size = new Size(631, 211);
            pnlAccount.Location = new Point(456, 22);
            pnlAccount.BackColor = Color.White;
            pnlAccount.BorderStyle = BorderStyle.FixedSingle;

            lblAcc.AutoSize = true;
            lblAcc.Font = new Font("Open Sans", 12.75f, FontStyle.Regular);
            lblAcc.Text = "Datele contului";
            lblAcc.Location = new Point(15, 12);

            pctUser.IconChar = IconChar.UserCircle;
            pctUser.SizeMode = PictureBoxSizeMode.Normal;
            pctUser.IconSize = 150;
            pctUser.Size = new Size(150, 150);
            pctUser.Location = new Point(19, 49);

            lblName.AutoSize = true;
            lblName.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblName.Text = "Nume: " + cust.getName();
            lblName.Location = new Point(175, 67);

            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblEmail.Text = "Email: " + cust.getEmail();
            lblEmail.Location = new Point(175, 99);

            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);

            if (cust.getAddress().Equals("none")) {
                lblAddress.Text = "Adresa: Nicio adresa setata";
            }
            else
            {
                lblAddress.Text = "Adresa: " + cust.getAddress();
            }
            
            lblAddress.Location = new Point(175, 134);

            pnlActivity.Size = new Size(631, 97);
            pnlActivity.Location = new Point(456, 247);
            pnlActivity.BackColor = Color.White;
            pnlActivity.BorderStyle = BorderStyle.FixedSingle;

            lblActivity.AutoSize = true;
            lblActivity.Font = new Font("Open Sans", 12.75f, FontStyle.Regular);
            lblActivity.Text = "Activitatea mea";
            lblActivity.Location = new Point(15, 10);

            pctTags.SizeMode = PictureBoxSizeMode.Normal;
            pctTags.IconChar = IconChar.Tags;
            pctTags.IconSize = 35;
            pctTags.Size = new Size(35, 35);
            pctTags.Location = new Point(149, 41);
            pctTags.IconColor = SystemColors.Highlight;

            lblOrders.AutoSize = true;
            lblOrders.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            if(countOr == 1)
            {
                lblOrders.Text = "1 comanda plasata";
            }
            else
            {
                lblOrders.Text = countOr.ToString() + " comenzi plasate";
            }

            lblOrders.Location = new Point(185, 42);

            lblFav.AutoSize = true;
            lblFav.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            if (countFav == 1)
            {
                lblFav.Text = "1 produs favorit";
            }
            else
            {
                lblFav.Text = countFav.ToString() + " comenzi favorite";
            }
            lblFav.Location = new Point(373, 42);

            pctFav.SizeMode = PictureBoxSizeMode.Normal;
            pctFav.IconChar = IconChar.Heart;
            pctFav.IconSize = 35;
            pctFav.Size = new Size(35, 35);
            pctFav.Location = new Point(337, 41);
            pctFav.IconColor = Color.Red;

            containerOrders.Location = new Point(456, 361);
            containerOrders.Size = new Size(631, 257);
            containerOrders.BackColor = Color.White;
            containerOrders.BorderStyle = BorderStyle.FixedSingle;
        }

        private void init()
        {
            pnlAccount = new Panel();
            pctUser = new IconPictureBox();
            lblName = new Label();
            lblEmail = new Label();
            lblAddress = new Label();
            pnlActivity = new Panel();
            lblActivity = new Label();
            pctTags = new IconPictureBox();
            lblOrders = new Label();
            pctFav = new IconPictureBox();
            lblFav = new Label();
            lblAcc = new Label();
            containerOrders = new Panel();

            pnlAccount.Parent = this;
            lblAcc.Parent = pnlAccount;
            pctUser.Parent = pnlAccount;
            lblName.Parent = pnlAccount;
            lblEmail.Parent = pnlAccount;
            lblAddress.Parent = pnlAccount;

            pnlActivity.Parent = this;
            lblActivity.Parent = pnlActivity;
            pctTags.Parent = pnlActivity;
            lblOrders.Parent = pnlActivity;
            pctFav.Parent = pnlActivity;
            lblFav.Parent = pnlActivity;
            containerOrders.Parent = this;

        }

        public void add(ViewCart cart)
        {
            OrderCard c = new OrderCard(this, new Point(x, 14), cart);

            x += 5;

            this.Controls.Add(c);
        }

    }
}
