using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_DTO.Tables
{
    public class Messenger_DTO
    {
        public int Messenger_Id { get; set; }
        public string Messenger_name { get; set; }
        public string Messenger_phone { get; set; }
        public string Messenger_Email { get; set; }
        public string Password { get; set; }
        public int MaxAmountPackages { get; set; }
        public bool IsAvailable { get; set; }
        public int Manager_Id { get; set; }
    }
}
