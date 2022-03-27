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
    public class ViewRegister : Panel
    {

        private PictureBox pctLogo;
        private Label lblHelllo;
        private Label lblInfo;
        private Label lblEmail;

        private Label lblName;
        private TextBox txtName;
        private Label lblPass;
        private TextBox txtPass;
        private Label lblConfirm;
        private TextBox txtConfirm;

        private CheckBox cbxAgree;
        private Button btnNext;

        public event EventHandler logoClick;
        public event EventHandler btnClick;

        private ControllerCustomers customers;

        public ViewRegister(Form par)
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

            customers = new ControllerCustomers();

            pctLogo = new PictureBox();
            lblHelllo = new Label();
            lblInfo = new Label();
            lblEmail = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblPass = new Label();
            txtPass = new TextBox();
            lblConfirm = new Label();
            txtConfirm = new TextBox();
            cbxAgree = new CheckBox();
            btnNext = new Button();

            pctLogo.Parent = this;
            lblHelllo.Parent = this;
            lblInfo.Parent = this;
            lblEmail.Parent = this;
            lblName.Parent = this;
            txtName.Parent = this;
            lblPass.Parent = this;
            txtPass.Parent = this;
            lblConfirm.Parent = this;
            txtConfirm.Parent = this;
            cbxAgree.Parent = this;
            btnNext.Parent = this;

            pctLogo.ImageLocation = Application.StartupPath + @"\images\Logo_Color.png";
            pctLogo.Top = 100;
            pctLogo.Size = new Size(143, 78);
            pctLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pctLogo.Left = (pctLogo.Parent.Width - pctLogo.Width) / 2;
            pctLogo.Cursor = Cursors.Hand;

            lblHelllo.Top = 230;
            lblHelllo.Text = "Bine ai venit!";
            lblHelllo.AutoSize = false;
            lblHelllo.Font = new Font("Open Sans Light", 30);
            lblHelllo.Size = new Size(this.Width, 70);
            lblHelllo.TextAlign = ContentAlignment.MiddleCenter;

            lblInfo.Top = 300;
            lblInfo.Text = "Se pare că nu ai un cont eMAG.\nHai să iți creăm un cont nou!";
            lblInfo.AutoSize = false;
            lblInfo.Font = new Font("Open Sans", 14);
            lblInfo.Size = new Size(this.Width, 67);
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;

            lblEmail.Top = 366;
            lblEmail.Text = "email@mail.com";
            lblEmail.AutoSize = false;
            lblEmail.Font = new Font("Open Sans", 10);
            lblEmail.ForeColor = SystemColors.ControlDark;
            lblEmail.Size = new Size(this.Width, 31);
            lblEmail.TextAlign = ContentAlignment.MiddleCenter;

            lblName.Top = 408;
            lblName.Text = "Nume și prenume";
            lblName.AutoSize = false;
            lblName.Font = new Font("Open Sans", 12);
            lblName.Size = new Size(this.Width, 23);
            lblName.TextAlign = ContentAlignment.MiddleCenter;

            txtName.Top = 434;
            txtName.Font = new Font("Open Sans", 13);
            txtName.Size = new Size(284, 31);
            txtName.Left = (txtName.Parent.Width - txtName.Width) / 2;

            lblPass.Top = 476;
            lblPass.Text = "Alege o parolă sigură";
            lblPass.AutoSize = false;
            lblPass.Font = new Font("Open Sans", 12);
            lblPass.Size = new Size(this.Width, 23);
            lblPass.TextAlign = ContentAlignment.MiddleCenter;

            txtPass.Top = 502;
            txtPass.Font = new Font("Open Sans", 13);
            txtPass.Size = new Size(284, 31);
            txtPass.Left = (txtPass.Parent.Width - txtPass.Width) / 2;
            txtPass.PasswordChar = '*';

            lblConfirm.Top = 543;
            lblConfirm.Text = "Confirmă parola";
            lblConfirm.AutoSize = false;
            lblConfirm.Font = new Font("Open Sans", 12);
            lblConfirm.Size = new Size(this.Width, 23);
            lblConfirm.TextAlign = ContentAlignment.MiddleCenter;

            txtConfirm.Top = 569;
            txtConfirm.Font = new Font("Open Sans", 13);
            txtConfirm.Size = new Size(284, 31);
            txtConfirm.Left = (txtConfirm.Parent.Width - txtConfirm.Width) / 2;
            txtConfirm.PasswordChar = '*';

            cbxAgree.Font = new Font("Open Sans", 8);
            cbxAgree.Location = new Point(txtConfirm.Left, 602);
            cbxAgree.Text = "Am citit și sunt de acord cu Termenii și Condițiile,\ncu Politica de Confidențialitate.";
            cbxAgree.AutoSize = false;
            cbxAgree.Size = new Size(311, 49);

            btnNext.Top = 650;
            btnNext.Size = new Size(284, 42);
            btnNext.Left = (btnNext.Parent.Width - btnNext.Width) / 2;
            btnNext.Text = "Continua";
            btnNext.Font = new Font("Open Sans", 12);
            btnNext.TextAlign = ContentAlignment.MiddleCenter;
            btnNext.BackColor = Color.FromArgb(0, 130, 230);
            btnNext.Cursor = Cursors.Hand;

            this.pctLogo.Click += new EventHandler(pctLogo_Click);
            this.btnNext.Click += new EventHandler(btnNext_Click);

        }

        private void pctLogo_Click(object sender, EventArgs e)
        {
            if (logoClick != null)
            {
                logoClick(this, null);
            }
        }

        public void clearName()
        {
            txtName.Text = String.Empty;
        }

        public void clearPassword()
        {
            txtPass.Text = String.Empty;
        }

        public void clearConfirm()
        {
            txtConfirm.Text = String.Empty;
        }

        private bool isNameValid()
        {
            String text = txtName.Text;

            for (int i = 0; i < text.Length; i++)
            {
                if ((text[i] != ' ' && text[i] != '-') && char.IsLetter(text[i]) == false)
                    return false;
            }

            return true;
        }

        public void setEmail(String email)
        {
            this.lblEmail.Text = email;
        }
        private void btnNext_Click(object sender,EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(txtName.Text) == true || cbxAgree.Checked == false)
            {
                MessageBox.Show("Toate campurile sunt obligatorii", "Inregistrare esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (isNameValid() == false)
            {
                MessageBox.Show("Numele și prenumele nu sunt valide", "Inregistrare esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPass.Text.Equals(txtConfirm.Text) == false)
            {
                MessageBox.Show("Parolele nu sunt identice", "Inregistrare esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Customer cust = new Customer(customers.nextId(), txtName.Text, lblEmail.Text, txtPass.Text, "none", false);
                customers.add(cust);
                customers.save();

                if (btnClick != null)
                {
                    btnClick(this, null);
                }
            }

        }

        public String getEmail()
        {
            return this.lblEmail.Text;
        }
    }
}
