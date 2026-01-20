using NuGet.Protocol;

namespace WebAppDam.Models
{
    interface ISort
    {
        void Sort(int[] arr);
    }
    //BL
    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //logic using BS
        }
    }
    class SelectioSort:ISort { 
        public void Sort(int[] arr)
        {

        }
    }
    class ChrisSort : ISort
    {
        public void Sort(int[] arr)
        {
            throw new NotImplementedException();
        }
    }
    //    class use class :depenecny
    //IOC : tigh couple ==> lossly couple
    //DIP : dont create ,ask 
    class MyList
    {
        int[] arr;
        ISort listSort;
        public MyList(ISort sortAl)//ask constructor 
        {
            arr = new int[10];
            listSort =sortAl;// new SelectioSort();
        }
        public void Order()
        {
            listSort.Sort(arr);//order using BBSort
        }
    }
    class Test
    {
        public void fun1()
        {
            MyList l11 = new MyList(new BubbleSort());
            l11.Order();//
            MyList l12 = new MyList(new SelectioSort());
            MyList l13 = new MyList(new ChrisSort());

        }
    }











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
