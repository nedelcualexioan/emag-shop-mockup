namespace view
{
    partial class ViewLoginT
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
            this.lblHello = new System.Windows.Forms.Label();
            this.lblEm = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHello
            // 
            this.lblHello.AutoSize = true;
            this.lblHello.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHello.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHello.Location = new System.Drawing.Point(334, 116);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(123, 45);
            this.lblHello.TabIndex = 1;
            this.lblHello.Text = "Salut!";
            // 
            // lblEm
            // 
            this.lblEm.AutoSize = true;
            this.lblEm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEm.Location = new System.Drawing.Point(308, 171);
            this.lblEm.Name = "lblEm";
            this.lblEm.Size = new System.Drawing.Size(171, 18);
            this.lblEm.TabIndex = 2;
            this.lblEm.Text = "Introdu adresa de email";
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.Location = new System.Drawing.Point(252, 203);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(284, 29);
            this.txtMail.TabIndex = 3;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNext.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(252, 244);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(284, 42);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Continua";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btn1_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(308, 322);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(186, 32);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Nu ai cont? Nu-ți face griji!\r\nPoți crea unul in pasul următor.\r\n";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pctLogo
            // 
            this.pctLogo.Image = global::view.Properties.Resources._1200px_Logo_eMAG_svg;
            this.pctLogo.Location = new System.Drawing.Point(311, 24);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(168, 49);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 0;
            this.pctLogo.TabStop = false;
            // 
            // ViewLoginT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.lblEm);
            this.Controls.Add(this.lblHello);
            this.Controls.Add(this.pctLogo);
            this.Name = "ViewLoginT";
            this.Text = "ViewLogin";
            this.Load += new System.EventHandler(this.ViewLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.Label lblEm;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblInfo;
    }
}