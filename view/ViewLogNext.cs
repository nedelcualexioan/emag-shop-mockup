using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace view
{
    internal class ViewLogNext : Panel
    {

        private PictureBox pctLogo;
        private Label lblHello;
        private PictureBox pctIcon;
        private Label lblEmail;
        private Label lblInfo;
        private TextBox txtPass;
        private Button btnNext;

        public event EventHandler btnClick;

        public ViewLogNext(Form par)
        {
            this.Parent = par;
            this.Location = new Point(0, 98);
            this.Width = par.Width - 20;
            this.Height = par.Height - 98;
            this.BackColor = SystemColors.Control;

            this.AutoScroll = false;
            this.HorizontalScroll.Maximum = 0;
            this.HorizontalScroll.Visible = false;
            this.AutoScroll = true;
            this.HorizontalScroll.Visible = true;

            pctLogo = new PictureBox();
            lblHello = new Label();
            pctIcon = new PictureBox();
            lblEmail = new Label();
            lblInfo = new Label();
            txtPass = new TextBox();
            btnNext = new Button();

            pctLogo.Parent = this;
            lblHello.Parent = this;
            pctIcon.Parent = this;
            lblEmail.Parent = this;
            lblInfo.Parent = this;
            txtPass.Parent = this;
            btnNext.Parent = this;

            pctLogo.ImageLocation = Application.StartupPath + @"\images\Logo_Color.png";
            pctLogo.Top = 100;
            pctLogo.Size = new Size(142, 81);
            pctLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pctLogo.Cursor = Cursors.Hand;
            pctLogo.Left = (pctLogo.Parent.Width - pctLogo.Width) / 2;

            lblHello.Top = 200;
            lblHello.AutoSize = false;
            lblHello.Height = 59;
            lblHello.Width = lblEmail.Parent.Width;
            lblHello.Font = new Font("Open Sans", 30);
            lblHello.TextAlign = ContentAlignment.MiddleCenter;
            lblHello.Text = "Salut!";
            lblHello.ForeColor = SystemColors.ControlDarkDark;

            pctIcon.ImageLocation = Application.StartupPath + @"\images\userIcon.png";
            pctIcon.Top = 269;
            pctIcon.Size = new Size(125, 122);
            pctIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pctIcon.Left = (pctIcon.Parent.Width - pctIcon.Width) / 2;

            lblEmail.Top = 395;
            lblEmail.AutoSize = false;
            lblEmail.Height = 23;
            lblEmail.Width = lblEmail.Parent.Width;
            lblEmail.Font = new Font("Open Sans", 11);
            lblEmail.TextAlign = ContentAlignment.MiddleCenter;
            lblEmail.Text = "email@email.com";
            lblEmail.ForeColor = SystemColors.ControlDark;

            lblInfo.Top = 433;
            lblInfo.AutoSize = false;
            lblInfo.Height = 22;
            lblInfo.Width = lblInfo.Parent.Width;
            lblInfo.Font = new Font("Open Sans", 13);
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblInfo.Text = "Introdu parola contului tau eMAG";
            lblInfo.ForeColor = SystemColors.ControlText;

            txtPass.Top = 460;
            txtPass.Font = new Font("Open Sans", 13);
            txtPass.Width = 284;
            txtPass.Left = (txtPass.Parent.Width - txtPass.Width) / 2;
            txtPass.PasswordChar = '*';

            btnNext.Top = 498;
            btnNext.Size = new Size(284, 42);
            btnNext.BackColor = Color.FromArgb(0, 130, 230);
            btnNext.Cursor = Cursors.Hand;
            btnNext.Font = new Font("Open Sans", 12);
            btnNext.Left = (btnNext.Parent.Width - btnNext.Width) / 2;
            btnNext.Text = "Continua";

            btnNext.Click += new EventHandler(btnNext_Click);

        }

        private void btnNext_Click(object sender,EventArgs e)
        {
            if (btnClick != null)
            {
                btnClick(this, null);
            }
        }

        public String getEmail()
        {
            return this.lblEmail.Text;
        }

        public String getPassword()
        {
            return this.txtPass.Text;
        }

        public void clearPassword()
        {
            this.txtPass.Text = String.Empty;
        }

        public void setEmail(String email)
        {
            this.lblEmail.Text = email;
        }


    }
}
