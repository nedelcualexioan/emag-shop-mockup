using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace view
{
    public class ViewLogin : Panel
    {

        private PictureBox pctLogo;
        private Label lblHello;
        private Label lblEmail;
        private TextBox txtMail;
        private Button btnNext;
        private Label lblInfo;

        public event EventHandler btnClick;
        public event EventHandler logoClick;

        public ViewLogin(Form par)
        {
            this.Parent = par;
            this.Location = new Point(0, 98);
            this.Width = par.Width;
            this.Height = 448;
            this.BackColor = SystemColors.Control;

            pctLogo = new PictureBox();
            lblHello = new Label();
            lblEmail = new Label();
            txtMail = new TextBox();
            lblInfo = new Label();
            btnNext = new Button();

            pctLogo.Parent = this;
            lblHello.Parent = this;
            lblEmail.Parent = this;
            txtMail.Parent = this;
            lblInfo.Parent = this;
            btnNext.Parent = this;

            pctLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pctLogo.ImageLocation = Application.StartupPath + @"\images\Logo_Color.png";
            pctLogo.Size = new Size(137, 77);
            pctLogo.Top = 100;
            pctLogo.BringToFront();
            pctLogo.Left = (pctLogo.Parent.Width - pctLogo.Width) / 2;
            pctLogo.Cursor = Cursors.Hand;

            lblHello.AutoSize = true;
            lblHello.Location = new Point(794, 205);
            lblHello.Font = new Font("Open Sans", 30);
            lblHello.Text = "Salut!";
            lblHello.Left = (lblHello.Parent.Width - lblHello.Width) / 2;
            lblHello.ForeColor = SystemColors.ControlDarkDark;

            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(763, 279);
            lblEmail.Font = new Font("Open Sans", 12);
            lblEmail.Text = "Introdu adresa de email";
            lblEmail.ForeColor = SystemColors.ControlText;
            lblEmail.Left = (lblEmail.Parent.Width - lblEmail.Width) / 2;

            txtMail.BorderStyle = BorderStyle.Fixed3D;
            txtMail.Location = new Point(712, 305);
            txtMail.Font = new Font("Open Sans", 14);
            txtMail.ForeColor = SystemColors.ControlText;
            txtMail.Size = new Size(284, 29);
            txtMail.Left = (txtMail.Parent.Width - txtMail.Width) / 2;

            btnNext.BackColor = Color.FromArgb(0, 130, 230);
            btnNext.Size = new Size(284, 42);
            btnNext.Font = new Font("Open Sans", 12);
            btnNext.Location = new Point(712, 346);
            btnNext.ForeColor = SystemColors.ControlText;
            btnNext.Left = (btnNext.Parent.Width - btnNext.Width) / 2;
            btnNext.Text = "Continua";
            btnNext.Cursor = Cursors.Hand;

            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(768, 401);
            lblInfo.Font = new Font("Open Sans", 10);
            lblInfo.Text = "Nu ai cont? Nu-ți face griji!\nPoți crea unul in pasul următor.";
            lblInfo.Left = (lblInfo.Parent.Width - lblInfo.Width) / 2;
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;

            btnNext.Click += new EventHandler(btnNext_Click);
            pctLogo.Click += new EventHandler(pctLogo_Click);
        }

        private bool isValid(String s)
        {
            String pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            Match m = Regex.Match(s, pattern);

            if (m.Success == true)
                return true;
            return false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            

            String text = txtMail.Text;

            if (String.IsNullOrWhiteSpace(text))
                MessageBox.Show("Email invalid", "Logare esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (char.IsLetterOrDigit(text[0]) == false || text.Contains("@") == false || text.Contains(".") == false)
                MessageBox.Show("Email invalid", "Logare esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (isValid(text) == false)
                MessageBox.Show("Email invalid", "Logare esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (btnClick != null)
                {
                    btnClick(this, null);
                }
            }
            
        }

        private void pctLogo_Click(object sender,EventArgs e)
        {
            if (logoClick != null)
            {
                logoClick(this, null);
            }
        }

        public void clearEmail()
        {
            this.txtMail.Text = String.Empty;
        }

        public String getEmail()
        {
            return this.txtMail.Text;
        }
    }
}