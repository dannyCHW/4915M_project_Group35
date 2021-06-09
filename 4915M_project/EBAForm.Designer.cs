
namespace _4915M_project
{
    partial class EBAForm
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.lable2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.checkBox);
            this.panel1.Controls.Add(this.txtOrder);
            this.panel1.Controls.Add(this.lable2);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 622);
            this.panel1.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConfirm.AutoSize = true;
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(342, 352);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(203, 49);
            this.btnConfirm.TabIndex = 126;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // checkBox
            // 
            this.checkBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.checkBox.Location = new System.Drawing.Point(110, 285);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(278, 23);
            this.checkBox.TabIndex = 125;
            this.checkBox.Text = "I\'m sure it is paid by the recipient";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // txtOrder
            // 
            this.txtOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtOrder.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtOrder.Location = new System.Drawing.Point(110, 221);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(695, 27);
            this.txtOrder.TabIndex = 124;
            this.txtOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // lable2
            // 
            this.lable2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lable2.AutoSize = true;
            this.lable2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lable2.Location = new System.Drawing.Point(103, 181);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(187, 38);
            this.lable2.TabIndex = 123;
            this.lable2.Text = "Order ID ：";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBack.AutoSize = true;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(38, 535);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(209, 45);
            this.btnBack.TabIndex = 122;
            this.btnBack.Text = "<-Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(76, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 38);
            this.label1.TabIndex = 111;
            this.label1.Text = "EBA Payment";
            // 
            // EBAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 622);
            this.Controls.Add(this.panel1);
            this.Name = "EBAForm";
            this.Text = "EBAForm";
            this.Load += new System.EventHandler(this.EBAForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Label lable2;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Button btnConfirm;
    }
}