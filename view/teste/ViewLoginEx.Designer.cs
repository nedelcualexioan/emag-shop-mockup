namespace view
{
    partial class ViewLoginEx
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
            this.pctIcon = new System.Windows.Forms.PictureBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHello
            // 
            this.lblHello.AutoSize = true;
            this.lblHello.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHello.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHello.Location = new System.Drawing.Point(330, 104);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(123, 45);
            this.lblHello.TabIndex = 2;
            this.lblHello.Text = "Salut!";
            // 
            // pctIcon
            // 
            this.pctIcon.Image = global::view.Properties.Resources._3898372_user_people_man_add_icon__3_;
            this.pctIcon.Location = new System.Drawing.Point(328, 152);
            this.pctIcon.Name = "pctIcon";
            this.pctIcon.Size = new System.Drawing.Size(125, 122);
            this.pctIcon.TabIndex = 3;
            this.pctIcon.TabStop = false;
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
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblEmail.Location = new System.Drawing.Point(368, 277);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 18);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(254, 321);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(284, 22);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Introdu parola contului tau eMAG\r\n";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(254, 369);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(284, 29);
            this.txtPass.TabIndex = 6;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNext.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(254, 404);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(284, 42);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "Continua";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ViewLoginEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 524);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.pctIcon);
            this.Controls.Add(this.lblHello);
            this.Controls.Add(this.pctLogo);
            this.Name = "ViewLoginEx";
            this.Text = "ViewLoginEx";
            this.Load += new System.EventHandler(this.ViewLoginEx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.PictureBox pctIcon;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnNext;
    }
}