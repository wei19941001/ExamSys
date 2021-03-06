﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Model
{
    /// <summary>
    ///  题库信息表
    /// </summary>
    public class Exam_Library
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        /// <summary>
        /// 题库编号
        /// </summary>
        public int LibraryID { get; set; }
        [StringLength(20)]
        /// <summary>
        /// 题库名称
        /// </summary>
        public string Library_Name { get; set; }
        [StringLength(200)]
        /// <summary>
        /// 题库备注
        /// </summary>
        public string Library_Remark { get; set; }
        
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreatTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 题库状态
        /// </summary>
        public bool LibraryStates { get; set; }
        public virtual List<Exam_Question> Exam_Question { get; set; }
        
    }
}
