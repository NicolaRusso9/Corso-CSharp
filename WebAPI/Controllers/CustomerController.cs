

using CorsoCSharp.EFCore.AutoGenModels;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]     //base address = api/customer
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository repo;


        // Constructor injects repository registrered in program
        public CustomerController(ICustomerRepository repo)
        {
            this.repo = repo;
        }

        //GET: api/customer
        //GET: api/customer/?country=[country]
        // this will always return a list of custoimers (but it might be empty)
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]       // Indica il tipo di risposta che si può ottenere, verrà automaticamente aggiunto anche alla documentazione generata
        public async Task<IEnumerable<Customer>> GetCustomers(string? country)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                return await repo.RetriveAllAsync();
            }
            else
            {
                return (await repo.RetriveAllAsync()).Where(
                    customer => customer.Country == country);
            }
        }

        // GET: api/customer/[id]
        [HttpGet("{id}", Name = nameof(GetCustomer))]                           // named route
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomer(string id)
        {
            Customer? c = await repo.RetriveAsync(id);
            if (c == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(c);               // 200 OK with customer in body
            }
        }

        //POST: api/customer
        //BODY: Customer(JSON,XML)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Customer c)
        {
            if (c == null) { return BadRequest(); }

            Customer? addedCustomer = await repo.CreateAsync(c);

            if (addedCustomer == null)
            {
                return BadRequest("Repository failed to create customer.");
            }
            else
            {
                return CreatedAtRoute(      // 201 Created
                    routeName: nameof(GetCustomer),
                    routeValues: new { id = addedCustomer.CustomerId.ToLower() },
                    value: addedCustomer);
            }
        }

        //PUT: api/customer/[id]
        //BODY: Customer(JSON,XML)
        [HttpPut("{id}")]
        [ProducesResponseType(204)]         // 204 No Content
        [ProducesResponseType(400)]         // 400 Bad request
        [ProducesResponseType(404)]         // 404 Not Found
        public async Task<IActionResult> Update(string id, [FromBody] Customer c)
        {
            id=id.ToUpper();
            c.CustomerId = c.CustomerId.ToUpper();

            if(c == null || c.CustomerId != id)
            {
                return BadRequest();        // 400 Bad request
            }

            Customer? existing  = await repo.RetriveAsync(id);
            if(existing == null)
            {
                return NotFound();          // 404 Not Found
            }

            await repo.UpdateAsync(id, c);
            return new NoContentResult();   // 204 No Content
        }

        //DELETE: api/customer/[id]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id =="bad")
            {
                // in caso di errore un'implementazione di default di questa classe viene restituita nella risposta. In questo caso vogliamo controllare cosa viene mostrato.
                ProblemDetails problemDetails = new()     
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://localhost:5001/customer/failed-to-delete",
                    Title = $"Customer {id} found but failed to delete.",
                    Detail = "More details like Company, Country and so on.",
                    Instance = HttpContext.Request.Path
                };
                return BadRequest(problemDetails);
            }


            Customer? existing = await repo.RetriveAsync(id);
            if(existing == null)
            {
                return NotFound();
            }

            bool? deleted = await repo.DeleteAsync(id);
            if(deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();
            }
            else
            {
                return BadRequest($"Customer {id} was found but failed to delete.");
            }

        }
    }
}
