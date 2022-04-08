using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using emag;

namespace view
{
    public class OrderCard : Panel
    {

        private Label lblOrder;
        private Label lblEmag;
        private Label lblPrice;
        private Label lblSepa;
        private Label lblDeliv;

        public OrderCard(Panel par, Point p, ViewCart cart)
        {
            this.Size = new Size(200, 228);
            this.Location = p;
            this.AutoScroll = true;

            lblOrder = new Label();
            lblEmag = new Label();
            lblPrice = new Label();
            lblSepa = new Label();
            lblDeliv = new Label();


            lblOrder.Parent = this;
            lblEmag.Parent = this;
            lblPrice.Parent = this;
            lblSepa.Parent = this;
            lblDeliv.Parent = this;

            lblOrder.AutoSize = false;
            lblOrder.Location = new Point(0, 10);
            lblOrder.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblOrder.Width = this.Width;
            lblOrder.TextAlign = ContentAlignment.MiddleCenter;

            lblEmag.AutoSize = true;
            lblEmag.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblEmag.Text = "Produse vandute si\nlivrate de eMAG";
            lblEmag.Location = new Point(0, 46);

            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
            lblPrice.Text = "Subtotal: " + cart.getAmmount();
            lblPrice.Location = new Point(0, 93);

            lblSepa.AutoSize = false;
            lblSepa.Size = new Size(this.Width, 1);
            lblSepa.Location = new Point(0, 115);
            lblSepa.Text = String.Empty;
            lblSepa.BorderStyle = BorderStyle.FixedSingle;
        }

        public void populate(ViewCart cart)
        {
            List<ProdCart> list = cart.getList();

            int y = 125;

            foreach(ProdCart c in list)
            {
                Label prod = new Label();

                prod.AutoSize = false;
                prod.Size = new Size(this.Width, 41);
                prod.Font = new Font("Open Sans", 9.75f, FontStyle.Regular);
                prod.Text = c.getPr() + " - " + c.getPrice() + " x " + c.getQuant() + " buc";
                prod.Location = new Point(0, y);


                y += 41;
            }
        }

    }
}
