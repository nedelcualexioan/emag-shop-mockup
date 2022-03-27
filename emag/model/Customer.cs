using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emag
{
    public class Customer
    {
        private int id;
        private String full_name;
        private String email;
        private String password;
        private String billing_address;
        private bool is_admin;

        public Customer(int id, String full_name, String email, String password, String billing_address, bool is_admin)
        {
            this.id = id;
            this.full_name = full_name;
            this.email = email;
            this.password = password;
            this.billing_address = billing_address;
            this.is_admin = is_admin;

        }

        public Customer()
        {

        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id=id;
        }

        public String getName()
        {
            return full_name;
        }

        public void setName(String name)
        {
            full_name=name;
        }

        public String getEmail()
        {
            return email;
        }

        public void setEmail(String email)
        {
            this.email=email;
        }

        public String getPassword()
        {
            return password;
        }

        public void setPassword(String password)
        {
            this.password=password;
        }

        public String getAddress()
        {
            return billing_address;
        }

        public void setAddress(String address)
        {
            billing_address=address;
        }

        public bool getAdmin()
        {
            return is_admin;
        }

        public void setAdmin(bool is_admin)
        {
            this.is_admin=is_admin;
        }

 
      

        public String descriere()
        {
            String text = "";

            text += "ID: " + id + "\n";
            text += "Nume: " + full_name + "\n";
            text += "Email: " + email + "\n";
            text += "Parola: " + password + "\n";
            text += "Adresa: " + billing_address + "\n";
            text += "Admin: " + is_admin + "\n";

            return text;
        }

        public String proprietati()
        {
            String text = "";
            text += id + "," + full_name + "," + email + "," + password + "," + billing_address;

            return text;
        }

    }
}
