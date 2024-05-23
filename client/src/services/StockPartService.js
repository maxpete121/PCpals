import { AppState } from "../AppState"
import { StockPart } from "../models/StockPart"
import { api } from "./AxiosService"


class StockPartService{
    async addStockPart(partData){
        let response = await api.post('api/stockParts', partData)
        let newPart = new StockPart(response.data)
        console.log(newPart)
    }

    async getStockParts(type){
        let response = await api.get(`api/stockParts/${type}`)
        let parts = await response.data.map(part => new StockPart(part))
        AppState.activeStockParts = parts
    }

    async getStockPartsIntel(type){
        let response = await api.get(`api/stockParts/${type}/intel`)
        let parts = await response.data.map(part => new StockPart(part))
        AppState.activeStockParts = parts
    }

    async getStockPartsAMD(type){
        let response = await api.get(`api/stockParts/${type}/amd`)
        let parts = await response.data.map(part => new StockPart(part))
        AppState.activeStockParts = parts
    }
}

export const stockPartService = new StockPartService()