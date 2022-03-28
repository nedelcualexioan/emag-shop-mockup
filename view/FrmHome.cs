using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using emag;

namespace view
{
    public partial class FrmHome : Form
    {


        private Header header;
        private Navbar navbar;
        private ViewHome home;
        private ViewLogin login;
        private ViewRegister register;
        private ViewLogNext log;
        private ProductPage product;
        private ViewCart cart;
        private ViewEmptyCart emptyCart;
        private ViewOrderDet orderDet;

        private Order order;
        private Customer customer;
        private bool isLogged;

        private ControllerCustomers customers;
        private ControllerProducts products;
        private ControllerOrderDetails details;
        private ControllerOrders orders;
        public FrmHome()
        {

            InitializeComponent();

            this.Size = Screen.PrimaryScreen.Bounds.Size;

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            this.WindowState = FormWindowState.Maximized;
            

            isLogged = false;

            header = new Header(this);
            navbar = new Navbar(this);
            home = new ViewHome(this);
            login = new ViewLogin(this);
            register = new ViewRegister(this);
            log = new ViewLogNext(this);
            cart = new ViewCart(this);
            emptyCart = new ViewEmptyCart(this);
           

            customers = new ControllerCustomers();
            products = new ControllerProducts();
            details = new ControllerOrderDetails();
            orders = new ControllerOrders();
            orderDet = new ViewOrderDet(this, customers.getCustomer("ctumbridge8@hexun.com"), 2, customers);
            header.Dock = DockStyle.Top;

            foreach(Control control in this.Controls)
            {
                control.Hide();
            }

            //initialize();

            orderDet.Show();
            header.Show();
            this.BackColor = Color.White;

            header.userClick += login_Click;
            header.logoClick += homeLogo_Click;
            header.searchClick += headerSearch_Click;
            header.cartClick += headerCart_Click;

            navbar.cmbChange += cmbProducts_SelectedIndexChanged;

            login.logoClick += loginLogo_Click;
            login.btnClick += loginBtnNext_Click;

            register.logoClick += registerLogo_Click;
            register.btnClick += registerBtn_Click;

            log.btnClick += logNextBtn_Click;

            home.ProdClick += homeCard_Click;



            cart.detailsDel += lblDelte_Click;

            emptyCart.returnClick += btnReturn_Click;
        }


        private void initialize()
        {
            home.Show();
            header.Show();
            navbar.Show();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (navbar.getCmbText().Equals("Produse"))
            {
                home.setProdTxt(navbar.getCmbText());
                home.emptyList();
                home.clearCards();
                home.populatePanel();
            }
            else
            {
                home.setProdTxt(navbar.getCmbText());
                home.emptyList();
                home.clearCards();
                home.populateCategory(navbar.getCmbText());
            }
        }

        private void login_Click(object sender, EventArgs e)
        {

            if (isLogged == false)
            {
                if (home.Visible)
                {
                    home.Hide();
                    navbar.Hide();
                    header.Hide();
                }
                else if (product != null && product.Visible)
                {
                    product.Hide();
                    header.Hide();
                }
                else if (cart.Visible)
                {
                    cart.Hide();
                    header.Hide();
                }
                else if (emptyCart.Visible)
                {
                    emptyCart.Hide();
                    header.Hide();
                }

                login.Show();
                this.BackColor = SystemColors.Control;
            }
            else
            {
                
            }

            

        }

        private void loginLogo_Click(object sender, EventArgs e)
        {

            login.Hide();
            home.Show();
            navbar.Show();
            header.Show();
            login.clearEmail();

            


        }

        private void registerLogo_Click(object sender, EventArgs e)
        {

            register.Hide();
            home.Show();
            navbar.Show();
            header.Show();

            register.clearName();
            register.clearPassword();
            register.clearConfirm();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            customers.load();

            register.Hide();

            home.Show();
            navbar.Show();
            header.Show();

            customer = customers.getCustomer(register.getEmail());

            order = new Order(orders.nextId(), customer.getId());
            

            register.clearName();
            register.clearPassword();
            register.clearConfirm();

            isLogged = true;
        }

        private void loginBtnNext_Click(object sender, EventArgs e) 
        {
            if (customers.isCustomer(login.getEmail()))
            {
                login.Hide();

                log.Show();
                log.setEmail(login.getEmail());
            }
            else
            {
                login.Hide();

                register.Show();
                register.setEmail(login.getEmail());
            }
        }

