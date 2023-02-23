using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class ViewRentalRecord : Form
    {
        private readonly rentCarDbEntities1 RdDb;
        public ViewRentalRecord()
        {
            InitializeComponent();
            RdDb= new rentCarDbEntities1();
        }

        private void ViewRentalRecord_Load(object sender, EventArgs e)
        {
            //var R_detail=RdDb.CarRentalRecords.ToList();

            //Select * from CarRental Records
            var R_detail = RdDb.CarRentalRecords.Select(r => new
            {
                ID = r.id,
                Name = r.CustomerNmae,
                Rent_Date = r.RentedDate,
                Return_Date = r.ReturnedDate,
                Rent_Cost = r.Cost,
                //CarType_ID=r.CarTypeId 
                Car = r.TypeOfCar.name + " " + r.TypeOfCar.model

            }).ToList();

            rentDetailGrid.DataSource=R_detail;
            
            //Edit Header Text
            rentDetailGrid.Columns[0].HeaderText = "Booking Id";


        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var addrentRecord=new AddRentalRecord(this);
            addrentRecord.MdiParent = this.MdiParent;
            addrentRecord.Show();
            addrentRecord.WindowState = FormWindowState.Maximized;

        }

        public void RefreshButton()
        {

            var reload = RdDb.CarRentalRecords.Select(q => new {
                
                Name=q.CustomerNmae,
                RentDate=q.RentedDate,
                ReturnDate=q.ReturnedDate,
                Rent_Cost=q.Cost,
                //CarTypeId=q.CarTypeId,
                Car = q.TypeOfCar.name + " " + q.TypeOfCar.model,
                q.id
            }).ToList();

            rentDetailGrid.DataSource= reload;



        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            // select row from in datagridView
            var Id = (int)rentDetailGrid.SelectedRows[0].Cells["ID"].Value;
            // queery databse for record
            var record = RdDb.CarRentalRecords.FirstOrDefault(q=>q.id==Id);
            // confirmation message
                   DialogResult dr = MessageBox.Show("Are you sure want to delete this record?",
                   "Delete", MessageBoxButtons.YesNoCancel,
                   MessageBoxIcon.Warning);

            // delete selected record

            if (dr==DialogResult.Yes)
            {
                RdDb.CarRentalRecords.Remove(record);
                RdDb.SaveChanges();
            }

            //Refresh
            RefreshButton();

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            var id = (int)rentDetailGrid.SelectedRows[0].Cells["ID"].Value;
            var editRecord = RdDb.CarRentalRecords.FirstOrDefault(q => q.id == id);
            var editRentRecord = new AddRentalRecord(editRecord,this);
            editRentRecord.MdiParent = this.MdiParent;
            editRentRecord.Show();
            editRentRecord.WindowState = FormWindowState.Maximized;


        }
    }
}
