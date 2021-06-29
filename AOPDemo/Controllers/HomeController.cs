using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AOPDemo.Models;

namespace AOPDemo.Controllers
{
    public class CustomerObject
    {
        public string Name { get; set; }
        public string SSN { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        private CustomerObject GetCustomerObject(){
            return new CustomerObject{
                Name = "Pookie Williams"
                , SSN = "100-20-3000"
            };
        }

        public IActionResult Privacy()
        {
            var customerObject = GetCustomerObject();
            try
            {
                var intvalue = int.Parse(customerObject.SSN);
            }
            catch (System.Exception)
            {
                throw;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
