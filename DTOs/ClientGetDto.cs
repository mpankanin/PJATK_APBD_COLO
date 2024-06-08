namespace PJATK_APBD_COLO.DTOs;

public class ClientGetDto
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public ICollection<SubscriptionGetDto> subscriptions { get; set; }
}