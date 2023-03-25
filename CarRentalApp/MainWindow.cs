using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalApp;

namespace CarRentalApp
{
    public partial class MainWindow : Form

    {
        private Login _login;

        private string _user;
        public string vid;

        public int _userPswd;
        public int _pwd;

        public string _userName;
        public string usrname;

        public string _roleName;
        public string _role;

        public Login lgform;
       

        public MainWindow(Login login, string vid, string usrname, string _role, int _pwd)
        {
            InitializeComponent();
            _login = login;
            _user = vid;
            _userName = usrname;
            _roleName = _role;
            _userPswd = _pwd;

            //_login = login;
            //_user = user;
            //_roleName= _user.UserRoles.FirstOrDefault().Role.shortName;

            //_roleName = ds.Tables[1].Rows[0]["shortName"];


        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            if (_user == Utils.DefaultHashPassword())
            {

                var resetPassword = new ResetPassword(_userPswd);
                resetPassword._User = _userPswd;
                resetPassword.ShowDialog();
                resetPassword.resetpswd = this;
            }


            var username = _userName;
            toolStripStatusLabel2.Text = $"Loged In As: {username}";

            if (_roleName != "admin")
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
                //vehicleListing.ClientSize = new System.Drawing.Size(1900, 750);
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
