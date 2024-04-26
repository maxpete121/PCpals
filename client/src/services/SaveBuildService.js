import { AppState } from "../AppState"
import { SaveBuild } from "../models/SaveBuild"
import { api } from "./AxiosService"


class SaveBuildService{
    async createSaveBuild(saveBuildData){
        let response = await api.post('api/saveBuilds', saveBuildData)
        let newSavedBuild = new SaveBuild(response.data)
        AppState.savedUserBuilds.unshift(newSavedBuild)
    }

    async getSaveBuilds(){
        let response = await api.get('api/saveBuilds/userBuilds')
        let savedBuilds = await response.data.map(saved => new SaveBuild(saved))
        AppState.savedUserBuilds = savedBuilds
    }

    async deleteSaveBuild(saveBuildId){
        let response = await api.delete(`api/saveBuilds/${saveBuildId}`)
        let saveIndex = AppState.savedUserBuilds.findIndex(saved => saved.id == saveBuildId)
        AppState.savedUserBuilds.splice(saveIndex, 1)
        return response.data
    }
}

export const saveBuildService = new SaveBuildService()