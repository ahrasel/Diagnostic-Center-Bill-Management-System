using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.DAL
{
    public class PaymentGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DMSDATABASE"].ConnectionString;
        public Patient GetPatientByBillId(int billId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string patientDataQuery = "SELECT * FROM Patient WHERE BillId='"+billId+"'";
            // string patientTestOrderQuery = "select * from PaientOrderdView where PatientBillId=100237";

            SqlCommand command = new SqlCommand(patientDataQuery,connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            Patient patient = null;
            
            if (reader.HasRows)
            {
                reader.Read();
                patient = new Patient();
                patient.Id = reader["Id"].ToString();
                patient.Billid = decimal.Parse(reader["BillId"].ToString());
                patient.Name = reader["Name"].ToString();
                patient.DateOfBirth = reader["DateOfBirth"].ToString();
                patient.MobileNo = reader["MobileNo"].ToString();
                patient.TotalBill = decimal.Parse(reader["TotalBill"].ToString());
                patient.PaidBill = decimal.Parse(reader["PaidBill"].ToString());
                patient.UnpaidBill = decimal.Parse(reader["UnpaidBill"].ToString());
                patient.Patiententrydate = reader["PatientEntryDate"].ToString();
                patient.Tests = PatienTests(patient.Billid);
            }
            reader.Close();
            connection.Close();
            return patient;
        }

        protected List<Test> PatienTests(decimal billId)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            
             string patientTestOrderQuery = "select * from PaientOrderdView where PatientBillId='"+billId+"'";

            SqlCommand command = new SqlCommand(patientTestOrderQuery, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Test> tests = null;
            tests = new List<Test>();
            Test test = null;
            int serial = 0;
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    serial++;
                    test = new Test();
                    test.Id = int.Parse(reader["Id"].ToString());
                    test.Name = reader["Name"].ToString();
                    test.Fee = decimal.Parse(reader["Fee"].ToString());
                    test.TestType = reader["Type"].ToString();
                    test.SerialNo = serial;
                    tests.Add(test);
                }
                

            }
            reader.Close();
            connection.Close();
            return tests;
        }

        public int UpdateBill(decimal amount, Patient patient)
        {

            //Patient(BillId, Name, DateOfBirth, MobileNo, TotalBill, PaidBill, UnpaidBill, PatientEntryDate)

            decimal unpaidBill = patient.UnpaidBill-amount;
            decimal paidBill = patient.TotalBill - unpaidBill;

            SqlConnection connection = new SqlConnection(connectionString);
            
            string query = "UPDATE Patient SET PaidBill='"+paidBill+"',UnpaidBill='"+unpaidBill+"' WHERE Id='" + patient.Id + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query,connection);

            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}