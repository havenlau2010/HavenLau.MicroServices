using System;


namespace EFCore.Oracle.Demo2.Entity.Hids.Lis
{
    public class SdfeyLisPatientReports
    {
        /// <summary>
        /// 编码
        /// </summary>
         public  string CODE { get; set; }


        /// <summary>
        /// 报告日期
        /// </summary>
        public  DateTime REPORTDATETIME { get; set; }


        /// <summary>
        /// 检查日期
        /// </summary>
        public  DateTime NDATE { get; set; }


        /// <summary>
        /// 检查样品编号
        /// </summary>
        public  string SAMPLENO { get; set; }

        /// <summary>
        /// 检查项目
        /// </summary>
        public string SPECIMENNAME { get; set; }

        
        /// <summary>
        /// 患者id
        /// </summary>
        public  string PATIENTID { get; set; }


        /// <summary>
        /// 患者来源
        /// </summary>
        public  int PATIENTTYPE { get; set; }


        /// <summary>
        /// 患者索引号
        /// </summary>
        public  string PATIENTINDEX { get; set; }


        /// <summary>
        /// 患者名称
        /// </summary>
        public  string PATIENTNAME { get; set; }


        /// <summary>
        /// 患者性别
        /// </summary>
        public  string SEX { get; set; }

        /// <summary>
        /// 患者生日
        /// </summary>
        public  DateTime BIRTHDAY { get; set; }


        /// <summary>
        /// 患者床号
        /// </summary>
        public  string PATIENTBED { get; set; }


        /// <summary>
        ///  患者年龄
        /// </summary>
        public  string PATIENTAGE { get; set; }


        /// <summary>
        /// 患者年龄单位
        /// </summary>
        public  string PATIENTAGEUNIT { get; set; }


        /// <summary>
        /// 送检科室
        /// </summary>
        public  string DEPARTMENTNAME { get; set; }


        /// <summary>
        /// 送检医生
        /// </summary>
        public  string DOCTORNAME { get; set; }


        /// <summary>
        /// 诊断
        /// </summary>
        public  string DIAGNOSIS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public  string TESTERNAME { get; set; } 

        public  string CHECKERNAME { get; set; }


        public  string INNO { get; set; }

        /// <summary>
        /// 检查项目
        /// </summary>
        public  string CHECKITEMNAME { get; set; }
    }

    //public sealed class SdfeyLisPatientReportsMapper : ClassMapper<SdfeyLisPatientReports>
    //{
    //    public SdfeyLisPatientReportsMapper()
    //    {
    //        Table("FEY.GETLISPATIENTREPORTS");
    //        Map(x => x.CODE).Column("CODE");
    //        Map(x => x.REPORTDATETIME).Column("REPORTDATETIME");
    //        Map(x => x.NDATE).Column("NDATE");
    //        Map(x => x.SAMPLENO).Column("SAMPLENO");
    //        Map(x => x.SPECIMENNAME).Column("SPECIMENNAME");
    //        Map(x => x.PATIENTID).Column("PATIENTID");
    //        Map(x => x.PATIENTTYPE).Column("PATIENTTYPE");
    //        Map(x => x.PATIENTINDEX).Column("PATIENTINDEX");
    //        Map(x => x.PATIENTNAME).Column("PATIENTNAME");
    //        Map(x => x.SEX).Column("SEX");
    //        Map(x => x.BIRTHDAY).Column("BIRTHDAY");
    //        Map(x => x.PATIENTBED).Column("PATIENTBED");
    //        Map(x => x.PATIENTAGE).Column("PATIENTAGE");
    //        Map(x => x.PATIENTAGEUNIT).Column("PATIENTAGEUNIT");
    //        Map(x => x.DEPARTMENTNAME).Column("DEPARTMENTNAME");
    //        Map(x => x.DOCTORNAME).Column("DOCTORNAME");
    //        Map(x => x.DIAGNOSIS).Column("DIAGNOSIS");
    //        Map(x => x.TESTERNAME).Column("TESTERNAME");
    //        Map(x => x.CHECKERNAME).Column("CHECKERNAME");
    //        Map(x => x.INNO).Column("INNO");
    //        Map(x => x.CHECKITEMNAME).Column("CHECKITEMNAME");
    //    }
    //}
}