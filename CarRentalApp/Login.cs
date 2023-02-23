using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class Login : Form
    {
        private readonly rentCarDbEntities1 _db;
        public Login()
        {
            InitializeComponent();
            _db= new rentCarDbEntities1();
        }
       
        private void loginBtn_Click(object sender, EventArgs e)
        {

           
            try
            {

                SHA256 sha = SHA256.Create();

                var username = tbUsername.Text.Trim();
                var password = tbPassword.Text;


                var hashed_Password = Utils.HashPassword(password);

                var user=_db.Users.FirstOrDefault(q=>q.username== username && q.password == hashed_Password && q.isActive==true);

                if (user == null)
                {
                    MessageBox.Show("Please provide valid credentials");
                }
                else
                {

                        var role=user.UserRoles.FirstOrDefault();
                        var roleShortName = role.Role.shortName;
                        var mainWindow = new MainWindow(this, user);
                        mainWindow.Show();
                        mainWindow.WindowState = FormWindowState.Maximized;
                        Hide();
                    
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
                    
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Maximized;
        }

       
    }
}
