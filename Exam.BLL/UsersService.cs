﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.DAL;
using Exam.Model;
using Utility;

namespace Exam.BLL
{
    public class UsersService
    {

        /// <summary>
        /// 查询数据库中是否存在数据，没有数据添加
        /// </summary>
        /// <returns></returns>
        public static int GetUserNum()
        {
            using (ExamSysDBContext dBContext = new ExamSysDBContext())
            {
                return dBContext.Exam_User.Count();
            }


        }
        public static Exam_User GetUserNum(string UserName, string Password)
        {
            using (ExamSysDBContext dBContext = new ExamSysDBContext())
            {
                string pwd = PassWordHelper.GetMD5(Password);
                return dBContext.Exam_User.Where(x => x.UserName == UserName && x.PassWord == pwd).FirstOrDefault();
            }
        }
        public static Exam_User GetUserByID(int userid)
        {
            using (ExamSysDBContext db=new ExamSysDBContext())
            {
               return db.Exam_User.Where(x => x.UserID == userid).FirstOrDefault();
            }
        }
        public static int InsertUser(Exam_User user)
        {
            using (ExamSysDBContext dBContext = new ExamSysDBContext())
            {
                dBContext.Exam_User.Add(user);
                return dBContext.SaveChanges();
            }
        }
    }
}
