using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class dbConnect
    {
        SqlConnection con = new SqlConnection("Data Source =VAZEEM-PC; Initial Catalog =rentCarDb; User ID =vazeem; Password =Vazeem#123");

        public SqlConnection getConnection()
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            return con;

        }

        public void ExcecuteNonQuery(SqlCommand cmd)
        {
            cmd.Connection=getConnection();
            cmd.ExecuteNonQuery();
            con.Close();
           

        }

        public void ExcecuteVehicleQuery(SqlCommand cmd)
        {
            cmd.Connection = getConnection();
            cmd.ExecuteNonQuery();
            con.Close();
         
        }

        public void ExcecuteUserQuery(SqlCommand cmd)
        {
            cmd.Connection = getConnection();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //public void ExcecuteLoginQuery(SqlCommand cmd)
        //{
        //    cmd.Connection = getConnection();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
    }
}
