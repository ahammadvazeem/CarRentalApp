namespace CarRentalApp
{
    partial class ManageUser
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
            this.deActivateBtn = new System.Windows.Forms.Button();
            this.PassResetBtn = new System.Windows.Forms.Button();
            this.addBtnUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gvManagUser = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvManagUser)).BeginInit();
            this.SuspendLayout();
            // 
            // deActivateBtn
            // 
            this.deActivateBtn.BackColor = System.Drawing.Color.PaleVioletRed;
            this.deActivateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deActivateBtn.Location = new System.Drawing.Point(641, 497);
            this.deActivateBtn.Name = "deActivateBtn";
            this.deActivateBtn.Size = new System.Drawing.Size(208, 63);
            this.deActivateBtn.TabIndex = 9;
            this.deActivateBtn.Text = "Activate/Deactivate User";
            this.deActivateBtn.UseVisualStyleBackColor = false;
            this.deActivateBtn.Click += new System.EventHandler(this.deActivateBtn_Click);
            // 
            // PassResetBtn
            // 
            this.PassResetBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.PassResetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassResetBtn.Location = new System.Drawing.Point(280, 497);
            this.PassResetBtn.Name = "PassResetBtn";
            this.PassResetBtn.Size = new System.Drawing.Size(293, 63);
            this.PassResetBtn.TabIndex = 8;
            this.PassResetBtn.Text = "Reset Password";
            this.PassResetBtn.UseVisualStyleBackColor = false;
            this.PassResetBtn.Click += new System.EventHandler(this.PassResetBtn_Click);
            // 
            // addBtnUser
            // 
            this.addBtnUser.BackColor = System.Drawing.Color.SpringGreen;
            this.addBtnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtnUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addBtnUser.Location = new System.Drawing.Point(14, 497);
            this.addBtnUser.Name = "addBtnUser";
            this.addBtnUser.Size = new System.Drawing.Size(194, 63);
            this.addBtnUser.TabIndex = 7;
            this.addBtnUser.Text = "Add New User";
            this.addBtnUser.UseVisualStyleBackColor = false;
            this.addBtnUser.Click += new System.EventHandler(this.addBtnUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Matura MT Script Capitals", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(238, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 62);
            this.label1.TabIndex = 6;
            this.label1.Text = "Manage Users";
            // 
            // gvManagUser
            // 
            this.gvManagUser.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gvManagUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvManagUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvManagUser.Location = new System.Drawing.Point(14, 127);
            this.gvManagUser.Name = "gvManagUser";
            this.gvManagUser.RowHeadersWidth = 51;
            this.gvManagUser.RowTemplate.Height = 24;
            this.gvManagUser.Size = new System.Drawing.Size(835, 331);
            this.gvManagUser.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Location = new System.Drawing.Point(752, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 33);
            this.button1.TabIndex = 10;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(863, 572);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.deActivateBtn);
            this.Controls.Add(this.PassResetBtn);
            this.Controls.Add(this.addBtnUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvManagUser);
            this.Name = "ManageUser";
            this.Text = "ManageUser";
            this.Load += new System.EventHandler(this.ManageUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvManagUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deActivateBtn;
        private System.Windows.Forms.Button PassResetBtn;
        private System.Windows.Forms.Button addBtnUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvManagUser;
        private System.Windows.Forms.Button button1;
    }
}