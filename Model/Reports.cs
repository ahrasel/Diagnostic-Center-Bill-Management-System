using System;
using System.Collections.Generic;
using DiagnosticManagementSystem.BLL;

namespace DiagnosticManagementSystem.Model
{
    
    public class Reports
    {
        ReportManager manager = new ReportManager();


        public string TestName { get; set; }
        public string TestTypeName { get; set; }
        public int NoOfTest { get; set; }
        public int NoTesTtype { get; set; }
        public string Ammount { get; set; }
        public int SerialNo { get; set; }



        public List<Reports> GetTestWiseReport(DateTime date1, DateTime date2)
        {
            return manager.GetTestWiseReport(date1, date2);
        }
        public List<Reports> GetTestTypeWiseReport(DateTime date1, DateTime date2)
        {
            return manager.GetTestTypeWiseReport(date1, date2);
        }
        public List<Patient> GetUnpaidBillReport(DateTime date1, DateTime date2)
        {
            return manager.GetUnpaidBillReport(date1, date2);
        }
    }

}