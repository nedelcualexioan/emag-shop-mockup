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
    public partial class AddAddress : Form
    {
        private Label lblInfo;
        private Label lblPers;
        private Label lblName;
        private TextBox txtName;

        private Label lblDeliv;
        private Label lblCounty;
        private TextBox txtCounty;
        private Label lblCity;
        private TextBox txtCity;
        private Label lblAddress;
        private TextBox txtAddress;

        private Button btnSave;
        private Label lblCancel;

        public event FormClosedEventHandler close = delegate { };

        public AddAddress(Customer cust, ControllerCustomers ctr)
        {
            this.Size = new Size(744, 419);
            this.Text = "Modificare adresa";

            init();

            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Open Sans", 15.75f, FontStyle.Regular);
            lblInfo.Text = "Adauga o noua adresa de livrare";
            lblInfo.Location = new Point(12, 9);

            lblPers.AutoSize = true;
            lblPers.Font = new Font("Open Sans", 9.75f, FontStyle.Bold);
            lblPers.Text = "Persoana de contact";
            lblPers.Location = new Point(14, 64);

            lblName.AutoSize = true;
            lblName.Font = new Font("Open Sans", 9, FontStyle.Regular);
            lblName.Text = "Nume si Prenume";
            lblName.Location = new Point(14, 92);
            lblName.ForeColor = SystemColors.ControlDark;

            txtName.Font = new Font("Open Sans", 12, FontStyle.Regular);
            txtName.Size = new Size(332, 29);
            txtName.Location = new Point(12, 112);

            lblDeliv.AutoSize = true;
            lblDeliv.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblDeliv.Text = "Adresa de livrare";
            lblDeliv.Location = new Point(14, 172);

            lblCounty.AutoSize = true;
            lblCounty.Font = new Font("Open Sans", 9, FontStyle.Regular);
            lblCounty.Text = "Judet";
            lblCounty.Location = new Point(15, 199);
            lblCounty.ForeColor = SystemColors.ControlDark;

            txtCounty.Font = new Font("Open Sans", 12, FontStyle.Regular);
            txtCounty.Size = new Size(332, 29);
            txtCounty.Location = new Point(12, 219);

            lblCity.AutoSize = true;
            lblCity.Font = new Font("Open Sans", 9, FontStyle.Regular);
            lblCity.Text = "Localitate";
            lblCity.Location = new Point(347, 199);
            lblCity.ForeColor = SystemColors.ControlDark;

            txtCity.Font = new Font("Open Sans", 12, FontStyle.Regular);
            txtCity.Size = new Size(332, 29);
            txtCity.Location = new Point(350, 219);

            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Open Sans", 9, FontStyle.Regular);
            lblAddress.Text = "Adresa";
            lblAddress.Location = new Point(14, 263);
            lblAddress.ForeColor = SystemColors.ControlDark;

            txtAddress.Font = new Font("Open Sans", 12, FontStyle.Regular);
            txtAddress.Size = new Size(332, 29);
            txtAddress.Location = new Point(12, 283);


            btnSave.Size = new Size(81, 32);
            btnSave.Location = new Point(12, 336);
            btnSave.Font = new Font("Open Sans", 9, FontStyle.Regular);
            btnSave.Text = "Salveaza";
            btnSave.BackColor = Color.FromArgb(23, 99, 170);
            btnSave.ForeColor = Color.White;
            btnSave.Cursor = Cursors.Hand;

            lblCancel.AutoSize = true;
            lblCancel.Font = new Font("Open Sans", 9, FontStyle.Regular);
            lblCancel.Text = "Anuleaza";
            lblCancel.Location = new Point(107, 344);
            lblCancel.ForeColor = Color.FromArgb(0, 85, 150);
            lblCancel.Cursor = Cursors.Hand;

            txtName.KeyPress += new KeyPressEventHandler(txtName_KeyPress);
            txtCounty.KeyPress += new KeyPressEventHandler(txtCounty_KeyPress);
            txtCity.KeyPress += new KeyPressEventHandler(txtCity_KeyPress);
            btnSave.Click += new EventHandler((s, e) => btnSave_Click(s, e, cust, ctr));
            lblCancel.Click += new EventHandler(lblCancel_Click);

            this.FormClosed += new FormClosedEventHandler(AddAdress_FormClosed);
        }

        private void init()
        {
            lblInfo = new Label();
            lblPers = new Label();
            lblName = new Label();
            txtName = new TextBox();

            lblDeliv = new Label();
            lblCounty = new Label();
            txtCounty = new TextBox();
            lblCity = new Label();
            txtCity = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            btnSave = new Button();
            lblCancel = new Label();

            lblInfo.Parent = this;
            lblPers.Parent = this;
            lblName.Parent = this;
            txtName.Parent = this;
            lblDeliv.Parent = this;
            lblCounty.Parent = this;
            txtCounty.Parent = this;
            lblCity.Parent = this;
            txtCity.Parent = this;
            lblAddress.Parent = this;
            txtAddress.Parent = this;
            btnSave.Parent = this;
            lblCancel.Parent = this;

        }

        private void txtName_KeyPress(object sender,KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) == false && char.IsLetter(e.KeyChar) == false && e.KeyChar != '-' && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void txtCounty_KeyPress(object sender,KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) == false && char.IsLetter(e.KeyChar) == false && e.KeyChar != '-' && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) == false && char.IsLetter(e.KeyChar) == false && e.KeyChar != '-' && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e, Customer cust, ControllerCustomers ctr)
        {
            if (String.IsNullOrWhiteSpace(txtName.Text) || String.IsNullOrWhiteSpace(txtCounty.Text) || String.IsNullOrWhiteSpace(txtCity.Text) || String.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Campuri invalide", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Regex.IsMatch(txtAddress.Text, "[a-zA-Z]") == false)
            {
                MessageBox.Show("Adresa invalida", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cust.setAddress(txtAddress.Text);
                ctr.save();
                this.Close();
            }
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public String getAddress()
        {
            return this.txtCounty.Text + " " + this.txtCity.Text + " " + this.txtAddress.Text;
        }

        public String getName()
        {
            return this.txtName.Text;
        }

        private void AddAdress_FormClosed(object sender, FormClosedEventArgs e)
        {
            close(this, null);
        }
    }
}
