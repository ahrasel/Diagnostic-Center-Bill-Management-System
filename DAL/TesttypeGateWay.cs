using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.DAL
{
    public class TesttypeGateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DMSDATABASE"].ConnectionString;


        public int SaveTesttype(TestType testType)
        {
            SqlConnection connection = new SqlConnection(connectionString);


            string query = "INSERT INTO Testtype VALUES ('" + testType.Name + "')";
            connection.Open();

            SqlCommand command = new SqlCommand(query,connection);

            int rowAffacted = command.ExecuteNonQuery();
            connection.Close();
            return rowAffacted;
        }

        public bool IsTesttypeExist(string typeName)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string query = "SELECT * FROM Testtype WHERE Name='" + typeName + "'";

            conn.Open();

            SqlCommand command = new SqlCommand(query,conn);

            SqlDataReader reader = command.ExecuteReader();
            string name="";
            if (reader.HasRows)
            {
                reader.Read();
                name = reader["Name"].ToString();
                reader.Close();
                conn.Close();
            }
            if (name==typeName)
            {
                return true;
            }
            return false;
            // throw new NotImplementedException();
        }

        public List<TestType> GetAllTypeName()
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string query = "SELECT * FROM Testtype";

            SqlCommand command = new SqlCommand(query,conn);

            conn.Open();

            SqlDataReader reader = command.ExecuteReader();
            TestType types=null;
            int serialNo = 0;
            List < TestType > testTypesList= new List<TestType>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    types=new TestType();
                    serialNo++;
                    types.Id = int.Parse(reader["Id"].ToString());
                    types.Name = reader["Name"].ToString();
                    types.SerialNo = serialNo;

                    testTypesList.Add(types);


                }
                reader.Close();
                conn.Close();
            }

            return testTypesList;
            //throw new NotImplementedException();
        }
    }
}