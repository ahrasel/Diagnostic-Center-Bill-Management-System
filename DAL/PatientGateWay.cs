using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.DAL
{
    public class PatientGateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DMSDATABASE"].ConnectionString;
        public int SavePataient(Patient patient)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Patient (BillId,Name,DateOfBirth,MobileNo,TotalBill,PaidBill,UnpaidBill,PatientEntryDate) " +
                           "VALUES ('"+patient.Billid+"','"+patient.Name+"','"+patient.DateOfBirth+"','"+patient.MobileNo+"','"+patient.TotalBill+"','"+0+"','"+patient.TotalBill+"','"+patient.Patiententrydate+"') ";

            SqlCommand command = new SqlCommand(query,connection);

            connection.Open();

            int roAffected = command.ExecuteNonQuery();

            connection.Close();
            return roAffected;

            //throw new NotImplementedException();
        }

        public decimal SetPatientBillId()
        {
            SqlConnection connection =new SqlConnection(connectionString);
            string getBillIdQuery = "SELECT TOP 1 BillId FROM Patient ORDER BY BillId DESC";

            SqlCommand command = new SqlCommand(getBillIdQuery,connection);

            connection.Open();
            
            SqlDataReader reader = command.ExecuteReader();

            decimal billId=0;
            if (reader.HasRows)
            {
                reader.Read();
                billId = decimal.Parse(reader["BillId"].ToString());
                reader.Close();
                connection.Close();
            }

            if (billId==0)
            {
                return 100234;
            }

            return billId+1;
        }



        public Test GetTestById(string value)
        {
           
            TestGateWay testGateWay = new TestGateWay();
            return testGateWay.GetTestById(value);

            //throw new NotImplementedException();
        }


        public int SevaPatientTestOrder(List<Test> patientTests, decimal patientBillid, string patientMobileNo, string patiententrydate)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            int roAffected=0;
            connection.Open();
            foreach (Test test in patientTests)
            {
                string query = "INSERT INTO PatientTestOrders VALUES ('"+patientBillid+"','"+test.Id+"','"+patientMobileNo+"','"+ patiententrydate + "') ";

                SqlCommand command = new SqlCommand(query, connection);

                
                 roAffected = command.ExecuteNonQuery();
                
            }
            connection.Close();
            connection.Close();
            return roAffected;




            //throw new NotImplementedException();
        }
    }
}