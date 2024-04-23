

export class SaveBuild{
    constructor(data){
        this.id = data.id
        this.creatorId = data.creatorId
        this.buildId = data.buildId
        this.build = data.build
    }
}