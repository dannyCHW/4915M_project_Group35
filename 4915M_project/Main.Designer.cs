
namespace _4915M_project
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCustomerLogin = new System.Windows.Forms.Button();
            this.btnStaffLogin = new System.Windows.Forms.Button();
            this.btnCustomerCreateAccount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(435, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 246);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // btnCustomerLogin
            // 
            this.btnCustomerLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnCustomerLogin.FlatAppearance.BorderSize = 0;
            this.btnCustomerLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerLogin.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerLogin.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCustomerLogin.Location = new System.Drawing.Point(456, 289);
            this.btnCustomerLogin.Name = "btnCustomerLogin";
            this.btnCustomerLogin.Size = new System.Drawing.Size(244, 48);
            this.btnCustomerLogin.TabIndex = 25;
            this.btnCustomerLogin.Text = "Customer Login";
            this.btnCustomerLogin.UseVisualStyleBackColor = false;
            this.btnCustomerLogin.Click += new System.EventHandler(this.btnCustomerLogin_Click);
            // 
            // btnStaffLogin
            // 
            this.btnStaffLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnStaffLogin.FlatAppearance.BorderSize = 0;
            this.btnStaffLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffLogin.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffLogin.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnStaffLogin.Location = new System.Drawing.Point(456, 386);
            this.btnStaffLogin.Name = "btnStaffLogin";
            this.btnStaffLogin.Size = new System.Drawing.Size(244, 48);
            this.btnStaffLogin.TabIndex = 26;
            this.btnStaffLogin.Text = "Staff Login";
            this.btnStaffLogin.UseVisualStyleBackColor = false;
            this.btnStaffLogin.Click += new System.EventHandler(this.btnStaffLogin_Click);
            // 
            // btnCustomerCreateAccount
            // 
            this.btnCustomerCreateAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnCustomerCreateAccount.FlatAppearance.BorderSize = 0;
            this.btnCustomerCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerCreateAccount.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerCreateAccount.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCustomerCreateAccount.Location = new System.Drawing.Point(456, 481);
            this.btnCustomerCreateAccount.Name = "btnCustomerCreateAccount";
            this.btnCustomerCreateAccount.Size = new System.Drawing.Size(244, 48);
            this.btnCustomerCreateAccount.TabIndex = 27;
            this.btnCustomerCreateAccount.Text = "Create Accout";
            this.btnCustomerCreateAccount.UseVisualStyleBackColor = false;
            this.btnCustomerCreateAccount.Click += new System.EventHandler(this.btnCustomerCreateAccount_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1186, 638);
            this.Controls.Add(this.btnCustomerCreateAccount);
            this.Controls.Add(this.btnStaffLogin);
            this.Controls.Add(this.btnCustomerLogin);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Main";
            this.Text = "EDE DELIVERY";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCustomerLogin;
        private System.Windows.Forms.Button btnStaffLogin;
        private System.Windows.Forms.Button btnCustomerCreateAccount;
    }
}

