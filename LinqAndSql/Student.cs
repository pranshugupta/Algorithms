using System.Collections.Generic;

namespace LinqAndSql
{
    public enum Gender
    {
    Male,
    Female,
    Transgender
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }

        public int BranchID { get; set; }

        public static List<Student> GetAllStudents() {
            return new List<Student>() {
                new Student(){ID =1, Name = "Pranshu" , Gender = Gender.Male , BranchID = 1},
                new Student(){ID =2, Name = "Priyanshu" , Gender = Gender.Male, BranchID = 2},
                new Student(){ID =2, Name = "Priyanshu" , Gender = Gender.Male, BranchID = 2},
                new Student(){ID =2, Name = "Priyanshu" , Gender = Gender.Male, BranchID = 2},
                new Student(){ID =3, Name = "Priyansha" , Gender = Gender.Female, BranchID = 3},
                new Student(){ID =4, Name = "Priyanshi" , Gender = Gender.Female, BranchID = 1},
                new Student(){ID =5, Name = "Priyanka" , Gender = Gender.Female, BranchID = 2},
                new Student(){ID =6, Name = "Prakash" , Gender = Gender.Male, BranchID = 3 },
                new Student(){ID =7, Name = "Pravesh" , Gender = Gender.Male, BranchID = 1},
                new Student(){ID =8, Name = "Priti" , Gender = Gender.Female, BranchID = 2},
                new Student(){ID =5, Name = "Priyanka" , Gender = Gender.Female, BranchID = 2},
                new Student(){ID =6, Name = "Prakash" , Gender = Gender.Male, BranchID = 3 },
                new Student(){ID =7, Name = "Pravesh" , Gender = Gender.Male, BranchID = 1},
                new Student(){ID =9, Name = "Prateek" , Gender = Gender.Male, BranchID = 3},
                new Student(){ID =10, Name = "Prakhar" , Gender = Gender.Male}

            };
        }

        public static List<Student> GetOtherStudents()
        {
            return new List<Student>() {
                new Student(){ID =1, Name = "Pranshu" , Gender = Gender.Male , BranchID = 1},
                new Student(){ID =11, Name = "Priyanshu" , Gender = Gender.Male, BranchID = 2},
                new Student(){ID =2, Name = "Priyanshu" , Gender = Gender.Male, BranchID = 2},
                new Student(){ID =12, Name = "Priyanshu" , Gender = Gender.Male, BranchID = 2},
                new Student(){ID =3, Name = "Priyansha" , Gender = Gender.Female, BranchID = 3},

            };
        }
    }


    // we can also override these two methods in Student class only. But it doesn't work with anonymous types
    public class StudentEqualityComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return x.ID == y.ID && x.Name == y.Name;
        }

        //need to do this so that it can work in dictionary as well, include the same properties as in equals method
        public int GetHashCode(Student obj)
        {
            return obj.ID.GetHashCode() ^ obj.Name.GetHashCode();
        }
    }
}
