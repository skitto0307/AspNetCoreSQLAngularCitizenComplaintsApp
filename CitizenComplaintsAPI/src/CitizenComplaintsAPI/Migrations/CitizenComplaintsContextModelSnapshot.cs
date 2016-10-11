using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CitizenComplaintsAPI.Models.CitizenComplaints;

namespace CitizenComplaintsAPI.Migrations
{
    [DbContext(typeof(CitizenComplaintsContext))]
    partial class CitizenComplaintsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CitizenComplaintsAPI.Models.CitizenComplaints.Citizen", b =>
                {
                    b.Property<Guid>("CitizenId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Address2")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 35);

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 254);

                    b.Property<bool>("Enabled")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 35);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 35);

                    b.Property<string>("MiddleInitial")
                        .HasAnnotation("MaxLength", 1);

                    b.Property<string>("PhoneDay")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("PhoneEvening")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("PhoneFax")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("StateId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 2);

                    b.Property<DateTime>("UpdatedDateTime");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 5);

                    b.HasKey("CitizenId");

                    b.ToTable("Citizen");
                });

            modelBuilder.Entity("CitizenComplaintsAPI.Models.CitizenComplaints.Complaint", b =>
                {
                    b.Property<Guid>("ComplaintId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CitizenId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("Enabled")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<int>("IssueTypeId");

                    b.Property<DateTime>("UpdatedDateTime");

                    b.HasKey("ComplaintId");

                    b.HasIndex("CitizenId")
                        .IsUnique();

                    b.HasIndex("IssueTypeId")
                        .IsUnique();

                    b.ToTable("Complaint");
                });

            modelBuilder.Entity("CitizenComplaintsAPI.Models.CitizenComplaints.ComplaintDescription", b =>
                {
                    b.Property<Guid>("ComplaintId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("ComplaintId");

                    b.HasIndex("ComplaintId")
                        .IsUnique();

                    b.ToTable("ComplaintDescription");
                });

            modelBuilder.Entity("CitizenComplaintsAPI.Models.CitizenComplaints.IssueType", b =>
                {
                    b.Property<int>("IssueTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("IssueTypeId");

                    b.ToTable("IssueType");
                });

            modelBuilder.Entity("CitizenComplaintsAPI.Models.CitizenComplaints.LocationAddress", b =>
                {
                    b.Property<Guid>("LocationAddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Address2")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.Property<Guid>("ComplaintId");

                    b.Property<string>("StateId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 2);

                    b.Property<string>("ZipCode")
                        .HasAnnotation("MaxLength", 5);

                    b.HasKey("LocationAddressId");

                    b.HasIndex("ComplaintId");

                    b.ToTable("LocationAddress");
                });

            modelBuilder.Entity("CitizenComplaintsAPI.Models.CitizenComplaints.Complaint", b =>
                {
                    b.HasOne("CitizenComplaintsAPI.Models.CitizenComplaints.Citizen", "Citizen")
                        .WithOne()
                        .HasForeignKey("CitizenComplaintsAPI.Models.CitizenComplaints.Complaint", "CitizenId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CitizenComplaintsAPI.Models.CitizenComplaints.IssueType", "Issue")
                        .WithOne()
                        .HasForeignKey("CitizenComplaintsAPI.Models.CitizenComplaints.Complaint", "IssueTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CitizenComplaintsAPI.Models.CitizenComplaints.ComplaintDescription", b =>
                {
                    b.HasOne("CitizenComplaintsAPI.Models.CitizenComplaints.Complaint")
                        .WithOne("Description")
                        .HasForeignKey("CitizenComplaintsAPI.Models.CitizenComplaints.ComplaintDescription", "ComplaintId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CitizenComplaintsAPI.Models.CitizenComplaints.LocationAddress", b =>
                {
                    b.HasOne("CitizenComplaintsAPI.Models.CitizenComplaints.Complaint")
                        .WithMany("LocationAddresses")
                        .HasForeignKey("ComplaintId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
