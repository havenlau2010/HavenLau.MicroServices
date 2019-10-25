using System;


namespace EFCore.Oracle.Demo2.Entity.Hids.Lis
{
    public class SdfeyLisReportsValue
    {
        /// <summary>
        /// 检查编号
        /// </summary>
        public  string CODE { get; set; }


        /// <summary>
        /// 样本编号
        /// </summary>
        public  string REPORTINDEX { get; set; }


        /// <summary>
        /// 检测编号
        /// </summary>
        public  string TESTINDEX { get; set; }


        /// <summary>
        /// 检查项目名称
        /// </summary>
        public  string TESTNAME { get; set; }

        /// <summary>
        /// 检查项目值
        /// </summary>
        public  string TESTVALUE { get; set; }


        /// <summary>
        /// 值单位
        /// </summary>
        public  string UNIT { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public  string STATUS { get; set; }

        /// <summary>
        /// 参考
        /// </summary>
        public  string REFERENCE { get; set; }


        /// <summary>
        /// 检查时间
        /// </summary>
        public  DateTime CHECKTIME { get; set; }


        /// <summary>
        /// 参考范围起始值
        /// </summary>
        public string REFERENCEBEGIN { get; set; }

        /// <summary>
        /// 参考范围结束值
        /// </summary>
        public  string REFERENCEEND { get; set; }
    }

    //public sealed class SdfeyLisReportsValueMapper : ClassMapper<SdfeyLisReportsValue>
    //{
    //    public SdfeyLisReportsValueMapper()
    //    {
    //        Table("FEY.GETLISREPORTTESTVALUE");
    //        Map(x => x.CODE).Column("CODE");
    //        Map(x => x.REPORTINDEX).Column("REPORTINDEX");
    //        Map(x => x.TESTINDEX).Column("TESTINDEX");
    //        Map(x => x.TESTNAME).Column("TESTNAME");
    //        Map(x => x.TESTVALUE).Column("TESTVALUE");
    //        Map(x => x.UNIT).Column("UNIT");
    //        Map(x => x.STATUS).Column("STATUS");
    //        Map(x => x.REFERENCE).Column("REFERENCE");
    //        Map(x => x.CHECKTIME).Column("CHECKTIME");
    //        Map(x => x.REFERENCEBEGIN).Column("REFERENCEBEGIN");
    //        Map(x => x.REFERENCEEND).Column("REFERENCEEND");
    //    }
    //}
}