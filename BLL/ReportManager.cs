using System;
using System.Collections.Generic;
using DiagnosticManagementSystem.DAL;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.BLL
{
    public class ReportManager
    {
        ReportGateway reportGateway = new ReportGateway();
        public List<Reports> GetTestWiseReport(DateTime date1, DateTime date2)
        {
            return reportGateway.GetTestWiseReport(date1, date2);
        }
        public List<Reports> GetTestTypeWiseReport(DateTime date1, DateTime date2)
        {
            return reportGateway.GetTestTypeWiseReport(date1, date2);
        }
        public List<Patient> GetUnpaidBillReport(DateTime date1, DateTime date2)
        {
            return reportGateway.GetUnpaidBillReport(date1, date2);
        }
    }
}