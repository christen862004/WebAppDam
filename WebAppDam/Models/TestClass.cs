using NuGet.Protocol;

namespace WebAppDam.Models
{
    class MyController
    {
        private object _data;

        public object Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public  dynamic Data2
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

    }

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
        public string NAme { get; set; }
    }

    public class TestClass
    {
        public void test()
        {
            Child2 child=null;
            //if (child != null)
            //{
            //    string n = child.NAme;
            //}
            //else
            //{
            //    Console.WriteLine("Child 1");
            //}
            string n = child?.NAme;






            MyController c= new MyController();
            c.Data = 10;

            //Child2 c = new Child2();
            //// Child1<int> cc=new Models.Child1

            ////Create object determon gemeeric
            //RazorPage<Student> o1 = new ();
            //RazorPage<int> o2 = new ();
            



            //dynamic x = 10;
            //dynamic name = "ahmed";
            //dynamic obj=new Student { Name = name};
            //obj.Name = "hskdad";
            //obj.hsdhagd = 10;
            //name=x + obj;
        }
    }
}
