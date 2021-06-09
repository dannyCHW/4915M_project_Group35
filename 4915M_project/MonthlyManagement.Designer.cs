
namespace _4915M_project
{
    partial class MonthlyManagement
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
            this.btnPay = new System.Windows.Forms.Button();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.lable2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.view = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPay);
            this.panel1.Controls.Add(this.txtMoney);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCount);
            this.panel1.Controls.Add(this.lable2);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.view);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 638);
            this.panel1.TabIndex = 0;
            // 
            // btnPay
            // 
            this.btnPay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPay.AutoSize = true;
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(485, 495);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(203, 49);
            this.btnPay.TabIndex = 143;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // txtMoney
            // 
            this.txtMoney.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMoney.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.txtMoney.Location = new System.Drawing.Point(556, 440);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.ReadOnly = true;
            this.txtMoney.Size = new System.Drawing.Size(373, 32);
            this.txtMoney.TabIndex = 142;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.label2.Location = new System.Drawing.Point(355, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 38);
            this.label2.TabIndex = 141;
            this.label2.Text = "Total ：";
            // 
            // txtCount
            // 
            this.txtCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCount.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.txtCount.Location = new System.Drawing.Point(556, 361);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(373, 32);
            this.txtCount.TabIndex = 140;
            // 
            // lable2
            // 
            this.lable2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lable2.AutoSize = true;
            this.lable2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lable2.Location = new System.Drawing.Point(237, 354);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(249, 38);
            this.lable2.TabIndex = 139;
            this.lable2.Text = "Order Count ：";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(32, 563);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(178, 50);
            this.btnBack.TabIndex = 126;
            this.btnBack.Text = "<-Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // view
            // 
            this.view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.view.Location = new System.Drawing.Point(189, 103);
            this.view.Name = "view";
            this.view.RowTemplate.Height = 24;
            this.view.Size = new System.Drawing.Size(792, 229);
            this.view.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(629, 38);
            this.label1.TabIndex = 124;
            this.label1.Text = "Unpaid monthly statement of this month";
            // 
            // MonthlyManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 638);
            this.Controls.Add(this.panel1);
            this.Name = "MonthlyManagement";
            this.Text = "MonthlyManagement";
            this.Load += new System.EventHandler(this.MonthlyManagement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView view;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label lable2;
        private System.Windows.Forms.Button btnPay;
    }
}