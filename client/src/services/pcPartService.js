import { AppState } from "../AppState"
import { PcPart } from "../models/PcPart"
import { api } from "./AxiosService"


class PcPartService{
    async addPcPart(pcPartData){
        let response = await api.post('api/buildParts', pcPartData)
        let newPart = new PcPart(response.data)
        AppState.activeBuildParts.push(newPart)

    }

    async getBuildParts(buildId){
        let response = await api.get(`api/buildParts/${buildId}`)
        let newParts = await response.data.map(part => new PcPart(part))
        AppState.activeBuildParts = newParts
    }
}

export const pcPartService = new PcPartService()