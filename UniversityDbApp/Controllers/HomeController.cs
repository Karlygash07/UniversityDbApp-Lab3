using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityDbApp.Data;
using UniversityDbApp.Models;

namespace UniversityDbApp.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Department> departments = await _context.Departments
            .Include(department => department.Teachers)
            .AsNoTracking()
            .ToListAsync();

        return View(departments);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await LoadDepartmentsAsync();
        return View(new Teacher());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,DepartmentId")] Teacher teacher)
    {
        bool departmentExists = await _context.Departments
            .AnyAsync(department => department.Id == teacher.DepartmentId);

        if (!departmentExists)
        {
            ModelState.AddModelError(nameof(teacher.DepartmentId), "Кафедраны таңдаңыз.");
        }

        if (!ModelState.IsValid)
        {
            await LoadDepartmentsAsync();
            return View(teacher);
        }

        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private async Task LoadDepartmentsAsync()
    {
        List<Department> departments = await _context.Departments
            .AsNoTracking()
            .OrderBy(department => department.Name)
            .ToListAsync();

        ViewBag.Departments = new SelectList(departments, nameof(Department.Id), nameof(Department.Name));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
