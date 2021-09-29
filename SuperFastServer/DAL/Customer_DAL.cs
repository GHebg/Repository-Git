using Entities_DTO.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Customer_DAL
    {
        //get
        //שליפת רשימת לקוחות
        public static List<Customer_DTO> GetAllCustomers()
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var c = db.Customer_tbl.ToList();
                return CustomerConverts.ConvertListToOurObject(c);
            }
        }
        //get
        //	שליפת לקוח לפי קוד
        public static Customer_DTO GetCustomerById(int Id)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var c = db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == Id);
                return CustomerConverts.ConvertFromMicToOurs(c);
            }
        }
        //get
        //	 שליפת לקוח לפי קוד מנהל
        public static List<Customer_DTO> GetCustomersByUserId(int Id)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                List<Customer_DTO> cL = new List<Customer_DTO>();

                List<Customer_tbl> Customers = new List<Customer_tbl>();
                Customers = (from c in db.Customer_tbl
                             where c.Manager_Id == Id
                             select c).ToList();
                cL = CustomerConverts.ConvertListToOurObject(Customers);
                return cL;
            }
        }

        ////foreach (var c in db.Customer_tbl)
        ////{
        ////    if (c.Manager_Id == Id)
        ////        cL.Add(CustomerConverts.ConvertFromMicToOurs(c));
        ////}
        
        //post
        //הוספת לקוח לרשימה
        public static List<Customer_DTO> AddCustomer(Customer_DTO c)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                db.Customer_tbl.Add(CustomerConverts.ConvertFromOursToMic(c));
                db.SaveChanges();
                return GetAllCustomers();
            }
        }
        //put
        //עדכון לקוח ברשימה
        public static bool UpdateCustomers(Customer_DTO c)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var newC = db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == c.Cust_Id);
                if (newC == null)
                    return false;
                else
                {
                    db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == c.Cust_Id).Manager_Id = c.Manager_Id;
                    db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == c.Cust_Id).Cust_name = c.Cust_name;
                    db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == c.Cust_Id).Cust_phone = c.Cust_phone;
                    db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == c.Cust_Id).Cust_phone2 = c.Cust_phone2;
                    db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == c.Cust_Id).City = c.City;
                    db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == c.Cust_Id).Street = c.Street;
                    db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == c.Cust_Id).House_num = c.House_num;
                    db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == c.Cust_Id).Apartment_num = c.Apartment_num;
                    db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == c.Cust_Id).Floor = c.Floor;
                    db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == c.Cust_Id).Lat = c.Lat;
                    db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == c.Cust_Id).Lan = c.Lan; ;
                    db.SaveChanges();
                    return true;
                }
            }
        }

        //delete
        //	מחיקת לקוח-כתובת מרשימה
        public static bool DeleteCustomer(int id)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var c = db.Customer_tbl.FirstOrDefault(x => x.Cust_Id == id);
                if (c == null)
                    return false;
                else
                {
                    db.Customer_tbl.Remove(c);
                    db.SaveChanges();
                    return true;
                }

            }
        }


    }
}
