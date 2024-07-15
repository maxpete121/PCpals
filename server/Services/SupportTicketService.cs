namespace PCpals.Services;

public class SupportTicketService{
    private readonly SupportTicketRepository repo;

    public SupportTicketService(SupportTicketRepository repo){
        this.repo = repo;
    }

    internal SupportTickets CreateSupportTickets(SupportTickets ticketData){
        SupportTickets supportTickets = repo.CreateSupportTickets(ticketData);
        return supportTickets;
    }

    internal List<SupportTickets> GetSupportTickets(){
        List<SupportTickets> supportTickets = repo.GetSupportTickets();
        return supportTickets;
    }
}