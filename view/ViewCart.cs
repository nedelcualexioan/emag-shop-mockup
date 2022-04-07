using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using emag;
using System.Text.RegularExpressions;

namespace view
{
    public class ViewCart:Panel
    {

        private Label lblCart;
        private Label lblEmag;
            

        private Panel pnlSum;
        private Label lblSum;
        private Label lblCost;
        private Label lblSumPr;
        private Label lblDeliv;
        private Label lblDelivPr;

        private PictureBox pctSepa;
        private Label lblTotal;
        private Label lblTotalPr;
        private PictureBox pctNext;

        private List<ProdCart> orders = new List<ProdCart>();
        private Panel containerOrders;



        private ControllerOrderDetails details;
        private ControllerProducts products;

        private int height = 34;

        private ProdCart sendDel;

        public event EventHandler detailsDel = delegate { };

        public event EventHandler nextClick = delegate { };

        public ViewCart(Form par)
        {
            this.Parent = par;
            this.Location = new Point(0, 98);
            this.Width = par.Width;
            this.Height = par.Height - 98;
            this.BackColor = Color.FromArgb(228, 241, 249);

            sendDel = new ProdCart();

            containerOrders = new Panel();
            details = new ControllerOrderDetails();
            products = new ControllerProducts();


            containerOrders.AutoScroll = false;
            containerOrders.VerticalScroll.Enabled = false;
            containerOrders.VerticalScroll.Visible = false;
            containerOrders.VerticalScroll.Maximum = 0;
            containerOrders.AutoScroll = true;

            containerOrders.Parent = this;
            containerOrders.Location = new Point(272, 85);
            containerOrders.Size = new Size(975, 700);


            init();


            this.lblCart.AutoSize = true;
            this.lblCart.Font = new Font("Open Sans", 22F, FontStyle.Regular);
            this.lblCart.Location = new Point(264, 0);
            this.lblCart.Size = new Size(168, 44);
            this.lblCart.Text = "Cosul meu";

            this.lblEmag.AutoSize = true;
            this.lblEmag.Font = new Font("Open Sans", 15.75F, FontStyle.Regular);
            this.lblEmag.Location = new Point(-6,0);
            this.lblEmag.Size = new Size(361, 31);
            this.lblEmag.Text = "Produse vandute si livrate de eMAG";

            


            

            this.pnlSum.BackColor = Color.White;
            this.pnlSum.Location = new Point(1267, 119);
            this.pnlSum.Size = new Size(280, 304);
            this.pnlSum.BorderStyle = BorderStyle.Fixed3D;

            lblSum.Parent = pnlSum;
            lblCost.Parent = pnlSum;
            lblSumPr.Parent = pnlSum;
            lblDeliv.Parent = pnlSum;
            lblDelivPr.Parent = pnlSum;
            lblTotal.Parent = pnlSum;
            lblTotalPr.Parent = pnlSum;
            pctNext.Parent = pnlSum;

            pnlSum.Controls.Add(this.pctSepa);

            this.lblSum.AutoSize = true;
            this.lblSum.Font = new Font("Open Sans", 15.75F, FontStyle.Bold);
            this.lblSum.Location = new Point(43, 28);
            this.lblSum.Size = new Size(189, 31);
            this.lblSum.Text = "Sumar comanda";

            this.lblCost.AutoSize = true;
            this.lblCost.Font = new Font("Open Sans", 12F,FontStyle.Regular);
            this.lblCost.Location = new Point(12, 80);
            this.lblCost.Size = new Size(116, 23);
            this.lblCost.Text = "Cost produse:";

            
            this.lblSumPr.AutoSize = true;
            this.lblSumPr.Font = new Font("Open Sans", 12F, FontStyle.Regular);
            this.lblSumPr.Location = new Point(197, 80);
            

            this.lblDeliv.AutoSize = true;
            this.lblDeliv.Font = new Font("Open Sans", 12F, FontStyle.Regular);
            this.lblDeliv.Location = new Point(12, 112);
            this.lblDeliv.Size = new Size(100, 23);
            this.lblDeliv.Text = "Cost livrare:";

            this.lblDelivPr.AutoSize = true;
            this.lblDelivPr.Font = new Font("Open Sans", 12F, FontStyle.Bold);
            this.lblDelivPr.ForeColor = Color.Green;
            this.lblDelivPr.Location = new Point(185, 112);
            this.lblDelivPr.Size = new Size(83, 23);
            this.lblDelivPr.Text = "GRATUIT";

            this.pctSepa.ImageLocation = Application.StartupPath + @"\images\line-sep.png";
            this.pctSepa.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pctSepa.Location = new Point(0,135);
            this.pctSepa.Size = new Size(280, 45);

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Open Sans", 15.75F, FontStyle.Bold);
            this.lblTotal.Location = new Point(10, 182);
            this.lblTotal.Size = new Size(75, 31);
            this.lblTotal.Text = "Total:";

            this.lblTotalPr.AutoSize = true;
            this.lblTotalPr.Font = new Font("Open Sans", 18.75F, FontStyle.Bold);
            this.lblTotalPr.Location = new Point(10, 212);
            this.lblTotalPr.Size = new Size(118, 36);

            this.pctNext.ImageLocation = Application.StartupPath + @"\images\continue.png";
            this.pctNext.Location = new Point(20, 253);
            this.pctNext.Size = new Size(241, 44);
            this.pctNext.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pctNext.Cursor = Cursors.Hand;

            this.pctNext.Click += new EventHandler(pctNext_Click);

        }

