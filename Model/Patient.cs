using System.Collections.Generic;

namespace DiagnosticManagementSystem.Model
{
    public class Patient
    {
        public string Id { get;  set; }
        public decimal Billid { get; set; }
        public string Name { get;  set; }
        public string DateOfBirth { get;  set; }
        public string MobileNo { get;  set; }
        public List<Test> Tests { get;  set; }
        public string SerialNo { get;  set; }
        public decimal TotalBill { get;  set; }
        public decimal PaidBill { get; set; }
        public decimal UnpaidBill { get;  set; }
        public string Patiententrydate { get; set; }

        
        public Patient(decimal billid,string name, string dateOfBirth, string mobileNo, List<Test> tests,  decimal totalBill ,string patienEntryDate):this()
        {
            Billid = billid;
            Name = name;
            DateOfBirth = dateOfBirth;
            MobileNo = mobileNo;
            Tests = tests;
            TotalBill = totalBill;
            Patiententrydate = patienEntryDate;

        }
        
        public Patient()
        {
            
        }

    }
}