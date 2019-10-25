using PD_HIDS.Scheduler.IService;
using System;
using System.Collections.Generic;
using System.Text;
namespace PD_HIDS.Scheduler.Service
{
    public class InPatientInfoJobService : IInPatientInfoJobService
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