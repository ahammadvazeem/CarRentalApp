using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using CarRentalApp;
using BLL;
using BAL;

namespace CarRentalApp
{
    public partial class AddEditVehicle : Form
    {
        private bool isEditMode;
        public int vid;
        public Manage_Vehicle_List  mvfrm;


        
        
        public AddEditVehicle(int vid)
        {
            InitializeComponent();

            if (vid == 0)
            {

                label6.Text = "Add New Vehicle";
                this.Text = "Add new Vehicle";
                isEditMode = false;
            }
            else
            {

                label6.Text = "Edit Vehicle";
                this.Text = "Edit Vehicle";
                isEditMode = true;
                DataTable dtbl= editRead(vid);
                
                    label7.Text = dtbl.Rows[0]["id"].ToString();
                    tbCarname.Text = dtbl.Rows[0]["name"].ToString();
                    tbModel.Text = dtbl.Rows[0]["model"].ToString();
                    tbVin.Text = dtbl.Rows[0]["VIN"].ToString();
                    tbYear.Text = dtbl.Rows[0]["Year"].ToString();
                    tbRegno.Text = dtbl.Rows[0]["Reg_No"].ToString();

                
                
            }


        }

        public DataTable editRead(int vid)
        {
            DataTable table = new DataTable();
            DBConnect.createConnection();
            SqlConnection con = new SqlConnection();
            con = DBConnect.SqlConnection;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "editButton";
            cmd.Parameters.AddWithValue("@id", vid);
            SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
            sqlSda.Fill(table);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return table;
          

        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //DBConnect.createConnection();
                //SqlConnection con = new SqlConnection();
                //con = DBConnect.SqlConnection;
                //SqlCommand cmd = con.CreateCommand();
                //cmd.CommandType = CommandType.StoredProcedure;



                if (isEditMode)
                {


                    // EDIT CODE
                    var id = int.Parse(label7.Text);
                    
                    vehicleInfo info=new vehicleInfo();

                    info.car_name = tbCarname.Text;
                    info.car_model = tbModel.Text;
                    info.car_vin = tbVin.Text;
                    info.car_year = tbYear.Text;
                    info.car_regno = tbRegno.Text;

                    vehicleOp opr= new vehicleOp(); 
                    opr.vehicleEdit(info,id);




                    //cmd.CommandText = "ManageVehicleList";
                    //cmd.Parameters.AddWithValue("@actiontype", "savedata");
                    //cmd.Parameters.AddWithValue("@id", id);
                    //cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = tbCarname.Text;
                    //cmd.Parameters.Add("@model", SqlDbType.VarChar, 50).Value = tbModel.Text;
                    //cmd.Parameters.Add("@vin", SqlDbType.VarChar, 50).Value = tbVin.Text;
                    //cmd.Parameters.Add("@year", SqlDbType.Int).Value = tbYear.Text;
                    //cmd.Parameters.Add("@regno", SqlDbType.VarChar, 50).Value = tbRegno.Text;

                }
                else
                {
                    // ADD CODE
                    int id = 0;

                    vehicleInfo info = new vehicleInfo();

                    info.car_name = tbCarname.Text;
                    info.car_model = tbModel.Text;
                    info.car_vin = tbVin.Text;
                    info.car_year = tbYear.Text;
                    info.car_regno = tbRegno.Text;

                    vehicleOp opr = new vehicleOp();
                    opr.vehicleEdit(info, id);





                    //cmd.CommandText = "ManageVehicleList";
                    //cmd.Parameters.AddWithValue("@actiontype", "savedata");
                    //cmd.Parameters.AddWithValue("@id", id);
                    //cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = tbCarname.Text;
                    //cmd.Parameters.Add("@model", SqlDbType.VarChar, 50).Value = tbModel.Text;
                    //cmd.Parameters.Add("@vin", SqlDbType.VarChar, 50).Value = tbVin.Text;
                    //cmd.Parameters.Add("@year", SqlDbType.Int).Value = tbYear.Text;
                    //cmd.Parameters.Add("@regno", SqlDbType.VarChar, 50).Value = tbRegno.Text;



                }
                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();
                MessageBox.Show("update operation completed, Refresh grid to see changes");
                mvfrm.populateGrid(); 
                //Close();
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