        private void init()
        {
            lblCart = new Label();
            lblEmag = new Label();
            pnlSum = new Panel();
            
            lblSum = new Label();
            lblCost = new Label();
            lblSumPr = new Label();
            lblDeliv = new Label();
            lblDelivPr = new Label();
            pctSepa = new PictureBox();
            lblTotal = new Label();
            lblTotalPr = new Label();
            pctNext = new PictureBox();

            lblCart.Parent = this;
            lblEmag.Parent = containerOrders;

            pnlSum.Parent = this;
            

        }

        public void add(Product p, String text, ViewFavorite fav, ControllerProducts prods)
        {

            ProdCart prod = new ProdCart(p, text, new Point(0, height), containerOrders);


            height += 312;

            int val = 0;

            if (String.IsNullOrWhiteSpace(lblSumPr.Text) == false)
            {
                val = int.Parse(Regex.Replace(lblSumPr.Text, @"[^0-9]+", String.Empty));
            }

            val += p.getPrice();

            lblSumPr.Text = val.ToString() + " Lei";
            
            lblTotalPr.Text = val.ToString() + " Lei";

            this.orders.Add(prod);

            prod.priceCh += cmbQuant_TextChanged;
            prod.delClick += lblDelete_Click;
            prod.lblMove += (s, e) => lblFav_Click(s, e, fav, prods);

            rearrange();
            
        }


        
        private void cmbQuant_TextChanged(object sender,EventArgs e)
        {
            foreach(ProdCart p in orders)
            {

                if (p == sender)
                {

                    int x = int.Parse(Regex.Replace(lblSumPr.Text, "[^0-9]+", String.Empty));

                    lblSumPr.Text = (x - (p.getLast() - p.getPrice())).ToString() + " Lei";
                    lblTotalPr.Text = (x - (p.getLast() - p.getPrice())).ToString() + " Lei";

                    return;
                }
               
            }


        }


        private void lblDelete_Click(object sender,EventArgs e)
        {



            foreach (ProdCart p in orders)
            {
                if (p == sender)
                {
                    orders.Remove(p);

                    int sum = int.Parse(Regex.Replace(lblSumPr.Text, @"[^0-9]+", String.Empty));

                    sum -= p.getPrice();

                    lblSumPr.Text = sum.ToString() + " Lei";
                    lblTotalPr.Text = sum.ToString() + " Lei";

                    sendDel = p;

                    break;
                }
            }

            containerOrders.Controls.Clear();


            this.lblEmag.Parent = containerOrders;
            this.lblEmag.Location = new Point(-6, 0);
           


            rearrange();

            

            detailsDel(this, null);

        }

