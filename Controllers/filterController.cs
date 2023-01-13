using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Context;


namespace WebApplication7.Controllers
{
    public class filterController : Controller
    {
            expensetrac6Entities1 dbobj = new expensetrac6Entities1();
            public ActionResult Filter(string searching)
            {
                var students = from s in dbobj.expense1
                               select s;
                if (!string.IsNullOrEmpty(searching))
                {
                    students = students.Where(x => x.ExpenseName.Contains(searching));
                }

               return View(students.ToList());
           }





        //using date
        //expensetrac6Entities1 dbobj = new expensetrac6Entities1();

       // public ActionResult filter()
       // {
       //    return View();
      //  }

      //  public ActionResult  filter(DateTime start, DateTime end)
      //  {    
      //      var result = from x in dbobj.expense1 where x.ExpenseDate >= start && x.ExpenseDate <= end select x;

      //      return View(result.ToList());
      //  }
    }
}


   
    
