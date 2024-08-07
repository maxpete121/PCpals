
export class PcBuild{
    constructor(data){
        this.id =data.id
        this.name = data.name
        this.creatorId = data.creatorId
        this.powerScore = data.powerScore || 0
        this.price = data.price || 0
        this.rating = data.rating || 0
        this.creator = data.creator
        this.isPrivate = data.isPrivate
        this.watts = data.watts
        this.maxWattage = data.maxWattage || 0
        this.pcCase = data.pcCase
        this.casePicture = data.casePicture
        this.pcCpu = data.pcCpu
        this.gpu = data.gpu
        this.motherBoard = data.motherBoard
        this.ram = data.ram
        this.pcStorage = data.pcStorage
        this.cooler = data.cooler
        this.powerSupply = data.powerSupply
    }
}