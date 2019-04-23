using System.Collections.Generic;

namespace LinqAndSql
{
    public enum Department {
        IT,
        HR,
        Technology,
        Finance
    }
    public class DepartmentDetail
    {
        public int ID { get; set; }
        public Department Department { get; set; }
        public string Location { get; set; }
        public List<Employee> Employees { get; set; }
        public static List<DepartmentDetail>  GetDepartmentDetail()
        {
            return  new List<DepartmentDetail>()
            {
                new DepartmentDetail(){ID = 1, Department=Department.Finance , Location ="Mumbai",
                Employees = new List<Employee>(){
                    new Employee(){ ID = 1, Department=Department.Finance, Gender=Gender.Male,FirstName="Pranshu",LastName="Gupta",Salary=46845},
                    new Employee(){ ID = 2, Department=Department.Finance,Gender=Gender.Male,FirstName="Prakash",LastName="Gupta",Salary=75315},
                    new Employee(){ ID = 3, Department=Department.Finance,Gender=Gender.Female,FirstName="Priyanka",LastName="Gupta",Salary=95461},
                    new Employee(){ ID = 4, Department=Department.Finance,Gender=Gender.Female,FirstName="Priti",LastName="Gupta",Salary=79505},
                    new Employee(){ ID = 5, Department=Department.Finance,Gender=Gender.Male,FirstName="Pravesh",LastName="Gupta",Salary=785412},
                }},
                new DepartmentDetail(){ID = 2, Department=Department.HR , Location ="Noida",
                Employees = new List<Employee>(){
                    new Employee(){ ID = 6, Department=Department.HR ,Gender=Gender.Male,FirstName="Ram",LastName="Gupta",Salary=78542},
                    new Employee(){ ID = 7, Department=Department.HR ,Gender=Gender.Male,FirstName="Raja",LastName="Gupta",Salary=78426},
                    new Employee(){ ID = 8,Department=Department.HR , Gender=Gender.Female,FirstName="Usha",LastName="Gupta",Salary=784512},
                    new Employee(){ ID = 9,Department=Department.HR , Gender=Gender.Female,FirstName="Lakshmi",LastName="Gupta",Salary=95426},
                    new Employee(){ ID = 10,Department=Department.HR , Gender=Gender.Female,FirstName="Pooja",LastName="Gupta",Salary=85246},
                }},
                new DepartmentDetail(){ID = 3, Department=Department.IT , Location ="Delhi",
                Employees = new List<Employee>(){
                    new Employee(){ ID = 11,Department=Department.IT , Gender=Gender.Male,FirstName="Nishant",LastName="Gupta",Salary=75319},
                    new Employee(){ ID = 12,Department=Department.IT , Gender=Gender.Male,FirstName="Nikhil",LastName="Gupta",Salary=95137},
                    new Employee(){ ID = 13,Department=Department.IT , Gender=Gender.Female,FirstName="Meera",LastName="Gupta",Salary=42865},
                    new Employee(){ ID = 14,Department=Department.IT , Gender=Gender.Female,FirstName="Shashi",LastName="Gupta",Salary=68542},
                    new Employee(){ ID = 15,Department=Department.IT , Gender=Gender.Female,FirstName="Nishi",LastName="Gupta",Salary=85279},
                }},
                new DepartmentDetail(){ID = 4, Department=Department.Technology , Location ="Pune",
                Employees = new List<Employee>(){
                    new Employee(){ ID = 16,Department=Department.Technology , Gender=Gender.Female,FirstName="Khushi",LastName="Gupta",Salary=75382},
                    new Employee(){ ID = 17,Department=Department.Technology , Gender=Gender.Male,FirstName="Chotu",LastName="Gupta",Salary=31795},
                    new Employee(){ ID = 18,Department=Department.Technology , Gender=Gender.Female,FirstName="Bitto",LastName="Gupta",Salary=39175},
                    new Employee(){ ID = 19,Department=Department.Technology , Gender=Gender.Female,FirstName="Mishthi",LastName="Gupta",Salary=97513},
                    new Employee(){ ID = 20,Department=Department.Technology , Gender=Gender.Female,FirstName="Radhika",LastName="Gupta",Salary=75684},
                }
            } };
        }
    }
}
