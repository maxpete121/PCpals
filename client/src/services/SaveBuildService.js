import { AppState } from "../AppState"
import { SaveBuild } from "../models/SaveBuild"
import { api } from "./AxiosService"


class SaveBuildService{
    async createSaveBuild(saveBuildData){
        let response = await api.post('api/saveBuilds', saveBuildData)
        let newSavedBuild = new SaveBuild(response.data)
        AppState.savedUserBuilds.unshift(newSavedBuild)
    }

    async getSaveBuilds(){}
}

export const saveBuildService = new SaveBuildService()