export class SupportTickets{
    constructor(data){
        this.id = data.id
        this.creatorId = data.creatorId
        this.customerName = data.customerName
        this.customerEmail = data.customerEmail
        this.issueSubject = data.issueSubject
        this.issueDescription = data.issueDescription
        this.ticketStatus = data.ticketStatus
        this.creator = data.creator
    }
}
