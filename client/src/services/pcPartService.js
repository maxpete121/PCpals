import { AppState } from "../AppState"
import { PcPart } from "../models/PcPart"
import { api } from "./AxiosService"
import { pcBuildService } from "./PcBuildService"


class PcPartService{
    async addPcPart(pcPartData){
        let response = await api.post('api/buildParts', pcPartData)
        let newPart = new PcPart(response.data)
        AppState.activeBuildParts.push(newPart)
        let price = await this.PriceMath()
        let average = await this.powerScoreMath(newPart.creatorId)
        let watts = await this.wattageMath()
        let maxWattage = await this.findMaxWattage()
        await pcBuildService.updatePowerScore(newPart.buildId, average, price, watts, maxWattage)
        if(newPart.part.type == 'cpu' && AppState.cpu.length == 0){AppState.cpu.push(newPart)}
        else if(newPart.part.type == 'gpu' && AppState.gpu.length == 0){AppState.gpu.push(newPart)}
        else if(newPart.part.type == 'motherB' && AppState.motherboard.length == 0){AppState.motherboard.push(newPart)}
        else if(newPart.part.type == 'case' && AppState.case.length == 0){AppState.case.push(newPart)}
        else if(newPart.part.type == 'ram' && AppState.ram.length == 0){AppState.ram.push(newPart)}
        else if(newPart.part.type == 'storage' && AppState.ram.length == 0){AppState.storage.push(newPart)}
        else if(newPart.part.type == 'powerS' && AppState.powerSupply.length == 0){AppState.powerSupply.push(newPart)}
    }
    async getBuildParts(buildId){
        let response = await api.get(`api/buildParts/${buildId}`)
        let newParts = await response.data.map(part => new PcPart(part))
        if(newParts.length == 0){
            this.allClear()
        }
        AppState.activeBuildParts = newParts
        for(let i = 0; AppState.activeBuildParts.length > i; i++){
            if(AppState.activeBuildParts[i].part.type == 'cpu' && AppState.cpu.length == 0){
                AppState.cpu.push(newParts[i])
            }else if(AppState.activeBuildParts[i].part.type == 'gpu' && AppState.gpu.length == 0){
                AppState.gpu.push(newParts[i])
            }else if(AppState.activeBuildParts[i].part.type == 'motherB' && AppState.motherboard.length == 0){
                AppState.motherboard.push(newParts[i])
            }else if(AppState.activeBuildParts[i].part.type == 'case' && AppState.case.length == 0){
                AppState.case.push(newParts[i])
            }else if(AppState.activeBuildParts[i].part.type == 'ram' && AppState.ram.length == 0){
                AppState.ram.push(newParts[i])
            }else if(AppState.activeBuildParts[i].part.type == 'storage' && AppState.storage.length == 0){
                AppState.storage.push(newParts[i])
            }else if(AppState.activeBuildParts[i].part.type == 'powerS' && AppState.powerSupply.length == 0){
                AppState.powerSupply.push(newParts[i])
            }
        }
    }
    async deletePcPart(partId){
        let response = await api.delete(`api/buildParts/${partId}`)
        let partIndex = AppState.activeBuildParts.findIndex(part => part.id == partId)
        let foundPart = AppState.activeBuildParts.find(part => part.id == partId)
        AppState.activeBuildParts.splice(partIndex, 1)
        this.PartClear(foundPart)
        return response.data
    }
    async PartClear(part){
        let price = await this.PriceMath()
        let average = await this.powerScoreMath()
        let watts = await this.wattageMath()
        let maxWattage = await this.findMaxWattage()
        pcBuildService.updatePowerScore(part.buildId, average, price, watts, maxWattage)
        if(part.part.type == 'cpu'){AppState.cpu = []}
        else if(part.part.type == 'gpu'){AppState.gpu = []}
        else if(part.part.type == 'motherB'){AppState.motherboard = []}
        else if(part.part.type == 'ram'){AppState.ram = []}
        else if(part.part.type == 'case'){AppState.case = []}
        else if(part.part.type == 'storage'){AppState.storage = []}
        else if(part.part.type == 'powerS'){AppState.powerSupply = []}
    }
    async allClear(){
        // console.log('hm')
        AppState.cpu = []
        AppState.gpu = []
        AppState.motherboard = []
        AppState.ram = []
        AppState.case = []
        AppState.storage = []
        AppState.powerSupply = []
    }
    async powerScoreMath(pcId){
        let totalScore = 0
        for(let i = 0; AppState.activeBuildParts.length > i; i++){
            totalScore += AppState.activeBuildParts[i].part.powerScore
        }
        let partCount = AppState.activeBuildParts.length
        if(partCount > 0){
            let average = totalScore / partCount
            let roundedAverage = Math.round(average)
            return roundedAverage
        }else{return 0}
    }
    async PriceMath(){
        let price = 0
        for(let i = 0; AppState.activeBuildParts.length > i; i++){
            price += AppState.activeBuildParts[i].part.price
        }
        let roundedAverage = Math.round(price * 100) / 100
        return roundedAverage
    }

    async findMaxWattage(){
        let maxWattage = 0
        let activePowerS = await AppState.activeBuildParts.find(part => part.part.type == 'powerS')
        if(activePowerS){
            maxWattage += activePowerS.part.watts
            return maxWattage
        }else{
            return maxWattage
        }
    }

    async wattageMath(){
        let wattage = 0
        for(let i = 0; AppState.activeBuildParts.length > i; i++){
            if(AppState.activeBuildParts[i].part.type !== "powerS"){
                wattage += AppState.activeBuildParts[i].part.watts
            }
        }
        return wattage
    }
}

export const pcPartService = new PcPartService()