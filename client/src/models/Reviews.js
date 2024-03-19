

export class Reviews{
    constructor(data){
        this.id = data.id
        this.creatorId = data.creatorId
        this.buildId = data.buildId
        this.title = data.title
        this.body = data.body
        this.stars = data.stars
        this.creator = data.creator
    }
}
