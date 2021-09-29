using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities_DTO.Tables;

namespace Entities_DTO.Tables
{
    public class CustomerConverts
    {
        //פונקציית המרה

        //מהאובייקטים של מיקרוסופט לאובייקטים שלנו
        //אובייקט יחיד
        public static Customer_DTO ConvertFromMicToOurs(Customer_tbl c)
        {
            Customer_DTO cust = new Customer_DTO
            {
                Cust_Id = c.Cust_Id,
                Manager_Id = c.Manager_Id,
                Cust_name = c.Cust_name,
                Cust_phone = c.Cust_phone,
                Cust_phone2 = c.Cust_phone2,
                City = c.City,
                Street = c.Street,
                House_num = c.House_num,
                Apartment_num = c.Apartment_num,
                Floor = c.Floor,
                Lat = c.Lat,
                Lan = c.Lan
            };
            return cust;

        }
        //רשימת אובייקטים
        public static List<Customer_DTO> ConvertListToOurObject(List<Customer_tbl> cL)
        {
            List<Customer_DTO> custList = new List<Customer_DTO>();
            foreach (var c in cL)
            {
                custList.Add(ConvertFromMicToOurs(c));
            }
            return custList;
        }

        //מהאובייקטים שלנו לאובייקטים מיקרוסופט
        //אובייקט יחיד
        public static Customer_tbl ConvertFromOursToMic(Customer_DTO c)
        {
            Customer_tbl cust = new Customer_tbl
            {

                Cust_Id = c.Cust_Id,
                Manager_Id = c.Manager_Id,
                Cust_name = c.Cust_name,
                Cust_phone = c.Cust_phone,
                Cust_phone2 = c.Cust_phone2,
                City = c.City,
                Street = c.Street,
                House_num = c.House_num,
                Apartment_num = c.Apartment_num,
                Floor = c.Floor,
                Lat = c.Lat,
                Lan = c.Lan
            };
            return cust;
        }
        //רשימת אובייקטים
        public static List<Customer_tbl> ConvertListToMicObject(List<Customer_DTO> cL)
        {
            List<Customer_tbl> custList = new List<Customer_tbl>();
            foreach (var c in cL)
            {
                custList.Add(ConvertFromOursToMic(c));
            }
            return custList;
        }
    }
}
