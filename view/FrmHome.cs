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
        private ViewSummary viewSummary;
        private ViewFavorite viewFav;
        private ViewUser user;

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
            this.Text = "eMAG - Libertate in fiecare zi";

            isLogged = false;

            header = new Header(this);
            navbar = new Navbar(this);
            home = new ViewHome(this);
            login = new ViewLogin(this);
            register = new ViewRegister(this);
            log = new ViewLogNext(this);
            cart = new ViewCart(this);
            emptyCart = new ViewEmptyCart(this);
            viewFav = new ViewFavorite(this);


            customers = new ControllerCustomers();
            products = new ControllerProducts();
            details = new ControllerOrderDetails();
            orders = new ControllerOrders();
            header.Dock = DockStyle.Top;

            foreach(Control control in this.Controls)
            {
                control.Hide();
            }

            initialize();

            header.userClick += login_Click;
            header.logoClick += homeLogo_Click;
            header.searchClick += (s, e) => headerSearch_Click(s, e, viewFav, products);
            header.cartClick += headerCart_Click;
            header.favClick += headerFav_Click;

            navbar.cmbChange += cmbProducts_SelectedIndexChanged;

            login.logoClick += loginLogo_Click;
            login.btnClick += loginBtnNext_Click;

            register.logoClick += registerLogo_Click;
            register.btnClick += registerBtn_Click;

            log.btnClick += logNextBtn_Click;

            home.ProdClick += (s, e) => homeCard_Click(s, e, viewFav, products);



            cart.detailsDel += lblDelete_Click;

            emptyCart.returnClick += btnReturn_Click;

            cart.nextClick += cartNext_Click;

            viewFav.btnClick += favoriteBtn_Click;

            viewFav.addClick += (s, e) => favoriteAdd_Click(s, e, viewFav, products);
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
                else if (viewFav.Visible)
                {
                    viewFav.Hide();
                    header.Hide();
                }

                login.Show();
                this.BackColor = SystemColors.Control;
            }
            else
            {
                

                navbar.Hide();
                home.Hide();
                user.Show();

                this.BackColor = Color.FromArgb(250, 250, 250);
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

            user = new ViewUser(this, customer, 5, 2);
            user.Hide();
        }

        private void loginBtnNext_Click(object sender, EventArgs e) 
        {
            if (customers.isCustomer(login.getEmail()))
            {
                login.Hide();

                log.Show();
                log.setEmail(login.getEmail().ToLower());
            }
            else
            {
                login.Hide();

                register.Show();
                register.setEmail(login.getEmail().ToLower());
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

                user = new ViewUser(this, customer, 0, 2);

                user.Hide();
            }
            else
            {
                MessageBox.Show("Ai introdus greșit parola sau adresa de email. Te rugăm completează din nou.", "Logare esuata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void homeCard_Click(object sender,EventArgs e,ViewFavorite fav,ControllerProducts prods)
        {
            home.Hide();
            navbar.Hide();
            product = new ProductPage(this, home.getLastProd());
            product.addClick += (a, b) => productAdd_Click(a, b, fav, prods);
            product.favClick += productFav_Click;
            product.Show();

            this.BackColor = Color.White;
        }

        private void homeLogo_Click(object sender, EventArgs e)
        {
            if (home.Visible == false)
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
                else if (orderDet != null && orderDet.Visible)
                {
                    orderDet.Hide();
                    home.Show();
                    navbar.Show();
                }
                else if (viewSummary != null && viewSummary.Visible)
                {
                    viewSummary.Hide();
                    navbar.Show();
                    home.Show();
                }
                else if (viewFav.Visible)
                {
                    viewFav.Hide();
                    navbar.Show();
                    home.Show();
                }
                else if (user != null && user.Visible)
                {
                    user.Hide();
                    navbar.Show();
                    home.Show();
                }

                this.BackColor = SystemColors.Control;
            }
        }

        private void headerSearch_Click(object sender,EventArgs e,ViewFavorite fav,ControllerProducts prods)
        {
            Product p = products.getProd(header.getSearch());
            if (p != null)
            {
                

                if (home.Visible)
                {
                    product = new ProductPage(this, p);

                    home.Hide();
                    navbar.Hide();
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
                    product = new ProductPage(this, p);

                    cart.Hide();
                    product.Show();

                    this.BackColor = Color.White;
                }
                else if (emptyCart.Visible)
                {
                    product = new ProductPage(this, p);

                    emptyCart.Hide();
                    product.Show();

                    this.BackColor = Color.White;
                }
                else if (viewFav.Visible)
                {
                    product = new ProductPage(this, p);

                    viewFav.Hide();
                    product.Show();

                    this.BackColor = Color.White;
                }

                product.favClick += productFav_Click;
                product.addClick += (a, b) => productAdd_Click(a, b, fav, prods);
            }
            else if(header.isNull() == false && header.getSearch().Equals("Ai libertatea să alegi ce vrei") == false)
            {
                MessageBox.Show("0 rezultate pentru " + header.getSearch(), "Produsul nu a fost gasit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void productAdd_Click(object sender,EventArgs e,ViewFavorite fav,ControllerProducts prods)  
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

                if (cart.isCart(p, product.getColor()) == false)
                {
                    this.cart.add(p, product.getColor(), fav, prods);
                    MessageBox.Show("Produs adaugat in cos", product.getName(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.cart.setPic(p, product.getPath(), product.getColor());

                }
                else if (cart.getProdCart(p, product.getColor()).getQuant() < 4)
                {
                    cart.setQuant(p, cart.getProdCart(p,product.getColor()).getQuant() + 1, product.getColor());
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
            else if (orderDet != null && orderDet.Visible)
            {
                orderDet.Hide();

                cart.Show();
            }
            else if (viewSummary != null && viewSummary.Visible)
            {
                viewSummary.Hide();

                cart.Show();
            }
            else if (viewFav.Visible)
            {
                viewFav.Hide();

                if (cart.getCount() > 0)
                    cart.Show();
                else
                    emptyCart.Show();
            }

            this.BackColor = Color.FromArgb(228, 241, 249);

        }

        private void lblDelete_Click(object sender,EventArgs e)
        {


            details.rmOrderDetails(products.getProdPartial(cart.getSender().getName()));

            if(cart.getCount() == 0)
            {
                cart.Hide();
                emptyCart.Show();
            }


        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            emptyCart.Hide();
            home.Show();
            navbar.Show();
        }

        private void cartNext_Click(object sender,EventArgs e)
        {
            if (cart.isEmpty() == false)
            {

                orderDet = new ViewOrderDet(this, customer, details.getCount(), cart.getAmmount(), customers);

                orderDet.nextClick += detailsNext_Click;

                cart.Hide();

                orderDet.Show();
                navbar.Hide();

                this.BackColor = Color.FromArgb(250, 250, 250);
            }
            else
            {
                MessageBox.Show("Cantitate invalida", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void detailsNext_Click(object sender,EventArgs e)
        {
            if (orderDet.isChecked() == false)
            {
                MessageBox.Show("Va rugam sa alegeti o modalitate de plata", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (customer.getAddress() == "none")
            {
                MessageBox.Show("Nicio adresa setata, va rugam sa adaugati datele pentru facturare", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                viewSummary = new ViewSummary(this, customer, orderDet.getMethod(), orderDet.getInfo(), cart);

                orderDet.Hide();

                viewSummary.Show();

                viewSummary.modifyClick += summaryModify_Click;
                viewSummary.sendClick += summarySend_Click;
            }
        }

        private void summaryModify_Click(object sender,EventArgs e)
        {
            viewSummary.Hide();
            orderDet.Show();
        }

        private void summarySend_Click(object sender,EventArgs e)
        {
            if(orderDet.getMethod().Equals("Ramburs la curier"))
            {
                viewSummary.Hide();
                home.Show();
                navbar.Show();

                this.BackColor = SystemColors.Control;

                MessageBox.Show("Comanda a fost plasata!\nPentru mai multe detalii verificati sectiunea contul meu.", "Actiune initiata cu succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void headerFav_Click(object sender,EventArgs e)
        {

            if (viewFav.Visible == false)
            {

                if (home.Visible)
                {
                    home.Hide();
                    navbar.Hide();
                }
                else if (cart.Visible)
                {
                    cart.Hide();
                }
                else if (product != null && product.Visible)
                {
                    product.Hide();
                }
                else if (emptyCart.Visible)
                {
                    emptyCart.Hide();
                }
                else if (orderDet != null && orderDet.Visible)
                {
                    orderDet.Hide();
                }
                else if (viewSummary != null && viewSummary.Visible)
                {
                    viewSummary.Hide();
                }

                viewFav.Show();
                this.BackColor = Color.FromArgb(242, 242, 247);

            }

        }

        private void favoriteBtn_Click(object sender,EventArgs e)
        {
            viewFav.Hide();

            home.Show();
            navbar.Show();

            this.BackColor = SystemColors.Control;
        }

        private void productFav_Click(object sender,EventArgs e)
        {
            if (viewFav.isFav(products.getProduct(product.getName())) == false)
            {
                viewFav.add(products.getProduct(product.getName()));

                MessageBox.Show("Produsul a fost adaugat la Favorite", "Actiune initiata cu succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Produsul este deja in lista de Favorite", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void favoriteAdd_Click(object sender,EventArgs e,ViewFavorite fav,ControllerProducts prods)
        {
            FavCard card = sender as FavCard;

            if (card.isStock() == false)
                MessageBox.Show("Stoc epuizat!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (isLogged == true)
            {
                OrderDetails det = new OrderDetails();

                det.setId(details.nextId());

                det.setOrderId(order.getId());

                Product p = products.getProd(card.getName());

                det.setProductId(p.getId());
                det.setPrice(p.getPrice());

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

                if (cart.isCart(p.getName()) == false)
                {
                    this.cart.add(products.getProduct(card.getName()), String.Empty, fav, prods);
                    MessageBox.Show("Produs adaugat in cos", card.getName(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.cart.setPic(p);

                }
                else if (cart.getProdCart(p).getQuant() < 4)
                {
                    cart.setQuant(p, cart.getProdCart(p).getQuant() + 1);
                    MessageBox.Show("Produs adaugat in cos", card.getName(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    viewFav.Hide();
                    header.Hide();

                    login.Show();
                    this.BackColor = SystemColors.Control;
                }
            }
        }
    }
}
