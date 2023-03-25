using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CarRentalApp;
using System.Security.Cryptography;
using BLL;
using BAL;


namespace CarRentalApp
{
    public partial class AddRentalRecord : Form
    {
        //private readonly rentCarDbEntities1 rentcarDbEntities1;
        private bool isEditMode1;
       // private ViewRentalRecord _viewRentalRecord;
        public int rid;
        public  ViewRentalRecord rnt_id;
        public AddRentalRecord(int rid)
        {
            InitializeComponent();

            if(rid == 0)
            {
                label1.Text = "Add New Rent Record";
                this.Text = "Add new Record";
                isEditMode1 = false;
                //_viewRentalRecord = viewRentalRecord;
                //rentcarDbEntities1 = new rentCarDbEntities1();

            }
            else
            {
                label1.Text = "Edit Rent Record";
                this.Text = "Edit Record";
                isEditMode1 = true;

                DataTable dtb= GetData(rid);

                label7.Text = dtb.Rows[0]["id"].ToString();
                textBox1.Text = dtb.Rows[0]["CustomerNmae"].ToString();
                dateTimePicker1.Value = (DateTime)dtb.Rows[0]["RentedDate"];
                dateTimePicker2.Value = (DateTime)dtb.Rows[0]["ReturnedDate"];
                textBox2.Text = dtb.Rows[0]["Cost"].ToString();
                comboBox1.Text = dtb.Rows[0]["CarTypeid"].ToString();

            }


        }

        

        private void populateFields(CarRentalRecord Record)
        {
            //textBox1.Text = Record.CustomerNmae;
            //textBox2.Text = Record.Cost.ToString();
            //dateTimePicker1.Value = (DateTime)Record.RentedDate;
            //dateTimePicker2.Value =(DateTime)Record.ReturnedDate;
            //label7.Text = Record.id.ToString();

        }

        public DataTable GetData(int rid) 
        {
            DataTable dt=new DataTable();
            Operations op = new Operations();
            dt=op.getRentData(rid);
            return dt;


        //    DataTable dt = new DataTable();
        //    DBConnect.createConnection();
        //    SqlConnection con = new SqlConnection();
        //    con = DBConnect.SqlConnection;
        //    SqlCommand cmd= con.CreateCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "EditData";
        //    cmd.Parameters.AddWithValue("@id", rid);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    return dt;
        }




        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string customername = textBox1.Text;
                var rentdate = dateTimePicker1.Value;
                var returneddate = dateTimePicker2.Value;
                double cost = Convert.ToDouble(textBox2.Text);
                var cartype = comboBox1.SelectedValue;
                var isValid = true;     // FOR USING VALIDATION
                var errormessage = "";


                if (isValid)

                {


                    //DBConnect.createConnection();
                    //SqlConnection con = new SqlConnection();
                    //con = DBConnect.SqlConnection;
                    //SqlCommand cmd = con.CreateCommand();
                    //cmd.CommandType = CommandType.StoredProcedure;

                    if (isEditMode1)
                    {
                        //EDIT CODE
                        int Id = int.Parse(label7.Text);

                        AddRentalInfo info = new AddRentalInfo();
                        info.Customer_name = customername;
                        info.rentDate = rentdate;
                        info.returnDate = returneddate;
                        info.Rent_cost = (decimal)cost;
                        info.cartype_id = (int)cartype;

                        Operations opr = new Operations();
                        opr.AddRentalDetail(info,Id);



                        //cmd.CommandText = "AddRentalDetail";
                        //cmd.Parameters.AddWithValue("@actiontype", "saveData");
                        //cmd.Parameters.Add("@id",SqlDbType.Int).Value = Id;
                        //cmd.Parameters.Add("@customername",SqlDbType.VarChar,50).Value= customername;
                        //cmd.Parameters.Add("@renteddate",SqlDbType.DateTime).Value= rentdate;
                        //cmd.Parameters.Add("@returneddate",SqlDbType.DateTime).Value= returneddate;
                        //cmd.Parameters.Add("@cost",SqlDbType.Decimal).Value= cost;
                        //cmd.Parameters.Add("@cartypeid",SqlDbType.Int).Value= cartype;

                        //con.Open();
                        //cmd.ExecuteNonQuery();
                        //con.Close();

                        //var rentalRecord = rentcarDbEntities1.CarRentalRecords.FirstOrDefault(q => q.id == Id);

                        //rentalRecord.CustomerNmae = customername;
                        //rentalRecord.RentedDate = rentdate;
                        //rentalRecord.ReturnedDate = returneddate;
                        //rentalRecord.Cost = (decimal)cost;
                        //rentalRecord.CarTypeId = (int)comboBox1.SelectedValue;



                    }
                    else
                    {
                        ///ADD CODE
                        ///
                         int Id=0;
                       
                        //cmd.CommandText = "AddRentalDetail";
                        //cmd.Parameters.AddWithValue("@actiontype", "saveData");
                        //cmd.Parameters.AddWithValue("@id",Id);
                        //cmd.Parameters.Add("@customername", SqlDbType.VarChar, 50).Value = customername;
                        //cmd.Parameters.Add("@renteddate", SqlDbType.DateTime).Value = rentdate;
                        //cmd.Parameters.Add("@returneddate", SqlDbType.DateTime).Value = returneddate;
                        //cmd.Parameters.Add("@cost", SqlDbType.Decimal).Value = cost;
                        //cmd.Parameters.Add("@cartypeid", SqlDbType.Int).Value = cartype;
                        //con.Open();
                        //cmd.ExecuteNonQuery();
                        //con.Close();


                        AddRentalInfo info= new AddRentalInfo();
                        info.Customer_name = customername;
                        info.rentDate = rentdate;
                        info.returnDate = returneddate;
                        info.Rent_cost = (decimal)cost;
                        info.cartype_id = (int)cartype;

                        Operations opr=new Operations();
                        opr.AddRentalDetail(info,Id);


                    }


                    MessageBox.Show($"CUSTOMER NAME:{customername}\n\r" +
                    $"RENTED DATE: {rentdate}\n\r" +
                    $"RETURN DATE: {returneddate}\n\r" +
                    $"SELECTED CAR: {cartype}\n\r" +
                    $"COST: {cost}\n\n\r" +
                    $"Thank You For Your Contribution");

                    rnt_id.RefreshButton();

                    Close();

                }

                else
                {
                    MessageBox.Show(errormessage);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void AddRentalRecord_Load(object sender, EventArgs e)
        {
            //int Id = comboBox1.SelectedIndex;
            ////var cars = rentcarDbEntities1.TypeOfCars.Select(q => new {ID=q.id,NAME=q.name+" "+q.model}).ToList();
            //DBConnect.createConnection();
            //SqlConnection con = new SqlConnection();
            //con = DBConnect.SqlConnection;
            //SqlCommand cmd=con.CreateCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "Combox";
            //cmd.Parameters.AddWithValue("@id",Id);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();

            comboBox1.DataSource = comboLoad();
            comboBox1.DisplayMember = "model";
            comboBox1.ValueMember = "id";



        }

        public DataTable comboLoad()
        {

            DataTable dt=new DataTable();
            Operations op=new Operations();
            dt=op.comboLoding();
            return dt;





            //DataTable dt = new DataTable();
            //DBConnect.createConnection();
            //SqlConnection con = new SqlConnection();
            //con = DBConnect.SqlConnection;
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "Combox";
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            //return dt;


        }

    }
}
