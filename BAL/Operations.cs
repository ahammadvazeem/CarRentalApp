using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;

namespace BAL
{
    public class Operations
    {
        public dbConnect db=new dbConnect();
        public AddRentalInfo info=new AddRentalInfo();
        public void AddRentalDetail(global::BLL.AddRentalInfo info,int Id)
        {
            

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AddRentalDetail";
            cmd.Parameters.AddWithValue("@actiontype", "saveData");
            cmd.Parameters.AddWithValue("@id",Id);
            cmd.Parameters.Add("@customername", SqlDbType.VarChar, 50).Value = info.Customer_name;
            cmd.Parameters.Add("@renteddate", SqlDbType.DateTime).Value = info.rentDate;
            cmd.Parameters.Add("@returneddate", SqlDbType.DateTime).Value =info.returnDate;
            cmd.Parameters.Add("@cost", SqlDbType.Decimal).Value =info.Rent_cost;
            cmd.Parameters.Add("@cartypeid", SqlDbType.Int).Value =info.cartype_id;
            db.ExcecuteNonQuery(cmd);


        
        }

        public DataTable comboLoding()
        {
            DataTable dt=new DataTable();
            dbConnect db = new dbConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "Combox";
            db.ExcecuteUserQuery(cmd);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }

        public void deleteRentData(AddRentalInfo info,int Id)
        {
            SqlCommand cmd=new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText= "deleteRentData";
            cmd.Parameters.AddWithValue("id", Id);
            db.ExcecuteNonQuery(cmd);

        }

        public DataTable getRentData(int rid)
        {
            dbConnect db=new dbConnect();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "EditData";
            cmd.Parameters.AddWithValue("@id", rid);
            db.ExcecuteNonQuery(cmd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable LoadRentalDetails()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LoadRentalDetails";
            db.ExcecuteNonQuery(cmd);

            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataSet refreshGrid()
        {
           
            SqlCommand cmd =new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LoadRentalDetails";
            db.ExcecuteNonQuery(cmd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "CarRentalRecord");
            return ds;

        }
    }
}
