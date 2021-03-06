﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Model;
using Exam.DAL;
using PagedList;
using System.Security.Cryptography.X509Certificates;

namespace Exam.BLL
{
    public class LibraryService
    {
        /// <summary>
        /// 获取所有题库
        /// </summary>
        /// <param name="lmid"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static IPagedList GetList(int page = 1)
        {
            ExamSysDBContext db = new ExamSysDBContext();
            int pagesize = 10;
            IPagedList list = db.Exam_Library.OrderBy(x => x.LibraryID).ToPagedList(page, pagesize);
            return list;
        }
        /// <summary>
        /// 加载题库
        /// </summary>
        /// <returns></returns>
        public static List<Exam_Library> GetAll()
        {
            ExamSysDBContext db = new ExamSysDBContext();
            var list = db.Exam_Library.ToList();
            return list;
        }

        /// <summary>
        /// 加载题库中未禁用的
        /// </summary>
        /// <returns></returns>
        public static List<Exam_Library> GetAllEnable()
        {
            ExamSysDBContext db = new ExamSysDBContext();
            var list = db.Exam_Library.Where(x => x.LibraryStates == true).ToList();
            return list;
        }
        /// <summary>
        /// 增加题库
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static int InsertLibrary(Exam_Library library)
        {
            ExamSysDBContext dBContext = new ExamSysDBContext();
            dBContext.Exam_Library.Add(library);
            return dBContext.SaveChanges();
        }
        /// <summary>
        /// 判断题库名称是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool GetNameCount(string name)
        {
            using (ExamSysDBContext dBContext = new ExamSysDBContext())
            {
               int res= dBContext.Exam_Library.Where(x => x.Library_Name == name).Count();
                if(res>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                    
            }
        }


        /// <summary>
        /// 通过ID找到该题库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Exam_Library FindLibraryByID(int id)
        {
            ExamSysDBContext dBContext = new ExamSysDBContext();
            var data = dBContext.Exam_Library.Where(x => x.LibraryID == id).FirstOrDefault();
            return data;
        }
        /// <summary>
        /// 禁用题库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DisableLibrary(int id)
        {
            ExamSysDBContext dBContext = new ExamSysDBContext();
           
            var data = dBContext.Exam_Library.Where(x => x.LibraryID == id).FirstOrDefault();

            data.LibraryStates = false;
            return dBContext.SaveChanges();
        }
        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int EnableLibrary(int id)
        {
            ExamSysDBContext dBContext = new ExamSysDBContext();

            var data = dBContext.Exam_Library.Where(x => x.LibraryID == id).FirstOrDefault();

            data.LibraryStates = true;
            return dBContext.SaveChanges();
        }
        /// <summary>
        /// 修改题库名称
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static int Update(Exam_Library library)
        {
            ExamSysDBContext dBContext = new ExamSysDBContext();
            var data = dBContext.Exam_Library.Where(x => x.LibraryID == library.LibraryID).FirstOrDefault();
            data.Library_Name = library.Library_Name;
            data.Library_Remark = library.Library_Remark;
            data.UpdateTime = library.UpdateTime;

            return dBContext.SaveChanges();
        }
    }
}
