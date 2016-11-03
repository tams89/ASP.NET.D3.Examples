using System.Collections.Generic;
using System.Linq;
using ASP.NET.D3.Examples.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ASP.NET.D3.Examples.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ResetData()
        {
            _context.Companies.RemoveRange(_context.Companies);
            _context.Departments.RemoveRange(_context.Departments);
            _context.Subsidiaries.RemoveRange(_context.Subsidiaries);
            _context.SaveChanges();

            _context.Companies.AddRange(
                new Models.Company
                {
                    Name = "Company A",
                    Children = new List<Models.Subsidiary>
                    {
                            new Models.Subsidiary
                            {
                                Name = "Subsidiary A",
                                Children = new List<Models.Department>
                                {
                                    new Models.Department
                                    {
                                        Name = "Department A",
                                    },
                                    new Models.Department
                                    {
                                        Name = "Department B",
                                    },
                                }
                            }
                    }
                },
                new Models.Company
                {
                    Name = "Company B",
                    Children = new List<Models.Subsidiary>
                    {
                            new Models.Subsidiary
                            {
                                Name = "Subsidiary A",
                                Children = new List<Models.Department>
                                {
                                    new Models.Department
                                    {
                                        Name = "Department A",
                                    },
                                    new Models.Department
                                    {
                                        Name = "Department B",
                                    },
                                }
                            }
                    }
                }
            );

            _context.SaveChanges();

            return RedirectToAction("D3Tree");
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult D3Tree()
        {
            var data = new List<Models.Company>();
            data.AddRange(_context.Companies);

            foreach (var company in data)
            {
                company.Children = _context.Subsidiaries
                    .Include(x => x.Parent)
                    .Where(x => x.Parent == company).ToList();

                foreach (var subsidiary in company.Children)
                {
                    subsidiary.Parent = company;
                    subsidiary.Children = _context.Departments
                        .Include(x => x.Parent)
                        .Where(x => x.Parent == subsidiary).ToList();

                    foreach (var department in subsidiary.Children)
                        department.Parent = subsidiary;
                }

            }

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };

            ViewBag.JsonData = JsonConvert.SerializeObject(data, settings);
            return View();
        }
    }
}