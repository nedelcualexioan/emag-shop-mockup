using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emag
{
    public class Order
    {

        private int id;
        private int customer_id;
        private int ammount;
        private String shipping_address;

        public Order(int id, int customer_id, String shipping_address = "none", int ammount = 0)
        {
            this.id = id;
            this.customer_id = customer_id;
            this.shipping_address = shipping_address;
            this.ammount = ammount;

        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getCustomerId()
        {
            return customer_id;
        }

        public void setCustomerId(int customer_id)
        {
            this.customer_id = customer_id;
        }

        public String getAddress()
        {
            return shipping_address;
        }

        public void setAddress(String address)
        {
            shipping_address = address;
        }

        public int getAmmount()
        {
            return ammount;
        }

        public void setAmmount(int ammount)
        {
            this.ammount = ammount;
        }

        public String descriere()
        {
            String text = "";

            text += "ID: " + id + "\n";
            text += "Customer ID: " + customer_id + "\n";
            text += "Shipping address: " + shipping_address + "\n";
            text += "Ammount: " + ammount + "\n";

            return text;
        }

        public String proprietati()
        {
            String text = "";

            text += id + "," + customer_id + "," + shipping_address + "," + ammount;
            return text;
        }

    }
}
