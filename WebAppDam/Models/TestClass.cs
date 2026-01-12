namespace WebAppDam.Models
{
    public class RazorPage<T>
    {
        public T Model { get; set; }
        public int Salary { get; set; }
    }
    public class Child1<T> : RazorPage<T>
    {

    }
    public class Child2 : RazorPage<Student>//Close type
    {

    }
    public class TestClass
    {
        public void test()
        {
            Child2 c = new Child2();
            // Child1<int> cc=new Models.Child1

            //Create object determon gemeeric
            RazorPage<Student> o1 = new ();
            
            RazorPage<int> o2 = new ();
            



            dynamic x = 10;
            dynamic name = "ahmed";
            dynamic obj=new Student { Name = name};
            obj.Name = "hskdad";
            obj.hsdhagd = 10;
            name=x + obj;
        }
    }
}
