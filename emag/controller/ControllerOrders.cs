using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace emag
{
    public class ControllerOrders
    {
        private List<Order> orders;

        public ControllerOrders()
        {
            orders = new List<Order>();
        }

        public void afisare()
        {
            for (int i = 0; i < orders.Count(); i++)
            {
                Console.WriteLine(orders[i].descriere());
            }
        }

        public int nextId()
        {
            return orders.Count + 1;
        }

        public void load()
        {
            String path = AppDomain.CurrentDomain.BaseDirectory + @"\db\orders.txt";

            StreamReader read = new StreamReader(path);

            String line = "";

            while ((line = read.ReadLine()) != null)
            {
                String[] parts = line.Split(',');
                if (String.IsNullOrEmpty(line) == false)
                {
                    this.orders.Add(new Order(int.Parse(parts[0]), int.Parse(parts[1])));
                }
            }

            read.Close();
        }

        private String proprietati()
        {
            String text = "";

            foreach(Order o in orders)
            {
                text += o.proprietati();
                text += "\n";
            }

            return text;
        }

        public void add(Order o)
        {
            orders.Add(o);
        }

        public void save()
        {
            String path = AppDomain.CurrentDomain.BaseDirectory + @"\db\orders.txt";

            StreamWriter write = new StreamWriter(path);

            write.WriteLine(proprietati());

            write.Close();
        }

        public Order getOrder(int customer_id)
        {
            for (int i = orders.Count - 1; i >= 0; i--)
            {
                if (orders[i].getCustomerId().Equals(customer_id))
                    return orders[i];
            }

            return null;
        }

    }
}
