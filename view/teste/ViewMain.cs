using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using emag;

namespace view
{
    public partial class ViewMain : Form
    {

        private ControllerProducts products;

        private List<Panel> panels = new List<Panel>();
        public ViewMain()
        {
           
            InitializeComponent();
            products = new ControllerProducts();

            this.populateCategories();

            containerCards.AutoScroll = true;

            populatePanel();
        }

        private void populatePanel()
        {

            int x = 0, y = 0;

            for(int i = 0; i < products.getCount(); i++)
            {
                if (i % 5 == 0 && i != 0)
                {
                    y += 227 + 2;
                    x = 0;
                }

                createCard(products.getProduct(i), new Point(x, y));

                x += panels[panels.Count - 1].Size.Width + 2;

           
            }
        }

        private void ViewMain_Load(object sender, EventArgs e)
        {

        }


        private void populateCategories()
        {
            List<String> categories = products.getCategories();

            foreach(String cat in categories)
            {
                lstProd.Items.Add(cat);
            }
        }

        private void pctSearch_MouseHover(object sender, EventArgs e)
        {
            pctSearch.BackColor = SystemColors.ActiveCaption;
        }

        private void pctSearch_MouseLeave(object sender, EventArgs e)
        {
            pctSearch.BackColor = SystemColors.Control;
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }


        private void createCard(Product product ,Point point)
        {

            Panel card = new Panel();

            card.Parent = containerCards;

            card.Location = point;
            card.Width = 172;
            card.Height = 227;
            card.BackColor = Color.PaleGreen;
            card.BorderStyle = BorderStyle.FixedSingle;
           

            Label lblProd = new Label();
            lblProd.AutoSize = false;
            lblProd.Parent = card;
            lblProd.Width = lblProd.Parent.Width;
            lblProd.Height = 40;

            lblProd.TextAlign = ContentAlignment.MiddleCenter;
     
            lblProd.Text = product.getName();

            lblProd.Font = new Font("Arial", 12, FontStyle.Regular);



            Label lblPret = new Label();
            lblPret.Parent = card;

            lblPret.AutoSize = false;
            lblPret.Width = lblPret.Parent.Width;
            lblPret.TextAlign = ContentAlignment.MiddleCenter;


            

            lblPret.Text = Convert.ToString(product.getPrice());
            lblPret.Font = new Font("Arial", 17, FontStyle.Regular);
            lblPret.ForeColor = Color.Red;  


            lblProd.Top = 112;
            lblPret.Top = 188;

            


            this.panels.Add(card);


           




        }

    }
}
