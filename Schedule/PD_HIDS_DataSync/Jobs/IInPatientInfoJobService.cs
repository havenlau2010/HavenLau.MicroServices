﻿using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Text;

namespace PD_HIDS_DataSync.Jobs
{
    public interface IInPatientInfoJobService:IDisposable
    {
        void ExecuteJob();
    }
}
