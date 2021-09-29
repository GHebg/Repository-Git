using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities_DTO.Tables;


namespace Entities_DTO.Tables
{
    public class MessengerConverts
    {

        //פונקציית המרה

        //מהאובייקטים של מיקרוסופט לאובייקטים שלנו
        //אובייקט יחיד
        public static Messenger_DTO ConvertFromMicToOurs(Messengers_tbl m)
        {
            Messenger_DTO mess = new Messenger_DTO
            {
                Messenger_Id = m.Messenger_Id,
                Messenger_name = m.Messenger_name,
                Messenger_phone = m.Messenger_phone,
                Password = m.Password,
                Manager_Id = m.Manager_Id,
                MaxAmountPackages = m.MaxAmountPackages,
                IsAvailable = m.IsAvailable,
                Messenger_Email = m.Messenger_Email                
            };
            return mess;
        }

        //רשימת אובייקטים
        public static List<Messenger_DTO> ConvertListToOurObject(List<Messengers_tbl> mL)
        {
            List<Messenger_DTO> messList = new List<Messenger_DTO>();
            foreach (var m in mL)
            {
                messList.Add(ConvertFromMicToOurs(m));
            }
            return messList;
        }

        //מהאובייקטים שלנו לאובייקטים מיקרוסופט
        //אובייקט יחיד
        public static Messengers_tbl ConvertFromOursToMic(Messenger_DTO m)
        {
            Messengers_tbl mess = new Messengers_tbl
            {
                Messenger_Id = m.Messenger_Id,
                Messenger_name = m.Messenger_name,
                Messenger_phone = m.Messenger_phone,
                Password = m.Password,
                Manager_Id = m.Manager_Id,
                MaxAmountPackages = m.MaxAmountPackages,
                IsAvailable = m.IsAvailable,
                Messenger_Email = m.Messenger_Email
            };
            return mess;
        }
        //רשימת אובייקטים
        public static List<Messengers_tbl> ConvertListToMicObject(List<Messenger_DTO> mL)
        {
            List<Messengers_tbl> messList = new List<Messengers_tbl>();
            foreach (var m in mL)
            {
                messList.Add(ConvertFromOursToMic(m));
            }
            return messList;
        }
    }
}
