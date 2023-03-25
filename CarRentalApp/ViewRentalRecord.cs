using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalApp;
using DAL;
using BLL;
using BAL;

namespace CarRentalApp
{
    public partial class ViewRentalRecord : Form
    {
        //  private readonly rentCarDbEntities1 RdDb;


        //public AddRentalInfo info = new AddRentalInfo();
        //public Operations opr = new Operations();

        public ViewRentalRecord()
        {
            InitializeComponent();
            //RdDb= new rentCarDbEntities1();
        }

        public  void  ViewRentalRecord_Load(object sender, EventArgs e)
        {

            //AddRentalInfo info = new AddRentalInfo();
            Operations opr = new Operations();

            DataTable dt = new DataTable();

            dt = opr.LoadRentalDetails();

            rentDetailGrid.DataSource = dt;

            //Select * from CarRental Records
            // rentDetailGrid.DataSource = gridLoad();
            //Edit Header Text
            //rentDetailGrid.Columns[0].HeaderText = "Booking Id";

        }

        
        //public DataTable gridLoad()
        //{
        //    DataTable dt = new DataTable();
        //    DBConnect.createConnection();
        //    SqlConnection con = new SqlConnection();
        //    con = DBConnect.SqlConnection;
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "LoadRentalDetails";

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    // DataSet ds= new DataSet(); 
        //    da.Fill(dt);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    return dt;

        //}



        private void addBtn_Click(object sender, EventArgs e)
        {
            var addrentRecord=new AddRentalRecord(0);
            addrentRecord.MdiParent = this.MdiParent;
            addrentRecord.rid = 0;
            addrentRecord.Show();
            addrentRecord.WindowState = FormWindowState.Maximized;
            addrentRecord.rnt_id = this;
        }

        public void RefreshButton()
        {
            DataSet ds=new DataSet();
            Operations opr=new Operations();
            ds=opr.refreshGrid();
            rentDetailGrid.DataSource = ds;
            rentDetailGrid.DataMember = "CarRentalRecord";



            //DBConnect.createConnection();
            //SqlConnection con = new SqlConnection();
            //con = DBConnect.SqlConnection;
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "LoadRentalDetails";
            ////for refresh work important 
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds, "CarRentalRecord");
            //rentDetailGrid.DataSource = ds;
            //rentDetailGrid.DataMember = "CarRentalRecord";
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // select row from in datagridView
                var Id = (int)rentDetailGrid.SelectedRows[0].Cells["ID"].Value;


                DialogResult dr = MessageBox.Show("Are you sure want to delete this record?",
                "Delete", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {

                    //dbConnect db = new dbConnect();
                    AddRentalInfo info= new AddRentalInfo();
                    Operations opr=new Operations();
                    opr.deleteRentData(info,Id);





                    //DBConnect.createConnection();
                    //SqlConnection con = new SqlConnection();
                    //con = DBConnect.SqlConnection;
                    //SqlCommand cmd = con.CreateCommand();
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "deleteRentData";
                    //cmd.Parameters.AddWithValue("id", Id);
                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();

                    RefreshButton();
                }
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var Id = (int)rentDetailGrid.SelectedRows[0].Cells["ID"].Value;
                //var editRecord = RdDb.CarRentalRecords.FirstOrDefault(q => q.id == id);
                var editRentRecord = new AddRentalRecord(Id);
                editRentRecord.MdiParent = this.MdiParent;
                editRentRecord.rid = Id;
                editRentRecord.Show();
                editRentRecord.WindowState = FormWindowState.Maximized;
                editRentRecord.rnt_id = this;

            }
            catch (Exception ex) 
            { 
            MessageBox.Show(ex.Message);
            
            }
        }

        
    }

}