        private void logNextBtn_Click(object sender,EventArgs e)
        {
            if (customers.isPassword(log.getEmail(), log.getPassword()))
            {
                log.Hide();

                home.Show();
                navbar.Show();
                header.Show();

                log.clearPassword();

                customer = customers.getCustomer(log.getEmail());

                order = new Order(orders.nextId(), customer.getId());

                isLogged = true;
            }
            else
            {
                MessageBox.Show("Ai introdus greșit parola sau adresa de email. Te rugăm completează din nou.", "Logare esuata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void homeCard_Click(object sender,EventArgs e)
        {
            home.Hide();
            navbar.Hide();
            product = new ProductPage(this, home.getLastProd());
            product.addClick += productAdd_Click;
            product.Show();

            this.BackColor = Color.White;
        }

        private void homeLogo_Click(object sender, EventArgs e)
        {
          
            if (product != null && product.Visible)
            {
                product.Hide();
                home.Show();
                navbar.Show();
            }
            else if (cart.Visible)
            {
                cart.Hide();
                home.Show();
                navbar.Show();
            }
            else if (emptyCart.Visible)
            {
                emptyCart.Hide();
                home.Show();
                navbar.Show();
            }
            this.BackColor = SystemColors.Control;
        }

        private void headerSearch_Click(object sender,EventArgs e)
        {
            Product p = products.getProd(header.getSearch());
            if (p != null)
            {

                if (home.Visible)
                {
                    home.Hide();
                    navbar.Hide();
                    product = new ProductPage(this, p);
                    this.BackColor = Color.White;
                    product.Show();
                }
                else if(product != null && product.Visible)
                {
                    product.Hide();
                    product = new ProductPage(this, p);
                    product.Show();
                }
                else if (cart.Visible)
                {
                    cart.Hide();
                    product = new ProductPage(this, p);
                    product.Show();

                    this.BackColor = Color.White;
                }

                product.addClick += productAdd_Click;
            }
            else if(header.isNull() == false && header.getSearch().Equals("Ai libertatea să alegi ce vrei") == false)
            {
                MessageBox.Show("0 rezultate pentru " + header.getSearch(), "Produsul nu a fost gasit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void productAdd_Click(object sender,EventArgs e)
        {

            if (product.isStock() == false)
                MessageBox.Show("Stoc epuizat!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (isLogged == true) {
                OrderDetails det = new OrderDetails();

                det.setId(details.nextId());

                det.setOrderId(order.getId());

                Product p = products.getProd(product.getName());

                det.setProductId(p.getId());
                det.setPrice(p.getPrice());

                order.setAmmount(order.getAmmount() + p.getPrice());

                products.setQuantity(p.getName(), p.getQuantity() - 1);

                if (details.isDetails(p.getId(), order.getId()) == false)
                {
                    details.add(det);
                }
                else
                {
                    details.contopire(p.getId(), order.getId(), det.getPrice(), 1);
                    det.setId(det.getId() - 1);
                }

                if (cart.isCart(p) == false)
                {
                    this.cart.add(p);
                    MessageBox.Show("Produs adaugat in cos", product.getName(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cart.getProdCart(p).getQuant() < 4)
                {
                    cart.setQuant(p, cart.getProdCart(p).getQuant() + 1);
                    MessageBox.Show("Produs adaugat in cos", product.getName(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ati atins maximul cantitatii pentru acest produs", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Pentru a adauga un produs in cos trebuie sa va autentificati!", "Adaugare esuata", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dialog == DialogResult.OK)
                {
                    product.Hide();
                    navbar.Hide();
                    header.Hide();

                    login.Show();
                    this.BackColor = SystemColors.Control;
                }
            }
        }

        private void headerCart_Click(object sender,EventArgs e)
        {

            if (home.Visible)
            {
                home.Hide();
                navbar.Hide();

                if (cart.getCount() > 0)
                    cart.Show();
                else
                    emptyCart.Show();

            }
            else if(product!=null && product.Visible)
            {
                product.Hide();

                if (cart.getCount() > 0)
                    cart.Show();
                else
                    emptyCart.Show();
            }

            this.BackColor = Color.FromArgb(228, 241, 249);

        }

        private void lblDelte_Click(object sender,EventArgs e)
        {


            details.rmOrderDetails(products.getProduct(cart.getSender().getName()));


        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            emptyCart.Hide();
            home.Show();
            navbar.Show();
        }
    }
}
