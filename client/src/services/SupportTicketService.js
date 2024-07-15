import { SupportTickets } from "../models/SupportTickets"
import { api } from "./AxiosService"


class SupportTicketService{
    async createSupportTicket(ticketData){
        let response = await api.post('api/supportTicket', ticketData)
        let newTicket = new SupportTickets(response.data)
    }
}

export const supportTicketService = new SupportTicketService()