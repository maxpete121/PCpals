namespace PCpals.Services;

public class SupportTicketService{
    private readonly SupportTicketRepository repo;

    public SupportTicketService(SupportTicketRepository repo){
        this.repo = repo;
    }
}