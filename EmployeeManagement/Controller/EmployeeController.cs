using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index(string? nameFilter)
        {
            var employees = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(nameFilter))
            {
                employees = employees.Where(e => e.Name != null && e.Name.Contains(nameFilter));
            }

            var sortedEmployees = await employees
                .OrderBy(e => e.BornDate)
                .ToListAsync();

            return View(sortedEmployees);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RFC,Name,LastName,BornDate,Status")] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            if (await _context.Employees.AnyAsync(e => e.RFC == employee.RFC))
            {
                ModelState.AddModelError(nameof(employee.RFC), "An employee with this RFC already exists.");
                return View(employee);
            }

            _context.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
