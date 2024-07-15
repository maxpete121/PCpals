namespace PCpals.Controllers;

[ApiController]
[Route("api/supportTicket")]

public class SupportTicketController{
    private readonly Auth0Provider auth;
    private readonly SupportTicketService supportTicketService;

    public SupportTicketController(Auth0Provider auth, SupportTicketService supportTicketService){
        this.auth = auth;
        this.supportTicketService = supportTicketService;
    }
}