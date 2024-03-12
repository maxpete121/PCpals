namespace PCpals.Repositories;

public class PcBuildRepository{
    private readonly IDbConnection db;
    public PcBuildRepository(IDbConnection db){
        this.db = db;
    }

    internal PcBuild CreatePcBuild(PcBuild pcBuildData){
        string sql = @"
        INSERT INTO pcBuilds
        (name, creatorId, powerScore, price, rating)
        VALUES
        (@name, @creatorId, @powerScore, @price, @rating);

        SELECT
        pcBuilds.*,
        accounts.*
        FROM pcBuilds
        JOIN accounts ON pcBuilds.creatorId = accounts.id
        WHERE pcBuilds.id = LAST_INSERT_ID()
        ";
        PcBuild pcBuild = db.Query<PcBuild, Account, PcBuild>(sql, (pcBuild, account)=>{
            pcBuild.Creator = account;
            return pcBuild;
        }, pcBuildData).FirstOrDefault();
        return pcBuild;
    }

    internal List<PcBuild> GetPersonalBuilds(string userId){
        string sql = @"
        SELECT
        pcBuilds.*,
        accounts.*
        FROM pcBuilds
        JOIN accounts ON pcBuilds.creatorId = accounts.id
        WHERE pcBuilds.creatorId = @userId
        ";
        List<PcBuild> pcBuilds = db.Query<PcBuild, Account, PcBuild>(sql,(pcBuild, account)=>{
            pcBuild.Creator = account;
            return pcBuild;
        }, new{userId}).ToList();
        return pcBuilds;
    }

    internal PcBuild GetPcById(int pcId){
        string sql = @"
        SELECT
        pcBuilds.*,
        accounts.*
        FROM pcBuilds
        JOIN accounts ON pcBuilds.creatorId = accounts.id
        WHERE pcBuilds.id = @pcId
        ";
        PcBuild pcBuild = db.Query<PcBuild, Account, PcBuild>(sql, (pcBuild, account)=>{
            pcBuild.Creator = account;
            return pcBuild;
        }, new{pcId}).FirstOrDefault();
        return pcBuild;

    }

    internal void DeletePcBuild(int pcBuildId){
        string sql = @"
        DELETE FROM pcBuilds
        WHERE id = @pcBuildId
        ";
        db.Execute(sql, new{pcBuildId});
    }

    internal PcBuild UpdateBuildParts(PcBuild buildData){
        string sql = @"
        UPDATE pcBuilds SET
        pcCase = @pcCase,
        casePicture = @casePicture,
        pcCpu = @pcCpu,
        gpu = @gpu,
        motherBoard = @motherBoard,
        ram = @ram,
        pcStorage = @pcStorage,
        cooler = @cooler,
        powerSupply = @powerSupply
        WHERE id = @id;

        SELECT
        pcBuilds.*,
        accounts.*
        FROM pcBuilds
        JOIN accounts ON pcBuilds.creatorId = accounts.id
        WHERE pcBuilds.id = @id
        ";
        PcBuild pcBuild = db.Query<PcBuild, Account, PcBuild>(sql, (pcBuild, account)=>{
            pcBuild.Creator = account;
            return pcBuild;
        }, buildData).FirstOrDefault();
        return pcBuild;
    }

    internal PcBuild UpdateShare(PcBuild updateData){
        string sql = @"
        UPDATE pcBuilds SET
        name = @name,
        isPrivate = @isPrivate
        WHERE id = @id;

        SELECT
        pcBuilds.*,
        accounts.*
        FROM pcBuilds
        JOIN accounts ON pcBuilds.creatorId = accounts.id
        WHERE pcBuilds.id = @id
        ";
        PcBuild newPcBuild = db.Query<PcBuild, Account, PcBuild>(sql, (pcBuild, account)=>{
            pcBuild.Creator = account;
            return pcBuild;
        }, updateData).FirstOrDefault();
        return newPcBuild;

    }
}

