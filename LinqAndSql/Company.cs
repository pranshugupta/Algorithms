using System.Collections.Generic;

namespace LinqAndSql
{
    public class Company
    {
        public string CompanyName { get; private set; }
        public Employee CEO { get; private set; }
        public List<Employee> Employees { get; private set; }

        public Company(string companyName, string ceoName)
        {
            CompanyName = companyName;
            CEO = new Employee() { Name = ceoName, EmployeeID = 0, ManagerId = 0, Department = "CEO", Salary = 1000000 };
            CEO.ManagerId = 0;
            Employees = new List<Employee>();
        }
        public void SetupCompanyBasicInfra()
        {
            Employees.Add(CEO);

            Employees.Add(new Employee() { Name = "Emp1", EmployeeID = 1, ManagerId = 0, Department = "Dept1", Salary = 1000 });
            Employees.Add(new Employee() { Name = "Emp2", EmployeeID = 2, ManagerId = 1, Department = "Dept1", Salary = 2000 });
            Employees.Add(new Employee() { Name = "Emp3", EmployeeID = 3, ManagerId = 2, Department = "Dept1", Salary = 5000 });

            Employees.Add(new Employee() { Name = "Emp4", EmployeeID = 4, ManagerId = 0, Department = "Dept2", Salary = 54200 });
            Employees.Add(new Employee() { Name = "Emp5", EmployeeID = 5, ManagerId = 4, Department = "Dept2", Salary = 4520 });
            Employees.Add(new Employee() { Name = "Emp6", EmployeeID = 6, ManagerId = 5, Department = "Dept2", Salary = 3210 });
            Employees.Add(new Employee() { Name = "Emp7", EmployeeID = 7, ManagerId = 5, Department = "Dept2", Salary = 7850 });

            Employees.Add(new Employee() { Name = "Emp8", EmployeeID = 8, ManagerId = 0, Department = "Dept3", Salary = 1000 });
            Employees.Add(new Employee() { Name = "Emp9", EmployeeID = 9, ManagerId = 8, Department = "Dept3", Salary = 1500 });
            Employees.Add(new Employee() { Name = "Emp10", EmployeeID = 10, ManagerId = 9, Department = "Dept3", Salary = 8500 });
            Employees.Add(new Employee() { Name = "Emp11", EmployeeID = 11, ManagerId = 10, Department = "Dept3", Salary = 350 });

            Employees.Add(new Employee() { Name = "Emp12", EmployeeID = 12, ManagerId = 0, Department = "Dept4", Salary = 4850 });
            Employees.Add(new Employee() { Name = "Emp13", EmployeeID = 13, ManagerId = 12, Department = "Dept4", Salary = 7890 });
            Employees.Add(new Employee() { Name = "Emp14", EmployeeID = 14, ManagerId = 12, Department = "Dept4", Salary = 5520 });
            Employees.Add(new Employee() { Name = "Emp15", EmployeeID = 15, ManagerId = 13, Department = "Dept4", Salary = 1000 });
            Employees.Add(new Employee() { Name = "Emp16", EmployeeID = 16, ManagerId = 14, Department = "Dept4", Salary = 5460 });

            Employees.Add(new Employee() { Name = "Emp17", EmployeeID = 17, ManagerId = 0, Department = "Dept5", Salary = 6540 });
            Employees.Add(new Employee() { Name = "Emp18", EmployeeID = 18, ManagerId = 17, Department = "Dept5", Salary = 8640 });
            Employees.Add(new Employee() { Name = "Emp19", EmployeeID = 19, ManagerId = 18, Department = "Dept5", Salary = 8542 });
            Employees.Add(new Employee() { Name = "Emp20", EmployeeID = 20, ManagerId = 19, Department = "Dept5", Salary = 9540 });

            Employees.Add(new Employee() { Name = "Emp21", EmployeeID = 21, ManagerId = 0, Department = "Dept6", Salary = 3600 });
            Employees.Add(new Employee() { Name = "Emp22", EmployeeID = 22, ManagerId = 21, Department = "Dept6", Salary = 4520 });
            Employees.Add(new Employee() { Name = "Emp23", EmployeeID = 23, ManagerId = 21, Department = "Dept6", Salary = 1250 });
        }
    }
}
