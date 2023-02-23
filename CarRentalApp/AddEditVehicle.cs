using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class AddEditVehicle : Form
    {
        private readonly rentCarDbEntities1 _db;
        private bool isEditMode;
        private Manage_Vehicle_List _manageVehicleList;

        public AddEditVehicle(Manage_Vehicle_List manage_Vehicle_List=null)
        {
            InitializeComponent();
            label6.Text = "Add New Vehicle";
            this.Text = "Add new Vehicle";
            isEditMode = false;
           _manageVehicleList= manage_Vehicle_List;
            _db = new rentCarDbEntities1();
        }
        public AddEditVehicle(TypeOfCar carToEdit,Manage_Vehicle_List manage_Vehicle_List = null)
        {
            InitializeComponent();
            label6.Text = "Edit Vehicle";
            this.Text = "Edit Vehicle";
            _manageVehicleList = manage_Vehicle_List;

            if (carToEdit == null)
            {
                MessageBox.Show("select valid record to edit");

            }
            else
            {
                isEditMode = true;
                _db = new rentCarDbEntities1();
                populateFields(carToEdit);
            }
        }

        private void populateFields(TypeOfCar car)
        {
            label7.Text=car.id.ToString();
            tbCarname.Text = car.name;
            tbModel.Text = car.model;
            tbVin.Text = car.VIN;
            tbYear.Text = car.Year.ToString();
            tbRegno.Text = car.Reg_NO; 
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (isEditMode)
                {
                    // EDIT CODE

                    var id = int.Parse(label7.Text);
                    var car = _db.TypeOfCars.FirstOrDefault(q => q.id == id);

                    car.name = tbCarname.Text;
                    car.model = tbModel.Text;
                    car.VIN = tbVin.Text;
                    car.Year = int.Parse(tbYear.Text);
                    car.Reg_NO = tbRegno.Text;
                }
                else
                {
                    // ADD CODE
                    var newCar = new TypeOfCar
                    {

                        name = tbCarname.Text,
                        model = tbModel.Text,
                        VIN = tbVin.Text,
                        Year = int.Parse(tbYear.Text),
                        Reg_NO = tbRegno.Text


                    };

                  

                    _db.TypeOfCars.Add(newCar);
                
                }
                _db.SaveChanges();
                _manageVehicleList.populateGrid();
                MessageBox.Show("update operation completed, Refresh grid to see changes");
                Close();
            }
            catch(Exception ex) 
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
