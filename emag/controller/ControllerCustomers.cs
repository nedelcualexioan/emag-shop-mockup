using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace emag
{
    public class ControllerCustomers
    {

        private List<Customer> customers;

        public ControllerCustomers()
        {
            customers = new List<Customer>();
            load();
        }

        public void afisare()
        {
            for(int i = 0; i < customers.Count(); i++)
            {
                Console.WriteLine(customers[i].descriere());
            }
        }

        public void load()
        {
            String path = AppDomain.CurrentDomain.BaseDirectory + @"\db\customers.txt";
                
            StreamReader read = new StreamReader(path);

            String line = "";

            while ((line = read.ReadLine()) != null)
            {
                String[] parts = line.Split(',');
                
                if (String.IsNullOrEmpty(line) == false)
                {
                    this.customers.Add(new Customer(int.Parse(parts[0]), parts[1], parts[2], parts[3], billing_address: parts[4], is_admin: bool.Parse(parts[5])));
                }
            }

            read.Close();

        }

        public int nextId()
        {
            return this.customers[customers.Count - 1].getId() + 1;
        }

        public bool isCustomer(String email)
        {
            for(int i = 0; i < customers.Count(); i++)
            {
                if (customers[i].getEmail().Equals(email))
                    return true;
            }
            return false;
        }

        public bool isPassword(String email, String pass)
        {
            for(int i = 0; i < customers.Count(); i++)
            {
                if (customers[i].getPassword().Equals(pass) && customers[i].getEmail().Equals(email))
                    return true;
            }
            return false;
        }

        public void add(Customer c)
        {
            customers.Add(c);
        }

        public String proprietati()
        {
            String text = "";

            foreach(Customer c in customers)
            {
                text += c.proprietati();
                text += "\n";
            }
            return text;
        }

        public void save()
        {
            String path = AppDomain.CurrentDomain.BaseDirectory + @"\db\customers.txt";

            StreamWriter write = new StreamWriter(path);

            write.WriteLine(proprietati());

            write.Close();
        }

        
        public Customer getCustomer(String email)
        {
            foreach(Customer c in customers)
            {
                if (c.getEmail().Equals(email))
                {
                    return c;
                }
            }
            return null;
        }

    }
}
