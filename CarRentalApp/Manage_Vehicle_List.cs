using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BAL;
using BLL;
using CarRentalApp;


namespace CarRentalApp
{
    public partial class Manage_Vehicle_List : Form
    {
        public Manage_Vehicle_List()
        {
            InitializeComponent();

        }
        public DataTable FetchDetail()
        {
            DataTable dtData = new DataTable();

            //vehicleInfo info= new vehicleInfo();
            vehicleOp opr= new vehicleOp();

            dtData=opr.vehicleView();



           // DBConnect.createConnection();
           // SqlConnection con = new SqlConnection();
           // con = DBConnect.SqlConnection;
           // SqlCommand cmd = con.CreateCommand();
           // cmd.CommandType = CommandType.StoredProcedure;
           // cmd.CommandText = "ViewDataGrid";
           //// cmd.Parameters.AddWithValue("@actiontype", "ViewData");
           // SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
           // DataSet ds = new DataSet();
           // sqlSda.Fill(dtData);
           // //dtData.Rows.Count  
           // con.Open();
           // cmd.ExecuteNonQuery();
           // con.Close();
            return dtData;

            
        }

        private void Manage_Vehicle_List_Load(object sender, EventArgs e)
        {

          
            //var cars = _db.TypeOfCars.Select(q=>new { ID=q.id,NAME=q.name,MODEL=q.model,VIN=q.VIN,YEAR=q.Year,REG_NO=q.Reg_NO}).ToList();

            dataGridView1.DataSource = FetchDetail();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "NAME";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // add new car button
            var addEdve=new AddEditVehicle(0);
            addEdve.MdiParent = this.MdiParent;
            addEdve.vid = 0;
            addEdve.Show();
            addEdve.WindowState = FormWindowState.Maximized;
            addEdve.mvfrm = this;

        }

        private void button2_Click(object sender, EventArgs e)
        {   
            //edit car button
            try
            {
                // get id of selected row

                var Id = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;

                // launch AddEditVehicle Window With Data

                if (!Utils.FormIsOpen("AddEditVehicle"))
                {   
                    var addEditVehicle = new AddEditVehicle(Id);
                    addEditVehicle.MdiParent = this.MdiParent;
                    addEditVehicle.vid = Id;
                    addEditVehicle.Show();
                    addEditVehicle.WindowState = FormWindowState.Maximized;
                    addEditVehicle.mvfrm = this;
                }


                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            //remove data from table 
            try
            {

                DialogResult dr = MessageBox.Show("Are you sure want to delete this record?",
                    "Delete", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                // delete from table
                if (dr == DialogResult.Yes)
                {
                    // get id of selected row
                    int id = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;


                    vehicleInfo info = new vehicleInfo();
                    vehicleOp opr=new vehicleOp();

                    opr.vehicleDelete(info,id);

                    //DBConnect.createConnection();
                    //SqlConnection con = new SqlConnection();
                    //con = DBConnect.SqlConnection;
                    //SqlCommand cmd = con.CreateCommand();
                    //cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.CommandText = "RemoveCar";
                    //cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();

      
                    populateGrid();
                }
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void populateGrid()
        {
            //for using refresh DatagridView
          
            vehicleOp opr=new vehicleOp();
            DataSet ds=new DataSet();
            ds = opr.refreshGrid();
            dataGridView1.DataSource=ds;
            dataGridView1.DataMember= "TypeOfCar";


            
            
            
            
            
            //DBConnect.createConnection();
            //SqlConnection con = new SqlConnection();
            //con = DBConnect.SqlConnection;
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "ViewDataGrid";
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds, "TypeOfCar");
            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "TypeOfCar";
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();

        }
        
        
    }
}
