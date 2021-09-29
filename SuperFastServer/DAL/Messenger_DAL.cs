using Entities_DTO.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Messenger_DAL
    {
        //get
        //שליפת רשימת שליחים
        public static List<Messenger_DTO> GetAllMessengers()
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var m = db.Messengers_tbl.ToList();
                return MessengerConverts.ConvertListToOurObject(m);
            }
        }

        //get
        //	שליפת שליח לפי קוד
        public static Messenger_DTO GetMessengersById(int Id)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var m = db.Messengers_tbl.FirstOrDefault(x => x.Messenger_Id == Id);
                return MessengerConverts.ConvertFromMicToOurs(m);
            }
        }

        //get
        //שליפת שליחים לפי קוד מנהל
        public static List<Messenger_DTO> GetMessengerByManegerId(int Id)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                List<Messenger_DTO> mL = new List<Messenger_DTO>();
                foreach (var m in db.Messengers_tbl)
                {
                    if (m.Manager_Id == Id)
                        mL.Add(MessengerConverts.ConvertFromMicToOurs(m));
                }
                return mL;
            }
        }

        //post
        //הוספת שליח לרשימה
        public static List<Messenger_DTO> AddMessenger(Messenger_DTO m)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                db.Messengers_tbl.Add(MessengerConverts.ConvertFromOursToMic(m));
                db.SaveChanges();
                return GetAllMessengers();
            }
        }

        //put
        //עדכון שליח ברשימה
        public static bool UpdateMessenger(Messenger_DTO m)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var newM = db.Messengers_tbl.FirstOrDefault(x => x.Messenger_Id == m.Messenger_Id);
                if (newM == null)
                    return false;
                else
                {
                    db.Messengers_tbl.FirstOrDefault(x => x.Messenger_Id == m.Messenger_Id).Messenger_Id = m.Messenger_Id;
                    db.Messengers_tbl.FirstOrDefault(x => x.Messenger_Id == m.Messenger_Id).Messenger_name = m.Messenger_name;
                    db.Messengers_tbl.FirstOrDefault(x => x.Messenger_Id == m.Messenger_Id).Messenger_phone = m.Messenger_phone;
                    db.Messengers_tbl.FirstOrDefault(x => x.Messenger_Id == m.Messenger_Id).Password = m.Password;
                    db.Messengers_tbl.FirstOrDefault(x => x.Messenger_Id == m.Messenger_Id).Manager_Id = m.Manager_Id;
                    db.Messengers_tbl.FirstOrDefault(x => x.Messenger_Id == m.Messenger_Id).MaxAmountPackages = m.MaxAmountPackages;
                    db.Messengers_tbl.FirstOrDefault(x => x.Messenger_Id == m.Messenger_Id).IsAvailable = m.IsAvailable;
                    db.Messengers_tbl.FirstOrDefault(x => x.Messenger_Id == m.Messenger_Id).Messenger_Email = m.Messenger_Email;
                    db.SaveChanges();
                    return true;
                }
            }
        }

        //delete
        //	מחיקת שליח מרשימה
        public static bool DeleteMessenger(int mId)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var m = db.Messengers_tbl.FirstOrDefault(x => x.Messenger_Id == mId);
                if (m == null)
                    return false;
                else
                {
                    db.Messengers_tbl.Remove(m);
                    db.SaveChanges();
                    return true;
                }
            }
        }

        //get
        //	בדיקה אם שליח קיים לפי מייל וסיסמה
        public static Messenger_DTO MessengerExists(string mail, string pass)
        {
            using (Super_FastEntities db = new Super_FastEntities())
            {
                var n = new Messenger_DTO();
                var m = db.Messengers_tbl.FirstOrDefault(x => x.Password == pass);//בודק אם קיים סיסמה כמו זאת שהתקבלה
                if (m == null)//במקרה שהסיסמה אינה קיימת
                    return n;//מחזיר אוביקט ריק
                else//במקרה שהסיסמה קיימת
                    try
                    {
                        if (mail != m.Messenger_Email)//אם למשתמש עם הסיסמה הזו  לא קיים המייל שקיבל
                            return n;//מחזיר אוביקט ריק
                    }
                    catch
                    {
                        return n;//מחזיר אוביקט ריק
                    }
                return MessengerConverts.ConvertFromMicToOurs(m);//במקרה שכל התנאים מתקיימים מחזיר את השליח
            }
        }
    }
}
