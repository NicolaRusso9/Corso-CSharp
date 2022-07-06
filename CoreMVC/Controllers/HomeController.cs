using CoreMVC.Models;
using CorsoCSharp.EFCore.AutoGenModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext db;                                   // context
        private readonly IHttpClientFactory clientFactory;                      // factory API

        public HomeController(ILogger<HomeController> logger,
            NorthwindContext injectedContext,
            IHttpClientFactory httpClientFactory)                               // utile per le chiamate alla API
        {
            _logger = logger;
            db = injectedContext;                                               // store a reference to context
            clientFactory = httpClientFactory;
        }

        [Authorize]                                                             // Only allow authenticated (non-anonymnous) visitors to access to this action method
        [ResponseCache(Duration = 10, Location =ResponseCacheLocation.Any)]     // Cache della risposta per ottimizzare i tempi di caricamento, cache con durata di 10 secondi
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Caricamento della index in corso");         // show a log information in console

            var l = db.Categories!.ToList();
            HomeIndexViewModel m2 = new((new Random()).Next(1, 1001), db.Categories!.ToList(), db.Products!.ToList());                                    


            HomeIndexViewModel model = new                                      // initialize view model - this view model is immutable (records)
            (
                VisitorCount: (new Random()).Next(1, 1001),
                Categories: await db.Categories.ToListAsync(),
                Products: await db.Products.ToListAsync()
            );


            return View(model);                                                 // pass model data to view
        }

        [Authorize(Roles ="Sales,Marketing")]                                   // Only this two roles can access to this method
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("private")]                                                      // change routing from /home/example to /private
        public IActionResult Example()
        {
            return View();
        }

        public async Task<IActionResult> ProductDetails(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("You must pass a product id in the route, forexample /Home/ProductDetails/21");
            }

            Product? model = await db.Products.SingleOrDefaultAsync(p => p.ProductId == id);

            if(model == null)
            {
                return NotFound($"ProductID {id} not found.");
            }

            return View(model);
        }


        public IActionResult ProductsThatCostMoreThan(decimal? price)
        {
            if (!price.HasValue)
            {
                return BadRequest("You must pass aproductporicein the query string.");
            }

            IEnumerable<Product> model = db.Products
                .Include(p => p.Category)
                .Where(P => P.UnitPrice > price);

            if (!model.Any())
            {
                return NotFound($"No product that cost more than {price:C}");
            }

            ViewData["MaxPrice"] = price.Value.ToString("C");
            return View(model);
        }

        public async Task<IActionResult> Customers(string country)
        {
            string uri;

            if(string.IsNullOrEmpty(country))
            {
                ViewData["Title"] = "All customers worldwide";
                uri = "api/customer/";
            }
            else
            {
                ViewData["Title"] = $"Customers in {country}";
                uri = $"api/customer/?country={country}";
            }

            HttpClient client = clientFactory.CreateClient(
                name:"Northwind.API");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
            HttpResponseMessage response = await client.SendAsync(request);
            IEnumerable<Customer>? model = await response.Content
                .ReadFromJsonAsync<IEnumerable<Customer>>();

            return View(model);
        }


        public IActionResult ModelBilding()
        {
            return View();
        }

        //[HttpPost]
        public IActionResult ModelBinding(Thing thing)
        {
            HomeModelBindingViewModel model = new(
                thing,
                !ModelState.IsValid,
                ModelState.Values.SelectMany(state => state.Errors).Select(error=> error.ErrorMessage));
            return View(model);
        }
    }
}