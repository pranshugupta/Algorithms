using System;
using System.Collections;
using System.Linq;

namespace LinqAndSql
{
    public class TestLinq
    {
        private static Department myCompany;
        public static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var evenNumbers = from number in numbers
                             where (number % 2) == 0
                             select number;
            Func<int, bool> predicate = num=> num %2==1;
            var oddNumbers1 = numbers.Where(predicate);
            var oddNumbers2 = numbers.Where(num=>isOdd(num));
            var smallestNumber = numbers.Min();
            var largestEvenNumber = numbers.Where(number => number % 2 == 0).Max();
            var sumOfEvenNumbers = numbers.Where(number => number % 2 == 0).Sum();
            var count = numbers.Count();
            var average = numbers.Average();
            var productOfNumber = numbers.Aggregate((a,b)=>a*b);
            var productOfNumber10Times = numbers.Aggregate(10, (a,b)=>a*b);
            var numberWithPosition = numbers.Select((num,index)=> new {Number=num,Index=index}).Where(item=> item.Number%2==0).Select(item=>item.Index);


            string[] countries = {"India", "Pakistan", "China", "United states of America", "Unis", "United Kingdoms"};
            var shortestCountryName = countries.Min(country=> country.Length);
            var largestestCountryName = countries.Max(country=> country.Length);
            var commaSepratedCountryNames = countries.Aggregate((a,b)=> a + ','+b);


            var maleStudents = Student.GetAllStudents().Where(student => student.Gender == Gender.Male);
            var femaleStudents = from student in Student.GetAllStudents()
                                 where student.Gender == Gender.Female
                                 select student;

            string[] stringArray = { "87895qwertyuiopasdfghjklzxcvbnm",
            "0123456789jghbhbh"};
            var concatenate = stringArray.SelectMany(s => s).Distinct();
            var concatenateSql = (from s in stringArray
                                 from c in s
                                 select c).Distinct();

            var allEmployees = DepartmentDetail.GetDepartmentDetail().SelectMany(emp => emp.Employees);
            var allEmployeesSql = from dept in DepartmentDetail.GetDepartmentDetail()
                           from employee in dept.Employees
                           select employee;
            var allEmployeeWithDepartment = DepartmentDetail.GetDepartmentDetail().SelectMany(dept => dept.Employees, (dpt, emp) => new { Department = dpt.Department, Employee = emp });
            var allEmployeeWithDepartmentSql = from dept in DepartmentDetail.GetDepartmentDetail()
                                               from emp in dept.Employees
                                               select new { Department = dept.Department, emp };
            var descSalaryEmployees = DepartmentDetail.GetDepartmentDetail().SelectMany(dept => dept.Employees).OrderBy(emp => emp.Salary);
            var ascSalaryEmployeesSql = from dept in DepartmentDetail.GetDepartmentDetail()
                                        from emp in dept.Employees
                                        orderby emp.Salary ascending
                                        select emp;
            var ascGenderDescSalaryEmployees = DepartmentDetail.GetDepartmentDetail().SelectMany(dept => dept.Employees).OrderBy(emp => emp.Gender).ThenByDescending(emp => emp.Salary);
            var ascGenderDescSalaryEmployeesSql = from dept in DepartmentDetail.GetDepartmentDetail()
                                                  from emp in dept.Employees
                                                  orderby emp.Gender, emp.Salary descending
                                                  select emp;

            var reverseEmployees = DepartmentDetail.GetDepartmentDetail().SelectMany(dept => dept.Employees).Reverse();

            var threeHighestPaidEmployees = DepartmentDetail.GetDepartmentDetail().SelectMany(dept => dept.Employees).OrderByDescending(emp => emp.Salary).Take(3);
            var otherThenTop3PaidEmployees = DepartmentDetail.GetDepartmentDetail().SelectMany(dept => dept.Employees).OrderByDescending(emp => emp.Salary).Skip(3);
            var fourthHighestPaidEmployee = (from dept in DepartmentDetail.GetDepartmentDetail()
                                             from emp in dept.Employees
                                             orderby emp.Salary descending
                                             select emp).Skip(3).Take(1);

            var allEmployeesTill40000MinSalaryEncounterdForFirstTime = (from dept in DepartmentDetail.GetDepartmentDetail()
                                                            from emp in dept.Employees
                                                            select emp).Skip(3).TakeWhile(emp=> emp.Salary > 40000);

            var pageNumber = 4;
            var itemPerPage = 3;
            var pagingOnEmployeeMethod = DepartmentDetail.GetDepartmentDetail().SelectMany(dept => dept.Employees).Skip(itemPerPage*(pageNumber-1)).Take(itemPerPage);

            var allEmployeeDictionary = DepartmentDetail.GetDepartmentDetail().SelectMany(dept => dept.Employees).ToDictionary(emp => emp.ID, emp => emp);
            var allEmployeeDictionarySameResultAsAbove = DepartmentDetail.GetDepartmentDetail().SelectMany(dept => dept.Employees).ToDictionary(emp => emp.ID);

            var employeesLookUpGender = DepartmentDetail.GetDepartmentDetail().SelectMany(dept => dept.Employees).ToLookup(emp => emp.Gender);

            var employeesGroupByGender = DepartmentDetail.GetDepartmentDetail().SelectMany(dept => dept.Employees).GroupBy(emp => emp.Gender);
            var employeesGroupByGenderOderring = from dept in DepartmentDetail.GetDepartmentDetail()
                                                 from emp in dept.Employees
                                                 group emp by emp.Gender into genderGroup
                                                 orderby genderGroup.Key descending
                                                 select new
                                                 {
                                                     Key = genderGroup.Key,
                                                     Employees = genderGroup.OrderBy(emp=> emp.FirstName)
                                                 };



            var complexGroupingOrderring = DepartmentDetail.GetDepartmentDetail()
                                    .SelectMany(dept => dept.Employees)
                                    .GroupBy(emp => new { emp.Department, emp.Gender })
                                    .OrderBy(grp => grp.Key.Department).ThenBy(grp => grp.Key.Gender)
                                    .Select(grp => new
                                    {
                                        Dept = grp.Key.Department,
                                        Gender = grp.Key.Gender,
                                        Employees = grp.OrderBy(emp => emp.FirstName)
                                    });
            var complexGroupingOrderringSql = from dept in DepartmentDetail.GetDepartmentDetail()
                                              from emp in dept.Employees
                                              group emp by new { emp.Department, emp.Gender } into eGroup
                                              orderby eGroup.Key.Department, eGroup.Key.Gender
                                              select new
                                              {
                                                  Dept = eGroup.Key.Department,
                                                  Gender = eGroup.Key.Gender,
                                                  Employees = eGroup.OrderBy(emp=> emp.FirstName)
                                              };
                                              

            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add("test");


            var intList = list.Cast<int>(); //exception is thrown if an item not convertible ...deferred execution
            var onlyIntList = list.OfType<int>(); // return only int and ignores other types


        }
        private static bool isOdd(int num)
        {
            return num %2 == 1;
        }
    }
}
