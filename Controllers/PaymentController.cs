using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_COLO.Models;
using PJATK_APBD_COLO.Properties.Contexts;

namespace PJATK_APBD_COLO.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly AppDbContext _context;
    public PaymentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddPayment(int idClient, int idSubcription, [FromBody] Payment payment)
    {
        // get client 
        var client = await _context.Clients.FindAsync(idClient);
        if (client == null)
        {
            return BadRequest("Client doesn't exist.");
        }
        
        // get subscription
        var subscription = await _context.Subscriptions.FindAsync(idSubcription);
        if (subscription == null)
        {
            return BadRequest("Subscription doesn't exist.");
        }
        
        // active subscription
        if (subscription.EndTime < DateTime.Now)
        {
            return BadRequest("Subscription expired.");
        }




        Payment created = new Payment
        {
            Date = DateTime.Now,
            IdClient = client.IdClient,
            IdSubscription = idSubcription
        };
        return Ok(created.IdPayment);
    }


}