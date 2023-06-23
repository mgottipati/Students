//using Microsoft.EntityFrameworkCore;

namespace Students.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

