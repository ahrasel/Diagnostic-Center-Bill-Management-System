namespace DiagnosticManagementSystem.Model
{
    public class TestType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SerialNo { get; set; }


        public TestType(string name):this()
        {
            Name = name;
        }

        public TestType()
        {
            
        }

    }
}