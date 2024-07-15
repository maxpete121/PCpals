namespace PCpals.Repositories;

public class SupportTicketRepository{
    private readonly IDbConnection db;

    public SupportTicketRepository(IDbConnection db){
        this.db = db;
    }

    internal SupportTickets CreateSupportTickets(SupportTickets ticketData){
        string sql = @"
        INSERT INTO supportTickets
        (creatorId, customerName, customerEmail, issueSubject, issueDescription, ticketStatus)
        VALUES
        (@creatorId, @customerName, @customerEmail, @issueSubject, @issueDescription, @ticketStatus);

        SELECT
        supportTickets.*,
        accounts.*
        FROM supportTickets
        JOIN accounts ON supportTickets.creatorId = accounts.id
        WHERE supportTickets.id = LAST_INSERT_ID()
        ";
        SupportTickets supportTickets = db.Query<SupportTickets, Account, SupportTickets>(sql, (ticket, account)=>{
          ticket.Creator = account;
          return ticket;
          }, ticketData).FirstOrDefault();
        return supportTickets;
    }

    internal List<SupportTickets> GetSupportTickets(){
        string sql = @"
        SELECT
        supportTickets.*,
        accounts.*
        FROM supportTickets
        JOIN accounts ON supportTickets.creatorId = accounts.id
        ";
        List<SupportTickets>  supportTickets = db.Query<SupportTickets, Account, SupportTickets>(sql, (ticket, account)=>{
          ticket.Creator = account;
          return ticket;
          }).ToList();
        return supportTickets;
    }
}