using System;

namespace DiagnosticManagementSystem.Model
{
    [Serializable]
    public class Test
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public decimal Fee { get; set; }
        public string TestType { get; set; }
        public int SerialNo { get; set; }


        public Test(string name, decimal fee, string type):this()
        {
            Name = name;
            Fee = fee;
            TestType = type;
        }

        public Test()
        {
            
        }
    }
}