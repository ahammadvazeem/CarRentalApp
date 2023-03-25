using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalApp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CarRentalApp
{
    public partial class Login : Form
    {
        public User  uid;

        //private readonly rentCarDbEntities1 _db;
        
        public Login()
        {
            InitializeComponent();
            //_db= new rentCarDbEntities1();
           
        }
             



        private void loginBtn_Click(object sender, EventArgs e)
        {

           
            try
            {

                SHA256 sha = SHA256.Create();

                var username = tbUsername.Text.Trim();
                var password = tbPassword.Text;
                //bool isActive=true;

                var hashed_Password = Utils.HashPassword(password);
                //var user=_db.Users.FirstOrDefault(q=>q.username== username && q.password == hashed_Password && q.isActive==true);
                //var isActive=true;


                bool IsActive = true;

                    DataTable dt = new DataTable();
                    DBConnect.createConnection();
                    SqlConnection con = new SqlConnection();
                    con = DBConnect.SqlConnection;
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Login_Data";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashed_Password);
                    cmd.Parameters.AddWithValue("@isactive", IsActive);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                var count = ds.Tables[0].Rows.Count;

                //var rolnm = ds.Tables[1].Rows[0]["shortName"];

                if (count==1)
                    {

                    var pid = (int)ds.Tables[0].Rows[0]["id"];


                    ////var role = _user.UserRoles.FirstOrDefault();
                    var role =(string)ds.Tables[1].Rows[0]["shortName"];
                    //var roleShortName = role.Roles.shortName;
                    var Uname =(string) ds.Tables[0].Rows[0]["username"];

                    var uid = (string)ds.Tables[0].Rows[0]["password"];
                   // var uid =(int)ds.Tables[0].Rows[0]["id"];

                    var mainWindow = new MainWindow(this,uid,Uname,role,pid);
                    mainWindow.usrname=Uname;
                    mainWindow.vid = uid;
                    mainWindow._role = role;
                    mainWindow._pwd = pid;
                    mainWindow.Show();
                    mainWindow.WindowState = FormWindowState.Maximized;
                    mainWindow.lgform = this;
                    
                    Hide();
                      
                    }
                    else
                    {
                        MessageBox.Show($"       Please Provide Valid Credentials\r\n\n(  OR User '{username}' Is Currently Not Active! )" );
                    }
                



                //if (username == _user.username || password == _user.password || _user.isActive == true)
                //{

                //    var role = _user.UserRoles.FirstOrDefault();
                //    var roleShortName = role.Role.shortName;
                //    var mainWindow = new MainWindow(this, _user);
                //    mainWindow.Show();
                //    mainWindow.WindowState = FormWindowState.Maximized;
                //    Hide();


                //}
                //else
                //{

                //    MessageBox.Show("Please provide valid credentials");


                //}




                //if (isActive == false)
                //{
                //    MessageBox.Show("Please provide valid credentials");
                //}
                //else
                //{

                //    var role = user.UserRoles.FirstOrDefault();
                //    var roleShortName = role.Role.shortName;
                //    var mainWindow = new MainWindow(this, user);
                //    mainWindow.Show();
                //    mainWindow.WindowState = FormWindowState.Maximized;
                //    Hide();

                //}

            }
            catch (Exception ex)
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
