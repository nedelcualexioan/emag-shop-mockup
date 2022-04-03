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
    public class ViewSummary : Panel
    {

        private Label lblSummary;

        private Panel pnlContainer;

        private Panel pnlDelivery;
        private IconPictureBox pctChk1;
        private Label lblDeliv;
        private Button btnModify1;
        private Label lblSep1;
        private Label lblCourier;
        private Label lblName;
        private Label lblAddress;

        private Panel pnlData;
        private IconPictureBox pctChk2;
        private Label lblData;
        private Button btnModify2;
        private Label lblSep2;
        private Label lblPerson;
        private Label lblNam;
        private Label lblAddr;

        private Panel pnlPayment;
        private IconPictureBox pctChk3;
        private Label lblPayment;
        private Label lblSep3;
        private Button btnModify3;
        private Label lblMethod;
        private Label lblInfo;

        public ViewSummary(Form par, Customer customer, String method, String info)
        {
            this.Parent = par;
            this.Location = new Point(0, 98);
            this.Width = this.Parent.Width;
            this.Height = this.Parent.Height - 98;
            this.BackColor = SystemColors.Control;

            init();

            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Open Sans", 20.25f, FontStyle.Regular);
            lblSummary.Text = "Sumar comanda";
            lblSummary.Location = new Point(284, 25);

            pnlContainer.Size = new Size(1170, 557);
            pnlContainer.Location = new Point(291, 67);
            pnlContainer.BackColor = Color.FromArgb(228, 241, 249);

            pnlDelivery.Size = new Size(373, 179);
            pnlDelivery.Location = new Point(18, 18);
            pnlDelivery.BackColor = Color.White;

            pctChk1.IconChar = IconChar.CheckCircle;
            pctChk1.IconSize = 32;
            pctChk1.Size = new Size(32, 32);
            pctChk1.Location = new Point(28, 21);

            lblDeliv.AutoSize = true;
            lblDeliv.Font = new Font("Open Sans", 15.75f, FontStyle.Regular);
            lblDeliv.Text = "Modalitate livrare";
            lblDeliv.Location = new Point(63, 17);

            btnModify1.Size = new Size(84, 32);
            btnModify1.Location = new Point(267, 20);
            btnModify1.Font = new Font("Open Sans", 8.25f, FontStyle.Bold);
            btnModify1.ForeColor = Color.FromArgb(46, 118, 183);
            btnModify1.Text = "modifica";

            lblSep1.AutoSize = false;
            lblSep1.Text = String.Empty;
            lblSep1.Size = new Size(330, 1);
            lblSep1.Location = new Point(21, 56);
            lblSep1.BorderStyle = BorderStyle.FixedSingle;

            lblCourier.AutoSize = true;
            lblCourier.Font = new Font("Open Sans", 11.25f, FontStyle.Bold);
            lblCourier.Text = "Livrare prin curier";
            lblCourier.Location = new Point(17, 69);

            lblName.AutoSize = true;
            lblName.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblName.Text = customer.getName();
            lblName.Location = new Point(17, 107);

            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Open Sans", 9.25f, FontStyle.Regular);
            lblAddress.Text = customer.getAddress();
            lblAddress.Location = new Point(17, 129);

            pnlData.Size = new Size(375, 179);
            pnlData.Location = new Point(397, 18);
            pnlData.BackColor = Color.White;

            pctChk2.IconChar = IconChar.CheckCircle;
            pctChk2.IconSize = 32;
            pctChk2.Size = new Size(32, 32);
            pctChk2.Location = new Point(28, 21);

            lblData.AutoSize = true;
            lblData.Font = new Font("Open Sans", 15.75f, FontStyle.Bold);
            lblData.Text = "Date facturare";
            lblData.Location = new Point(63, 17);

            btnModify2.Font = new Font("Open Sans", 8.25f, FontStyle.Bold);
            btnModify2.Size = new Size(84, 32);
            btnModify2.Location = new Point(267, 20);
            btnModify2.Text = "modifica";
            btnModify2.ForeColor = Color.FromArgb(46, 118, 183);

            lblSep2.AutoSize = false;
            lblSep2.Size = new Size(330, 1);
            lblSep2.Location = new Point(21, 56);
            lblSep2.Text = String.Empty;
            lblSep2.BorderStyle = BorderStyle.FixedSingle;

            lblPerson.AutoSize = true;
            lblPerson.Font = new Font("Open Sans", 11.25f, FontStyle.Bold);
            lblPerson.Text = "Persoana fizica";
            lblPerson.Location = new Point(17, 69);

            lblNam.AutoSize = true;
            lblNam.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblNam.Text = customer.getName();
            lblNam.Location = new Point(17, 107);

            lblAddr.AutoSize = true;
            lblAddr.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblAddr.Text = customer.getAddress() + "\n" + customer.getEmail();
            lblAddr.Location = new Point(17, 129);

            pnlPayment.Size = new Size(375, 179);
            pnlPayment.Location = new Point(778, 18);
            pnlPayment.BackColor = Color.White;


            pctChk3.IconChar = IconChar.CheckCircle;
            pctChk3.IconSize = 32;
            pctChk3.Size = new Size(32, 32);
            pctChk3.Location = new Point(21, 21);

            lblPayment.AutoSize = true;
            lblPayment.Font = new Font("Open Sans", 15.75f, FontStyle.Bold);
            lblPayment.Text = "Modalitate de plata";
            lblPayment.Location = new Point(59, 20);

            btnModify3.Font = new Font("Open Sans", 8.25f, FontStyle.Bold);
            btnModify3.Size = new Size(84, 32);
            btnModify3.Location = new Point(278, 20);
            btnModify3.Text = "modifica";
            btnModify3.ForeColor = Color.FromArgb(46, 118, 183);
            btnModify3.BringToFront();

            lblSep3.AutoSize = false;
            lblSep3.Size = new Size(340, 1);
            lblSep3.Location = new Point(19, 56);
            lblSep3.Text = String.Empty;
            lblSep3.BorderStyle = BorderStyle.FixedSingle;

            lblMethod.AutoSize = true;
            lblMethod.Font = new Font("Open Sans", 11.25f, FontStyle.Bold);
            lblMethod.Text = method;
            lblMethod.Location = new Point(17, 69);

            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblInfo.Text = info;
            lblInfo.Location = new Point(17, 107);

        }

        private void init()
        {
            lblSummary = new Label();

            pnlContainer = new Panel();

            pnlDelivery = new Panel();
            pctChk1 = new IconPictureBox();
            lblDeliv = new Label();
            btnModify1 = new Button();
            lblSep1 = new Label();
            lblCourier = new Label();
            lblName = new Label();
            lblAddress = new Label();

            pnlData = new Panel();
            pctChk2 = new IconPictureBox();
            lblData = new Label();
            btnModify2 = new Button();
            lblSep2 = new Label();
            lblPerson = new Label();
            lblNam = new Label();
            lblAddr = new Label();


            pnlPayment = new Panel();
            pctChk3 = new IconPictureBox();
            lblPayment = new Label();
            lblSep3 = new Label();
            btnModify3 = new Button();
            lblMethod = new Label();
            lblInfo = new Label();

            pnlContainer.Parent = this;

            lblSummary.Parent = this;

            pnlDelivery.Parent = pnlContainer;
            pctChk1.Parent = pnlDelivery;
            lblDeliv.Parent = pnlDelivery;
            btnModify1.Parent = pnlDelivery;
            lblSep1.Parent = pnlDelivery;
            lblCourier.Parent = pnlDelivery;
            lblName.Parent = pnlDelivery;
            lblAddress.Parent = pnlDelivery;

            pnlData.Parent = pnlContainer;
            pctChk2.Parent = pnlData;
            lblData.Parent = pnlData;
            btnModify2.Parent = pnlData;
            lblSep2.Parent = pnlData;
            lblPerson.Parent = pnlData;
            lblNam.Parent = pnlData;
            lblAddr.Parent = pnlData;

            pnlPayment.Parent = pnlContainer;
            pctChk3.Parent = pnlPayment;
            lblPayment.Parent = pnlPayment;
            lblSep3.Parent = pnlPayment;
            btnModify3.Parent = pnlPayment;
            lblMethod.Parent = pnlPayment;
            lblInfo.Parent = pnlPayment;


        }

    }
}
