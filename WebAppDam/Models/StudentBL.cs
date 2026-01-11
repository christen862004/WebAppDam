namespace WebAppDam.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>() { 
                new Student() {Id=1,Name="ahmed",ImageURL="m.png"},
                new Student() {Id=2,Name="ali",ImageURL="m.png"},
                new Student() {Id=3,Name="hala",ImageURL="2.jpg"},
                new Student() {Id=4,Name="islam",ImageURL="m.png"},
                new Student() {Id=5,Name="saed",ImageURL="m.png"},
            };
        }
        public List<Student> GetAll()
        {
            return students;
        }
        public Student GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
