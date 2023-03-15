using Microsoft.AspNetCore.Mvc;
using Registration_Form.Models;

namespace Registration_Form.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index(Person person)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            return View(person);
        }
    }
}
