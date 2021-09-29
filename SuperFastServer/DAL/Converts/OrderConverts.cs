using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_DTO.Tables
{
    public class OrderConverts
    {
        //פונקציית המרה

        //מהאובייקטים של מיקרוסופט לאובייקטים שלנו
        //אובייקט יחיד
        public static Order_DTO ConvertFromMicToOurs(Order_tbl o)
        {
            Order_DTO order = new Order_DTO
            {
                Order_Id =o.Order_Id,
                Manager_Id = o.Manager_Id,
                Cust_Id = o.Cust_Id,
                Amount_packages = o.Amount_packages,
                Messenger_Id = (int)o.Messenger_Id
            };
            return order;
        }

        //רשימת אובייקטים
        public static List<Order_DTO> ConvertListToOurObject(List<Order_tbl> oL)
        {
            List<Order_DTO> orderList = new List<Order_DTO>();
            foreach (var o in oL)
            {
                orderList.Add(ConvertFromMicToOurs(o));
            }
            return orderList;
        }

        //מהאובייקטים שלנו לאובייקטים מיקרוסופט
        //אובייקט יחיד
        public static Order_tbl ConvertFromOursToMic(Order_DTO o)
        {
            Order_tbl order = new Order_tbl
            {
                Order_Id = o.Order_Id,
                Manager_Id = o.Manager_Id,
                Cust_Id = o.Cust_Id,
                Amount_packages = o.Amount_packages,
                Messenger_Id = o.Messenger_Id
            };
            return order;
        }
        //רשימת אובייקטים
        public static List<Order_tbl> ConvertListToMicObject(List<Order_DTO> oL)
        {
            List<Order_tbl> orderList = new List<Order_tbl>();
            foreach (var o in oL)
            {
                orderList.Add(ConvertFromOursToMic(o));
            }
            return orderList;
        }
    }
}
