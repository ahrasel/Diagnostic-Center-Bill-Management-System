using System.Collections.Generic;
using DiagnosticManagementSystem.DAL;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.BLL
{
    public class TestManager
    {
        TestGateWay testGateWay = new TestGateWay();
        public int SaveTest(Test test)
        {
            if (IsTetsExist(test.Name,test.TestType)==false)
            {
                return testGateWay.SaveTest(test);
                
            }
            else
            {
                return 0;
            }
            //throw new Exception("Semiler Test Already Exist On Your System");
        }

        public bool IsTetsExist(string testName, string testType)
        {
            return testGateWay.IsTetsExist( testName, testType);
        }

        public List<Test> GetAllTestName()
        {

            return testGateWay.GetAllTestName();
            //throw new NotImplementedException();
        }
    }
}