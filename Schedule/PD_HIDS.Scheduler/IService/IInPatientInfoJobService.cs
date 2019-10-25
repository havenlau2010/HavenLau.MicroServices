using System;
using System.Collections.Generic;
using System.Text;

namespace PD_HIDS.Scheduler.IService
{
    public interface IInPatientInfoJobService:IDisposable
    {
        void ExecuteJob();
    }
}
