using DiagnosticManagementSystem.DAL;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.BLL
{
    public class PatientManager
    {
        PatientGateWay patientGateWay = new PatientGateWay();

        public int SavePataient(Patient patient)
        {
            int patientSave= patientGateWay.SavePataient(patient);
            int patienOrderSave=patientGateWay.SevaPatientTestOrder(patient.Tests,patient.Billid,patient.MobileNo,patient.Patiententrydate);

            if (patientSave>0&&patienOrderSave>0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

            // throw new NotImplementedException();
        }

        //protected void SevaPatientTestOrder(List<Test> selectedTest)
        //{
        //    throw new NotImplementedException();
        //}

        public decimal SetPatientBillId()
        {
            return patientGateWay.SetPatientBillId();
            
        }

        public Test GetTestById(string value)
        {
            return patientGateWay.GetTestById(value);
        }

        
    }
}