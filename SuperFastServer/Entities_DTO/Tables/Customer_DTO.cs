using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_DTO.Tables
{
    public class Customer_DTO
    {
        public int Cust_Id { get; set; }
        public int Manager_Id { get; set; }
        public string Cust_name { get; set; }
        public string Cust_phone { get; set; }
        public string Cust_phone2 { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House_num { get; set; }
        public int Apartment_num { get; set; }
        public int Floor { get; set; }
        public string Lat { get; set; }
        public string Lan { get; set; }
    }
}
