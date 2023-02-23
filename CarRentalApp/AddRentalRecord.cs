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

namespace CarRentalApp
{
    public partial class AddRentalRecord : Form
    {
        private readonly rentCarDbEntities1 rentcarDbEntities1;
        private bool isEditMode1;
        private ViewRentalRecord _viewRentalRecord;
        public AddRentalRecord(ViewRentalRecord viewRentalRecord)
        {
            InitializeComponent();
            label1.Text = "Add New Rent Record";
            this.Text = "Add new Record";
            isEditMode1 = false;
            _viewRentalRecord = viewRentalRecord;
            rentcarDbEntities1 = new rentCarDbEntities1();

        }

        public AddRentalRecord(CarRentalRecord EditRecord, ViewRentalRecord viewRentalRecord)
        {
            InitializeComponent();
            label1.Text = "Edit Rent Record";
            this.Text = "Edit Record";
            rentcarDbEntities1 = new rentCarDbEntities1();
            

            if(EditRecord==null)
            {
                MessageBox.Show("select valid record to edit");

            }
            else
            {
                isEditMode1 = true;
                populateFields(EditRecord);
                _viewRentalRecord = viewRentalRecord;

            }

        }


        private void populateFields(CarRentalRecord Record)
        {
            textBox1.Text = Record.CustomerNmae;
            textBox2.Text = Record.Cost.ToString();
            dateTimePicker1.Value = (DateTime)Record.RentedDate;
            dateTimePicker2.Value =(DateTime)Record.ReturnedDate;
            label7.Text = Record.id.ToString();

        }




        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string customername = textBox1.Text;
                var rentdate = dateTimePicker1.Value;
                var returneddate = dateTimePicker2.Value;
                double cost =Convert.ToDouble( textBox2.Text);
                var cartype =comboBox1.Text;
                var isValid = true;     // FOR USING VALIDATION
                var errormessage = "";

                // no empty customer name and car type
                if (string.IsNullOrWhiteSpace(customername) || string.IsNullOrWhiteSpace(cartype))
                {
                    isValid = false;
                    errormessage = "Error:please enter missing input!\n\r";
                }
                //returned date must be greater than rented date
                if (returneddate < rentdate)
                {
                    isValid = false;
                    errormessage = "Error:invalid date input!\r";

                }

                if(isValid) 
                
                {
                    if(isEditMode1)
                    {
                        //EDIT CODE
                        var Id = int.Parse(label7.Text);
                        var rentalRecord= rentcarDbEntities1.CarRentalRecords.FirstOrDefault(q=>q.id== Id);

                        rentalRecord.CustomerNmae = customername;
                        rentalRecord.RentedDate = rentdate;
                        rentalRecord.ReturnedDate = returneddate;
                        rentalRecord.Cost =(decimal)cost;
                        rentalRecord.CarTypeId = (int)comboBox1.SelectedValue;

                       

                    }
                    else 
                    {
                        //ADD CODE

                        var rentalRecord = new CarRentalRecord();
                        rentalRecord.CustomerNmae = customername;
                        rentalRecord.RentedDate = rentdate;
                        rentalRecord.ReturnedDate = returneddate;
                        rentalRecord.Cost =(decimal)cost;
                        rentalRecord.CarTypeId = (int)comboBox1.SelectedValue;

                        rentcarDbEntities1.CarRentalRecords.Add(rentalRecord);
                       

                    }
                    rentcarDbEntities1.SaveChanges();
                    _viewRentalRecord.RefreshButton();

                    MessageBox.Show($"CUSTOMER NAME:{customername}\n\r" +
                    $"RENTED DATE: {rentdate}\n\r" +
                    $"RETURN DATE: {returneddate}\n\r" +
                    $"SELECTED CAR: {cartype}\n\r" +
                    $"COST: {cost}\n\n\r" +
                    $"Thank You For Your Contribution");


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
            var cars = rentcarDbEntities1.TypeOfCars.Select(q => new {ID=q.id,NAME=q.name+" "+q.model}).ToList();
            comboBox1.DisplayMember = "NAME";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = cars;

        }
    }
}
