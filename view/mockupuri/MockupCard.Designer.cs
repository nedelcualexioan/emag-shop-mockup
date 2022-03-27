namespace view
{
    partial class MockupCard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPret = new System.Windows.Forms.Label();
            this.lblProd = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblPret);
            this.panel1.Controls.Add(this.lblProd);
            this.panel1.Location = new System.Drawing.Point(274, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 303);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = global::view.Properties.Resources.macAir;
            this.pictureBox1.Location = new System.Drawing.Point(27, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblPret
            // 
            this.lblPret.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPret.ForeColor = System.Drawing.Color.Red;
            this.lblPret.Location = new System.Drawing.Point(0, 267);
            this.lblPret.Name = "lblPret";
            this.lblPret.Size = new System.Drawing.Size(192, 36);
            this.lblPret.TabIndex = 1;
            this.lblPret.Text = "Pret";
            // 
            // lblProd
            // 
            this.lblProd.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProd.Location = new System.Drawing.Point(0, 204);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(190, 50);
            this.lblProd.TabIndex = 0;
            this.lblProd.Text = "Produs";
            this.lblProd.Click += new System.EventHandler(this.lblProd_Click);
            // 
            // MockupCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "MockupCard";
            this.Text = "MockupCard";
            this.Load += new System.EventHandler(this.MockupCard_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Label lblPret;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}