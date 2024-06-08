using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PJATK_APBD_COLO.DTOs;
using PJATK_APBD_COLO.Models;
using PJATK_APBD_COLO.Properties.Contexts;

namespace PJATK_APBD_COLO.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly AppDbContext _context;
    public ClientController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClientData(int id)
    {
        // get client by id
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound("Client not found.");
        }

        List<Sale> sales = await _context.Sales.Where(sales => sales.IdClient == id)
            .ToListAsync();

        List<SubscriptionGetDto> subscriptionGetDtos = new List<SubscriptionGetDto>();
        foreach (var sale in sales)
        {
            var total = sale.SubscriptionNavigator.RenewalPeriod * sale.SubscriptionNavigator.Price;
            subscriptionGetDtos.Add(new SubscriptionGetDto
            {
                IdSubscription = sale.SubscriptionNavigator.IdSubscription,
                Name = sale.SubscriptionNavigator.Name,
                TotalPaidAmount = total
            }); 
        }

        ClientGetDto clientGetDto = new ClientGetDto
        {
            firstName = client.FirstName,
            lastName = client.LastName,
            email = client.Email,
            phone = client.Phone,
            subscriptions = subscriptionGetDtos
        };
        
        return Ok(clientGetDto);
    }
    
    
    
}