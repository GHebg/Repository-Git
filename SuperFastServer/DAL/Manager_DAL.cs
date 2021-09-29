using Entities_DTO.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Manager_DAL
    {

        //get
        //  שליפת רשימה
        public static List<Manager_DTO> GetAllManagers()
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var m = db.Manager_tbl.ToList();
                return ManagerConverts.ConvertListToOurObject(m);
            }
        }
        //get
        //	שליפת מנהל לפי קוד
        public static Manager_DTO GetManagerByID(int id)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var m = db.Manager_tbl.FirstOrDefault(x => x.Manager_Id == id);
                return ManagerConverts.ConvertFromMicToOurs(m);
            }
        }
        //post
        //הוספת מנהל לרשימה
        public static List<Manager_DTO> AddManager(Manager_DTO m)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                db.Manager_tbl.Add(ManagerConverts.ConvertFromOursToMic(m));
                db.SaveChanges();
                return GetAllManagers();
            }
        }
        //pot
        //עדכון מנהל ברשימה
        public static bool UpdatManager(Manager_DTO m)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var newM = db.Manager_tbl.FirstOrDefault(x => x.Manager_Id == m.Manager_Id);
                if (newM == null)
                    return false;
                else
                {
                    db.Manager_tbl.FirstOrDefault(x => x.Manager_Id == m.Manager_Id).First_name = m.First_name;
                    db.Manager_tbl.FirstOrDefault(x => x.Manager_Id == m.Manager_Id).Last_name = m.Last_name;
                    db.Manager_tbl.FirstOrDefault(x => x.Manager_Id == m.Manager_Id).Password = m.Password;
                    db.Manager_tbl.FirstOrDefault(x => x.Manager_Id == m.Manager_Id).Manager_phone = m.Manager_phone;
                    db.Manager_tbl.FirstOrDefault(x => x.Manager_Id == m.Manager_Id).Email = m.Email;
                    db.SaveChanges();
                    return true;
                }
            }
        }
        //get
        //בדיקה אם מנהל קיים לפי מייל וסיסמה
        public static Manager_DTO ManagerExists(string mail, string pass)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var n = new Manager_DTO();
                var m = db.Manager_tbl.FirstOrDefault(x => x.Password == pass);
                if (m == null)
                    return n;
                else
                {
                    try
                    {
                        if (mail != m.Email)
                            return n;
                    }
                    catch
                    {
                        return n;
                    }
                }
                return ManagerConverts.ConvertFromMicToOurs(m);
            }
        }
    }
}
