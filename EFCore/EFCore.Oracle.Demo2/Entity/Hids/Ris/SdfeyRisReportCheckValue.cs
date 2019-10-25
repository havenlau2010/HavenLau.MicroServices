using System;


namespace EFCore.Oracle.Demo2.Entity.Hids.Ris
{
    public class SdfeyRisReportCheckValue
    {
        /// <summary>
        /// 编号
        /// </summary>
        public  long CODE { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public  string DESCRIBE { get; set; }

        /// <summary>
        /// 诊断
        /// </summary>
        public  string DIAGNOSE { get; set; }

        /// <summary>
        /// 医生
        /// </summary>
        public  string FHDOCTOR { get; set; }

        /// <summary>
        /// 操作日期
        /// </summary>
        public  DateTime OPERATETIME { get; set; }
    }


    //public sealed class SdfeyRisReportCheckValueMapper : ClassMapper<SdfeyRisReportCheckValue>
    //{
    //    public SdfeyRisReportCheckValueMapper()
    //    {
    //        Table("PACS.GETRISREPORTCHECKVALUE");
    //        Map(x => x.CODE).Column("CODE");
    //        Map(x => x.DESCRIBE).Column("DESCRIBE");
    //        Map(x => x.DIAGNOSE).Column("DIAGNOSE");
    //        Map(x => x.FHDOCTOR).Column("FHDOCTOR");
    //        Map(x => x.OPERATETIME).Column("OPERATETIME");
         
    //    }
    //}


}