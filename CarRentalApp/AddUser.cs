using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class AddUser : Form
    {

        private readonly rentCarDbEntities1 _db;
        private ManageUser _manageUsers;
        public AddUser(ManageUser manageUser)
        {
            InitializeComponent();
            _db = new rentCarDbEntities1();
            _manageUsers = manageUser;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            var role=_db.Roles.ToList();
            cbRoles.DataSource=role;
            cbRoles.ValueMember = "id";
            cbRoles.DisplayMember = "name";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                var user_name = textBox1.Text;
                var roleid = (int)cbRoles.SelectedValue;
                var password = Utils.DefaultHashPassword();
                var user = new User
                {
                    username = user_name,
                    password = password,
                    isActive = true
                };
                _db.Users.Add(user);
                _db.SaveChanges();
                _manageUsers.populateGrid();

                MessageBox.Show($"New User Added Successfully");
                Close();

                var userid = user.id;

                var userRole = new UserRole
                {

                    roleid = roleid,
                    userid = userid
                };
                _db.UserRoles.Add(userRole);
                _db.SaveChanges();
            }
            catch(Exception)
            {
                MessageBox.Show($"erros occured ");
            }

        }
    }
}
