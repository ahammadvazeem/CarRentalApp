using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BAL;
using BLL;
using CarRentalApp;

namespace CarRentalApp
{
    public partial class AddUser : Form
    {

        //private readonly rentCarDbEntities1 _db;
        private ManageUser _manageUsers;

        public ManageUser mguform;

        public AddUser(ManageUser manageUser)
        {
            InitializeComponent();
            //_db = new rentCarDbEntities1();
            _manageUsers = manageUser;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            cbRoles.DataSource=role();
            cbRoles.ValueMember = "id";
            cbRoles.DisplayMember = "shortName";
        }
        public DataTable role()
        {
            
            DataTable dt=new DataTable();
            UserOp urp=new UserOp();

            dt=urp.roleView();
            
            return dt;
            
            
            //DataTable dt = new DataTable();
            //DBConnect.createConnection();
            //SqlConnection con = new SqlConnection();
            //con = DBConnect.SqlConnection;
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "RolesCombo";
            //SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //sqlSda.Fill(dt);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            //return dt;
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
                var isActive = true;

               
                //----------

                RoleInfo roleInfo=new RoleInfo();
                AddUserInfo userInfo= new AddUserInfo();
                UserOp up= new UserOp();

                userInfo.is_Active = isActive;
                userInfo.userName = user_name;
                userInfo.passWord= password;
                roleInfo.roleid=roleid;

                up.userAdd(userInfo,roleInfo);

                //--------





                //DBConnect.createConnection();
                //SqlConnection con = new SqlConnection();
                //con = DBConnect.SqlConnection;
                //SqlCommand cmd = con.CreateCommand();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "User_Insert";
                //cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = user_name;
                //cmd.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = password;
                //cmd.Parameters.Add("@isactive", SqlDbType.Bit).Value = isActive;

                //cmd.Parameters.Add("@roleid", SqlDbType.Int).Value = roleid;

                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
              

                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();

                MessageBox.Show($"New User Added Successfully");
                
                mguform.populateGrid();
                Close();


            }
            catch (Exception)
            {
                MessageBox.Show($"erros occured ");
            }

        }
    }
}
