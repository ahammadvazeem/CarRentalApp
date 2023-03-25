using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace CarRentalApp
{
    class DBConnect
    {
        public static SqlConnection myCon=null;
        public static void createConnection()
        {
            string connectionString = "Data Source =VAZEEM-PC; Initial Catalog =rentCarDb; User ID =vazeem; Password =Vazeem#123";
            myCon = new SqlConnection(connectionString);
            //myCon.Open();

        }

        public static SqlConnection SqlConnection
        {
            get 
            { 
                return myCon;
            }
        }

    }
}
