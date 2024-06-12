
import { AppState } from "../AppState"
import { PcBuild } from "../models/PcBuild"
import Pop from "../utils/Pop"
import { api } from "./AxiosService"
import { pcPartService } from "./pcPartService"


class PcBuildService{

    async createBuild(buildData){
        buildData.isPrivate = true
        let response = await api.post('api/pcBuilds', buildData)
        let build = new PcBuild(response.data)
        AppState.userBuilds.unshift(build)
        return build
    }
    async getUserBuilds(){
        let response = await api.get('api/pcBuilds/account')
        let userBuilds = response.data.map(build => new PcBuild(build))
        AppState.userBuilds = userBuilds
        // console.log(userBuilds)
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
        else if(stockPartData.type == 'powerS'){
            buildData.powerSupply = stockPartData.name
        }
        else if(stockPartData.type == 'cooler'){buildData.cooler = stockPartData.name}
        let response = await api.put(`api/pcBuilds/${pcId}/parts`, buildData)
        let updatedBuild = new PcBuild(response.data)
        AppState.activeBuildToEdit = updatedBuild
    }

    async updateShare(pcId){
        let activeBuild = AppState.userBuilds.find(build => build.id == pcId)
        let hasAllParts = await this.checkForParts(pcId)
        if(activeBuild.isPrivate == true && hasAllParts == true){
            activeBuild.isPrivate = false
            let updateData = {isPrivate: activeBuild.isPrivate}
            let response = await api.put(`api/pcBuilds/${pcId}/share/update`, updateData)
            let newBuildData = new PcBuild(response.data)
            AppState.userBuilds = await AppState.userBuilds.map(build => build.id !== pcId ? build : newBuildData)
            Pop.success('PC was shared for others to see!')
        }else if(activeBuild.isPrivate == true && hasAllParts == false){
            Pop.error('PC does not have all required parts.')
        }
        else if(activeBuild.isPrivate == false){
            activeBuild.isPrivate = true
            let updateData = {isPrivate: activeBuild.isPrivate}
            let response = await api.put(`api/pcBuilds/${pcId}/share/update`, updateData)
            let newBuildData = new PcBuild(response.data)
            AppState.userBuilds = AppState.userBuilds.map(build => build.id !== pcId ? build : newBuildData)
            Pop.success('PC was made private.')
        }
    }

    async updatePowerScore(pcId, average, price, wattage, maxWatts){
        let buildData = {powerScore: average, price: price, watts: wattage, maxWattage: maxWatts}
        // console.log(buildData)
        let response = await api.put(`api/pcBuilds/${pcId}/powerScore`, buildData)
        let newBuild = new PcBuild(response.data)
        AppState.activeBuildToEdit = newBuild
    }

    async updateRating(ratingData, buildId){
        let buildData = {rating: ratingData}
        // console.log(buildData, buildId)
        let response = await api.put(`api/pcBuilds/${buildId}/rating`, buildData)
        let updatedBuild = new PcBuild(response.data)
        AppState.activeBuildForReview = updatedBuild
        AppState.recentBuilds = AppState.recentBuilds.map(pc => pc.id !== buildId ? pc : updatedBuild)
    }

    async getSharedBuilds(){
        let response = await api.get('api/pcBuilds/shared')
        let allBuilds = await response.data.map(build => new PcBuild(build))
        AppState.recentBuilds = allBuilds
    }
    
    async checkForParts(buildId){
        let hasParts = false
        await pcPartService.getBuildParts(buildId)
        await pcPartService.allClear()
        let partCount = AppState.activeBuildParts.length
        if(partCount >= 7){
            hasParts = true
        }
        return hasParts
    }

}

export const pcBuildService = new PcBuildService()


