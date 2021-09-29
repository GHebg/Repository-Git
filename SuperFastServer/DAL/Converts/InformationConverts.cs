using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities_DTO.Tables;

namespace Entities_DTO.Tables
{
    public class InformationConverts
    {
        //פונקציית המרה

        //מהאובייקטים של מיקרוסופט לאובייקטים שלנו
        //אובייקט יחיד
        public static Information_DTO ConvertFromMicToOurs(Information_tbl i)
        {
            Information_DTO info = new Information_DTO
            {
                Messenger_Id = i.Messenger_Id,
                Cust_Id = i.Cust_Id,
                Date = i.Date
            };
            return info;

        }
        //רשימת אובייקטים
        public static List<Information_DTO> ConvertListToOurObject(List<Information_tbl> iL)
        {
            List<Information_DTO> infoList = new List<Information_DTO>();
            foreach (var i in iL)
            {
                infoList.Add(ConvertFromMicToOurs(i));
            }
            return infoList;
        }

        //מהאובייקטים שלנו לאובייקטים מיקרוסופט
        //אובייקט יחיד
        public static Information_tbl ConvertFromOursToMic(Information_DTO i)
        {
            Information_tbl info = new Information_tbl
            {
                Messenger_Id = i.Messenger_Id,
                Cust_Id = i.Cust_Id,
                Date = i.Date
            };
            return info;
        }
        //רשימת אובייקטים
        public static List<Information_tbl> ConvertListToMicObject(List<Information_DTO> iL)
        {
            List<Information_tbl> infoList = new List<Information_tbl>();
            foreach (var i in iL)
            {
                infoList.Add(ConvertFromOursToMic(i));
            }
            return infoList;
        }
    }
}
