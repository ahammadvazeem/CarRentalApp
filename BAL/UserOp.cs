using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BAL
{
    public class UserOp
    {
       
        public void userAdd(AddUserInfo userInfo, RoleInfo roleInfo)
        {
            dbConnect db=new dbConnect();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "User_Insert";
            cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = userInfo.userName;
            cmd.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = userInfo.passWord;
            cmd.Parameters.Add("@isactive", SqlDbType.Bit).Value = userInfo.is_Active;
            cmd.Parameters.Add("@roleid", SqlDbType.Int).Value = roleInfo.roleid;

            db.ExcecuteUserQuery(cmd);

        }



        public DataTable roleView()
        {
            dbConnect db= new dbConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RolesCombo";
            db.ExcecuteUserQuery(cmd);
            SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlSda.Fill(dt);
            return dt;


        }

        public void ResetPassword(AddUserInfo info, int Id)
        {
            dbConnect db = new dbConnect();
            SqlCommand cmd=new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PassReset";
            cmd.Parameters.AddWithValue("id", Id);
            cmd.Parameters.AddWithValue("@password", info.passWord);
            db.ExcecuteUserQuery(cmd);


        }

        public void deActivate(AddUserInfo info, int Id)
        {

            dbConnect db = new dbConnect();
            SqlCommand cmd=new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "deActivate";
            cmd.Parameters.AddWithValue("id", Id);
            cmd.Parameters.AddWithValue("@isactive", info.is_Active);
            db.ExcecuteUserQuery(cmd);

        }

        public DataTable pageload()
        {
            dbConnect db = new dbConnect(); 
            SqlCommand cmd=new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ManageUserGrid";
            db.ExcecuteUserQuery(cmd);
            SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlSda.Fill(dt);
            return dt;



        }

        public DataSet refreshGrid()
        {
            dbConnect db=new dbConnect();
            SqlCommand cmd=new SqlCommand();    
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RefreshManageUser";
            db.ExcecuteUserQuery(cmd);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataSet ds= new DataSet(); 
            da.Fill(ds, "Users");
            return ds;

        }
    }
}
