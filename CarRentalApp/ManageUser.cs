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
    public partial class ManageUser : Form
    {
        //private readonly rentCarDbEntities1 _db;
        public ManageUser()
        {
            InitializeComponent();
            //_db= new rentCarDbEntities1();
        }

        private void addBtnUser_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("AddUser"))
            {
                var adduser = new AddUser(this);
                adduser.MdiParent = this.MdiParent;
                adduser.Show();
                adduser.mguform = this;
            }
        }

        private void PassResetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //get id of selected row
                var Id = (int)gvManagUser.SelectedRows[0].Cells["id"].Value;

                //query database for record (check database table id and stored id)
              
                var pass = "";
                pass = Utils.DefaultHashPassword();

                AddUserInfo info = new AddUserInfo();
                info.passWord = pass;
                UserOp up=new UserOp();
                up.ResetPassword(info,Id);




                //DBConnect.createConnection();
                //SqlConnection con = new SqlConnection();
                //con = DBConnect.SqlConnection;
                //SqlCommand cmd = con.CreateCommand();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "PassReset";
                //cmd.Parameters.AddWithValue("id", Id);
                //cmd.Parameters.AddWithValue("@password", pass);
                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();



               
                MessageBox.Show(" Password Successfully Reseted");
                populateGrid();
            }
            catch (Exception ex)
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


               var isActive =(bool)gvManagUser.SelectedRows[0].Cells["isActive"].Value;

                ////    //query database for record (check database table id and stored id)
                isActive = isActive == true ? false : true;

                AddUserInfo info=new AddUserInfo();
                info.is_Active= isActive;
                UserOp upr=new UserOp();
                upr.deActivate(info,Id);





                //DBConnect.createConnection();
                //SqlConnection con = new SqlConnection();
                //con = DBConnect.SqlConnection;
                //SqlCommand cmd = con.CreateCommand();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "deActivate";
                //cmd.Parameters.AddWithValue("id", Id);
                //cmd.Parameters.AddWithValue("@isactive", isActive);
                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();

              

               
                  MessageBox.Show("Activate Status Changed");
                    populateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{(ex.Message)}");
            }



}

        public DataTable gridLoad()
        {


            DataTable dt= new DataTable();
            UserOp  upr= new UserOp();
            dt=upr.pageload();
            return dt;



            //DataTable dtData = new DataTable();
            //DBConnect.createConnection();
            //SqlConnection con = new SqlConnection();
            //con = DBConnect.SqlConnection;
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "ManageUserGrid";
            //SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //sqlSda.Fill(dtData);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            //return dtData;
            
        }

        private void ManageUser_Load(object sender, EventArgs e)
        {
            gvManagUser.DataSource = gridLoad();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    populateGrid();
        //}

        public DataSet populateGrid()
        {
            DataSet ds = new DataSet();
            UserOp up = new UserOp();
            ds=up.refreshGrid();
            gvManagUser.DataSource = ds;
            gvManagUser.DataMember = "Users";
            return ds;





            //DBConnect.createConnection();
            //SqlConnection con = new SqlConnection();
            //con = DBConnect.SqlConnection;
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "RefreshManageUser";

            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds, "Users");
            //gvManagUser.DataSource = ds;
            //gvManagUser.DataMember = "Users";
            
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();

        }

        
    }
}
