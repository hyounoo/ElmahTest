using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ElmahTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            int a = 0;
            int b;
            //b = 1 / a;
            HandleExceptions();
            ViewBag.Message = "Your contact page.";
            return View();
        }

        static string[] GetAllFiles(string str)
        {
            // Should throw an AccessDenied exception on Vista. 
            return System.IO.Directory.GetFiles(str, "*.txt", System.IO.SearchOption.AllDirectories);
        }
        static void HandleExceptions()
        {
            // Assume this is a user-entered string. 
            string path = @"C:\";

            // Use this line to throw UnauthorizedAccessException, which we handle.
            Task<string[]> task1 = Task<string[]>.Factory.StartNew(() => GetAllFiles(path));

            // Use this line to throw an exception that is not handled. 
            //  Task task1 = Task.Factory.StartNew(() => { throw new IndexOutOfRangeException(); } ); 
            try
            {
                task1.Wait();
            }
            catch (AggregateException ae)
            {

                throw ae;

            }

            Console.WriteLine("task1 has completed.");
        }

    }
}