using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class MainWindow : Form
    {
        private Login _login;
        public string _roleName;
        public User _user;
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(Login login,User user)
        {
            InitializeComponent();
            _login = login;
            _user = user;
            _roleName= user.UserRoles.FirstOrDefault().Role.shortName;
        }

        

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            if(_user.password==Utils.DefaultHashPassword())
            {

                var resetPassword = new  ResetPassword(_user);
                resetPassword.ShowDialog();
            }


            var username = _user.username;
            toolStripStatusLabel2.Text = $"Loged In As: {username}";

            if(_roleName!="admin")
            {
                manageUserToolStripMenuItem1.Visible = false;

            }
        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Openforms = Application.OpenForms.Cast<Form>();
            var isOpen = Openforms.Any(q => q.Name == "Manage_Vehicle_List");
            if (!isOpen)
            {
                var vehicleListing = new Manage_Vehicle_List();
                vehicleListing.MdiParent = this;
                vehicleListing.ClientSize = new System.Drawing.Size(1900, 750);
                vehicleListing.Show();
                vehicleListing.WindowState = FormWindowState.Maximized;
            }
        }

        private void manageRentalRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Openforms = Application.OpenForms.Cast<Form>();
            var isOpen = Openforms.Any(q => q.Name == "ViewRentalRecord");
            if (!isOpen)
            {

                var rentDView = new ViewRentalRecord();
                rentDView.MdiParent = this;
                rentDView.Show();
                rentDView.WindowState = FormWindowState.Maximized;

            }
        }

        private void manageUserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("ManageUser"))
            {
                var usermanage = new ManageUser();
                usermanage.MdiParent = this;
                usermanage.Show();
                usermanage.WindowState = FormWindowState.Maximized;
            }
        }

        
    }
}