        private void lblFav_Click(object sender,EventArgs e,ViewFavorite fav,ControllerProducts products)
        {

            

            foreach (ProdCart p in orders)
            {
                if (p == sender)
                {
                    orders.Remove(p);

                    int sum = int.Parse(Regex.Replace(lblSumPr.Text, @"[^0-9]+", String.Empty));

                    sum -= p.getPrice();

                    lblSumPr.Text = sum.ToString() + " Lei";
                    lblTotalPr.Text = sum.ToString() + " Lei";

                    sendDel = p;

                    fav.add(products.getProdPartial(p.getName()));

                    break;
                }
            }

            containerOrders.Controls.Clear();


            this.lblEmag.Parent = containerOrders;
            this.lblEmag.Location = new Point(-6, 0);



            rearrange();



            detailsDel(this, null);

            MessageBox.Show("Produsul a fost adaugat la favorite", "Actiune initiata cu succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void rearrange()
        {


            height = 34;

            foreach(ProdCart p in orders)
            {
                containerOrders.Size = new Size(975, 700);

                ProdCart aux = p;

                aux.Parent = containerOrders;

                aux.Location = new Point(0, height);

                height += 312;
            }

            
        }

        public ProdCart getSender()
        {
            return this.sendDel;
        }

        public bool isCart(Product p, String color)
        {
            foreach(ProdCart c in orders)
            {
                if (c.getName().Contains(p.getName()) && c.getName().Contains(color))
                {
                    return true;
                }
            }
            return false;
        }

        public int getCount()
        {
            return this.orders.Count;
        }

        public ProdCart getProdCart(Product p, String color)
        {
            foreach (ProdCart cart in orders)
            {
                if (cart.getName().Contains(p.getName()) && cart.getName().Contains(color))
                {
                    return cart;
                }
            }
            return null;
        }

        public ProdCart getProdCart(Product p)
        {
            foreach(ProdCart cart in orders)
            {
                if (cart.getName().Equals(p.getName()))
                    return cart;
            }
            return null;
        }
        public void setQuant (Product p, int val, String color)
        {
            foreach(ProdCart cart in orders)
            {
                if (cart.getName().Contains(p.getName()) && cart.getName().Contains(color))
                {
                    cart.setQuant(val);
                }
            }
        }
        public void setQuant(Product p, int val)
        {
            foreach (ProdCart cart in orders)
            {
                if (cart.getName().Equals(p.getName()))
                {
                    cart.setQuant(val);
                }
            }
        }

        public bool isEmpty()
        {
            foreach(Control c in containerOrders.Controls)
            {
                ProdCart pr = c as ProdCart;

                if (pr != null)
                {
                    if (pr.isEmpty())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void pctNext_Click(object sender,EventArgs e)
        {
            nextClick(this, null);
        }
        public void setPic(Product p, String path, String color)
        {
            foreach(Control c in containerOrders.Controls)
            {
                ProdCart prod = c as ProdCart;

                if (prod != null)
                {

                    if (prod.getProdName().Contains(p.getName()) && prod.getName().Contains(color))
                    {
                        prod.setImage(path);

                        break;
                    }
                }
            }
        }

        public void setPic(Product p)
        {
            foreach(Control c in containerOrders.Controls)
            {
                ProdCart prod = c as ProdCart;

                if (prod != null)
                {
                    if (prod.getProdName().Equals(p.getName()))
                    {
                        prod.setImage(Application.StartupPath + @"\images\" + p.getPicture());

                        break;
                    }
                }
            }
        }

        public int getAmmount()
        {
            return int.Parse(Regex.Replace(lblTotalPr.Text, "[^0-9]+", String.Empty));
        }

        public Panel getContainer()
        {
            return this.containerOrders;
        }

        public bool isCart(String s)
        {
            foreach (ProdCart c in orders)
            {
                if (c.getName().Contains(s))
                    return true;
            }
            return false;
        }

    /*   public void populateOrders(ControllerOrderDetails ctr)
        {
            this.lblSumPr.Text = String.Empty;
            this.lblTotalPr.Text = String.Empty;



            int x = 0, y = 34;


            for(int i = 0; i < ctr.getCount(); i++)
            {

                ProdCart prod = new ProdCart(products.getProductById(ctr.getOrderDetails(i).getProductId()), new Point(x, y));


                y += prod.Height + 8;

                int val = 0;

                if (String.IsNullOrWhiteSpace(lblSumPr.Text) == false)
                {
                    val = int.Parse(Regex.Replace(lblSumPr.Text, @"[^0-9]+", String.Empty));
                }

                val += products.getProductById(ctr.getOrderDetails(i).getProductId()).getPrice();

                lblSumPr.Text = val.ToString() + " Lei";

                lblTotalPr.Text = val.ToString() + " Lei";

                this.containerOrders.Controls.Add(prod);
                this.orders.Add(prod);

            }


        }
     */

        


    /*private void txtQuant_TextChanged(object sender, EventArgs e)
        {


            Regex r = new Regex(@"\d+");


            MessageBox.Show(r.IsMatch(txtQuant.Text).ToString());



        }*/


       
   

    }
}
