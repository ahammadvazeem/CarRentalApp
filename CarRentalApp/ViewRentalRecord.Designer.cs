namespace CarRentalApp
{
    partial class ViewRentalRecord
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
            this.label1 = new System.Windows.Forms.Label();
            this.rentDetailGrid = new System.Windows.Forms.DataGridView();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rentDetailGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Matura MT Script Capitals", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(345, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(700, 79);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Rental Details";
            // 
            // rentDetailGrid
            // 
            this.rentDetailGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.rentDetailGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rentDetailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rentDetailGrid.Location = new System.Drawing.Point(34, 149);
            this.rentDetailGrid.Name = "rentDetailGrid";
            this.rentDetailGrid.RowHeadersWidth = 51;
            this.rentDetailGrid.RowTemplate.Height = 24;
            this.rentDetailGrid.Size = new System.Drawing.Size(1247, 490);
            this.rentDetailGrid.TabIndex = 1;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.HotPink;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(736, 666);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(253, 47);
            this.deleteBtn.TabIndex = 8;
            this.deleteBtn.Text = "Remove Cust Record";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.editBtn.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Location = new System.Drawing.Point(477, 666);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(253, 47);
            this.editBtn.TabIndex = 7;
            this.editBtn.Text = "Edit Record";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.addBtn.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(218, 666);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(253, 47);
            this.addBtn.TabIndex = 6;
            this.addBtn.Text = "Add New Customer";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // ViewRentalRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 742);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.rentDetailGrid);
            this.Controls.Add(this.label1);
            this.Name = "ViewRentalRecord";
            this.Text = "ViewRentalRecord";
            this.Load += new System.EventHandler(this.ViewRentalRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rentDetailGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView rentDetailGrid;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addBtn;
    }
}