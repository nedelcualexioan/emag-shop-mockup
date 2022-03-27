using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace view
{
    public class ViewEmptyCart : Panel
    {

        private Label lblCart;
        private Label lblInfo;
        private Button btnReturn;

        public event EventHandler returnClick = delegate { };
        public ViewEmptyCart(Form par)
        {
            this.Parent = par;
            this.Location = new Point(0, 60);
            this.Width = par.Width;
            this.Height = 950;
            this.BackColor = SystemColors.Control;
            this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\images\pattern.png");

            init();

            this.lblCart.AutoSize = false;
            this.lblCart.Top = 327;
            this.lblCart.Font = new Font("Open Sans", 22, FontStyle.Regular);
            this.lblCart.Text = "Cosul tau este gol";
            this.lblCart.Size = new Size(lblCart.Parent.Width, 44);
            this.lblCart.TextAlign = ContentAlignment.MiddleCenter;
            this.lblCart.BackColor = Color.Transparent;
            
            this.lblInfo.AutoSize = false;
            this.lblInfo.Top = 399;
            this.lblInfo.Font = new Font("Open Sans", 11.25f, FontStyle.Regular);
            this.lblInfo.Text = "Pentru a adauga produse in cos\nte rugam sa te intorci in magazin.";
            this.lblInfo.Size = new Size(lblInfo.Parent.Width, 49);
            this.lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            this.lblInfo.BackColor = Color.Transparent;

            this.btnReturn.Size = new Size(171, 36);
            this.btnReturn.Top = 460;
            this.btnReturn.Left = (btnReturn.Parent.Width - btnReturn.Width) / 2;
            this.btnReturn.Font = new Font("Open Sans", 11.25f, FontStyle.Regular);
            this.btnReturn.BackColor = Color.FromArgb(0, 94, 184);
            this.btnReturn.Text = "Intoarce-te in magazin";
            this.btnReturn.ForeColor = Color.White;
            this.btnReturn.Cursor = Cursors.Hand;

            this.btnReturn.Click += new EventHandler(btnReturn_Click);
        }

        private void init()
        {
            lblCart = new Label();
            lblInfo = new Label();
            btnReturn = new Button();

            lblCart.Parent = this;
            lblInfo.Parent = this;
            btnReturn.Parent = this;
        }

        private void btnReturn_Click(object sender,EventArgs e)
        {
            returnClick(this, null);
        }
    }
}
