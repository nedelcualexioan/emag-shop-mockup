using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace emag
{
    public class ControllerOrderDetails
    {
        private List<OrderDetails> details;

        public ControllerOrderDetails()
        {
            details = new List<OrderDetails>();

            load();
        }

        public void afisare()
        {
            for (int i = 0; i < details.Count(); i++)
            {
                Console.WriteLine(details[i].descriere());
            }
        }

        public int nextId()
        {
            return details.Count() + 1;
        }

        private String proprietati()
        {
            String text = "";

            foreach (OrderDetails o in details)
            {
                text += o.proprietati();
                text += "\n";
            }

            return text;
        }

        public void add(OrderDetails det)
        {
            details.Add(det);
        }

        public void save()
        {
            String path = AppDomain.CurrentDomain.BaseDirectory + @"\db\orderDetails.txt";

            StreamWriter write = new StreamWriter(path);

            write.WriteLine(proprietati());

            write.Close();
        }

        public void load()
        {
            String path = AppDomain.CurrentDomain.BaseDirectory + @"\db\orderDetails.txt";

            StreamReader read = new StreamReader(path);

            String line = "";

            while ((line = read.ReadLine()) != null)
            {
                String[] parts = line.Split(',');

                this.details.Add(new OrderDetails(nextId(), int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
            }

            read.Close();
        }

        public bool isDetails(int prod_id, int order_id)
        {
            foreach (OrderDetails det in details)
            {
                if (det.getProductId().Equals(prod_id) && det.getOrderId().Equals(order_id))
                    return true;
            }
            return false;
        }

        public void contopire(int prod_id, int order_id, int price, int quantity)
        {
            foreach (OrderDetails det in details)
            {
                if (det.getProductId().Equals(prod_id) && det.getOrderId().Equals(order_id))
                {
                    det.setPrice(det.getPrice() + price);
                    det.setQuantity(det.getQuantity() + quantity);
                }
            }
        }

        public int getCount()
        {
            return this.details.Count;
        }

        public OrderDetails getOrderDetails(int poz)
        {
            return details[poz];
        }

        public void rmOrderDetails(Product p)
        {
            foreach(OrderDetails det in details)
            {
                if (det.getProductId().Equals(p.getId()))
                {
                    details.Remove(det);
                    break;
                }
            }
        }

        public String getDetails()
        {
            String txt = "";

            foreach(OrderDetails d in details)
            {
                txt += d.descriere();
                txt += "\n";
            }

            return txt;
        }

        public int getDetails(Order order)
        {
            int k = 0;

            foreach(OrderDetails o in details)
            {
                if (o.getOrderId() == order.getId())
                    k++;
            }
            return k;
        }
    }
}
