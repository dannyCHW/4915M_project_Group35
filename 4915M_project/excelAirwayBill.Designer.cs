
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
            this.dgvShipment = new System.Windows.Forms.DataGridView();
            this.dgvGoods = new System.Windows.Forms.DataGridView();
            this.label21 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetfile
            // 
            this.btnGetfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnGetfile.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnGetfile.ForeColor = System.Drawing.Color.White;
            this.btnGetfile.Location = new System.Drawing.Point(12, 533);
            this.btnGetfile.Name = "btnGetfile";
            this.btnGetfile.Size = new System.Drawing.Size(189, 46);
            this.btnGetfile.TabIndex = 0;
            this.btnGetfile.Text = "Import Excel";
            this.btnGetfile.UseVisualStyleBackColor = false;
            this.btnGetfile.Click += new System.EventHandler(this.btnGetfile_Click);
            // 
            // dgvShipment
            // 
            this.dgvShipment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShipment.Location = new System.Drawing.Point(12, 59);
            this.dgvShipment.Name = "dgvShipment";
            this.dgvShipment.RowTemplate.Height = 24;
            this.dgvShipment.Size = new System.Drawing.Size(896, 205);
            this.dgvShipment.TabIndex = 1;
            // 
            // dgvGoods
            // 
            this.dgvGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoods.Location = new System.Drawing.Point(12, 270);
            this.dgvGoods.Name = "dgvGoods";
            this.dgvGoods.RowTemplate.Height = 24;
            this.dgvGoods.Size = new System.Drawing.Size(896, 247);
            this.dgvGoods.TabIndex = 2;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(12, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(404, 38);
            this.label21.TabIndex = 72;
            this.label21.Text = "Bulk Order (Import Excel)";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblFileName.Location = new System.Drawing.Point(207, 551);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(125, 16);
            this.lblFileName.TabIndex = 73;
            this.lblFileName.Text = "Waiting for Import";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(604, 602);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(304, 46);
            this.btnSubmit.TabIndex = 74;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // excelAirwayBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 660);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dgvGoods);
            this.Controls.Add(this.dgvShipment);
            this.Controls.Add(this.btnGetfile);
            this.Name = "excelAirwayBill";
            this.Text = "excelAirwayBill";
            this.Load += new System.EventHandler(this.excelAirwayBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetfile;
        private System.Windows.Forms.DataGridView dgvShipment;
        private System.Windows.Forms.DataGridView dgvGoods;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnSubmit;
    }
}