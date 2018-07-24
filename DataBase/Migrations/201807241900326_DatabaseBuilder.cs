namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseBuilder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "Country_ID", "dbo.Countries");
            DropForeignKey("dbo.Countries", "Continent_ID", "dbo.Continents");
            DropForeignKey("dbo.Footballers", "Country_ID", "dbo.Countries");
            DropForeignKey("dbo.Footballers", "Position_ID", "dbo.Positions");
            DropForeignKey("dbo.Teams", "City_ID", "dbo.Cities");
            DropForeignKey("dbo.Footballers", "Team_ID", "dbo.Teams");
            DropForeignKey("dbo.Leagues", "Country_ID", "dbo.Countries");
            DropForeignKey("dbo.Teams", "League_ID", "dbo.Leagues");
            DropForeignKey("dbo.Managers", "Country_ID", "dbo.Countries");
            DropForeignKey("dbo.Teams", "ID", "dbo.Managers");
            DropForeignKey("dbo.Stadia", "City_ID", "dbo.Cities");
            DropForeignKey("dbo.Teams", "Stadium_ID", "dbo.Stadia");
            DropForeignKey("dbo.SupporterGroups", "Team_ID", "dbo.Teams");
            DropIndex("dbo.Cities", new[] { "Country_ID" });
            DropIndex("dbo.Countries", new[] { "Continent_ID" });
            DropIndex("dbo.Footballers", new[] { "Country_ID" });
            DropIndex("dbo.Footballers", new[] { "Position_ID" });
            DropIndex("dbo.Footballers", new[] { "Team_ID" });
            DropIndex("dbo.Teams", new[] { "ID" });
            DropIndex("dbo.Teams", new[] { "City_ID" });
            DropIndex("dbo.Teams", new[] { "League_ID" });
            DropIndex("dbo.Teams", new[] { "Stadium_ID" });
            DropIndex("dbo.Leagues", new[] { "Country_ID" });
            DropIndex("dbo.Managers", new[] { "Country_ID" });
            DropIndex("dbo.Stadia", new[] { "City_ID" });
            DropIndex("dbo.SupporterGroups", new[] { "Team_ID" });
            CreateTable(
                "dbo.EngWords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TurWords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TurWordEngWords",
                c => new
                    {
                        TurWord_ID = c.Int(nullable: false),
                        EngWord_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TurWord_ID, t.EngWord_ID })
                .ForeignKey("dbo.TurWords", t => t.TurWord_ID, cascadeDelete: true)
                .ForeignKey("dbo.EngWords", t => t.EngWord_ID, cascadeDelete: true)
                .Index(t => t.TurWord_ID)
                .Index(t => t.EngWord_ID);
            
            DropTable("dbo.Cities");
            DropTable("dbo.Countries");
            DropTable("dbo.Continents");
            DropTable("dbo.Footballers");
            DropTable("dbo.Positions");
            DropTable("dbo.Teams");
            DropTable("dbo.Leagues");
            DropTable("dbo.Managers");
            DropTable("dbo.Stadia");
            DropTable("dbo.SupporterGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SupporterGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Team_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stadia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Country_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        City_ID = c.Int(),
                        League_ID = c.Int(),
                        Stadium_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Footballers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Country_ID = c.Int(),
                        Position_ID = c.Int(),
                        Team_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Continents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Continent_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.TurWordEngWords", "EngWord_ID", "dbo.EngWords");
            DropForeignKey("dbo.TurWordEngWords", "TurWord_ID", "dbo.TurWords");
            DropIndex("dbo.TurWordEngWords", new[] { "EngWord_ID" });
            DropIndex("dbo.TurWordEngWords", new[] { "TurWord_ID" });
            DropTable("dbo.TurWordEngWords");
            DropTable("dbo.TurWords");
            DropTable("dbo.EngWords");
            CreateIndex("dbo.SupporterGroups", "Team_ID");
            CreateIndex("dbo.Stadia", "City_ID");
            CreateIndex("dbo.Managers", "Country_ID");
            CreateIndex("dbo.Leagues", "Country_ID");
            CreateIndex("dbo.Teams", "Stadium_ID");
            CreateIndex("dbo.Teams", "League_ID");
            CreateIndex("dbo.Teams", "City_ID");
            CreateIndex("dbo.Teams", "ID");
            CreateIndex("dbo.Footballers", "Team_ID");
            CreateIndex("dbo.Footballers", "Position_ID");
            CreateIndex("dbo.Footballers", "Country_ID");
            CreateIndex("dbo.Countries", "Continent_ID");
            CreateIndex("dbo.Cities", "Country_ID");
            AddForeignKey("dbo.SupporterGroups", "Team_ID", "dbo.Teams", "ID");
            AddForeignKey("dbo.Teams", "Stadium_ID", "dbo.Stadia", "ID");
            AddForeignKey("dbo.Stadia", "City_ID", "dbo.Cities", "ID");
            AddForeignKey("dbo.Teams", "ID", "dbo.Managers", "ID");
            AddForeignKey("dbo.Managers", "Country_ID", "dbo.Countries", "ID");
            AddForeignKey("dbo.Teams", "League_ID", "dbo.Leagues", "ID");
            AddForeignKey("dbo.Leagues", "Country_ID", "dbo.Countries", "ID");
            AddForeignKey("dbo.Footballers", "Team_ID", "dbo.Teams", "ID");
            AddForeignKey("dbo.Teams", "City_ID", "dbo.Cities", "ID");
            AddForeignKey("dbo.Footballers", "Position_ID", "dbo.Positions", "ID");
            AddForeignKey("dbo.Footballers", "Country_ID", "dbo.Countries", "ID");
            AddForeignKey("dbo.Countries", "Continent_ID", "dbo.Continents", "ID");
            AddForeignKey("dbo.Cities", "Country_ID", "dbo.Countries", "ID");
        }
    }
}
