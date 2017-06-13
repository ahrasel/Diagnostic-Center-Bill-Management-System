using System.Collections.Generic;
using DiagnosticManagementSystem.DAL;
using DiagnosticManagementSystem.Model;

namespace DiagnosticManagementSystem.BLL
{
    public class TesttypeManager
    {
        TesttypeGateWay testtypeGate = new TesttypeGateWay();
        public int SaveTesttype(TestType testType)
        {
           return  testtypeGate.SaveTesttype(testType);
        }


        public bool IsTesttypeExist(string TypeName)
        {
           return testtypeGate.IsTesttypeExist(TypeName);
            //throw new NotImplementedException();
        }


        public List<TestType> GetAllTypeName()
        {
            return testtypeGate.GetAllTypeName();
            // throw new NotImplementedException();
        }
    }
}