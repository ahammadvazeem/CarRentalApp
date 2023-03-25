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
using BLL;
using BAL;
using CarRentalApp;

namespace CarRentalApp
{
    public partial class ResetPassword : Form
    {
        //  private readonly rentCarDbEntities1 _db;
        // public User _User;

        public int user;
        public int _User;

        public MainWindow resetpswd;

        public ResetPassword(int _User)
        {
            InitializeComponent();
           // _db = new rentCarDbEntities1();
             user=_User;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                var password = textBox1.Text;
                var confirmpswd = textBox2.Text;
                //var user = _db.Users.FirstOrDefault(q => q.id ==_User.id);
                int Id = user;


                if (password != confirmpswd)
                {
                    MessageBox.Show("Entered Password is mismatched,please try Again...");

                }
                else
                {

                    password = Utils.HashPassword(password);


                    PassResetInfo info= new PassResetInfo();

                    info.ResetId = Id;
                    info.rePassword= password;
                    
                    PassResetOp opr=new  PassResetOp();
                    opr.reset_password(info);





                    //DBConnect.createConnection();
                    //SqlConnection con = new SqlConnection();
                    //con = DBConnect.SqlConnection;
                    //SqlCommand cmd = con.CreateCommand();
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "ResetPassword";
                    //cmd.Parameters.AddWithValue("@id", Id);
                    //cmd.Parameters.AddWithValue("@password", password);
                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();



                    MessageBox.Show("possword is successfully Reseted");
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
