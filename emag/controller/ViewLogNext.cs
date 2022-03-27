using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace emag.controller
{
    internal class ViewLogNext : Panel
    {

        private PictureBox pctLogo;
        private Label lblHello;
        private PictureBox pctIcon;
        private Label lblEmail;
        private Label lblInfo;
        private TextBox txtPass;
        private Button btnNext;

        public ViewLogNext(Form par)
        {
            this.Parent = par;
            this.Location = new Point(0, 98);
            this.Width = par.Width - 20;
            this.Height = 448;
            this.BackColor = SystemColors.Control;

            this.AutoScroll = false;
            this.HorizontalScroll.Maximum = 0;
            this.HorizontalScroll.Visible = false;
            this.AutoScroll = true;
            this.HorizontalScroll.Visible = true;

            pctLogo = new PictureBox();
            lblHello = new Label();
            pctIcon = new PictureBox();
            lblEmail = new Label();
            lblInfo = new Label();
            txtPass = new TextBox();
            btnNext = new Button();

            pctLogo.Parent = this;
            lblHello.Parent = this;
            pctIcon.Parent = this;
            lblEmail.Parent = this;
            lblInfo.Parent = this;
            txtPass.Parent = this;
            btnNext.Parent = this;
        }

    }
}
