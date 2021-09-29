using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities_DTO.Tables;

namespace Entities_DTO.Tables
{
    public class ManagerConverts
    {
        //פונקציית המרה

        //מהאובייקטים של מיקרוסופט לאובייקטים שלנו
        //אובייקט יחיד
        public static Manager_DTO ConvertFromMicToOurs(Manager_tbl m)
        {
            Manager_DTO maneger = new Manager_DTO
            {

                Manager_Id = m.Manager_Id,
                First_name = m.First_name,
                Last_name = m.Last_name,
                Password = m.Password,
                Manager_phone = m.Manager_phone,
                Email = m.Email
            };
            return maneger;

        }
        //רשימת אובייקטים
        public static List<Manager_DTO> ConvertListToOurObject(List<Manager_tbl> mL)
        {
            List<Manager_DTO> manegerList = new List<Manager_DTO>();
            foreach (var m in mL)
            {
                manegerList.Add(ConvertFromMicToOurs(m));
            }
            return manegerList;
        }

        //מהאובייקטים שלנו לאובייקטים מיקרוסופט
        //אובייקט יחיד
        public static Manager_tbl ConvertFromOursToMic(Manager_DTO m)
        {
            Manager_tbl maneger = new Manager_tbl
            {

                Manager_Id = m.Manager_Id,
                First_name = m.First_name,
                Last_name = m.Last_name,
                Password = m.Password,
                Manager_phone = m.Manager_phone,
                Email = m.Email
            };
            return maneger;
        }
        //רשימת אובייקטים
        public static List<Manager_tbl> ConvertListToMicObject(List<Manager_DTO> mL)
        {
            List<Manager_tbl> manegerList = new List<Manager_tbl>();
            foreach (var m in mL)
            {
                manegerList.Add(ConvertFromOursToMic(m));
            }
            return manegerList;
        }
    }
}
