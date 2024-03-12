import { AppState } from "../AppState"
import { PcPart } from "../models/PcPart"
import { api } from "./AxiosService"


class PcPartService{
    async addPcPart(pcPartData){
        let response = await api.post('api/buildParts', pcPartData)
        let newPart = new PcPart(response.data)
        AppState.activeBuildParts.push(newPart)
        this.powerScoreMath(newPart.creatorId)

    }
    async getBuildParts(buildId){
        let response = await api.get(`api/buildParts/${buildId}`)
        let newParts = await response.data.map(part => new PcPart(part))
        AppState.activeBuildParts = newParts
    }
    async deletePcPart(partId){
        let response = await api.delete(`api/buildParts/${partId}`)
        let partIndex = AppState.activeBuildParts.findIndex(part => part.id == partId)
        AppState.activeBuildParts.splice(partIndex, 1)
        return response.data
    }
    async powerScoreMath(pcId){
        let totalScore = 0
        for(let i = 0; AppState.activeBuildParts.length > i; i++){
            totalScore += AppState.activeBuildParts[i].part.powerScore
        }
        let partCount = AppState.activeBuildParts.length
        let average = totalScore / partCount
        console.log(average)
    }
}

export const pcPartService = new PcPartService()