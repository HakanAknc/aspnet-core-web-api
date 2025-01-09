using studentDemo.Models;

namespace studentDemo.Data
{
    public class ApplicationContext
    {
        public static List<Student> Students = new List<Student>
        {
            new Student { Id = 1, Name = "Hakan Akıncı", Age = 23, Section = "Yazılım" },
            new Student { Id = 2, Name = "Bünyamin Korkulu", Age = 18, Section = "Öğretmen" },
            new Student { Id = 3, Name = "Yusuf Erdem", Age = 15, Section = "Sanayi" }
        };
    }
}
