using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emag
{
    public class OrderDetails
    {
        private int id;
        private int order_id;
        private int product_id;
        private int price;
        private int quantity;

        public OrderDetails(int id, int order_id, int product_id, int price, int quantity)
        {
            this.id = id;
            this.order_id = order_id;
            this.product_id = product_id;
            this.price = price;
            this.quantity = quantity;
        }

        public OrderDetails()
        {
            this.quantity = 1;
        }
        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getOrderId()
        {
            return order_id;
        }

        public void setOrderId(int order_id)
        {
            this.order_id = order_id;
        }

        public int getProductId()
        {
            return product_id;
        }

        public void setProductId(int product_id)
        {
            this.product_id = product_id;
        }

        public int getPrice()
        {
            return price;
        }

        public void setPrice(int price)
        {
            this.price = price;
        }

        public int getQuantity()
        {
            return quantity;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public String descriere()
        {
            String text = "";

            text += "ID: " + id + "\n";
            text += "Order ID: " + order_id + "\n";
            text += "Product ID: " + product_id + "\n";
            text += "Price: " + price + "\n";
            text += "Quantity: " + quantity + "\n";

            return text;
        }

        public String proprietati()
        {
            String text = "";

            text += id + "," + order_id + "," + product_id + "," + price + "," + quantity;

            return text;
        }


    }

}