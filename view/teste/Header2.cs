using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace view
{

    public class Header2:Panel
    {
        private Button button;
        private Label label;

        public Header2(Form par)
        {
            button = new Button();

            label = new Label();
            this.Parent = par;
            this.Width = this.Parent.Width;
            this.BorderStyle = BorderStyle.FixedSingle;

            this.Height = 200;

            button.Parent = this;
            button.Text = "Buton";

            button.Location = new Point(0, 50);

            label.Parent = this;
            label.AutoSize = false;
            label.Width=label.Parent.Width;
            label.Text = "Acesta este un alt header";
            label.Font = new Font("Arial", 14, style: FontStyle.Regular);

            label.TextAlign = ContentAlignment.MiddleCenter;

        }

    }
}
