using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;


namespace BAL
{
    public class LoginOp
    {
        public DataSet LoginPage(loginInfo info)
        {

            dbConnect db=new dbConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Login_Data";
            cmd.Parameters.AddWithValue("@username",info.u_name);
            cmd.Parameters.AddWithValue("@password",info.u_password);
            cmd.Parameters.AddWithValue("@isactive",info.is_active);
            db.ExcecuteUserQuery(cmd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
