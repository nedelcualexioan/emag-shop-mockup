using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using emag;

namespace view
{
    public partial class ViewLoginT : Form
    {
        private ControllerCustomers control;
        public ViewLoginT()
        {
            control = new ControllerCustomers();
            InitializeComponent();
        }

        private void ViewLogin_Load(object sender, EventArgs e)
        {

        }

        public bool isValid(String s)
        {
            int k = 0;
            bool flag = false;

            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '@')
                    k++;

                if (s[i] == '@' || s[i] == '.')
                    flag = true;

                if ((s[i] != '@' && s[i] != '.' && s[i] != '-' && s[i] != '_') && char.IsLetterOrDigit(s[i]) == false)
                    return false;
                if (flag == true && s[i] == '_')
                    return false;

                if (s[i] == '.' && (s.Length - 1 - i) < 2)
                    return false;


            }

            for(int i=s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '.')
                    break;
                else if (char.IsLetter(s[i]) == false)
                    return false;
            }

            if(k == 1)
                return true;
            return false;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            String text=txtMail.Text;

            if (String.IsNullOrWhiteSpace(text))
                MessageBox.Show("Email invalid", "Logare esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (char.IsLetterOrDigit(text[0]) == false || text.Contains("@") == false || text.Contains(".") == false)
                MessageBox.Show("Email invalid", "Logare esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (isValid(text) == false)
                MessageBox.Show("Email invalid", "Logare esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (control.isCustomer(text))
                {
                    ViewLoginEx viewLog = new ViewLoginEx(text);
                    viewLog.ShowDialog();
                }
                else
                {
                    //ViewRegister viewReg = new ViewRegister(text);
                    //viewReg.ShowDialog();
                }
            }

        }

        
    }
}
