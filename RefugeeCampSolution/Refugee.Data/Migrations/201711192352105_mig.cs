namespace Refugee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adoptions",
                c => new
                    {
                        DateAdoption = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        RefugID = c.Int(nullable: false),
                        MemberID = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Etat = c.String(),
                    })
                .PrimaryKey(t => new { t.DateAdoption, t.RefugID, t.MemberID })
                .ForeignKey("dbo.AspNetUsers", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Refugs", t => t.RefugID, cascadeDelete: true)
                .Index(t => t.RefugID)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserRole = c.String(),
                        Password = c.String(maxLength: 100),
                        ConfirmPassword = c.String(),
                        Token = c.String(),
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
                        Picture = c.String(),
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
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        AdminID = c.String(maxLength: 128),
                        DateCourse = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Matiere = c.String(),
                        NbrPlaceDispo = c.Int(nullable: false),
                        ZoneAge = c.String(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminID)
                .Index(t => t.AdminID);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        DonationID = c.Int(nullable: false, identity: true),
                        MemberID = c.String(nullable: false, maxLength: 128),
                        CampID = c.Int(nullable: false),
                        DateDonation = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TypeDonation = c.String(),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DonationID)
                .ForeignKey("dbo.Camps", t => t.CampID)
                .ForeignKey("dbo.AspNetUsers", t => t.MemberID)
                .Index(t => t.MemberID)
                .Index(t => t.CampID);
            
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
                        Status = c.Int(nullable: false),
                        TentID = c.Int(nullable: false),
                        Skills = c.String(),
                        HealthStatus = c.String(),
                    })
                .PrimaryKey(t => t.RefugID)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminID)
                .ForeignKey("dbo.Tents", t => t.TentID)
                .Index(t => t.AdminID)
                .Index(t => t.TentID);
            
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        DateConsultation = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        RefugID = c.Int(nullable: false),
                        MedecinID = c.Int(nullable: false),
                        Maladie = c.String(),
                        Etat = c.String(),
                    })
                .PrimaryKey(t => new { t.DateConsultation, t.RefugID, t.MedecinID })
                .ForeignKey("dbo.MedicalCares", t => t.MedecinID, cascadeDelete: true)
                .ForeignKey("dbo.Refugs", t => t.RefugID, cascadeDelete: true)
                .Index(t => t.RefugID)
                .Index(t => t.MedecinID);
            
            CreateTable(
                "dbo.MedicalCares",
                c => new
                    {
                        MedecinID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Field = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MedecinID);
            
            CreateTable(
                "dbo.MedecinDisponibilites",
                c => new
                    {
                        DispoID = c.Int(nullable: false, identity: true),
                        DateDebut = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateFin = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MedecinID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DispoID)
                .ForeignKey("dbo.MedicalCares", t => t.MedecinID, cascadeDelete: true)
                .Index(t => t.MedecinID);
            
            CreateTable(
                "dbo.JobOffers",
                c => new
                    {
                        RefugID = c.Int(nullable: false),
                        PartnerID = c.Int(nullable: false),
                        Post = c.String(),
                        Salary = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.RefugID, t.PartnerID })
                .ForeignKey("dbo.Partners", t => t.PartnerID, cascadeDelete: true)
                .ForeignKey("dbo.Refugs", t => t.RefugID, cascadeDelete: true)
                .Index(t => t.RefugID)
                .Index(t => t.PartnerID);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        PartnerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Specialty = c.String(),
                        AdminID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PartnerID)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminID)
                .Index(t => t.AdminID);
            
            CreateTable(
                "dbo.PartnerDocs",
                c => new
                    {
                        DocumentID = c.Int(nullable: false, identity: true),
                        DocumentPath = c.String(nullable: false),
                        PartnerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentID)
                .ForeignKey("dbo.Partners", t => t.PartnerID)
                .Index(t => t.PartnerID);
            
            CreateTable(
                "dbo.Gifts",
                c => new
                    {
                        GiftID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Amount = c.Double(nullable: false),
                        AdminID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.GiftID)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminID)
                .Index(t => t.AdminID);
            
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
                        ProdID = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Qtt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MemberID, t.ProdID, t.PurchaseDate })
                .ForeignKey("dbo.AspNetUsers", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProdID, cascadeDelete: true)
                .Index(t => t.MemberID)
                .Index(t => t.ProdID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProdID = c.Int(nullable: false, identity: true),
                        Image = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        rating = c.Int(nullable: false),
                        Description = c.String(),
                        Stock = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Participations", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Participations", "EventID", "dbo.Events");
            DropForeignKey("dbo.Orders", "ProdID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Orders", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gifts", "AdminID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Donations", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Donations", "CampID", "dbo.Camps");
            DropForeignKey("dbo.Refugs", "TentID", "dbo.Tents");
            DropForeignKey("dbo.JobOffers", "RefugID", "dbo.Refugs");
            DropForeignKey("dbo.PartnerDocs", "PartnerID", "dbo.Partners");
            DropForeignKey("dbo.JobOffers", "PartnerID", "dbo.Partners");
            DropForeignKey("dbo.Partners", "AdminID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Consultations", "RefugID", "dbo.Refugs");
            DropForeignKey("dbo.MedecinDisponibilites", "MedecinID", "dbo.MedicalCares");
            DropForeignKey("dbo.Consultations", "MedecinID", "dbo.MedicalCares");
            DropForeignKey("dbo.Adoptions", "RefugID", "dbo.Refugs");
            DropForeignKey("dbo.Refugs", "AdminID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Equipments", "TentID", "dbo.Tents");
            DropForeignKey("dbo.Tents", "CampID", "dbo.Camps");
            DropForeignKey("dbo.Courses", "AdminID", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostClaims", "PostID", "dbo.Posts");
            DropForeignKey("dbo.PostClaims", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Comments", "MemberID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Adoptions", "MemberID", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Participations", new[] { "MemberID" });
            DropIndex("dbo.Participations", new[] { "EventID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Orders", new[] { "ProdID" });
            DropIndex("dbo.Orders", new[] { "MemberID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Gifts", new[] { "AdminID" });
            DropIndex("dbo.PartnerDocs", new[] { "PartnerID" });
            DropIndex("dbo.Partners", new[] { "AdminID" });
            DropIndex("dbo.JobOffers", new[] { "PartnerID" });
            DropIndex("dbo.JobOffers", new[] { "RefugID" });
            DropIndex("dbo.MedecinDisponibilites", new[] { "MedecinID" });
            DropIndex("dbo.Consultations", new[] { "MedecinID" });
            DropIndex("dbo.Consultations", new[] { "RefugID" });
            DropIndex("dbo.Refugs", new[] { "TentID" });
            DropIndex("dbo.Refugs", new[] { "AdminID" });
            DropIndex("dbo.Equipments", new[] { "TentID" });
            DropIndex("dbo.Tents", new[] { "CampID" });
            DropIndex("dbo.Donations", new[] { "CampID" });
            DropIndex("dbo.Donations", new[] { "MemberID" });
            DropIndex("dbo.Courses", new[] { "AdminID" });
            DropIndex("dbo.PostClaims", new[] { "PostID" });
            DropIndex("dbo.PostClaims", new[] { "MemberID" });
            DropIndex("dbo.Posts", new[] { "MemberID" });
            DropIndex("dbo.Comments", new[] { "MemberID" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Adoptions", new[] { "MemberID" });
            DropIndex("dbo.Adoptions", new[] { "RefugID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Events");
            DropTable("dbo.Participations");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Gifts");
            DropTable("dbo.PartnerDocs");
            DropTable("dbo.Partners");
            DropTable("dbo.JobOffers");
            DropTable("dbo.MedecinDisponibilites");
            DropTable("dbo.MedicalCares");
            DropTable("dbo.Consultations");
            DropTable("dbo.Refugs");
            DropTable("dbo.Equipments");
            DropTable("dbo.Tents");
            DropTable("dbo.Camps");
            DropTable("dbo.Donations");
            DropTable("dbo.Courses");
            DropTable("dbo.PostClaims");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Adoptions");
        }
    }
}
