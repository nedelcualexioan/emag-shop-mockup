using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FontAwesome.Sharp;
using emag;

namespace view
{
    public class ViewOrderDet : Panel
    {

        private Label lblDetails;

        private Panel pnlDelivery;
        private PictureBox pctOne;
        private Label lblDelivery;
        private CheckBox cbxCourier;
        private PictureBox pctSep1;
        private Label lblPerson;
        private Label lblName;
        private Label lblAddress;
        private TextBox txtAddress;
        private IconPictureBox pctTruck;
        private Label lblEmag;
        private Label lblProds;
        private CheckBox cbxDelivery;
        private PictureBox pctSep2;
        private IconButton btnAdd;

        public ViewOrderDet(Form par, Customer customer, int prodNr, ControllerCustomers control)
        {

            this.Parent = par;

            this.Location = new Point(0, 98);
            this.Width = par.Width;
            this.Height = par.Height - 98;

            init();

            pnlDelivery.BackColor = Color.FromArgb(228, 241, 249);
            pnlDelivery.Location = new Point(210, 42);
            pnlDelivery.Size = new Size(870, 438);

            lblDetails.Font = new Font("Open Sans", 20.25f, FontStyle.Regular);
            lblDetails.AutoSize = true;
            lblDetails.Text = "Detalii comanda";
            lblDetails.Location = new Point(203, 0);

            pctOne.ImageLocation = Application.StartupPath + @"\images\circle1.png";
            pctOne.SizeMode = PictureBoxSizeMode.StretchImage;
            pctOne.Location = new Point(67, 29);
            pctOne.Size = new Size(41, 39);

            lblDelivery.Font = new Font("Open Sans", 15.75f, FontStyle.Regular);
            lblDelivery.AutoSize = true;
            lblDelivery.Text = "Modalitate livrare";
            lblDelivery.Location = new Point(110, 33);

            cbxCourier.Location = new Point(67, 84);
            cbxCourier.Checked = true;
            cbxCourier.Font = new Font("Open Sans", 12, FontStyle.Regular);
            cbxCourier.Text = "Livrare prin curier";
            cbxCourier.ForeColor = Color.FromArgb(68, 129, 186);
            cbxCourier.Enabled = false;
            cbxCourier.Size = new Size(165, 27);

            pctSep1.SizeMode = PictureBoxSizeMode.StretchImage;
            pctSep1.ImageLocation = Application.StartupPath + @"\images\sep.png";
            pctSep1.Location = new Point(-41, 93);
            pctSep1.Size = new Size(940, 82);
            pctSep1.SendToBack();

            lblPerson.Font = new Font("Open Sans", 9.75f, FontStyle.Bold);
            lblPerson.AutoSize = true;
            lblPerson.Text = "Persoana de contact";
            lblPerson.Location = new Point(63, 156);

            lblName.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblName.AutoSize = true;
            lblName.Text = customer.getName();
            lblName.Location = new Point(63, 175);

            lblAddress.Font = new Font("Open Sans", 9.75f, FontStyle.Bold);
            lblAddress.AutoSize = true;
            lblAddress.Text = "Adresa de livrare";
            lblAddress.Location = new Point(63, 205);

            txtAddress.Location = new Point(66, 227);
            txtAddress.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            txtAddress.Size = new Size(338, 25);

            pctTruck.IconChar = IconChar.Truck;
            pctTruck.IconSize = 27;
            pctTruck.Location = new Point(67, 272);
            pctTruck.SendToBack();

            lblEmag.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblEmag.AutoSize = true;
            lblEmag.Text = "Comanda livrata de eMAG";
            lblEmag.Location = new Point(90, 275);

            lblProds.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblProds.AutoSize = true;

            if (prodNr == 1)
                lblProds.Text = "(1 produs)";
            else
            {
                lblProds.Text = String.Format("({0} produse)", prodNr.ToString());
            }

            lblProds.Location = new Point(250, 275);


            cbxDelivery.Location = new Point(88, 305);
            cbxDelivery.Checked = false;
            cbxDelivery.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            cbxDelivery.Text = "Livrare standard\nEstimat livrare: 2 - 4 zile lucratoare\n(15 Lei)";
            cbxDelivery.AutoSize = false;
            cbxDelivery.Size = new Size(243, 61);
            cbxDelivery.BringToFront();

            pctSep2.SizeMode = PictureBoxSizeMode.StretchImage;
            pctSep2.ImageLocation = Application.StartupPath + @"\images\sep.png";
            pctSep2.Location = new Point(-41, 336);
            pctSep2.Size = new Size(940, 82);
            pctSep2.SendToBack();

            btnAdd.Location = new Point(66, 394);
            btnAdd.Size = new Size(97, 32);
            btnAdd.IconChar = IconChar.Plus;
            btnAdd.IconColor = Color.FromArgb(23, 99, 170);
            btnAdd.ImageAlign = ContentAlignment.BottomLeft;
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            btnAdd.Text = "adauga";
            btnAdd.IconSize = 20;

            txtAddress.TextChanged += new EventHandler((s, e) => txtAddress_TextChanged(s, e, customer, control));
        }

        private void init()
        {

            lblDetails = new Label();
            pnlDelivery = new Panel();
            pctOne = new PictureBox();
            lblDelivery = new Label();
            cbxCourier = new CheckBox();
            pctSep1 = new PictureBox();
            lblPerson = new Label();
            lblName = new Label();
            lblAddress = new Label();
            txtAddress = new TextBox();
            pctTruck = new IconPictureBox();
            lblEmag = new Label();
            lblProds = new Label();
            cbxDelivery = new CheckBox();
            pctSep2 = new PictureBox();
            btnAdd = new IconButton();

            lblDetails.Parent = this;
            pnlDelivery.Parent = this;

            pctOne.Parent = pnlDelivery;
            lblDelivery.Parent = pnlDelivery;
            cbxCourier.Parent = pnlDelivery;
            pctSep1.Parent = pnlDelivery;
            lblPerson.Parent = pnlDelivery;
            lblName.Parent = pnlDelivery;
            lblAddress.Parent = pnlDelivery;
            txtAddress.Parent = pnlDelivery;
            pctTruck.Parent = pnlDelivery;
            lblEmag.Parent = pnlDelivery;
            lblProds.Parent = pnlDelivery;
            cbxDelivery.Parent = pnlDelivery;
            pctSep2.Parent = pnlDelivery;
            btnAdd.Parent = pnlDelivery;




        }

        private void txtAddress_TextChanged(object sender, EventArgs e, Customer cust, ControllerCustomers ctr)
        {



            if (String.IsNullOrWhiteSpace(txtAddress.Text))
                cust.setAddress("none");
            else
            {
                cust.setAddress(txtAddress.Text);
            }

            ctr.save();

        }
    }
}
