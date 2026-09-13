


namespace dz2ef
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; }

        public StudentCard? StudentCard { get; set; }
        public List<Course> Courses { get; set; } = new();
    }
}
