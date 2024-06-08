namespace PJATK_APBD_COLO.Models;

public class Sale
{
    public int IdSale { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public int IdClient { get; set; }
    public Client ClientNavigator { get; set; }
    
    public int IdSubscription { get; set; }
    public Subscription SubscriptionNavigator { get; set; }
}