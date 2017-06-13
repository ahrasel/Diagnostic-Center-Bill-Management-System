using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.DAL
{
    public class ReportGateway
    {
        private string connectionstrings = WebConfigurationManager.ConnectionStrings["DMSDATABASE"].ConnectionString;
        public List<Reports> GetTestWiseReport(DateTime date1, DateTime date2)
        {
            List<Reports> reports = new List<Reports>();

            string connectionString = WebConfigurationManager.ConnectionStrings["DMSDATABASE"].ConnectionString;


            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("spGetTestNameWiseReport", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = date1;
            command.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = date2;

            con.Open();

            SqlDataReader reader = command.ExecuteReader();

           
            Reports report = null;

            int serialNo = 0;
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    report = new Reports();
                    serialNo++;
                    report.SerialNo = serialNo;
                    report.TestName = reader["TestName"].ToString();
                    report.NoOfTest = int.Parse(reader["TotalNoTest"].ToString());
                    report.Ammount = reader["Amount"].ToString();
                    reports.Add(report);
                }
            }
            reader.Close();
            con.Close();
            return reports;

        }

        public List<Reports> GetTestTypeWiseReport(DateTime date1, DateTime date2)
        {
            List<Reports> reports=new List<Reports>();
           
            string connectionString = WebConfigurationManager.ConnectionStrings["DMSDATABASE"].ConnectionString;


            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("spGetTestTypeWiseReport", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FromDate", SqlDbType.DateTime).Value =date1;
            command.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = date2;
            con.Open();
            SqlDataReader reader = command.ExecuteReader();

           
            Reports report= null;
            
            int serialNo = 0;
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    report = new Reports();
                    serialNo++;
                    report.SerialNo = serialNo;
                    report.TestTypeName = reader["TestType"].ToString();
                    report.NoTesTtype = int.Parse(reader["TotalNo"].ToString());
                    report.Ammount = reader["Amount"].ToString();
                    reports.Add(report);
                }
            }
            reader.Close();
            con.Close();
            return reports;
        }

        public List<Patient> GetUnpaidBillReport(DateTime date1, DateTime date2)
        {
            List<Patient> patients = new List<Patient>();

            string connectionString = WebConfigurationManager.ConnectionStrings["DMSDATABASE"].ConnectionString;


            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("spUnpaidBillReport", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = date1;
            command.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = date2;
            con.Open();
            SqlDataReader reader = command.ExecuteReader();


            Patient patient = null;

            int serialNo = 0;
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    patient = new Patient();
                    serialNo++;
                    patient.SerialNo = serialNo.ToString();
                    patient.Billid = decimal.Parse(reader["BillNo"].ToString());
                    patient.MobileNo = reader["ContactNo"].ToString();
                    patient.Name = reader["PatientName"].ToString();
                    patient.UnpaidBill = decimal.Parse(reader["BillAmount"].ToString());
               
                    patients.Add(patient);
                }
            }
            reader.Close();
            con.Close();
            return patients;
        }
    }
}