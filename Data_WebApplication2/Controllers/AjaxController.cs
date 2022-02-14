using Microsoft.AspNetCore.Mvc;
using Data_WebApplication2.Models;
using Data_WebApplication2.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Data_WebApplication2.Controllers
{
    public class AjaxController : Controller
    {
        private static List<Person> People = new List<Person>()
            {
                new Person {Id = 1, Name = "Elin", PhoneNumber = "12345678", City = "Gothenburg" },
                new Person {Id = 2, Name = "Poulin", PhoneNumber = "87654321", City = "Stockholm" },
                new Person {Id = 3, Name = "john", PhoneNumber = "12348765", City = "Malmo" },
                new Person {Id = 4, Name = "sandra", PhoneNumber = "87345621", City = "jönkoping" },
                new Person {Id = 5, Name = "olof", PhoneNumber = "654321765", City = "Karlstad" },
                new Person {Id = 6, Name = "Elinora", PhoneNumber = "12345678", City = "trollhättan" },
                new Person {Id = 7, Name = "Poulinora", PhoneNumber = "87654321", City = "uddevalla" },
                new Person {Id = 8, Name = "johnsena", PhoneNumber = "12348765", City = "stenugsund" },
                new Person {Id = 9, Name = "sandranea", PhoneNumber = "87345621", City = "stromstad" },
                new Person {Id = 10, Name = "olofson", PhoneNumber = "654321765", City = "oslo" }

            };
        public IActionResult Index()
        {

            PersonDetailViewModel viewModels = new PersonDetailViewModel();


            foreach (var item in People)
            {
                viewModels.PeopleViewModel.Add(new PeopleViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    PhoneNumber = item.PhoneNumber,
                    City = item.City,
                });
            }

            return View(viewModels);
        }
        public IActionResult GetPeople()
        {
            PersonDetailViewModel viewModels = new PersonDetailViewModel();


            foreach (var item in People)
            {
                viewModels.PeopleViewModel.Add(new PeopleViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    PhoneNumber = item.PhoneNumber,
                    City = item.City,
                });
            }
            return PartialView("_AjaxPersonViewPartial", viewModels);
        }

        public IActionResult GetDetails(int id)
        {
            if (id > 1)
            {
                PersonDetailViewModel viewModels = new PersonDetailViewModel();

                var filteredData = People.Where(x => x.Id == id).ToList();

                foreach (var item in filteredData)
                {
                    viewModels.PeopleViewModel.Add(new PeopleViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        PhoneNumber = item.PhoneNumber,
                        City = item.City,
                    });
                }

                return PartialView("_AjaxPersonViewPartial", viewModels);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult GetDelete(int id)
        {
            var result = false;
            if (id > 1)
            {
                PersonDetailViewModel viewModels = new PersonDetailViewModel();
                var record = People.Where(x => x.Id == id).FirstOrDefault();
                if (record != null)
                {
                    People.Remove(record);
                    result = true;
                }

            }

            return Json(result);
        }
    }
}
