namespace dz2ef
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public List<Student> Students { get; set; } = new();
    }
}


