using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShekruLabAssessment.Models;
using System.Diagnostics.Metrics;

namespace ShekruLabAssessment.Controllers
{
    public class CurdController : Controller
    {
        public readonly DatabaseContext _context;
        public CurdController(DatabaseContext context)
        {
            _context = context;
        }

       


        [HttpGet]
        public IActionResult AddEmployees()
        {
            var _designation = _context.designation.ToList();
            ViewData["Designation"] = new SelectList(_designation.OrderBy(s => s.Id), "Id", "DesignationName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployees(Employees emp)
         {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(emp);
                    int x = _context.SaveChanges();
                    if (x > 0)
                    {
                        return RedirectToAction("UserList");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }


        [HttpGet]
        public IActionResult GetGrades(int DesignationId)
        {
            var Grades = _context.designationgrade.Where(x => x.DesignationIdRef == DesignationId).ToList();
            return Json(new SelectList(Grades, "Id", "GradeName"));
        }



        public IActionResult UserList()
        {
            List<Display> obj;
            string sql = "exec  sp_getEmployees";
            obj = _context.display.FromSqlRaw<Display>(sql).ToList();
            return View(obj);



        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var _designation = _context.designation.ToList();

            var _grades = _context.designationgrade.ToList();
            ViewData["Designation"] = new SelectList(_designation.OrderBy(s => s.Id), "Id", "DesignationName");
           
            var data = _context.employees.Find(Id);
            return View(data);
        }


        [HttpPost]
        public IActionResult Edit(int? Id, Employees obj)
        {

            _context.Update(obj);
            _context.SaveChanges();
            return RedirectToAction("UserList");

        }


        public IActionResult Delete(int? Id)
        {
            var data = _context.employees.Find(Id);
            if (data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
                return RedirectToAction("UserList");
            }
            return View(data);
        }


    }
}
