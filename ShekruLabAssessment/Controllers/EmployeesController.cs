using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShekruLabAssessment.Models;

namespace ShekruLabAssessment.Controllers
{

    public class EmployeesController : Controller
    {
        public readonly DatabaseContext _context;
        public EmployeesController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult AddEmployees()
        {
            var countries = _context.designation.ToList();
            return View(countries);
        }
    }
}
