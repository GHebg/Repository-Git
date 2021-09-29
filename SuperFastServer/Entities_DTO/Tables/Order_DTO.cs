using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_DTO.Tables
{
    public class Order_DTO
    {
        public int Order_Id { get; set; }
        public int Manager_Id { get; set; }
        public int Cust_Id { get; set; }
        public int Amount_packages { get; set; }
        public int Messenger_Id { get; set; }
    }
}
