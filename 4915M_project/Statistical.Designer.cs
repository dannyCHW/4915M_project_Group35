
namespace _4915M_project
{
    partial class Statistical
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
            this.timeMonth = new System.Windows.Forms.DateTimePicker();
            this.timeDay = new System.Windows.Forms.DateTimePicker();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.lable2 = new System.Windows.Forms.Label();
            this.btnMonth = new System.Windows.Forms.Button();
            this.btnDay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.timeMonth);
            this.panel1.Controls.Add(this.timeDay);
            this.panel1.Controls.Add(this.txtMoney);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCount);
            this.panel1.Controls.Add(this.lable2);
            this.panel1.Controls.Add(this.btnMonth);
            this.panel1.Controls.Add(this.btnDay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 638);
            this.panel1.TabIndex = 0;
            // 
            // timeMonth
            // 
            this.timeMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.timeMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeMonth.Location = new System.Drawing.Point(429, 270);
            this.timeMonth.MinDate = new System.DateTime(2021, 5, 25, 0, 0, 0, 0);
            this.timeMonth.Name = "timeMonth";
            this.timeMonth.Size = new System.Drawing.Size(356, 29);
            this.timeMonth.TabIndex = 140;
            this.timeMonth.Value = new System.DateTime(2021, 6, 1, 0, 0, 0, 0);
            this.timeMonth.ValueChanged += new System.EventHandler(this.timeMonth_ValueChanged);
            // 
            // timeDay
            // 
            this.timeDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.timeDay.Location = new System.Drawing.Point(429, 270);
            this.timeDay.MinDate = new System.DateTime(2021, 5, 25, 0, 0, 0, 0);
            this.timeDay.Name = "timeDay";
            this.timeDay.Size = new System.Drawing.Size(356, 29);
            this.timeDay.TabIndex = 139;
            this.timeDay.Value = new System.DateTime(2021, 6, 9, 0, 0, 0, 0);
            this.timeDay.ValueChanged += new System.EventHandler(this.timeDay_ValueChanged);
            // 
            // txtMoney
            // 
            this.txtMoney.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMoney.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.txtMoney.Location = new System.Drawing.Point(529, 436);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.ReadOnly = true;
            this.txtMoney.Size = new System.Drawing.Size(373, 32);
            this.txtMoney.TabIndex = 138;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.label2.Location = new System.Drawing.Point(271, 430);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 38);
            this.label2.TabIndex = 137;
            this.label2.Text = "Turnover ：";
            // 
            // txtCount
            // 
            this.txtCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCount.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.txtCount.Location = new System.Drawing.Point(529, 357);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(373, 32);
            this.txtCount.TabIndex = 136;
            // 
            // lable2
            // 
            this.lable2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lable2.AutoSize = true;
            this.lable2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lable2.Location = new System.Drawing.Point(210, 350);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(249, 38);
            this.lable2.TabIndex = 135;
            this.lable2.Text = "Order Count ：";
            // 
            // btnMonth
            // 
            this.btnMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMonth.AutoSize = true;
            this.btnMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnMonth.FlatAppearance.BorderSize = 0;
            this.btnMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonth.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonth.ForeColor = System.Drawing.Color.White;
            this.btnMonth.Location = new System.Drawing.Point(699, 170);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(203, 49);
            this.btnMonth.TabIndex = 134;
            this.btnMonth.Text = "Statistical By Month";
            this.btnMonth.UseVisualStyleBackColor = false;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
            // 
            // btnDay
            // 
            this.btnDay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDay.AutoSize = true;
            this.btnDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDay.FlatAppearance.BorderSize = 0;
            this.btnDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDay.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDay.ForeColor = System.Drawing.Color.White;
            this.btnDay.Location = new System.Drawing.Point(304, 170);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(203, 49);
            this.btnDay.TabIndex = 133;
            this.btnDay.Text = "Statistical By Day";
            this.btnDay.UseVisualStyleBackColor = false;
            this.btnDay.Click += new System.EventHandler(this.btnDay_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(54, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 38);
            this.label1.TabIndex = 128;
            this.label1.Text = "Statistical Data:";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(38, 564);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(178, 50);
            this.btnBack.TabIndex = 99;
            this.btnBack.Text = "<-Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Statistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 638);
            this.Controls.Add(this.panel1);
            this.Name = "Statistical";
            this.Text = "Statistical";
            this.Load += new System.EventHandler(this.Statistical_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMonth;
        private System.Windows.Forms.Button btnDay;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label lable2;
        private System.Windows.Forms.DateTimePicker timeMonth;
        private System.Windows.Forms.DateTimePicker timeDay;
        private System.Windows.Forms.Button btnBack;
    }
}