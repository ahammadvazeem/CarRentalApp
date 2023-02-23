namespace CarRentalApp
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manageVehicleListingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRentalRecordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUserToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRentalRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRentalRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageVehicleListingToolStripMenuItem,
            this.manageRentalRecordToolStripMenuItem1,
            this.manageUserToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(844, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
          //  this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // manageVehicleListingToolStripMenuItem
            // 
            this.manageVehicleListingToolStripMenuItem.Name = "manageVehicleListingToolStripMenuItem";
            this.manageVehicleListingToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.manageVehicleListingToolStripMenuItem.Text = "Manage Vehicle Listing";
            this.manageVehicleListingToolStripMenuItem.Click += new System.EventHandler(this.manageVehicleListingToolStripMenuItem_Click);
            // 
            // manageRentalRecordToolStripMenuItem1
            // 
            this.manageRentalRecordToolStripMenuItem1.Name = "manageRentalRecordToolStripMenuItem1";
            this.manageRentalRecordToolStripMenuItem1.Size = new System.Drawing.Size(174, 24);
            this.manageRentalRecordToolStripMenuItem1.Text = "Manage Rental Record";
            this.manageRentalRecordToolStripMenuItem1.Click += new System.EventHandler(this.manageRentalRecordToolStripMenuItem1_Click);
            // 
            // manageUserToolStripMenuItem1
            // 
            this.manageUserToolStripMenuItem1.Name = "manageUserToolStripMenuItem1";
            this.manageUserToolStripMenuItem1.Size = new System.Drawing.Size(110, 24);
            this.manageUserToolStripMenuItem1.Text = "Manage User";
            this.manageUserToolStripMenuItem1.Click += new System.EventHandler(this.manageUserToolStripMenuItem1_Click);
            // 
            // manageVehicleToolStripMenuItem
            // 
            this.manageVehicleToolStripMenuItem.Name = "manageVehicleToolStripMenuItem";
            this.manageVehicleToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.manageVehicleToolStripMenuItem.Text = "Manage Vehicle Listing";
            // 
            // manageRentalRecordToolStripMenuItem
            // 
            this.manageRentalRecordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewRentalRecordToolStripMenuItem});
            this.manageRentalRecordToolStripMenuItem.Name = "manageRentalRecordToolStripMenuItem";
            this.manageRentalRecordToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.manageRentalRecordToolStripMenuItem.Text = "Manage Rental Records";
            // 
            // viewRentalRecordToolStripMenuItem
            // 
            this.viewRentalRecordToolStripMenuItem.Name = "viewRentalRecordToolStripMenuItem";
            this.viewRentalRecordToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.viewRentalRecordToolStripMenuItem.Text = "View Rental Record";
            // 
            // manageUserToolStripMenuItem
            // 
            this.manageUserToolStripMenuItem.Name = "manageUserToolStripMenuItem";
            this.manageUserToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.manageUserToolStripMenuItem.Text = "Manage User";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(844, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 16);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 543);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = " Car Rental Management System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manageVehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRentalRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewRentalRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUserToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem manageVehicleListingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRentalRecordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageUserToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}