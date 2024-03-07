import { AppState } from "../AppState"
import { PcBuild } from "../models/PcBuild"
import { api } from "./AxiosService"


class PcBuildService{

    async createBuild(buildData){
        let response = await api.post('api/pcBuilds', buildData)
        let build = new PcBuild(response.data)
        AppState.userBuilds.unshift(build)
        return build
    }
    async getUserBuilds(){
        let response = await api.get('api/pcBuilds/account')
        let userBuilds = response.data.map(build => new PcBuild(build))
        AppState.userBuilds = userBuilds
    }
}

export const pcBuildService = new PcBuildService()