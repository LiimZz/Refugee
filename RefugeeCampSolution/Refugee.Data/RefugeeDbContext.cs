using Microsoft.AspNet.Identity.EntityFramework;
using Refugee.Data.Configurations;
using Refugee.Data.Conventions;
using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data
{
    public class RefugeeDbContext : IdentityDbContext<User>
    {
        public RefugeeDbContext() : base("name=ASPRefugeeDB", throwIfV1Schema: false)
        {
        }
        public static RefugeeDbContext Create()
        {
            return new RefugeeDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new LocalisationConfiguration());
            modelBuilder.Configurations.Add(new AgeStructConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new RefugeeConfiguration());
            modelBuilder.Configurations.Add(new DonationConfiguration());
            modelBuilder.Configurations.Add(new GiftsConfiguration());
            modelBuilder.Configurations.Add(new PartnerConfiguration());
            //modelBuilder.Configurations.Add(new MemberConfiguration());
            modelBuilder.Conventions.Add(new DataTime2Convention());
        }

        //public DbSet<Admin> admin { get; set; }
        //public DbSet<Member> Member { get; set; }
        //public DbSet<Volunteer> Volunteer { get; set; }

        public DbSet<Camp> Camp { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Equipment> Equipement { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Participation> participation { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Refug> refugeee { get; set; }
        public DbSet<Tent> Tent { get; set; }

        //jee
        public DbSet<Donations> Donations { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<MedicalCare> Medecin { get; set; }
        public DbSet<MedecinDisponibilite> MedecinDisponibilite { get; set; }
        public DbSet<Consultation> Consultation { get; set; }
        public DbSet<Adoption> Adoption { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<PartnerDocs> PartnerDocs { get; set; }
        public DbSet<JobOffer> JobOffer { get; set; }
    }
}
