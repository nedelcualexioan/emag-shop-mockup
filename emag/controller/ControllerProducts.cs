using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emag
{
    public class ControllerProducts
    {

        private List<Product> products;

        public ControllerProducts()
        {
            products = new List<Product>();
            load();
        }

        public void afisare()
        {
            for(int i = 0; i < products.Count(); i++)
            {
                Console.WriteLine(products[i].descriere());
            }
        }

        public int nextId()
        {
            return products.Count() + 1;
        }

        public void load()
        {
            String path = AppDomain.CurrentDomain.BaseDirectory + @"\db\products.txt";

            StreamReader read = new StreamReader(path);

            String line = "";

            while ((line = read.ReadLine()) != null)
            {
                String [] parts = line.Split(',');

                this.products.Add(new Product(nextId(), parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3]), parts[4], int.Parse(parts[5])));
                
            }
        }

        public void save()
        {
            String path = AppDomain.CurrentDomain.BaseDirectory + @"\db\products.txt";

            StreamWriter write = new StreamWriter(path);

            write.WriteLine();
        }

        public int getCount()
        {
            return products.Count();
        }

        public Product getProduct(int poz)
        {
            return this.products[poz];
        }

        public Product getProduct(String name)
        {
            foreach(Product p in products)
            {
                if (p.getName().Equals(name))
                    return p;
            }
            return null;
        }

        public List<String> getCategories()
        {
            List<String> categories = new List<String>();

            foreach(Product p in products)
            {
                if(categories.Contains(p.getCategory()) == false)
                    categories.Add(p.getCategory());
            }

            return categories;
        }

        public Product getProd(String text)
        {
            text = text.ToLower();

            foreach(Product p in products)
            {
                String aux = p.getName();
                aux = aux.ToLower();

                if (aux.Contains(text))
                    return p;
            }
            return null;
        }

        public Product getProdPartial(String text)
        {
            foreach(Product p in products)
            {
                if (text.Contains(p.getName()))
                    return p;
            }
            return null;
        }

        public void setQuantity(String name, int quantity)
        {
            foreach(Product p in products)
            {
                if (p.getName().Equals(name))
                {
                    if (quantity <= 0)
                    {
                        p.setQuantity(0);
                        p.setStock(false);
                    }
                    else
                        p.setQuantity(quantity);

                    break;
                }
            }
        }

        public Product getProductById(int product_id)
        {
            foreach(Product p in products)
            {
                if (p.getId().Equals(product_id))
                    return p;
            }
            return null;
        }

    }
}
