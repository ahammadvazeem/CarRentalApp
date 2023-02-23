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
    public partial class ManageUser : Form
    {
        private readonly rentCarDbEntities1 _db;
        public ManageUser()
        {
            InitializeComponent();
            _db= new rentCarDbEntities1();
        }

        private void addBtnUser_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("AddUser"))
            {
                var adduser = new AddUser(this);
                adduser.MdiParent = this.MdiParent;
                adduser.Show();
            }
        }

        private void PassResetBtn_Click(object sender, EventArgs e)
        {
            try 
            { 
                //get id of selected row
                var Id= (int)gvManagUser.SelectedRows[0].Cells["id"].Value;

                //query database for record (check database table id and stored id)
                var user = _db.Users.FirstOrDefault(q=>q.id==Id);

                var hash_password = Utils.DefaultHashPassword(); 
                user.password= hash_password;
                _db.SaveChanges();
                MessageBox.Show($"{user.username}'s Password Successfully Reseted");
                populateGrid();
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Error:{(ex.Message)}");
            }

        }

        private void deActivateBtn_Click(object sender, EventArgs e)
        {


            try
            {
                //get id of selected row
                var Id = (int)gvManagUser.SelectedRows[0].Cells["id"].Value;

                //query database for record (check database table id and stored id)
                var user = _db.Users.FirstOrDefault(q => q.id == Id);

                //  if(user.isActive==true)
                //  {
                //    true;
                //  } 
                //  else
                //  {
                //  false;
                //  }  

                user.isActive = user.isActive ==true ? false :true ;
                
                _db.SaveChanges();
                MessageBox.Show($"{user.username}'s Activate Status Changed");
                populateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{(ex.Message)}");
            }



        }

        public void populateGrid()
        {
            try
            {
                var users = _db.Users.Select(q => new
                {   q.id,
                    q.username,
                    q.password,
                    q.UserRoles.FirstOrDefault().Role.name,
                    q.isActive
                })
                    .ToList();
                gvManagUser.DataSource = users;
                gvManagUser.Columns["username"].HeaderText = "User Name";
                gvManagUser.Columns["name"].HeaderText = "Role Name";
                gvManagUser.Columns["isActive"].HeaderText = "Active";

                gvManagUser.Columns["id"].Visible = false;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void ManageUser_Load(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            populateGrid();
        }
    }
}
