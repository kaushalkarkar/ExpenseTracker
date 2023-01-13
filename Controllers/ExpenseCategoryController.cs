using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Context;

namespace WebApplication7.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        expensetrac6Entities1 dbobj2 = new expensetrac6Entities1();
        // GET: ExpenseCategory
        public ActionResult ExpenseCategory()
        {
            return View();
        }


         public ActionResult Addcategory(expensecate model)
         {

          expensecate obj1 = new expensecate();
          obj1.CategoryID = model.CategoryID;
          obj1.ExpenseCategory = model.ExpenseCategory;
            dbobj2.expensecates.Add(obj1);
          dbobj2.SaveChanges();
           return RedirectToAction("CategoryList");
          }
      //  [HttpPost]

      //  public ActionResult ExpenseCategory([Bind(Include = "ExpenseCategory")] expensecate expensecate)
      //  {
      //      if (ModelState.IsValid)
      //      {
      ////          dbobj2.expensecates.Add(expensecate);
      //          dbobj2.SaveChanges();
      //          return RedirectToAction("CategoryList");
      //      }

     //       return View("CategoryList");
     //   }



        public ActionResult CategoryList()
        {
            var res = dbobj2.expensecates.ToList();

            return View(res);
        }

       


        //  [HttpPost, ActionName("Delete")]
        //  [ValidateAntiForgeryToken]
        //  public ActionResult DeleteConfirmed(int id)
        //   {
        //      expensecate expensecate = dbobj2.expensecates.Find(id);
        //       dbobj2.expensecates.Remove(expensecate);
        ///       dbobj2.SaveChanges();
        //       return RedirectToAction("Index");

        //    }

        public ActionResult Delete(int id)
       {
            var res = dbobj2.expensecates.Where(x => x.CategoryID == id).First();
            dbobj2.expensecates.Remove(res);
            dbobj2.SaveChanges();

            var list = dbobj2.expensecates.ToList();
           return View("CategoryList", list);
        }

    }
}

