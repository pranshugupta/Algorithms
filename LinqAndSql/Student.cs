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

        public static List<Student> GetAllStudents() {
            return new List<Student>() {
                new Student(){ID =1, Name = "Pranshu" , Gender = Gender.Male},
                new Student(){ID =2, Name = "Priyanshu" , Gender = Gender.Male},
                new Student(){ID =3, Name = "Priyansha" , Gender = Gender.Female},
                new Student(){ID =4, Name = "Priyanshi" , Gender = Gender.Female},
                new Student(){ID =5, Name = "Priyanka" , Gender = Gender.Female},
                new Student(){ID =6, Name = "Prakash" , Gender = Gender.Male},
                new Student(){ID =7, Name = "Pravesh" , Gender = Gender.Male},
                new Student(){ID =8, Name = "Priti" , Gender = Gender.Female},
                new Student(){ID =9, Name = "Prateek" , Gender = Gender.Male},
                new Student(){ID =10, Name = "Prakhar" , Gender = Gender.Male}

            };
        }
    }
}
