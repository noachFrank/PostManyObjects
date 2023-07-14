using ManyPeople.data;
using ManyPepole.web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ManyPepole.web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=PeopleAndCars;Integrated Security=true;";

        public IActionResult Index()
        {
            var manager = new DbManager(_connectionString);
            var vm = new PersonViewModel
            {
                People = manager.GetPeople()
            };

            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }

            return View(vm);
        }

        public IActionResult AddForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(List<Person> people)
        {
            var manager = new DbManager(_connectionString);

            manager.AddMany(people);

            TempData["message"] = "People Have Been Added";

            return Redirect("/");

        }
    }
}