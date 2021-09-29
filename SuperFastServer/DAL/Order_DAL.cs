using Entities_DTO.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Order_DAL
    {
        //get
        //שליפת רשימת הזמנות
        public static List<Order_DTO> GetAllOrders()
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var o = db.Order_tbl.ToList();
                return OrderConverts.ConvertListToOurObject(o);
            }
        }

        //get
        //שליפת הזמנות לפי קוד שליח
        public static List<Order_DTO> GetOrderByMessenger(int Id)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                List<Order_DTO> oL = new List<Order_DTO>();
                foreach (var o in db.Order_tbl)
                {
                    if (o.Messenger_Id == Id)
                        oL.Add(OrderConverts.ConvertFromMicToOurs(o));
                }
                return oL;
            }
        }
        //get
        //שליפת הזמנות לפי קוד לקוח
        public static List<Order_DTO> GetOrderByCustId(int Id)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                List<Order_DTO> oL = new List<Order_DTO>();
                foreach (var o in db.Order_tbl)
                {
                    if (o.Cust_Id == Id)
                        oL.Add(OrderConverts.ConvertFromMicToOurs(o));
                }
                return oL;
            }
        }
        //get
        //שליפת הזמנות לפי קוד מנהל
        public static List<Order_DTO> GetOrderByManegertId(int Id)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                List<Order_DTO> oL = new List<Order_DTO>();
                foreach (var o in db.Order_tbl)
                {
                    if (o.Manager_Id == Id)
                        oL.Add(OrderConverts.ConvertFromMicToOurs(o));
                }
                return oL;
            }
        }

        //post
        //הוספת הזמנה לרשימה
        public static List<Order_DTO> AddOrder(Order_DTO o)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                db.Order_tbl.Add(OrderConverts.ConvertFromOursToMic(o));
                db.SaveChanges();
                return GetAllOrders();
            }
        }

        //put
        //עדכון הזמנה ברשימה
        public static bool UpdateOrder(Order_DTO o)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var newI = db.Order_tbl.FirstOrDefault(x => x.Cust_Id == o.Cust_Id);
                if (newI == null)
                    return false;
                else
                {
                    db.Order_tbl.FirstOrDefault(x => x.Cust_Id == o.Cust_Id).Manager_Id = o.Manager_Id;
                    db.Order_tbl.FirstOrDefault(x => x.Cust_Id == o.Cust_Id).Cust_Id = o.Cust_Id;
                    db.Order_tbl.FirstOrDefault(x => x.Cust_Id == o.Cust_Id).Amount_packages = o.Amount_packages;
                    db.Order_tbl.FirstOrDefault(x => x.Cust_Id == o.Cust_Id).Messenger_Id = o.Messenger_Id;
                    db.SaveChanges();
                    return true;
                }
            }
        }
        //delete
        //	מחיקת הזמנה מרשימה
        public static bool DeleteOrder(int oId)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var i = db.Order_tbl.FirstOrDefault(x => x.Cust_Id == oId);
                if (i == null)
                    return false;
                else
                {
                    db.Order_tbl.Remove(i);
                    db.SaveChanges();
                    return true;
                }
            }
        }
    }
}
