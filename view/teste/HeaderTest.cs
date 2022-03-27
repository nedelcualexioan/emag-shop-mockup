using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace view
{
    public class HeaderTest:Panel
    {

        private Button button;
        private Label label;



        public HeaderTest(Form par)
        {



            this.Parent = par;
            this.Width = this.Parent.Width;

            this.Height = 200;
            this.BorderStyle = BorderStyle.FixedSingle;

            label = new Label();

            label.Parent = this;
            label.AutoSize = false;

            label.Width = label.Parent.Width;
            
            label.Text = "Acesta este un header";
            
            label.Font = new Font("Arial", 14, style: FontStyle.Regular);
            
            label.TextAlign = ContentAlignment.MiddleCenter;


            button = new Button();

            button.Text = "Test";

            button.Parent = this;

            button.Location = new Point(0, 50);
            

            

        }




    }
}
