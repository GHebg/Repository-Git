using Entities_DTO.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Information_DAL
    {
        //get
        //שליפת רשימת מידע
        public static List<Information_DTO> GetAllInformation()
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var i = db.Information_tbl.ToList();
                return InformationConverts.ConvertListToOurObject(i);
            }
        }

        //get
        //שליפת מידע לפי קוד שליח
        public static List<Information_DTO> GetInfoByMessenger(int MessengerId)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                List<Information_DTO> iL = new List<Information_DTO>();
                foreach (var i in db.Information_tbl)
                {
                    if (i.Messenger_Id == MessengerId)
                        iL.Add(InformationConverts.ConvertFromMicToOurs(i));
                }
                return iL;
            }
        }
        //get
        //שליפת מידע לפי קוד לקוח
        public static Information_DTO GetInfoByCust(int CustId)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var z = new Information_DTO();
                var i = db.Information_tbl.FirstOrDefault(x => x.Cust_Id == CustId);
                if (i == null)
                    return z;
                return InformationConverts.ConvertFromMicToOurs(i);
            }
        }

        //post
        //הוספת מידע לרשימה
        public static List<Information_DTO> AddInfo(Information_DTO i)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                db.Information_tbl.Add(InformationConverts.ConvertFromOursToMic(i));
                db.SaveChanges();
                return GetAllInformation();
            }
        }

        //put
        //עדכון מידע ברשימה
        public static bool UpdateInfo(Information_DTO i)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var newI = db.Information_tbl.FirstOrDefault(x => x.Cust_Id == i.Cust_Id);
                if (newI == null)
                    return false;
                else
                {
                    db.Information_tbl.FirstOrDefault(x => x.Cust_Id == i.Cust_Id).Messenger_Id = i.Messenger_Id;
                    db.Information_tbl.FirstOrDefault(x => x.Cust_Id == i.Cust_Id).Date = i.Date;
                    db.SaveChanges();
                    return true;
                }
            }
        }
        //delete
        //	מחיקת מידע מרשימה
        public static bool DeleteInfo(int cId)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var i = db.Information_tbl.FirstOrDefault(x => x.Cust_Id == cId);
                if (i == null)
                    return false;
                else
                {
                    db.Information_tbl.Remove(i);
                    db.SaveChanges();
                    return true;
                }
            }
        }
    }
}
