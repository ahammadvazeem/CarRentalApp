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
    public partial class Manage_Vehicle_List : Form
    {
        private readonly rentCarDbEntities1 _db;
        public Manage_Vehicle_List()
        {
            InitializeComponent();
            _db= new rentCarDbEntities1();
        }

        private void Manage_Vehicle_List_Load(object sender, EventArgs e)
        {
            //var cars=_db.TypeOfCars.ToList();
            var cars = _db.TypeOfCars.Select(q=>new { ID=q.id,NAME=q.name,MODEL=q.model,VIN=q.VIN,YEAR=q.Year,REG_NO=q.Reg_NO}).ToList();
            
            dataGridView1.DataSource= cars;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "NAME";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // add new car button
            var addEdve=new AddEditVehicle(this);
            addEdve.MdiParent = this.MdiParent;
            addEdve.Show();
            addEdve.WindowState = FormWindowState.Maximized;


        }

        private void button2_Click(object sender, EventArgs e)
        {   
            //edit car button
            try
            {


                    // get id of selected row
                    var id = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;

                    //query database for record
                    var car = _db.TypeOfCars.FirstOrDefault(q => q.id == id);

                // launch AddEditVehicle Window With Data

                if (!Utils.FormIsOpen("AddEditVehicle"))
                {
                    var addEditVehicle = new AddEditVehicle(car, this);
                    addEditVehicle.MdiParent = this.MdiParent;
                    addEditVehicle.Show();
                    addEditVehicle.WindowState = FormWindowState.Maximized;
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
                // get id of selected row
                var id = (int)dataGridView1.SelectedRows[0].Cells["ID"].Value;

                //query database for record
                var car = _db.TypeOfCars.FirstOrDefault(q => q.id == id);

                DialogResult dr = MessageBox.Show("Are you sure want to delete this record?",
                    "Delete",MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);


                // delete from table
                if (dr == DialogResult.Yes)
                {
                    _db.TypeOfCars.Remove(car);
                    _db.SaveChanges();
                }

                //dataGridView1.Refresh();
                populateGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        

        public void populateGrid()
        {

            //for using refresh DatagridView
            var reset = _db.TypeOfCars.Select(
                q => new
                {

                    Name = q.name,
                    Modal = q.model,
                    Vin = q.VIN,
                    year = q.Year,
                    regno = q.Reg_NO,
                    q.id
                }

                ).ToList();
            dataGridView1.DataSource = reset;
            dataGridView1.Columns[5].HeaderText = "REG NUM";
            dataGridView1.Columns["id"].Visible = false;

        }
    }
}
