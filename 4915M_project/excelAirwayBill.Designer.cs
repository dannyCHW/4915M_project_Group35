
namespace _4915M_project
{
    partial class excelAirwayBill
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
            this.btnGetfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetfile
            // 
            this.btnGetfile.Location = new System.Drawing.Point(480, 578);
            this.btnGetfile.Name = "btnGetfile";
            this.btnGetfile.Size = new System.Drawing.Size(75, 23);
            this.btnGetfile.TabIndex = 0;
            this.btnGetfile.Text = "button1";
            this.btnGetfile.UseVisualStyleBackColor = true;
            this.btnGetfile.Click += new System.EventHandler(this.btnGetfile_Click);
            // 
            // excelAirwayBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 660);
            this.Controls.Add(this.btnGetfile);
            this.Name = "excelAirwayBill";
            this.Text = "excelAirwayBill";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetfile;
    }
}