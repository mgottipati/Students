using Microsoft.AspNetCore.Mvc;
using Students.Models;

namespace Students.Controllers
{
    public class StudentProfileController : Controller
    {
        private static List<Student>? students = BuildStudents().OrderBy(O=>O.Name).ToList();
      
        public IActionResult Index()
        {
            return View(students);
        }
        private static List<Student> BuildStudents()
        {
            //List<string> l = File.ReadAllLines("Students-20230613-123739").ToList();
            List<string> l = System.IO.File.ReadLines(@"C:\Users\d314mg\source\repos\StudentInfo\Students\Data\Students-20230614-113725.txt").ToList();
            List<Student> ret = new List<Student>();
            foreach(string str in l)
            {
                string[] temp = str.Split(",");
                Student s = new Student();
                s.Name = temp[1];
                s.ID = Convert.ToInt32(temp[0]);
                ret.Add(s);
            }
            return ret;
        }
        public IActionResult Save()
        {
            string dataFolder = @"C:\Users\d314mg\source\repos\StudentInfo\Students\Data\";
            //string fileName = "Students-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".txt";
            string fileName = "Students-20230614-113725.txt";
            System.IO.File.WriteAllText(dataFolder + fileName, "");
            foreach (Student s in students)
            {
                System.IO.File.AppendAllText(dataFolder + fileName, s.ID.ToString() + "," + s.Name + Environment.NewLine);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student stu)
        {
            students.Add(stu);
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int ID)
        {
            Student student = students.Where(s => s.ID == ID).FirstOrDefault();
            return View(student);
        }

        public IActionResult DeleteStudent(int ID)
        {
            Student student = students.Where(s => s.ID == ID).FirstOrDefault();
            if(student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            Student student = students.Where(s => s.ID == ID).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student) //display ID without making it editable
        {
            Student ogStudent = students.Where(s => s.ID == student.ID).FirstOrDefault();
            ogStudent.Name = student.Name;
            //ogStudent.ID = student.ID;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int ID)
        {
            Student student = students.Where(s => s.ID == ID).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public IActionResult Details() //need to only display the name and id instead of making them editable
        {
            //Student ogStudent = students.Where(s => s.ID == student.ID).FirstOrDefault();
            //ogStudent.Name = student.Name;
            ////ogStudent.ID = student.ID;
            return RedirectToAction("Index");
        }
    }
}
  