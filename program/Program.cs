using dz2ef.Models; // Подключает пакю с моделями (Course, Student и т.д.)
using dz2ef.context; // Подключает ваш контекст (AppDbContext)
using Microsoft.EntityFrameworkCore;

using (var context = new AppDbContext())
{
    // Убедимся, что база создана
    context.Database.EnsureCreated();

    // Проверяем, чтобы не добавлять данные повторно
    if (!context.Teachers.Any())
    {
        // 1. Создаем преподавателей и связываем с ними курсы
        var teacherJohn = new Teacher
        {
            Name = "John",
            Email = "john@university.com",
            Courses = new List<Course>
            {
                new Course { Name = "C#", Description = "C# Programming" },
                new Course { Name = "EF Core", Description = "Entity Framework Core" }
            }
        };

        var teacherAli = new Teacher
        {
            Name = "Ali",
            Email = "ali@university.com",
            Courses = new List<Course>
            {
                new Course { Name = "SQL", Description = "Databases and SQL" },
                new Course { Name = "Algorithms", Description = "Data Structures & Algorithms" }
            }
        };

        var teacherSarah = new Teacher
        {
            Name = "Sarah",
            Email = "sarah@university.com",
            Courses = new List<Course>
            {
                new Course { Name = "Web Development", Description = "HTML/CSS/JS" }
            }
        };

        // Сохраняем преподавателей и курсы
        context.Teachers.AddRange(teacherJohn, teacherAli, teacherSarah);
        context.SaveChanges();

        // Получаем созданные курсы из базы для привязки к студентам
        var courses = context.Courses.ToList();
        var csharp = courses.First(c => c.Name == "C#");
        var efCore = courses.First(c => c.Name == "EF Core");
        var sql = courses.First(c => c.Name == "SQL");
        var algorithms = courses.First(c => c.Name == "Algorithms");
        var web = courses.First(c => c.Name == "Web Development");

        // 2. Создаем 5 студентов со студенческими битами и курсами (минимум по 2 курса)
        var students = new List<Student>
        {
            new Student
            {
                Name = "Alex Smith",
                Age = 20,
                Email = "alex@mail.com",
                StudentCard = new StudentCard { CardNumber = "CARD-001", IssueDate = DateTime.Now },
                Courses = new List<Course> { csharp, efCore }
            },
            new Student
            {
                Name = "Maria Ivanova",
                Age = 21,
                Email = "maria@mail.com",
                StudentCard = new StudentCard { CardNumber = "CARD-002", IssueDate = DateTime.Now },
                Courses = new List<Course> { sql, algorithms }
            },
            new Student
            {
                Name = "Elchin Aliyev",
                Age = 22,
                Email = "elchin@mail.com",
                StudentCard = new StudentCard { CardNumber = "CARD-003", IssueDate = DateTime.Now },
                Courses = new List<Course> { csharp, sql }
            },
            new Student
            {
                Name = "Leyla Mammadova",
                Age = 19,
                Email = "leyla@mail.com",
                StudentCard = new StudentCard { CardNumber = "CARD-004", IssueDate = DateTime.Now },
                Courses = new List<Course> { algorithms, web }
            },
            new Student
            {
                Name = "David Beck",
                Age = 23,
                Email = "david@mail.com",
                StudentCard = new StudentCard { CardNumber = "CARD-005", IssueDate = DateTime.Now },
                Courses = new List<Course> { efCore, web }
            }
        };

        context.Students.AddRange(students);
        context.SaveChanges();
        Console.WriteLine("Данные успешно добавлены в базу данных!");
    }

    // 3. Вывод данных с использованием .Include()
    Console.WriteLine("\n--- КУРСЫ И ПРЕПОДАВАТЕЛИ ---");
    var coursesList = context.Courses.Include(c => c.Teacher).ToList();
    foreach (var course in coursesList)
    {
        Console.WriteLine($"Курс: {course.Name} | Преподаватель: {course.Teacher.Name}");
    }

    Console.WriteLine("\n--- СТУДЕНТЫ, КАРТЫ И КУРСЫ ---");
    var studentsList = context.Students
        .Include(s => s.StudentCard)
        .Include(s => s.Courses)
        .ToList();

    foreach (var student in studentsList)
    {
        var studentCourses = string.Join(", ", student.Courses.Select(c => c.Name));
        Console.WriteLine($"Студент: {student.Name} | Билет: {student.StudentCard?.CardNumber} | Курсы: {studentCourses}");
    }
}