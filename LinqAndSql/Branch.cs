using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAndSql
{
   public  class Branch
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<Branch> GetAllBranches() {
            return new List<Branch>() {
                new Branch(){ ID = 1, Name ="CSE"},
                new Branch(){ ID = 2, Name ="IT"},
                new Branch(){ ID = 3, Name ="EC"},
                new Branch(){ ID = 4, Name ="ME"},
            };
        }
    }
}
