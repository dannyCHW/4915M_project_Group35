
namespace _4915M_project
{
    partial class AirwayBill3
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReVAT_GST = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHarmonized = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVAT_GST = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDeclaredValue = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSubmit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(902, 464);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(131, 50);
            this.btnSubmit.TabIndex = 134;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.createbtn_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(222, 464);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(131, 50);
            this.btnBack.TabIndex = 133;
            this.btnBack.Text = "<- Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(84, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(342, 38);
            this.label11.TabIndex = 116;
            this.label11.Text = "(P.3) Input Airway Bill";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(672, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 19);
            this.label6.TabIndex = 143;
            this.label6.Text = "Receiver\'s VAT/GST no.:";
            // 
            // txtReVAT_GST
            // 
            this.txtReVAT_GST.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReVAT_GST.Location = new System.Drawing.Point(865, 319);
            this.txtReVAT_GST.Name = "txtReVAT_GST";
            this.txtReVAT_GST.Size = new System.Drawing.Size(168, 27);
            this.txtReVAT_GST.TabIndex = 142;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(173, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 19);
            this.label4.TabIndex = 141;
            this.label4.Text = "Sender\'s VAT/GST no.:";
            // 
            // txtHarmonized
            // 
            this.txtHarmonized.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHarmonized.Location = new System.Drawing.Point(865, 272);
            this.txtHarmonized.Name = "txtHarmonized";
            this.txtHarmonized.Size = new System.Drawing.Size(168, 27);
            this.txtHarmonized.TabIndex = 140;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(608, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(251, 19);
            this.label7.TabIndex = 139;
            this.label7.Text = "Harmonized Commodity Code:";
            // 
            // txtVAT_GST
            // 
            this.txtVAT_GST.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVAT_GST.Location = new System.Drawing.Point(366, 311);
            this.txtVAT_GST.Name = "txtVAT_GST";
            this.txtVAT_GST.Size = new System.Drawing.Size(168, 27);
            this.txtVAT_GST.TabIndex = 138;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(212, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 19);
            this.label8.TabIndex = 137;
            this.label8.Text = "Declared Value:";
            // 
            // txtDeclaredValue
            // 
            this.txtDeclaredValue.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeclaredValue.Location = new System.Drawing.Point(366, 269);
            this.txtDeclaredValue.Name = "txtDeclaredValue";
            this.txtDeclaredValue.Size = new System.Drawing.Size(168, 27);
            this.txtDeclaredValue.TabIndex = 136;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label10.Location = new System.Drawing.Point(192, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(444, 32);
            this.label10.TabIndex = 135;
            this.label10.Text = "Package Express Shipment Only:";
            // 
            // AirwayBill3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1250, 603);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtReVAT_GST);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHarmonized);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtVAT_GST);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDeclaredValue);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label11);
            this.Name = "AirwayBill3";
            this.Text = "AirwayBill3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReVAT_GST;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHarmonized;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVAT_GST;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDeclaredValue;
        private System.Windows.Forms.Label label10;
    }
}