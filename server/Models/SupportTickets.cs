namespace PCpals.Models;

public class SupportTickets : RepoItem<int>{
    public string CreatorId {get; set;}
    public string CustomerName {get; set;}
    public string CustomerEmail {get; set;}
    public string IssueSubject {get; set;}
    public string IssueDescription {get; set;}
}
