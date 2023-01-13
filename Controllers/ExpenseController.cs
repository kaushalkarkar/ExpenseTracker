using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Context;

namespace WebApplication7.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        expensetrac6Entities1 dbobj = new expensetrac6Entities1();
        public ActionResult Expense(expense1 obj)
        {

            return View(obj);
        }
       

        [HttpPost]
        public ActionResult AddExpense(expense1 model)
        {
            if (ModelState.IsValid)
            {

                expense1 obj = new expense1();
                
                obj.ExpenseName = model.ExpenseName;
                obj.ExpenseCategoryID = model.ExpenseCategoryID;
                obj.ExpensePrice = model.ExpensePrice;
                obj.ExpenseDate = model.ExpenseDate;
                obj.ExpenseDescription = model.ExpenseDescription;
                if (model.ID == 0)
                {
                    dbobj.expense1.Add(obj);
                    dbobj.SaveChanges();
                 //   dbobj.Entry(obj).State = EntityState.Modified;
                //    dbobj.SaveChanges();
                }
                else
                {
                   //  dbobj.expense1.Add(obj);
                    //dbobj.SaveChanges();
                    dbobj.Entry(obj).State = EntityState.Modified;
                    dbobj.SaveChanges();
                }

            }
            ModelState.Clear();

            return RedirectToAction("ExpenseList");
        }

        public ActionResult ExpenseList()
        {
            var res = dbobj.expense1.ToList();

            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbobj.expense1.Where(x => x.ID == id).First();
            dbobj.expense1.Remove(res);
            dbobj.SaveChanges();

            var list = dbobj.expense1.ToList();
            return View("ExpenseList", list);
        }

    }
}
//----------------------------------//
