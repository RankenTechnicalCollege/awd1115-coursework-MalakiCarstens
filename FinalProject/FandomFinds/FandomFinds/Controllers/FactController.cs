using FandomFinds.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;


namespace FandomFinds.Controllers
{
    public class FactController : Controller
    {
        private readonly HttpClient _http;

        public FactController(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var fact = await _http.GetFromJsonAsync<FactViewModel>(
                "https://uselessfacts.jsph.pl/random.json?language=en"
            );

            return View(fact);
        }

    }
}


