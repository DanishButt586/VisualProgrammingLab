using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vp_programming_Lab_assignment
{
    public class ChangeRequest : WorkItem
    {
        protected int originalItemID { get; set; }

        // Default constructor for the derived class.
        public ChangeRequest()
        {
        }

        // Instance constructor that has four parameters.
        public ChangeRequest(string title, string desc, TimeSpan joblen, int originalID)
            : base(title, desc, joblen)
        {
            // The following properties and the GetNextID method are inherited
            // from WorkItem.
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.JobLength = joblen;
            // Property originalItemId is a member of ChangeRequest, but not
            // of WorkItem.
            this.originalItemID = originalID;
        }

        public ChangeRequest(int originalItemID)
        {
            this.originalItemID = originalItemID;
        }
    }

    public class WorkItem
    {
        // Static field currentID stores the job ID of the last WorkItem that
        // has been created.
        private static int currentID;

        // Properties.
        protected int ID { get; set; }
        protected string Title { get; set; }
        protected string Description { get; set; }
        protected TimeSpan JobLength { get; set; }

        // Default constructor. If a derived class does not invoke a base-
        // class constructor explicitly, the default constructor is called
        // implicitly.
        public WorkItem()
        {
            ID = 0;
            Title = "Default title";
            Description = "Default description.";
            JobLength = new TimeSpan();
        }

        public WorkItem(string title, string desc, TimeSpan joblen)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.JobLength = joblen;
        }

        // Static constructor to initialize the static member, currentID.
        // This constructor is called one time, automatically, before any instance
        // of WorkItem or ChangeRequest is created, or currentID is referenced.
        static WorkItem()
        {
            currentID = 0;
        }

        protected int GetNextID()
        {
            // currentID is a static field. It is incremented each time a new
            // instance of WorkItem is created.
            return ++currentID;
        }

        // Method Update enables you to update the title and job length of an
        // existing WorkItem object.
        public void Update(string title, TimeSpan joblen)
        {
            this.Title = title;
            this.JobLength = joblen;
        }

        // Virtual method override of the ToString method that is inherited
        // from System.Object.
        public override string ToString()
        {
            return String.Format("{0} - {1}", this.ID, this.Title);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of WorkItem by using the constructor in the
            // base class that takes three arguments.
            WorkItem item = new WorkItem("Fix Bugs", "Fix all bugs in my code branch", new TimeSpan(3, 4, 0, 0));

            // Create an instance of ChangeRequest by using the constructor in
            // the derived class that takes four arguments.
            ChangeRequest change = new ChangeRequest("Change Base Class Design", "Add members to the class", new TimeSpan(4, 0, 0), 1);

            // Use the ToString method defined in WorkItem.
            Console.WriteLine(item.ToString());

            // Use the inherited Update method to change the title of the
            // ChangeRequest object.
            change.Update("Change the Design of the Base Class", new TimeSpan(4, 0, 0));

            // ChangeRequest inherits WorkItem's override of ToString.
            Console.WriteLine(change.ToString());

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}



// ChangeRequest derives from WorkItem and adds a property (originalItemID)


//internal class Program
//    {
//        private static StreamWriter sw;

//        static void Main(string[] args)
//        {

//            //-->Activity 1
//            //double a = 98, b = 0;
//            //double result = 0;
//            //try
//            //{
//            //    result = SafeDivision(a, b);
//            //    Console.WriteLine($"{a} divided by {b} = {result}");


//            //}
//            //catch (DivideByZeroException e)
//            //{
//            //    { Console.WriteLine("Attempted divide by zero."); }
//            //}

//            //-->Activity 2
//            //TestCatch2();




//        }
//        //-->Activity 1
//        //static double SafeDivision(double x, double y)
//        //{
//        //    if (y == 0)
//        //        throw new System.DivideByZeroException();
//        //    return x / y;
//        //}

//        //-->Activity 2
//        //static void TestCatch2()
//        //{
//        //    System.IO.StreamWriter sw = null;
//        //    try
//        //    {
//        //        sw = new System.IO.StreamWriter(@"C:\test\test.txt");
//        //        sw.WriteLine("Hello");
//        //    }
//        //    catch (System.IO.FileNotFoundException ex) {
//        //        Console.WriteLine(ex.ToString());
//        //    }
//        //    catch (System.IO.IOException ex) {
//        //        System.Console.WriteLine(ex.ToString());
//        //    }
//        //    finally
//        //    {
//        //        sw.Close();
//        //    }
//        //    System.Console.WriteLine("Done");
//        //}

//    }
//}
