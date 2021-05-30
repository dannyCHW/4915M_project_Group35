
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
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.goLoginbtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.goCreatebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(1062, 565);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // goLoginbtn
            // 
            this.goLoginbtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.goLoginbtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goLoginbtn.Location = new System.Drawing.Point(356, 586);
            this.goLoginbtn.Name = "goLoginbtn";
            this.goLoginbtn.Size = new System.Drawing.Size(338, 80);
            this.goLoginbtn.TabIndex = 14;
            this.goLoginbtn.Text = "Customer Login";
            this.goLoginbtn.UseVisualStyleBackColor = false;
            this.goLoginbtn.Click += new System.EventHandler(this.goLoginbtn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(700, 586);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(338, 80);
            this.button2.TabIndex = 22;
            this.button2.Text = "Staff Login";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // goCreatebtn
            // 
            this.goCreatebtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.goCreatebtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goCreatebtn.Location = new System.Drawing.Point(12, 586);
            this.goCreatebtn.Name = "goCreatebtn";
            this.goCreatebtn.Size = new System.Drawing.Size(338, 80);
            this.goCreatebtn.TabIndex = 23;
            this.goCreatebtn.Text = "Create Account";
            this.goCreatebtn.UseVisualStyleBackColor = false;
            this.goCreatebtn.Click += new System.EventHandler(this.goCreatebtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1060, 707);
            this.Controls.Add(this.goCreatebtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.goLoginbtn);
            this.Controls.Add(this.pictureBox4);
            this.Name = "Main";
            this.Text = "EDE DELIVERY";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button goLoginbtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button goCreatebtn;
    }
}

