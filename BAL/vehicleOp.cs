using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BAL
{
    public class vehicleOp
    {
        

        public void vehicleEdit(vehicleInfo info,int id)
        {
                dbConnect db = new dbConnect();
            
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ManageVehicleList";
                cmd.Parameters.AddWithValue("@actiontype", "savedata");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = info.car_name;
                cmd.Parameters.Add("@model", SqlDbType.VarChar, 50).Value = info.car_model;
                cmd.Parameters.Add("@vin", SqlDbType.VarChar, 50).Value = info.car_vin;
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = info.car_year;
                cmd.Parameters.Add("@regno", SqlDbType.VarChar, 50).Value = info.car_regno;

                db.ExcecuteVehicleQuery(cmd);


            
        }

        public  DataTable vehicleView()
        {

            
            dbConnect db = new dbConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ViewDataGrid";
            db.ExcecuteVehicleQuery(cmd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
           
        }


        public void vehicleDelete(vehicleInfo info,int id)
        {
            dbConnect db = new dbConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RemoveCar";
            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
            db.ExcecuteVehicleQuery(cmd);
        }

        public DataSet refreshGrid()
        {
            dbConnect db=new dbConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ViewDataGrid";
            db.ExcecuteVehicleQuery(cmd);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataSet ds=new DataSet();
            da.Fill(ds, "TypeOfCar");
            return ds;
            
        }

        public DataTable editVehicleRead(int vid)
        {
            dbConnect db = new dbConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "editButton";
            cmd.Parameters.AddWithValue("@id", vid);
            SqlDataAdapter da =new SqlDataAdapter(cmd);
            db.ExcecuteVehicleQuery(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
    }
}
