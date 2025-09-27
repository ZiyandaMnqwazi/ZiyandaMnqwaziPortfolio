using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ZiyandaMnqwaziPortfolio.Models;
using ZiyandaMnqwaziPortfolio.ProjectRepository;

namespace ZiyandaMnqwaziPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _email;

        public HomeController(ILogger<HomeController> logger,IEmailService email)
        {
            _logger = logger;
            _email = email;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactForm(string name, string email, string message)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message))
            {
                TempData["Error"] = "Please fill out all fields before submitting the form.";
                return RedirectToAction("Index", new { anchor = "contact" });
            }

            try
            {
                string subject = $"Portfolio Contact Form Submission from {name}";
                string body = $@"
            <p><strong>Name:</strong> {name}</p>
            <p><strong>Email:</strong> {email}</p>
            <p><strong>Message:</strong></p>
            <p>{message}</p>
        ";
                //ADD MY EMAIL HERE DONT FORGET
                string toEmail = "zmnqwazi1998@gmail.com"; 
                await _email.sendEmailAsync(toEmail, subject, body);

                TempData["Message"] = "Thank you for contacting me. I’ll respond soon!";
            }
            catch (Exception ex)
            {
                // Log the error (optional)
                TempData["Error"] = "Oops! Something went wrong while sending your message.";
            }

            return RedirectToAction("Index", new { anchor = "contact" });
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
