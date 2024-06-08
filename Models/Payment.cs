namespace PJATK_APBD_COLO.Models;

public class Payment
{
    public int IdPayment { get; set; }
    public DateTime Date { get; set; }
    
    public int IdClient { get; set; }
    public Client ClientNavigator { get; set; }
    
    public int IdSubscription { get; set; }
    public Subscription SubscriptionNavigator;
}