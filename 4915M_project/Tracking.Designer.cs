
namespace _4915M_project
{
    partial class Tracking
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
            this.txtExpected = new System.Windows.Forms.TextBox();
            this.txtNow = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtExpected
            // 
            this.txtExpected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtExpected.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtExpected.Location = new System.Drawing.Point(263, 413);
            this.txtExpected.Name = "txtExpected";
            this.txtExpected.Size = new System.Drawing.Size(725, 41);
            this.txtExpected.TabIndex = 30;
            this.txtExpected.Text = "Date is expected to arrive：";
            // 
            // txtNow
            // 
            this.txtNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtNow.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtNow.Location = new System.Drawing.Point(263, 336);
            this.txtNow.Name = "txtNow";
            this.txtNow.Size = new System.Drawing.Size(725, 41);
            this.txtNow.TabIndex = 29;
            this.txtNow.Text = "Now, the shipment  is in :";
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCheck.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(437, 245);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(282, 42);
            this.btnCheck.TabIndex = 28;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(319, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 28);
            this.label2.TabIndex = 27;
            this.label2.Text = "Order Number:";
            // 
            // txtOrder
            // 
            this.txtOrder.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrder.Location = new System.Drawing.Point(512, 171);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(272, 27);
            this.txtOrder.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(123, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 38);
            this.label1.TabIndex = 25;
            this.label1.Text = "Shipment Tracking";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(84, 500);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(131, 50);
            this.btnBack.TabIndex = 109;
            this.btnBack.Text = "<- Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Tracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1250, 603);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtExpected);
            this.Controls.Add(this.txtNow);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.label1);
            this.Name = "Tracking";
            this.Text = "Tracking";
            this.Load += new System.EventHandler(this.Tracking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExpected;
        private System.Windows.Forms.TextBox txtNow;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
    }
}