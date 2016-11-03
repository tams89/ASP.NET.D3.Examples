using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ASP.NET.D3.Examples.Model;

namespace ASP.NET.D3.Examples.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20161103162510_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASP.NET.D3.Examples.Model.Models+Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ASP.NET.D3.Examples.Model.Models+Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ParentSubsidiaryId");

                    b.HasKey("DepartmentId");

                    b.HasIndex("ParentSubsidiaryId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ASP.NET.D3.Examples.Model.Models+Subsidiary", b =>
                {
                    b.Property<int>("SubsidiaryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ParentCompanyId");

                    b.HasKey("SubsidiaryId");

                    b.HasIndex("ParentCompanyId");

                    b.ToTable("Subsidiaries");
                });

            modelBuilder.Entity("ASP.NET.D3.Examples.Model.Models+Department", b =>
                {
                    b.HasOne("ASP.NET.D3.Examples.Model.Models+Subsidiary", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentSubsidiaryId");
                });

            modelBuilder.Entity("ASP.NET.D3.Examples.Model.Models+Subsidiary", b =>
                {
                    b.HasOne("ASP.NET.D3.Examples.Model.Models+Company", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentCompanyId");
                });
        }
    }
}
