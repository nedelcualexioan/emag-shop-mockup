using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FontAwesome.Sharp;
using System.Text.RegularExpressions;
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
        private Label sep1;
        private Label lblPerson;
        private Label lblName;
        private Label lblAddress;
        private Label lblAddr;
        private IconPictureBox pctTruck;
        private Label lblEmag;
        private Label lblProds;
        private CheckBox cbxDelivery;
        private Label sep2;
        private IconButton btnAdd;

        private AddAddress add;

        private Panel pnlPayment;
        private PictureBox pctTwo;
        private Label lblPayMet;
        private Panel pnlInfo;
        private IconPictureBox pctInfo;
        private Label lblInfo;
        private IconPictureBox pctMaster;
        private IconPictureBox pctVisa;

        private CheckedListBox clbMethod;
        private Label lblFee;

        private Panel pnlSummary;
        private Label lblSummary;

        private Label lblProd;
        private Label lblDeliv;
        private Label lblProc;

        private Label lblProdPrice;
        private Label lblDelivPrice;
        private Label lblProcPrice;

        private Label lblTotal;
        private Label lblTotalPr;
        private PictureBox pctNext;

        private Label sep3;

        private Panel pnlFooter;

        private Label lblAtEmag;

        private IconPictureBox pctOpen;
        private Label lblOpen;
        private Label lblOpenA;

        private IconPictureBox pctSupport;
        private Label lblSupport;
        private Label lblSupportA;

        private IconPictureBox pctReturn;
        private Label lblReturn;
        private Label lblReturnA;

        private IconPictureBox pctSafe;
        private Label lblSafe;
        private Label lblSafeA;


        public event EventHandler nextClick = delegate { };


        public ViewOrderDet(Form par, Customer customer, int prodNr, int price, ControllerCustomers control)
        {

            this.Parent = par;

            this.Location = new Point(0, 98);
            this.Width = par.Width;
            this.Height = par.Height - 98;
            this.BackColor = SystemColors.Control;

            add = new AddAddress(customer, control);

            init();

            this.AutoScroll = true;

            pnlDelivery.BackColor = Color.FromArgb(228, 241, 249);
            pnlDelivery.Location = new Point(210, 42);
            pnlDelivery.Size = new Size(870, 409);
            pnlDelivery.BorderStyle = BorderStyle.FixedSingle;

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

            sep1.Location = new Point(0, 114);
            sep1.Size = new Size(870, 1);
            sep1.Text = String.Empty;
            sep1.BorderStyle = BorderStyle.FixedSingle;

            lblPerson.Font = new Font("Open Sans", 9.75f, FontStyle.Bold);
            lblPerson.AutoSize = true;
            lblPerson.Text = "Persoana de contact";
            lblPerson.Location = new Point(63, 129);

            lblName.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblName.AutoSize = true;
            lblName.Text = customer.getName();
            lblName.Location = new Point(63, 148);

            lblAddress.Font = new Font("Open Sans", 9.75f, FontStyle.Bold);
            lblAddress.AutoSize = true;
            lblAddress.Text = "Adresa de livrare";
            lblAddress.Location = new Point(63, 178);

            lblAddr.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblAddr.AutoSize = true;
            if (customer.getAddress().Equals("none") == false)
            {
                lblAddr.Text = customer.getAddress();
            }
            else
            {
                lblAddr.Text = "Nicio adresa setata";
            }
            lblAddr.Location = new Point(63, 200);

            pctTruck.IconChar = IconChar.Truck;
            pctTruck.IconSize = 27;
            pctTruck.Location = new Point(67, 245);
            pctTruck.SendToBack();

            lblEmag.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblEmag.AutoSize = true;
            lblEmag.Text = "Comanda livrata de eMAG";
            lblEmag.Location = new Point(90, 248);

            lblProds.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblProds.AutoSize = true;

            if (prodNr == 1)
                lblProds.Text = "(1 produs)";
            else
            {
                lblProds.Text = String.Format("({0} produse)", prodNr.ToString());
            }

            lblProds.Location = new Point(250, 248);


            cbxDelivery.Location = new Point(88, 278);
            cbxDelivery.Checked = false;
            cbxDelivery.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            cbxDelivery.Text = "Livrare standard\nEstimat livrare: 2 - 4 zile lucratoare\n(15 Lei)";
            cbxDelivery.AutoSize = false;
            cbxDelivery.Size = new Size(243, 61);
            cbxDelivery.BringToFront();

            sep2.Location = new Point(0, 348);
            sep2.Size = new Size(870, 1);
            sep2.BorderStyle = BorderStyle.FixedSingle;
            sep2.Text = String.Empty;

            btnAdd.Location = new Point(66, 359);
            btnAdd.Size = new Size(97, 32);
            btnAdd.IconChar = IconChar.Plus;
            btnAdd.IconColor = Color.FromArgb(23, 99, 170);
            btnAdd.ImageAlign = ContentAlignment.BottomLeft;
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            btnAdd.Text = "adauga";
            btnAdd.IconSize = 20;


            pnlPayment.BackColor = Color.FromArgb(228, 241, 249);
            pnlPayment.Top = pnlDelivery.Top + 429;
            pnlPayment.Size = new Size(870, 245);
            pnlPayment.Left = pnlDelivery.Left;
            pnlPayment.BorderStyle = BorderStyle.FixedSingle;

            pctTwo.ImageLocation = Application.StartupPath + @"\images\circle2.png";
            pctTwo.SizeMode = PictureBoxSizeMode.StretchImage;
            pctTwo.Location = new Point(66, 32);
            pctTwo.Size = new Size(37, 35);

            lblPayMet.Font = new Font("Open Sans", 15.75f, FontStyle.Regular);
            lblPayMet.AutoSize = true;
            lblPayMet.Text = "Modalitate de plata";
            lblPayMet.Location = new Point(110, 33);

            pnlInfo.BackColor = Color.FromArgb(251, 252, 253);
            pnlInfo.Location = new Point(16, 85);
            pnlInfo.Size = new Size(837, 52);


            pctInfo.IconChar = IconChar.InfoCircle;
            pctInfo.IconColor = Color.FromArgb(121, 167, 204);
            pctInfo.IconSize = 42;
            pctInfo.Size = new Size(46, 42);
            pctInfo.Location = new Point(3, 7);
            pctInfo.BringToFront();

            lblInfo.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblInfo.AutoSize = false;
            lblInfo.Size = new Size(499, 51);
            lblInfo.Text = "Achită cu card Mastercard sau Maestro și poți câștiga un Card Cadou de 500 de lei!";

            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblInfo.Location = new Point(54, 0);
            

            pctMaster.IconChar = IconChar.CcMastercard;
            pctMaster.IconColor = Color.OrangeRed;
            pctMaster.IconSize = 72;
            pctMaster.Size = new Size(76, 72);
            pctMaster.Location = new Point(658, -5);

            pctVisa.IconChar = IconChar.CcVisa;
            pctVisa.IconColor = Color.DarkBlue;
            pctVisa.IconSize = 72;
            pctVisa.Size = new Size(104, 72);
            pctVisa.Location = new Point(728, -5);


            clbMethod.Size = new Size(833, 69);
            clbMethod.Location = new Point(16, 163);
            clbMethod.SelectionMode = SelectionMode.One;
            clbMethod.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            clbMethod.Items.Add("Card online - Platesti imediat, fără costuri suplimentare.");
            clbMethod.Items.Add("Ramburs la curier - Vei plati in momentul in care comanda va fi livrata.");

            lblFee.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblFee.AutoSize = true;
            lblFee.Text = "(5,00 Lei reprezintă costul pentru procesarea plății la livrare. Plata online cu cardul este gratuită)";
            lblFee.Location = new Point(36, 204);
            lblFee.BringToFront();
            lblFee.BackColor = clbMethod.BackColor;

            pnlSummary.BackColor = Color.White;
            pnlSummary.Location = new Point(pnlPayment.Left, pnlPayment.Top + 262);
            pnlSummary.Size = new Size(870, 167);
            pnlSummary.BorderStyle = BorderStyle.Fixed3D;

            lblSummary.Font = new Font("Open Sans", 15.75f, FontStyle.Regular);
            lblSummary.AutoSize = true;
            lblSummary.Text = "Sumar comanda";
            lblSummary.Location = new Point(29, 17);


            lblProd.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblProd.AutoSize = true;
            lblProd.Text = "Cost produse";
            lblProd.Location = new Point(32, 62);

            lblDeliv.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblDeliv.AutoSize = true;
            lblDeliv.Text = "Cost livrare:";
            lblDeliv.Location = new Point(32, 84);

            lblProc.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblProc.AutoSize = true;
            lblProc.Text = "Cost procesare plata";
            lblProc.Location = new Point(32, 107);

            lblProdPrice.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblProdPrice.AutoSize = false;
            lblProdPrice.Size = new Size(92, 19);
            lblProdPrice.TextAlign = ContentAlignment.MiddleRight;
            lblProdPrice.Text = price + " Lei";
            lblProdPrice.Location = new Point(394, 62);

            lblDelivPrice.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblDelivPrice.AutoSize = false;
            lblDelivPrice.Size = new Size(92, 19);
            lblDelivPrice.TextAlign = ContentAlignment.MiddleRight;
            lblDelivPrice.Text = "15 Lei";
            lblDelivPrice.Location = new Point(394, 84);

            lblProcPrice.Font = new Font("OpenSans", 9.75f, FontStyle.Regular);
            lblProcPrice.AutoSize = false;
            lblProcPrice.Size = new Size(92, 19);
            lblProcPrice.TextAlign = ContentAlignment.MiddleRight;
            lblProcPrice.Text = "5 Lei";
            lblProcPrice.Location = new Point(394, 107);

            sep3.Text = String.Empty;
            sep3.Size = new Size(1, 123);
            sep3.Location = new Point(541, 20);
            sep3.BorderStyle = BorderStyle.FixedSingle;

            lblTotal.Font = new Font("Open Sans", 15.75f, FontStyle.Bold);
            lblTotal.AutoSize = true;
            lblTotal.Text = "Total:";
            lblTotal.Location = new Point(575, 30);

            lblTotalPr.Font = new Font("Open Sans", 20.25f, FontStyle.Bold);
            lblTotalPr.AutoSize = true;
            lblTotalPr.Text = (int.Parse(Regex.Replace(lblProdPrice.Text, "[^0-9]+", String.Empty)) + int.Parse(Regex.Replace(lblDelivPrice.Text, "[^0-9]+", String.Empty))).ToString();
            lblTotalPr.Text = (int.Parse(lblTotalPr.Text) + int.Parse(Regex.Replace(lblProcPrice.Text, "[^0-9]+", String.Empty))).ToString() + " Lei";
            lblTotalPr.Location = new Point(574, 61);

            pctNext.ImageLocation = Application.StartupPath + @"\images\next.png";
            pctNext.SizeMode = PictureBoxSizeMode.Normal;
            pctNext.Size = new Size(272, 40);
            pctNext.Location = new Point(577, 103);
            pctNext.Cursor = Cursors.Hand;

            pnlFooter.BackColor = Color.White;
            pnlFooter.Size = new Size(this.Width, 170);
            pnlFooter.Location = new Point(0, pnlSummary.Top + pnlSummary.Height + 20);

            lblAtEmag.Font = new Font("Open Sans", 9.75f, FontStyle.Bold);
            lblAtEmag.AutoSize = true;
            lblAtEmag.Text = "La eMAG te bucuri de:";
            lblAtEmag.Location = new Point(284, 11);
            lblAtEmag.ForeColor = SystemColors.ControlDarkDark;

            pctOpen.IconChar = IconChar.BoxOpen;
            pctOpen.IconSize = 51;
            pctOpen.Size = new Size(56, 51);
            pctOpen.Location = new Point(285, 45);
            pctOpen.IconColor = SystemColors.ControlDarkDark;

            lblOpen.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblOpen.AutoSize = true;
            lblOpen.Text = "Deschiderea coletului la livrare";
            lblOpen.Location = new Point(352, 48);

            lblOpenA.Font = new Font("Open Sans", 8.25f, FontStyle.Regular);
            lblOpenA.AutoSize = true;
            lblOpenA.Text = "pentru produsele vandute de eMAG";
            lblOpenA.Location = new Point(353, 69);

            pctSupport.IconChar = IconChar.Headset;
            pctSupport.IconSize = 51;
            pctSupport.Size = new Size(56, 51);
            pctSupport.Location = new Point(611, 45);
            pctSupport.IconColor = SystemColors.ControlDarkDark;

            lblSupport.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblSupport.AutoSize = true;
            lblSupport.Text = "Suport 24/7";
            lblSupport.Location = new Point(694, 48);

            lblSupportA.Font = new Font("Open Sans", 8.25f, FontStyle.Regular);
            lblSupportA.AutoSize = true;
            lblSupportA.Text = "Operatorii nostri sunt gata sa-ti raspunda";
            lblSupportA.Location = new Point(695, 69);

            pctReturn.IconChar = IconChar.Box;
            pctReturn.IconSize = 51;
            pctReturn.Size = new Size(56, 51);
            pctReturn.Location = new Point(966, 45);
            pctReturn.IconColor = SystemColors.ControlDarkDark;

            lblReturn.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblReturn.AutoSize = true;
            lblReturn.Text = "30 de zile drept de retur";
            lblReturn.Location = new Point(1028, 48);

            lblReturnA.Font = new Font("Open Sans", 8.25f, FontStyle.Regular);
            lblReturnA.AutoSize = true;
            lblReturnA.Text = "pentru produsele vandute de eMAG";
            lblReturnA.Location = new Point(1029, 69);

            pctSafe.IconChar = IconChar.Lock;
            pctSafe.IconSize = 51;
            pctSafe.Size = new Size(56, 51);
            pctSafe.Location = new Point(1284, 45);
            pctSafe.IconColor = SystemColors.ControlDarkDark;

            lblSafe.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblSafe.AutoSize = true;
            lblSafe.Text = "Comenzi si plati 100% sigure";
            lblSafe.Location = new Point(1345, 48);

            lblSafeA.Font = new Font("Open Sans", 8.25f, FontStyle.Regular);
            lblSafeA.AutoSize = true;
            lblSafeA.Text = "Toate datele sunt transmise securizat";
            lblSafeA.Location = new Point(1346, 69);



            clbMethod.ItemCheck += new ItemCheckEventHandler(clbMethod_ItemCheck);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            add.add += btnSave_Click;

            pctNext.Click += new EventHandler(pctNext_Click);
        }

        private void init()
        {

            lblDetails = new Label();
            pnlDelivery = new Panel();
            pctOne = new PictureBox();
            lblDelivery = new Label();
            cbxCourier = new CheckBox();
            sep1 = new Label();
            lblPerson = new Label();
            lblName = new Label();
            lblAddress = new Label();
            lblAddr = new Label();
            pctTruck = new IconPictureBox();
            lblEmag = new Label();
            lblProds = new Label();
            cbxDelivery = new CheckBox();
            sep2 = new Label();
            btnAdd = new IconButton();
            pnlPayment = new Panel();
            pctTwo = new PictureBox();
            lblPayMet = new Label();
            pnlInfo = new Panel();
            pctInfo = new IconPictureBox();
            lblInfo = new Label();
            pctMaster = new IconPictureBox();
            pctVisa = new IconPictureBox();
            clbMethod = new CheckedListBox();
            lblFee = new Label();
            pnlSummary = new Panel();
            lblSummary = new Label();
            lblProd = new Label();
            lblDeliv = new Label();
            lblProc = new Label();
            lblProdPrice = new Label();
            lblDelivPrice = new Label();
            lblProcPrice = new Label();
            sep3 = new Label();
            lblTotal = new Label();
            lblTotalPr = new Label();
            pctNext = new PictureBox();
            

            lblDetails.Parent = this;
            pnlDelivery.Parent = this;

            pctOne.Parent = pnlDelivery;
            lblDelivery.Parent = pnlDelivery;
            cbxCourier.Parent = pnlDelivery;
            sep1.Parent = pnlDelivery;
            lblPerson.Parent = pnlDelivery;
            lblName.Parent = pnlDelivery;
            lblAddress.Parent = pnlDelivery;
            lblAddr.Parent = pnlDelivery;
            pctTruck.Parent = pnlDelivery;
            lblEmag.Parent = pnlDelivery;
            lblProds.Parent = pnlDelivery;
            cbxDelivery.Parent = pnlDelivery;
            sep2.Parent = pnlDelivery;
            btnAdd.Parent = pnlDelivery;

            pnlPayment.Parent = this;

            pctTwo.Parent = pnlPayment;
            lblPayMet.Parent = pnlPayment;
            pnlInfo.Parent = pnlPayment;

            pctInfo.Parent = pnlInfo;
            lblInfo.Parent = pnlInfo;
            pctMaster.Parent = pnlInfo;
            pctVisa.Parent = pnlInfo;
            clbMethod.Parent = pnlPayment;
            lblFee.Parent = pnlPayment;

            pnlSummary.Parent = this;

            lblSummary.Parent = pnlSummary;
            lblProd.Parent = pnlSummary;
            lblDeliv.Parent = pnlSummary;
            lblProc.Parent = pnlSummary;
            lblProdPrice.Parent = pnlSummary;
            lblDelivPrice.Parent = pnlSummary;
            lblProcPrice.Parent = pnlSummary;
            sep3.Parent = pnlSummary;
            lblTotal.Parent = pnlSummary;
            lblTotalPr.Parent = pnlSummary;
            pctNext.Parent = pnlSummary;

            pnlFooter = new Panel();
            pnlFooter.Parent = this;

            lblAtEmag = new Label();
            pctOpen = new IconPictureBox();
            lblOpen = new Label();
            lblOpenA = new Label();
            pctSupport = new IconPictureBox();
            lblSupport = new Label();
            lblSupportA = new Label();
            pctReturn = new IconPictureBox();
            lblReturn = new Label();
            lblReturnA = new Label();
            pctSafe = new IconPictureBox();
            lblSafe = new Label();
            lblSafeA = new Label();

            lblAtEmag.Parent = pnlFooter;
            pctOpen.Parent = pnlFooter;
            lblOpen.Parent = pnlFooter;
            lblOpenA.Parent = pnlFooter;
            pctSupport.Parent = pnlFooter;
            lblSupport.Parent = pnlFooter;
            lblSupportA.Parent = pnlFooter;
            pctReturn.Parent = pnlFooter;
            lblReturn.Parent = pnlFooter;
            lblReturnA.Parent = pnlFooter;
            pctSafe.Parent = pnlFooter;
            lblSafe.Parent = pnlFooter;
            lblSafeA.Parent = pnlFooter;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            add.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblName.Text = add.getName();
            lblAddr.Text = add.getAddress();
        }

        private void clbMethod_ItemCheck(object sender,ItemCheckEventArgs e)
        {
            for(int i = 0; i < clbMethod.Items.Count; i++)
            {
                if (i != e.Index)  
                {
                    clbMethod.SetItemChecked(i, false);
                }
            }

            if(clbMethod.Items[e.Index].ToString().Contains("Card") == true)
            {
                pnlSummary.Size = new Size(870, 134);

                lblProc.Hide();
                lblProcPrice.Hide();

                sep3.Size = new Size(1, 109);
                sep3.Top = 12;

                lblTotal.Location = new Point(575, 6);
                lblTotalPr.Location = new Point(574, 37);
                pctNext.Location = new Point(577, 79);

                lblTotalPr.Text = (int.Parse(Regex.Replace(lblProdPrice.Text, "[^0-9]+", String.Empty)) + int.Parse(Regex.Replace(lblDelivPrice.Text, "[^0-9]+", String.Empty))).ToString() + " Lei";
            }
            else
            {
                pnlSummary.Size = new Size(870, 167);

                lblProc.Show();
                lblProcPrice.Show();

                sep3.Size = new Size(1, 123);
                sep3.Top = 20;

                lblTotal.Location = new Point(575, 30);
                lblTotalPr.Location = new Point(574, 61);
                pctNext.Location = new Point(577, 103);


                lblTotalPr.Text = (int.Parse(Regex.Replace(lblProdPrice.Text, "[^0-9]+", String.Empty)) + int.Parse(Regex.Replace(lblDelivPrice.Text, "[^0-9]+", String.Empty)) + 5).ToString() + " Lei";
            }
        }

        public bool isChecked()
        {
            for(int i = 0; i < clbMethod.Items.Count; i++)
            {
                if (clbMethod.GetItemChecked(i) == true)
                    return true;
            }
            return false;
        }

        private void pctNext_Click(object sender,EventArgs e)
        {
            nextClick(this, null);
        }
    }
}
