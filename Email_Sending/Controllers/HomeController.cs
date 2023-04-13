using Email_Sending.Models;
using Email_Sending.Models.Emailing;
using Email_Sending.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Email_Sending.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailService mailService;

        public HomeController(ILogger<HomeController> logger, IMailService mailService)
        {
            _logger = logger;
            this.mailService = mailService;
        }

        public async Task<IActionResult> Index()
        {
            var mailRequest = new MailRequest
            {
                ToEmail = "anrchas777@gmail.com",
                Body = "Hello World!",
                Subject = "Test e-mail"
            };

            await mailService.SendEmailAsync(mailRequest);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}