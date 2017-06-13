using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.DAL
{
    public class TestGateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DMSDATABASE"].ConnectionString;

        public int SaveTest(Test test)
        {
           SqlConnection conn = new SqlConnection(connectionString);
            
            string query = "INSERT INTO TestName VALUES ('" + test.Name+"',"+test.Fee+",'"+test.TestType+"')";


            conn.Open();
            SqlCommand command = new SqlCommand(query,conn);

            

            int rowAffected = command.ExecuteNonQuery();

            conn.Close();

            return rowAffected;
            // throw new NotImplementedException();
        }


        public List<Test> GetAllTestName()
        {
           SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM TestName ORDER BY Name ASC";

            SqlCommand command = new SqlCommand(query,con);

            con.Open();

            SqlDataReader reader = command.ExecuteReader();
            Test test = null;
            List<Test> allTests = new List<Test>();
            int serialNo = 0;
             if (reader.HasRows)
            {
                while (reader.Read())
                {
                    serialNo++;
                    test = new Test();
                    test.Id = int.Parse(reader["Id"].ToString());
                    test.Name = reader["Name"].ToString();
                    test.Fee = decimal.Parse(reader["Fee"].ToString());
                    test.TestType = reader["Type"].ToString();
                    test.SerialNo = serialNo;
                    allTests.Add(test);
                }
                 reader.Close();
                 con.Close();
            }

            return allTests;
            //throw new NotImplementedException();
        }


        public bool IsTetsExist(string testName, string testType)
        {

            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM TestName WHERE Name='"+testName+"' AND Type='"+testType+"'";

            SqlCommand command = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = command.ExecuteReader();
            Test test = null;
            string name="";
            string type="";
            if (reader.HasRows)
            {
                reader.Read();
                name = reader["Name"].ToString();
                type = reader["Type"].ToString();
                reader.Close();
                con.Close();

            }
            if (testName == name && testType == type)
            {
                return true;
            }
            return false;
            //throw new NotImplementedException();
        }

        public Test GetTestById(string value)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM TestName WHERE Id='" + value + "'";

            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Test t = null;
            if (reader.HasRows)
            {
                reader.Read();
                 t  =new Test();
                t.Id = int.Parse(reader["Id"].ToString());
                t.Name = reader["Name"].ToString();
                t.Fee =decimal.Parse(reader["Fee"].ToString()) ;
                t.TestType = reader["Type"].ToString();
            }
            reader.Close();
            connection.Close();
            return t;
            //throw new NotImplementedException();
        }
    }
}