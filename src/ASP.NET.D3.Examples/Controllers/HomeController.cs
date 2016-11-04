using System.Collections.Generic;
using System.Linq;
using ASP.NET.D3.Examples.Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            var data = new List<Model.Json.Models.Company>();

            var companies = Mapper.Map<IEnumerable<Model.Json.Models.Company>>(
                _context.Companies
                .Include(x => x.Children)
                );

            data.AddRange(companies);

            foreach (var company in data)
            {
                company.Children = Mapper.Map<IEnumerable<Model.Json.Models.Subsidiary>>(
                    _context.Subsidiaries
                    .Include(x => x.Children)
                    .Where(x => x.Parent.Id == company.Id)
                    );
            }

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            ViewBag.JsonData = JsonConvert.SerializeObject(data, settings);
            return View();
        }

        public IActionResult Update(int id, string name)
        {
            var company = _context.Companies.SingleOrDefault(x => x.Id == id);
            if (company != null)
            {
                company.Name = name;
                _context.Update(company);
                _context.SaveChanges();
            }

            return RedirectToAction("D3Tree");
        }
    }
}