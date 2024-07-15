namespace PCpals.Repositories;

public class SupportTicketRepository{
    private readonly IDbConnection db;

    public SupportTicketRepository(IDbConnection db){
        this.db = db;
    }
}