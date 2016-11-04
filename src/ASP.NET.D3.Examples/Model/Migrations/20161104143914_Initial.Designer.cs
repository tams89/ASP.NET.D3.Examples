using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ASP.NET.D3.Examples.Model;

namespace ASP.NET.D3.Examples.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20161104143914_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASP.NET.D3.Examples.Models.Models+Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ASP.NET.D3.Examples.Models.Models+Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ASP.NET.D3.Examples.Models.Models+Subsidiary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Subsidiaries");
                });

            modelBuilder.Entity("ASP.NET.D3.Examples.Models.Models+Department", b =>
                {
                    b.HasOne("ASP.NET.D3.Examples.Models.Models+Subsidiary", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("ASP.NET.D3.Examples.Models.Models+Subsidiary", b =>
                {
                    b.HasOne("ASP.NET.D3.Examples.Models.Models+Company", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });
        }
    }
}
