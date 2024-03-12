import { AppState } from "../AppState"
import { PcPart } from "../models/PcPart"
import { api } from "./AxiosService"
import { pcBuildService } from "./PcBuildService"


class PcPartService{
    async addPcPart(pcPartData){
        let response = await api.post('api/buildParts', pcPartData)
        let newPart = new PcPart(response.data)
        AppState.activeBuildParts.push(newPart)
        let average = await this.powerScoreMath(newPart.creatorId)
        pcBuildService.updatePowerScore(newPart.buildId, average)
        if(newPart.part.type == 'cpu' && AppState.cpu.length == 0){AppState.cpu.push(newPart)}
        else if(newPart.part.type == 'gpu' && AppState.gpu.length == 0){AppState.gpu.push(newPart)}
        else if(newPart.part.type == 'motherB' && AppState.motherboard.length == 0){AppState.motherboard.push(newPart)}
        else if(newPart.part.type == 'case' && AppState.case.length == 0){AppState.case.push(newPart)}
        else if(newPart.part.type == 'ram' && AppState.ram.length == 0){AppState.ram.push(newPart)}
    }
    async getBuildParts(buildId){
        let response = await api.get(`api/buildParts/${buildId}`)
        let newParts = await response.data.map(part => new PcPart(part))
        AppState.activeBuildParts = newParts
        for(let i = 0; AppState.activeBuildParts.length > i; i++){
            console.log(i)
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
        if(part.part.type == 'cpu'){AppState.cpu = []}
        else if(part.part.type == 'gpu'){AppState.gpu = []}
        else if(part.part.type == 'motherB'){AppState.motherboard = []}
        else if(part.part.type == 'ram'){AppState.ram = []}
        else if(part.part.type == 'case'){AppState.case = []}
    }
    async powerScoreMath(pcId){
        let totalScore = 0
        for(let i = 0; AppState.activeBuildParts.length > i; i++){
            totalScore += AppState.activeBuildParts[i].part.powerScore
        }
        let partCount = AppState.activeBuildParts.length
        let average = totalScore / partCount
        let roundedAverage = Math.round(average)
        return roundedAverage
    }
}

export const pcPartService = new PcPartService()