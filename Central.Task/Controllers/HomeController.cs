using Central.Task.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;



namespace Central.Task.Controllers
{
    public class HomeController : Controller
    {


        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(ApplicationDbContext applicationDbContext, IHttpClientFactory httpClientFactory)
        {

            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _httpClientFactory = httpClientFactory;

        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index([Bind("WebinarTopic,FirstName,LastName,Email,Company,Title,Questions")] Registrations registration)
        {



            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState)
                {

                    if (error.Value.Errors.Count > 0)
                    {
                        foreach (var errors in error.Value.Errors)
                        {
                            Console.WriteLine($" - {errors.ErrorMessage}");
                        }
                        //Console.WriteLine($"{error.Key} validation failed: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}");
                    }
                }
                return BadRequest(ModelState);
            }

            try
            {
                var client = _httpClientFactory.CreateClient("APIClient");
                var response = await client.PostAsJsonAsync("api/registrations", registration);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = $"Thank you, {registration.FirstName}, your registration has been successful!";
                    return RedirectToAction("Success");
                }

            }

            catch
            {

                ModelState.AddModelError("", "An error occurred while communicating with the API.");
                //return View(registration);
                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");



        }

        //==============
        public IActionResult Success()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View();
        }


    }
}
