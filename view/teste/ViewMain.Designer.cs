namespace view
{
    partial class ViewMain
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lstProd = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pctSearch = new System.Windows.Forms.PictureBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.lblProd = new System.Windows.Forms.Label();
            this.containerCards = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSearch.Location = new System.Drawing.Point(274, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(561, 29);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Ai libertatea să alegi ce vrei";
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            // 
            // lstProd
            // 
            this.lstProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProd.FormattingEnabled = true;
            this.lstProd.ItemHeight = 20;
            this.lstProd.Location = new System.Drawing.Point(240, 74);
            this.lstProd.Name = "lstProd";
            this.lstProd.Size = new System.Drawing.Size(138, 64);
            this.lstProd.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::view.Properties.Resources._588a6507d06f6719692a2d15;
            this.pictureBox1.Location = new System.Drawing.Point(100, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pctSearch
            // 
            this.pctSearch.Image = global::view.Properties.Resources._500px_Search_Icon_svg;
            this.pctSearch.Location = new System.Drawing.Point(832, 12);
            this.pctSearch.Name = "pctSearch";
            this.pctSearch.Size = new System.Drawing.Size(30, 29);
            this.pctSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctSearch.TabIndex = 2;
            this.pctSearch.TabStop = false;
            this.pctSearch.MouseLeave += new System.EventHandler(this.pctSearch_MouseLeave);
            this.pctSearch.MouseHover += new System.EventHandler(this.pctSearch_MouseHover);
            // 
            // pctLogo
            // 
            this.pctLogo.Image = global::view.Properties.Resources._88362;
            this.pctLogo.Location = new System.Drawing.Point(100, 4);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(138, 40);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 0;
            this.pctLogo.TabStop = false;
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProd.Location = new System.Drawing.Point(119, 74);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(68, 20);
            this.lblProd.TabIndex = 5;
            this.lblProd.Text = "Produse";
            // 
            // containerCards
            // 
            this.containerCards.Location = new System.Drawing.Point(100, 177);
            this.containerCards.Name = "containerCards";
            this.containerCards.Size = new System.Drawing.Size(1248, 233);
            this.containerCards.TabIndex = 6;
            // 
            // ViewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 622);
            this.Controls.Add(this.containerCards);
            this.Controls.Add(this.lblProd);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstProd);
            this.Controls.Add(this.pctSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.pctLogo);
            this.Name = "ViewMain";
            this.Text = "ViewMain";
            this.Load += new System.EventHandler(this.ViewMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox pctSearch;
        private System.Windows.Forms.ListBox lstProd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Panel containerCards;
    }
}