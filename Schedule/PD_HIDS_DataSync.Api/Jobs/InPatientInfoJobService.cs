using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace PD_HIDS_DataSync.Api.Jobs
{
    public class InPatientInfoJobService : IInPatientInfoJobService,IDisposable
    {

        // private readonly Mapper _mapper;
        // public InPatientInfoJobService(Mapper mapper)
        public InPatientInfoJobService()
        {
            // _mapper = mapper;
        }

        public void Dispose()
        {
            
        }

        public void Execute()
        {
            Console.WriteLine("execute...");
        }

        public void ExecuteJob()
        {
            Console.WriteLine("ExecuteJob...");
        }
    }
}