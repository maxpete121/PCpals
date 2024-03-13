
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
        console.log(userBuilds)
    }

    async getPcById(pcId){
        let response = await api.get(`api/pcBuilds/${pcId}`)
        AppState.activeBuildToEdit = new PcBuild(response.data)
    }

    async deleteBuild(buildId){
        let response = await api.delete(`api/pcBuilds/${buildId}`)
        let buildIndex = AppState.userBuilds.findIndex(build => build.id == buildId)
        AppState.userBuilds.splice(buildIndex, 1)
        return response.data
    }

    async updateBuildParts(pcId, stockPartData){
        let buildData = {}
        if(stockPartData.type == 'case'){
            buildData.pcCase = stockPartData.name
            buildData.casePicture = stockPartData.productImage
        }else if(stockPartData.type == 'cpu'){ buildData.pcCpu = stockPartData.name}
        else if(stockPartData.type == 'gpu'){ buildData.gpu = stockPartData.name}
        else if(stockPartData.type == 'motherB'){buildData.motherBoard = stockPartData.name}
        else if(stockPartData.type == 'ram'){buildData.ram = stockPartData.name}
        else if(stockPartData.type == 'storage'){buildData.pcStorage = stockPartData.name}
        else if(stockPartData.type == 'powerSupply'){buildData.powerSupply = stockPartData.name}
        else if(stockPartData.type == 'cooler'){buildData.cooler = stockPartData.name}
        let response = await api.put(`api/pcBuilds/${pcId}/parts`, buildData)
        let updatedBuild = new PcBuild(response.data)
        AppState.activeBuildToEdit = updatedBuild
    }

    async updateShare(pcId){
        let activeBuild = AppState.userBuilds.find(build => build.id == pcId)
        if(activeBuild.isPrivate == true){
            activeBuild.isPrivate = false
        }else if(activeBuild.isPrivate == false){
            activeBuild.isPrivate = true
        }
        let updateData = {isPrivate: activeBuild.isPrivate}
        let response = await api.put(`api/pcBuilds/${pcId}/share/update`, updateData)
        let newBuildData = new PcBuild(response.data)
        AppState.userBuilds = AppState.userBuilds.map(build => build.id !== pcId ? build : newBuildData)
    }

    async updatePowerScore(pcId, average, price){
        let buildData = {powerScore: average, price: price}
        console.log(buildData)
        let response = await api.put(`api/pcBuilds/${pcId}/powerScore`, buildData)
        let newBuild = new PcBuild(response.data)
        AppState.activeBuildToEdit = newBuild
    }


}

export const pcBuildService = new PcBuildService()