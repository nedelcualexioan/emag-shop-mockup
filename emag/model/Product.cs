using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emag
{
    public class Product
    {
        private int id;
        private String name;
        private String category;
        private int price;
        private bool stock;
        private String picture;
        private int stock_q;
        public Product(int id, String name, String category, int price, bool stock, String picture, int stock_q)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.stock = stock;
            this.category = category;
            this.picture = picture;
            this.stock_q = stock_q;

        }
        public Product()
        {

        }

        public int getId()
        {
            return id;
        }

        private void setId(int id)
        {

            this.id=id;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name=name;
        }

        public String getCategory()
        {
            return category;
        }

        public void setCategory(String category)
        {

            this.category=category;
        }

        public int getPrice()
        {
            return price;
        }

        public void setPrice(int price)
        {
            this.price=price;
        }

        public bool getStock()
        {
            return stock;
        }

        public void setStock(bool stock)
        {
            this.stock=stock;
        }

        public String getPicture()
        {
            return this.picture;
        }

        public void setPicture(String pic)
        {
            this.picture = pic;
        }

        public int getQuantity()
        {
            return this.stock_q;
        }

        public void setQuantity(int stock_q)
        {
            this.stock_q = stock_q;
        }

        public String descriere()
        {
            String text = "";

            text += "ID: " + id + "\n";
            text += "Nume produs: " + name + "\n";
            text += "Pret: " + price + " RON\n";
            text += "Stoc: " + stock + "\n";
            text += "Cantitate: " + stock_q + "\n";

            return text;
        }

    }
}
