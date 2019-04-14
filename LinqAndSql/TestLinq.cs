using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAndSql
{
    public class TestLinq
    {
        private static Company myCompany;
        public static void Main(string[] args)
        {
            myCompany = new Company("Nestle", "Pinki");
            myCompany.SetupCompanyBasicInfra();
            GetMangaersMoreMoreReporting(1);
            Console.ReadKey();
        }


        public static IEnumerable<Employee> GetMangaersMoreMoreReporting(int reportingLimit)
        {
            IEnumerable<Employee> managers;

            IEnumerable<int> mangersIds = myCompany.Employees.GroupBy(emp => emp.ManagerId).Where(group => group.Count() > reportingLimit).Select(group => group.Key);

            managers = myCompany.Employees.Where(mng => mangersIds.Contains(mng.EmployeeID));

            //or 

            managers = myCompany.Employees.Where(mng => myCompany.Employees.GroupBy(emp => emp.ManagerId).Where(group => group.Count() > reportingLimit).Select(group => group.Key).Contains(mng.EmployeeID)).ToList();



            return managers;
        }
    }
}
