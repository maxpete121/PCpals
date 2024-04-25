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
}

export const saveBuildService = new SaveBuildService()