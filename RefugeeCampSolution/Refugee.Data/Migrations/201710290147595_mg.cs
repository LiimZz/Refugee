namespace Refugee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Camps",
                c => new
                    {
                        CampID = c.Int(nullable: false, identity: true),
                        Localisation_Country = c.String(nullable: false),
                        Localisation_Street = c.String(nullable: false),
                        Localisation_ZipCode = c.String(nullable: false, maxLength: 4),
                        Localisation_Longitude = c.String(),
                        Localisation_Latitude = c.String(),
                        CampName = c.String(),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CampID);
            
            CreateTable(
                "dbo.Tents",
                c => new
                    {
                        TentID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Taille = c.Int(nullable: false),
                        Img = c.String(),
                        CampID = c.Int(),
                    })
                .PrimaryKey(t => t.TentID)
                .ForeignKey("dbo.Camps", t => t.CampID)
                .Index(t => t.CampID);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Qtt = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        Img = c.String(),
                        TentID = c.Int(),
                    })
                .PrimaryKey(t => t.EquipID)
                .ForeignKey("dbo.Tents", t => t.TentID)
                .Index(t => t.TentID);
            
            CreateTable(
                "dbo.Refugs",
                c => new
                    {
                        RefugID = c.Int(nullable: false, identity: true),
                        AdminID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age_Day = c.Int(nullable: false),
                        Age_Month = c.Int(nullable: false),
                        Age_Year = c.Int(nullable: false),
                        Nationality = c.String(nullable: false),
                        Staus = c.Int(nullable: false),
                        TentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RefugID)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminID)
                .ForeignKey("dbo.Tents", t => t.TentID)
                .Index(t => t.AdminID)
                .Index(t => t.TentID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserRole = c.String(),
                        Password = c.String(maxLength: 100),
                        ConfirmPassword = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        DateComment = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PostID = c.Int(nullable: false),
                        MemberID = c.String(nullable: false, maxLength: 128),
                        Content = c.String(),
                    })
                .PrimaryKey(t => new { t.DateComment, t.PostID, t.MemberID })
                .ForeignKey("dbo.AspNetUsers", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 128),
                        DatePub = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        image = c.String(),
                        Content = c.String(),
                        Like = c.Int(nullable: false),
                        Dislike = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.AspNetUsers", t => t.MemberID)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.PostClaims",
                c => new
                    {
                        MemberID = c.String(nullable: false, maxLength: 128),
                        PostID = c.Int(nullable: false),
                        DateClaim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Description = c.String(nullable: false),
                        Objet = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => new { t.MemberID, t.PostID })
                .ForeignKey("dbo.AspNetUsers", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.MemberID)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        MemberID = c.String(nullable: false, maxLength: 128),
                        ProductID = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Qtt = c.Int(nullable: false),
                        product_ProdID = c.Int(),
                    })
                .PrimaryKey(t => new { t.MemberID, t.ProductID, t.PurchaseDate })
                .ForeignKey("dbo.AspNetUsers", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.product_ProdID)
                .Index(t => t.MemberID)
                .Index(t => t.product_ProdID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProdID = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Price = c.Double(nullable: false),
                        Name = c.String(),
                        rating = c.Int(nullable: false),
                        Description = c.String(),
                        Category = c.String(),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdID);
            
            CreateTable(
                "dbo.Participations",
                c => new
                    {
                        EventID = c.Int(nullable: false),
                        MemberID = c.String(nullable: false, maxLength: 128),
                        ParticipationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ParticipationPlace_Country = c.String(nullable: false),
                        ParticipationPlace_Street = c.String(nullable: false),
                        ParticipationPlace_ZipCode = c.String(nullable: false, maxLength: 4),
                        ParticipationPlace_Longitude = c.String(),
                        ParticipationPlace_Latitude = c.String(),
                    })
                .PrimaryKey(t => new { t.EventID, t.MemberID, t.ParticipationDate })
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.EventID)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        EventImg = c.String(),
                        EventName = c.String(),
                        EventDescription = c.String(),
                        EventLocal_Country = c.String(nullable: false),
                        EventLocal_Street = c.String(nullable: false),
                        EventLocal_ZipCode = c.String(nullable: false, maxLength: 4),
                        EventLocal_Longitude = c.String(),
                        EventLocal_Latitude = c.String(),
                        EventType = c.String(),
                        EventDateD = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EventDateF = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EventRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.PostUsers",
                c => new
                    {
                        Post_PostID = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Post_PostID, t.User_Id })
                .ForeignKey("dbo.Posts", t => t.Post_PostID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Post_PostID)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Refugs", "TentID", "dbo.Tents");
            DropForeignKey("dbo.Refugs", "AdminID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Participations", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Participations", "EventID", "dbo.Events");
            DropForeignKey("dbo.Orders", "product_ProdID", "dbo.Products");
            DropForeignKey("dbo.Orders", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostClaims", "PostID", "dbo.Posts");
            DropForeignKey("dbo.PostClaims", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostUsers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostUsers", "Post_PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Comments", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Equipments", "TentID", "dbo.Tents");
            DropForeignKey("dbo.Tents", "CampID", "dbo.Camps");
            DropIndex("dbo.PostUsers", new[] { "User_Id" });
            DropIndex("dbo.PostUsers", new[] { "Post_PostID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Participations", new[] { "MemberID" });
            DropIndex("dbo.Participations", new[] { "EventID" });
            DropIndex("dbo.Orders", new[] { "product_ProdID" });
            DropIndex("dbo.Orders", new[] { "MemberID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.PostClaims", new[] { "PostID" });
            DropIndex("dbo.PostClaims", new[] { "MemberID" });
            DropIndex("dbo.Posts", new[] { "MemberID" });
            DropIndex("dbo.Comments", new[] { "MemberID" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Refugs", new[] { "TentID" });
            DropIndex("dbo.Refugs", new[] { "AdminID" });
            DropIndex("dbo.Equipments", new[] { "TentID" });
            DropIndex("dbo.Tents", new[] { "CampID" });
            DropTable("dbo.PostUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Events");
            DropTable("dbo.Participations");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.PostClaims");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Refugs");
            DropTable("dbo.Equipments");
            DropTable("dbo.Tents");
            DropTable("dbo.Camps");
        }
    }
}
