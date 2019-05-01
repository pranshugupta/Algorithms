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
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add("test");
            var intList = list.Cast<int>(); //exception is thrown if an item not convertible ...deferred execution
            var onlyIntList = list.OfType<int>(); // return only int and ignores other types

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var evenNumbers = from number in numbers
                             where (number % 2) == 0
                             select number;
            var numberGreaterThan100First = numbers.Where(num => num > 100).First(); // first element otherwise exception
            var numberGreaterThan100FirstDefault = numbers.Where(num => num > 100).FirstOrDefault(); // first element otherwise default value of int

            var numberGreaterThan100Last = numbers.Where(num => num > 100).Last(); // last element otherwise exception
            var numberGreaterThan100LasttDefault = numbers.Where(num => num > 100).LastOrDefault(); // last element otherwise default value of int

            var numerElementAt = numbers.ElementAt(5); //element at 5 or exception
            var numerElementAtDefault = numbers.ElementAtOrDefault(5); //element at 5 or default value of int

            var singleNumber = numbers.Single(); // only element of the sequence or exception
            var singleNumberPredicate = numbers.Single(x=> x%2==0); // only element of the sequence staisfaying condition or exception
            var singleNumberDefault = numbers.SingleOrDefault(); // only element of the sequence or if array is empty then default value if more than one element then exception
            var defaultOrEmpty = numbers.DefaultIfEmpty();// original array if not empty otherwise array witrh one element with default value

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

            string[] names = {"Pranshu", "pranshu", "Pravesh", "Pravesh", "Priyanka" ,"Pranshu"};
            var distinctNames = names.Distinct(); // distinct names
            var distinctNamesCaseInsensitive = names.Distinct(StringComparer.OrdinalIgnoreCase); // disticnt ignore case


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


            var studentGroupByBranch = Branch.GetAllBranches()
                            .GroupJoin(
                                Student.GetAllStudents(),
                                bra => bra.ID,
                                stu => stu.BranchID,
                                (bra, stu) => new { Branch = bra, Students = stu });

            var studentGroupByBranchSql= from bra in Branch.GetAllBranches()
                                    join stu in Student.GetAllStudents()
                                    on bra.ID equals stu.BranchID into sGroup
                                    select new { Branch = bra, Students = sGroup };


            var BranchInnerJoinStudent = Branch.GetAllBranches()
                                        .Join(Student.GetAllStudents(),
                                        bra => bra.ID,
                                        stu => stu.BranchID,
                                        (bra, stu) => new { Branch = bra.Name, Student = stu.Name });

            var BranchInnerJoinStudentSql = from bra in Branch.GetAllBranches()
                                            join stu in Student.GetAllStudents()
                                            on bra.ID equals stu.BranchID
                                            select new { Branch = bra.Name, Student = stu.Name };

            var BranchLeftOutertJoinStudent = Branch.GetAllBranches()
                                            .GroupJoin(Student.GetAllStudents(),
                                                bra=> bra.ID,
                                                stu=> stu.BranchID,
                                                (bra, stus)=> new { Branch = bra, Students = stus })
                                            .SelectMany(z=> z.Students.DefaultIfEmpty(),
                                                (bra, stu)=> new {
                                                    Branch = bra.Branch.Name,
                                                    Student = stu == null ? "" : stu.Name
                                                });

            var BranchLeftOutertJoinStudentSql = from bra in Branch.GetAllBranches()
                                              join stu in Student.GetAllStudents()
                                              on bra.ID equals stu.BranchID into sGroup
                                              from stu in sGroup.DefaultIfEmpty()
                                              select new {
                                                  Branch = bra.Name,
                                                  Student = stu== null? "":stu.Name };

            var BranchCrossJoinStudent = Branch.GetAllBranches()
                                        .SelectMany(stu=> Student.GetAllStudents(),
                                        (bra,stu)=> new
                                        {
                                            Branch = bra.Name,
                                            Name = stu.Name
                                        });

            var BranchCrossJoinStudentJoin = Branch.GetAllBranches()
                                        .Join(Student.GetAllStudents(),
                                        bra => true,
                                        stu => true,
                                        (bra, stu) => new { Branch = bra.Name, Student = stu.Name });

            var BranchCrossJoinStudentSql = from bra in Branch.GetAllBranches()
                                            from stu in Student.GetAllStudents()
                                            select new
                                            {
                                                Branch = bra.Name,
                                                Name = stu.Name
                                            };

            var distinctStudents = Student.GetAllStudents().Distinct(new StudentEqualityComparer());
            var distinctStudentIdNames = Student.GetAllStudents()
                                           .Select(stu => new { ID = stu.ID, Name = stu.Name }).Distinct(); // anonymous types override equals and Gethashcode method so this works fine

            var concatStudents = Student.GetAllStudents()
                                .Select(stu => new { ID = stu.ID, Name = stu.Name })
                                .Concat(Student.GetOtherStudents().Select(stu => new { ID = stu.ID, Name = stu.Name }));

            var unionStudents = Student.GetAllStudents()
                                .Select(stu => new { ID = stu.ID, Name = stu.Name })
                                .Union(Student.GetOtherStudents().Select(stu => new { ID = stu.ID, Name = stu.Name }));

            var intersectStudents = Student.GetAllStudents()
                                .Select(stu => new { ID = stu.ID, Name = stu.Name })
                                .Intersect(Student.GetOtherStudents().Select(stu => new { ID = stu.ID, Name = stu.Name }));

            var evenNumbersViaRange = Enumerable.Range(0, 10).Select(num => num % 2 == 0);
            var repeat = Enumerable.Repeat("Pranshu", 10);// repeat will contain 5 items of Pranshu
            var empty = Enumerable.Empty<int>();// return new IEnumerable<int>()

            string[] seq1 = { "PraNshu", "pranshu", "PRAVESH", "Pravesh", "PRIYANKA", "Pranshu" };
            string[] seq2 = { "Pranshu", "pranshu", "Pravesh", "Pravesh", "Priyanka", "Pranshu" };

            var areSequenceEquals = seq1.SequenceEqual(seq2, StringComparer.OrdinalIgnoreCase);// true as sequence are equal for object types override Gethashcode and equals

            var all = numbers.All(num => num < 100);
            var any = numbers.Any(num => num % 2 == 0);
            var contains = numbers.Contains(10);



        }
        private static bool isOdd(int num)
        {
            return num %2 == 1;
        }
    }
}
