using dz2ef;
using dz2ef.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;



//using (var context = new AppDbContext())
//{

//    if (!context.Teachers.Any())
//    {
//        var teacherJohn = new Teacher
//        {
//            Name = "John",
//            Email = "john@university.com",
//            Courses = new List<Course>
//            {
//                new Course { Name = "C#", Description = "C# Programming" },
//                new Course { Name = "EF Core", Description = "Entity Framework Core" }
//            }
//        };

//var teacherAli = new Teacher
//{
//    Name = "Ali",
//    Email = "ali@university.com",
//    Courses = new List<Course>
//            {
//                new Course { Name = "SQL", Description = "Databases and SQL" },
//                new Course { Name = "Algorithms", Description = "Data Structures & Algorithms" }
//            }
//};

//        var teacherSarah = new Teacher
//        {
//            Name = "Sarah",
//            Email = "sarah@university.com",
//            Courses = new List<Course>
//            {
//                new Course { Name = "Web Development", Description = "HTML/CSS/JS" }
//            }
//        };

//        context.Teachers.AddRange(teacherJohn, teacherAli, teacherSarah);
//        context.SaveChanges();

//var courses = context.Courses.ToList();
//var csharp = courses.First(c => c.Name == "C#");
//var efCore = courses.First(c => c.Name == "EF Core");
//var sql = courses.First(c => c.Name == "SQL");
//var algorithms = courses.First(c => c.Name == "Algorithms");
//var web = courses.First(c => c.Name == "Web Development");

//        var students = new List<Student>
//        {
//            new Student
//            {
//                Name = "Alex Smith",
//                Age = 20,
//                Email = "alex@mail.com",
//                StudentCard = new StudentCard { CardNumber = "CARD-001", IssueDate = DateTime.Now },
//                Courses = new List<Course> { csharp, efCore }
//            },
//            new Student
//            {
//                Name = "Maria Ivanova",
//                Age = 21,
//                Email = "maria@mail.com",
//                StudentCard = new StudentCard { CardNumber = "CARD-002", IssueDate = DateTime.Now },
//                Courses = new List<Course> { sql, algorithms }
//            },
//            new Student
//            {
//                Name = "Elchin Aliyev",
//                Age = 22,
//                Email = "elchin@mail.com",
//                StudentCard = new StudentCard { CardNumber = "CARD-003", IssueDate = DateTime.Now },
//                Courses = new List<Course> { csharp, sql }
//            },
//            new Student
//            {
//                Name = "Leyla Mammadova",
//                Age = 19,
//                Email = "leyla@mail.com",
//                StudentCard = new StudentCard { CardNumber = "CARD-004", IssueDate = DateTime.Now },
//                Courses = new List<Course> { algorithms, web }
//            },
//            new Student
//            {
//                Name = "David Beck",
//                Age = 23,
//                Email = "david@mail.com",
//                StudentCard = new StudentCard { CardNumber = "CARD-005", IssueDate = DateTime.Now },
//                Courses = new List<Course> { efCore, web }
//            }
//        };

//        context.Students.AddRange(students);
//        context.SaveChanges();

//    }




//}

//5.1

//Console.WriteLine("Students:");

//var context = new AppDbContext();

//var students = context.Students.ToList();

//foreach (var student in students)
//{
//    Console.WriteLine($" - {student.Name}");
//    Console.WriteLine($"   Age: {student.Age}");
//    Console.WriteLine($"   Email: {student.Email}");
//    Console.WriteLine($"   ID: {student.Id}");
//    Console.WriteLine();
//}


//5.2

//var context = new AppDbContext();

//var students = context.Students.
//    Include(sc => sc.StudentCard);

//foreach (var student in students)
//{
//    Console.WriteLine($"Студент: {student.Name} | Билет: {student.StudentCard?.CardNumber}");
//}

//5.3

//var context = new AppDbContext();

//var courses = context.Courses.Include(c => c.Teacher);
//foreach (var course in courses)
//{
//    Console.WriteLine($"Курс: {course.Name} | Преподаватель: {course.Teacher.Name}");
//}



//5.4

//var context = new AppDbContext();

//var students = context.Students.Include(s => s.Courses);

//foreach (var student in students)
//{
//    Console.WriteLine($"Студент: {student.Name}");
//    Console.WriteLine("Курсы: ");

//    foreach (var course in student.Courses)
//    {
//        Console.WriteLine($" - {course.Name}");
//    }

//}




//5

//var context = new AppDbContext();

//var student = new Student
//{
//    Name = "Test Student",
//    Age = 20,
//    Email = "test@test.com"
//};

//Console.WriteLine(context.Entry(student).State);
//context.Students.Add(student);
//Console.WriteLine(context.Entry(student).State);
//context.SaveChanges();
//Console.WriteLine(context.Entry(student).State);



//4
//var context = new AppDbContext();


//var teacherAli = context.Teachers.FirstOrDefault(t => t.Name == "Ali");

//Course course = new Course()
//{
//    Name = "ASP.NET Core",
//    Description = "Web development with ASP.NET Core",
//};

//teacherAli.Courses.Add(course);
//context.SaveChanges();




//6


//var context = new AppDbContext();
//var student = context.Students
//    .First(x => x.Id == 1);

//Console.WriteLine(context.Entry(student).State);
//student.Name = "New Name";


//Console.WriteLine(context.Entry(student).State);

//context.SaveChanges();


//Console.WriteLine(context.Entry(student).State);


//Unchanged
//Modified
//Unchanged



////7
//var context = new AppDbContext();
//var students = context.Students;
//Console.WriteLine("СПИСОК СТУДЕНТОВ:");
//foreach (var st in students)
//{
//    Console.WriteLine($" - {st.Name} - {st.Id}");
//}
//var student = context.Students.Where(s => s.Id == 3).FirstOrDefault();
//students.Remove(student);
//Console.WriteLine($"СОСТОЯНИЕ ПОСЛЕ УДАЛЕНИЯ: {context.Entry(student).State}");
//context.SaveChanges();


//Console.WriteLine("СПИСОК СТУДЕНТОВ ПОСЛЕ УДАЛЕНИЯ:");
//foreach (var st in students)
//{
//    Console.WriteLine($" - {st.Name} - {st.Id}");
//}

//Console.WriteLine("СОСТОЯНИЕ: ");
//Console.WriteLine(context.Entry(student).State);




//8

//var context = new AppDbContext();


//var students = context.Students
//    .Take(3)
//    .ToList();

//students[0].Age = 21;
//students[1].Age = 22;

//var teachers = context.Teachers
//    .Take(2)
//    .ToList();

//teachers[0].Name = "Maxim";

//Course course = new Course()
//{
//    Name = "Python",
//    Description = "Python Programming",
//};

//context.Courses.Add(course);


//foreach (var entry in context.ChangeTracker.Entries())
//{
//    Console.WriteLine(
//        $"{entry.Entity.GetType().Name} - {entry.State}");
//}

//9 dobavil

//10
//var context = new AppDbContext();

//var teachers = context.Teachers.Include(s => s.Courses).ThenInclude(c => c.Students).ToList();

//foreach (var item in teachers)
//{
//    if (item.Name == "John")
//    {
//        Console.WriteLine($"Преподаватель: {item.Name}");
//        foreach (var course in item.Courses)
//        {
//            Console.WriteLine($"  Курс: {course.Name}");
//            foreach (var student in course.Students)
//            {
//                Console.WriteLine($"    Студент: {student.Name}");
//            }
//        }
//    }
//}

