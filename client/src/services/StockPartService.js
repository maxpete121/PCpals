import { StockPart } from "../models/StockPart"
import { api } from "./AxiosService"


class StockPartService{
    async addStockPart(partData){
        let response = await api.post('api/stockParts', partData)
        let newPart = new StockPart(response.data)
        console.log(newPart)
    }
}

export const stockPartService = new StockPartService()