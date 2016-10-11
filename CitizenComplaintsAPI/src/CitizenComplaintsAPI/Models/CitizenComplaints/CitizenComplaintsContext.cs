using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CitizenComplaintsAPI.Models.CitizenComplaints
{
    public class CitizenComplaintsContext : DbContext
    {
        public CitizenComplaintsContext(DbContextOptions<CitizenComplaintsContext> options)
            : base(options)
        { }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ComplaintDescription> ComplaintDescriptions { get; set; }
        public DbSet<LocationAddress> LocationAddresses { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            //No need to map key fields if the id naming convention is same is class name with Id  or just Id eg. ClassNameId
            
            #region Complaint
            
            builder.Entity<Complaint>()
                .Property(c => c.CitizenId)
                .IsRequired();

            builder.Entity<Complaint>()
               .Property(c => c.IssueTypeId)
               .IsRequired();

            builder.Entity<Complaint>()
               .Property(c => c.CreatedDateTime)
               .IsRequired();

            builder.Entity<Complaint>()
              .Property(c => c.UpdatedDateTime)
              .IsRequired();

            builder.Entity<Complaint>()
              .Property(c => c.Enabled)
              .HasDefaultValue(true)
              .IsRequired();

            //relationships child entities
            builder.Entity<Complaint>()
              .HasOne(c => c.Citizen)
              .WithOne()
              .HasForeignKey<Complaint>(c => c.CitizenId);
           
            builder.Entity<Complaint>()
              .HasOne(c => c.Description)
              .WithOne()
              .HasForeignKey<ComplaintDescription>(c => c.ComplaintId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Complaint>()
               .HasMany(c => c.LocationAddresses)
               .WithOne()
               .HasForeignKey(c => c.ComplaintId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Complaint>()
              .HasOne(c => c.Issue)
              .WithOne()
              .HasForeignKey<Complaint>(c => c.IssueTypeId);
            

              
            #endregion
            #region ComplaintDescription
            //CreatedDateTime
            builder.Entity<ComplaintDescription>()
                .HasKey(c => c.ComplaintId);

            builder.Entity<ComplaintDescription>()
                .Property(c => c.Description)
                .IsRequired();
            #endregion
            #region LocationAddress
            //Address
            builder.Entity<LocationAddress>()
                .Property(c => c.Address)
                .HasMaxLength(64)
                .IsRequired();
            //Address2
            builder.Entity<LocationAddress>()
                .Property(c => c.Address2)
                .HasMaxLength(64);
            //City
            builder.Entity<LocationAddress>()
                .Property(c => c.City)
                .HasMaxLength(30)
                .IsRequired();
            //State
            builder.Entity<LocationAddress>()
                .Property(c => c.StateId)
                .HasMaxLength(2)
                .IsRequired();
            //ZipCode
            builder.Entity<LocationAddress>()
                .Property(c => c.ZipCode)
                .HasMaxLength(5);
                //.IsRequired(); citizen may not know address
            #endregion
            #region Citizen
            //Title 

            //First Name
            builder.Entity<Citizen>()
                .Property(c => c.FirstName)
                .HasMaxLength(35)
                .IsRequired();
            //Middle Name
            builder.Entity<Citizen>()
                .Property(c => c.MiddleInitial)
                .HasMaxLength(1);
            //Last Name
            builder.Entity<Citizen>()
                .Property(c => c.LastName)
                .HasMaxLength(35)
                .IsRequired();
            //Address
            builder.Entity<Citizen>()
                .Property(c => c.Address)
                .HasMaxLength(64)
                .IsRequired();
            //Address2
            builder.Entity<Citizen>()
                .Property(c => c.Address2)
                .HasMaxLength(64);
            //City
            builder.Entity<Citizen>()
                .Property(c => c.City)
                .HasMaxLength(35)
                .IsRequired();
            //State
            builder.Entity<Citizen>()
                .Property(c => c.StateId)
                .HasMaxLength(2)
                .IsRequired();
            //ZipCode
            builder.Entity<Citizen>()
                .Property(c => c.ZipCode)
                .HasMaxLength(5)
                .IsRequired();
            //PhoneDay + ext
            builder.Entity<Citizen>()
                .Property(c => c.PhoneDay)
                .HasMaxLength(20)
                .IsRequired();
            //PhoneEvening + ext
            builder.Entity<Citizen>()
                .Property(c => c.PhoneEvening)
                .HasMaxLength(20);
            //PhoneFax
            builder.Entity<Citizen>()
                .Property(c => c.PhoneFax)
                .HasMaxLength(10);
            //Email
            builder.Entity<Citizen>()
                .Property(c => c.Email)
                .HasMaxLength(254);
            //CreatedDateTime
            builder.Entity<Citizen>()
                .Property(c => c.CreatedDateTime)
                .IsRequired();
            //UpdatedDateTime
            builder.Entity<Citizen>()
                .Property(c => c.UpdatedDateTime)
                .IsRequired();
            //Enabled
            builder.Entity<Citizen>()
                .Property(c => c.Enabled)
                .HasDefaultValue(true)
                .IsRequired();

            ////Relationship Mapping
            //builder.Entity<Citizen>()
            //    .HasOne(c=> c.Title)
            //    .WithOne()
            //    .HasForeignKey<Citizen>(c=> c.TitleId);

            #endregion
            #region IssueType

            builder.Entity<IssueType>()
                .Property(i => i.IssueTypeId)
                .ValueGeneratedOnAdd();

            builder.Entity<IssueType>()
                .Property(i=> i.DisplayName)
                .IsRequired()
                .HasMaxLength(100);

            #endregion

            builder.RemovePluralizingTableNameConvention();

        }

        public override int SaveChanges()
        {
            //Set CreatedDateTime and UpdateDateTime if  exist
            this.ChangeTracker.DetectChanges();

            var entries = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);


            foreach (var entry in entries)
            {
                if (entry.Entity.GetType() == typeof(Complaint) || entry.Entity.GetType() == typeof(Citizen))
                {
                    DateTime timeStamp = DateTime.UtcNow;

                    //Created 
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedDateTime").CurrentValue = timeStamp;
                        entry.Property("Enabled").CurrentValue = true;
                    }
                    entry.Property("UpdatedDateTime").CurrentValue = timeStamp;
                    
                }
                
            }

            return base.SaveChanges();
        }
    }
}
