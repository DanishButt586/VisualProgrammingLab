using System;

public class Program
{
    public enum Department
    {
        ComputerScience,
        Mathematics,
        Physics,
        Chemistry
    }

    
    public class Person
    {
        
        private string name;

        public Person()
        {
            name = null;
        }

        
        public Person(string name)
        {
            this.name = name;
        }

        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    
    public class Student : Person
    {
        
        private string regNo;
        private int age;
        private Department program;

        
        public Student() : base() 
        {
            regNo = null;
            age = 0;
            program = 0; 
        }

        
        public Student(string name, string regNo, int age, Department program) : base(name) 
        {
            this.regNo = regNo;
            this.age = age;
            this.program = program;
        }

        
        public string RegNo
        {
            get { return regNo; }
            set { regNo = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Department Program
        {
            get { return program; }
            set { program = value; }
        }
    }

    
    public static void Main(string[] args)
    {
        Student student1 = new Student();
        student1.Name = "Danish Butt";
        student1.RegNo = "233606";
        student1.Age = 20;
        student1.Program = Department.ComputerScience;

        Console.WriteLine("Student 1:");
        Console.WriteLine($"Name: {student1.Name}");
        Console.WriteLine($"Reg No: {student1.RegNo}");
        Console.WriteLine($"Age: {student1.Age}");
        Console.WriteLine($"Program: {student1.Program}");

        
        Student student2 = new Student("Muhammad Ali", "233510", 22, Department.Mathematics);

        Console.WriteLine("\nStudent 2:");
        Console.WriteLine($"Name: {student2.Name}");
        Console.WriteLine($"Reg No: {student2.RegNo}");
        Console.WriteLine($"Age: {student2.Age}");
        Console.WriteLine($"Program: {student2.Program}");
    }
}
