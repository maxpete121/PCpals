
export class PcBuild{
    constructor(data){
        this.name = data.name
        this.creatorId = data.creatorId
        this.powerScore = data.powerScore || 0
        this.price = data.price || 0
        this.rating = data.rating || 'None'
        this.creator = data.creator
    }
}