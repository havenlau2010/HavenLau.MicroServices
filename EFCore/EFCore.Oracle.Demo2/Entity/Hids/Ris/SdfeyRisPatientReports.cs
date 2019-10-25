using System;


namespace EFCore.Oracle.Demo2.Entity.Hids.Ris
{
    public class SdfeyRisPatientReports
    {
        /// <summary>
        /// 编码
        /// </summary>
         public  long CODE { get; set; }

        /// <summary>
        /// 报告日期
        /// </summary>
        public  DateTime REPORTDATETIME { get; set; }

        /// <summary>
        /// 检查日期
        /// </summary>
        public  DateTime NDATE { get; set; }


        /// <summary>
        /// 检查项目
        /// </summary>
        public string SPECIMENNAME { get; set; }


        /// <summary>
        /// 患者来源
        /// </summary>
        public  string PATIENTTYPE { get; set; }


        /// <summary>
        /// 患者考好
        /// </summary>
        public  string CARDNO { get; set; }


        /// <summary>
        /// 患者编号
        /// </summary>
        public  string PATIENTID { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public  string PATIENTNAME { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public  string SEX { get; set; }


        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BIRTHDAY { get; set; }


        /// <summary>
        /// 患者年龄
        /// </summary>
        public  int PATIENTAGE { get; set; }

        /// <summary>
        /// 患者年龄单位
        /// </summary>
        public  string PATIENTAGEUNIT { get; set; }

        /// <summary>
        /// 送检科室
        /// </summary>
        public string DEPARTMENTNAME { get; set; }

        /// <summary>
        /// 送检医生
        /// </summary>
        public string DOCTORNAME { get; set; }


        public  string TESTERNAME { get; set; }

        /// <summary>
        /// 检查者名称
        /// </summary>
        public  string CHECKERNAME { get; set; }

        /// <summary>
        /// 检查类型
        /// </summary>
        public string CHEKTYPE { get; set; }


        /// <summary>
        /// 检验科室
        /// </summary>
        public  string CHECKDEPATMENTNAME { get; set; }


        /// <summary>
        /// 检查影像
        /// </summary>
        public  string CHECKPHOTONO { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
       public   string AUDITSTATE { get; set; }

        /// <summary>
        /// 检查部位
        /// </summary>
        public string CHECKPART { get; set; }
    }


    //public sealed class SdfeyRisPatientReportsMapper : ClassMapper<SdfeyRisPatientReports>
    //{
    //    public SdfeyRisPatientReportsMapper()
    //    {
    //        Table("PACS.GETRISPATIENTREPORTS");
    //        Map(x => x.CODE).Column("CODE");
    //        Map(x => x.REPORTDATETIME).Column("REPORTDATETIME");
    //        Map(x => x.NDATE).Column("NDATE");
    //        Map(x => x.SPECIMENNAME).Column("SPECIMENNAME");
    //        Map(x => x.PATIENTTYPE).Column("PATIENTTYPE");
    //        Map(x => x.CARDNO).Column("CARDNO");
    //        Map(x => x.PATIENTID).Column("PATIENTID");
    //        Map(x => x.PATIENTNAME).Column("PATIENTNAME");
    //        Map(x => x.SEX).Column("SEX");
    //        Map(x => x.BIRTHDAY).Column("BIRTHDAY");
    //        Map(x => x.PATIENTAGE).Column("PATIENTAGE");
    //        Map(x => x.PATIENTAGEUNIT).Column("PATIENTAGEUNIT");
    //        Map(x => x.DEPARTMENTNAME).Column("DEPARTMENTNAME");
    //        Map(x => x.DOCTORNAME).Column("DOCTORNAME");
    //        Map(x => x.TESTERNAME).Column("TESTERNAME");
    //        Map(x => x.CHECKERNAME).Column("CHECKERNAME");
    //        Map(x => x.CHEKTYPE).Column("CHEKTYPE");
    //        Map(x => x.CHECKDEPATMENTNAME).Column("CHECKDEPATMENTNAME");
    //        Map(x => x.CHECKPHOTONO).Column("CHECKPHOTONO");
    //        Map(x => x.AUDITSTATE).Column("AUDITSTATE");
    //        Map(x => x.CHECKPART).Column("CHECKPART");
    //    }
    //}
}