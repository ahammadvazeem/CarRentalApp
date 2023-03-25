using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class PassResetOp
    {
        public void reset_password(PassResetInfo info)
        {
            dbConnect db = new dbConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ResetPassword";
            cmd.Parameters.AddWithValue("@id", info.ResetId);
            cmd.Parameters.AddWithValue("@password",info.rePassword);
            db.ExcecuteUserQuery(cmd);


        }
    }
}
