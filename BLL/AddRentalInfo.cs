using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AddRentalInfo
    {
        public string Customer_name { get; set; }
        public DateTime rentDate { get; set; }     
        public DateTime returnDate  { get;set;}
        public decimal Rent_cost { get; set; }       
        public int cartype_id { get; set; }



    }
}
