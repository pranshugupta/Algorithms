namespace LinqAndSql
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }

        public int ManagerId { get; set; }
    }
}
