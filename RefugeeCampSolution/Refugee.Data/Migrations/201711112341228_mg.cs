namespace Refugee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedecinDisponibilites", "MedicalCare_MedecinID", "dbo.MedicalCares");
            DropIndex("dbo.MedecinDisponibilites", new[] { "MedicalCare_MedecinID" });
            RenameColumn(table: "dbo.MedecinDisponibilites", name: "MedicalCare_MedecinID", newName: "MedecinID");
            AlterColumn("dbo.MedecinDisponibilites", "MedecinID", c => c.Int(nullable: false));
            CreateIndex("dbo.MedecinDisponibilites", "MedecinID");
            AddForeignKey("dbo.MedecinDisponibilites", "MedecinID", "dbo.MedicalCares", "MedecinID", cascadeDelete: true);
            DropColumn("dbo.MedecinDisponibilites", "MedicalCareID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedecinDisponibilites", "MedicalCareID", c => c.Int(nullable: false));
            DropForeignKey("dbo.MedecinDisponibilites", "MedecinID", "dbo.MedicalCares");
            DropIndex("dbo.MedecinDisponibilites", new[] { "MedecinID" });
            AlterColumn("dbo.MedecinDisponibilites", "MedecinID", c => c.Int());
            RenameColumn(table: "dbo.MedecinDisponibilites", name: "MedecinID", newName: "MedicalCare_MedecinID");
            CreateIndex("dbo.MedecinDisponibilites", "MedicalCare_MedecinID");
            AddForeignKey("dbo.MedecinDisponibilites", "MedicalCare_MedecinID", "dbo.MedicalCares", "MedecinID");
        }
    }
}
