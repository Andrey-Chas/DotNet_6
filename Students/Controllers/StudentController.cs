using Microsoft.AspNetCore.Mvc;
using Students.Models;

namespace Students.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration configuration;

        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        static IList<StudentViewModel> studentList = new List<StudentViewModel>()
        {
            new StudentViewModel() { FirstName = "Bill", LastName = "Brown", StudentNumber = "SN1" },
            new StudentViewModel() { FirstName = "Jack", LastName = "Jones", StudentNumber = "SN2" },
            new StudentViewModel() { FirstName = "Sally", LastName = "Noolan", StudentNumber = "SN3" },
            new StudentViewModel() { FirstName = "Jude", LastName = "Toll", StudentNumber = "SN4" },
            new StudentViewModel() { FirstName = "Tom", LastName = "Hoolan", StudentNumber = "SN5" }
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(studentList);
        }
    }
}
