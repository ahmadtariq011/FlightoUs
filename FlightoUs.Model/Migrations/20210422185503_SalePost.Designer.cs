﻿// <auto-generated />
using System;
using FlightoUs.Model.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightoUs.Model.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210422185503_SalePost")]
    partial class SalePost
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlightoUs.Model.Data.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Lead_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PSF")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Lead_Id")
                        .IsUnique();

                    b.HasIndex("User_Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.Lead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AssignDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AssignToUser")
                        .HasColumnType("int");

                    b.Property<string>("CNIC")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ClassOfTravel")
                        .HasColumnType("int");

                    b.Property<string>("ContactCustomer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerType")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FreeText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("LeadStatus")
                        .HasColumnType("int");

                    b.Property<string>("LeadTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeadType")
                        .HasColumnType("int");

                    b.Property<int>("LeadTypeDemand")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Telephone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("TripTyepLead")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AssignToUser");

                    b.ToTable("Lead");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.Recipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FirstServicePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FirstServiceTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FormOfPayment")
                        .HasColumnType("int");

                    b.Property<int>("ItemNo")
                        .HasColumnType("int");

                    b.Property<int>("Lead_Id")
                        .HasColumnType("int");

                    b.Property<string>("ReciptNo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ReciptStatus")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SecondServicePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SecondServiceTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ThirdServicePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ThirdServiceTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("Lead_Id");

                    b.ToTable("Recipt");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.Remarks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ContactDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lead_Id")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Lead_Id");

                    b.HasIndex("UserId");

                    b.ToTable("Remarks");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.SalePost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Adults")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Children")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("From")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Lead_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PNR")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PSF")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SalePostType")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TripType")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Lead_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("SalePost");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Adults")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Children")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Lead_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PSF")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TripType")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Lead_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNIC")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GenderType")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.Hotel", b =>
                {
                    b.HasOne("FlightoUs.Model.Data.Lead", "Lead")
                        .WithOne("Hotels")
                        .HasForeignKey("FlightoUs.Model.Data.Hotel", "Lead_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FlightoUs.Model.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Lead");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.Lead", b =>
                {
                    b.HasOne("FlightoUs.Model.Data.User", "User")
                        .WithMany("Leads")
                        .HasForeignKey("AssignToUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.Recipt", b =>
                {
                    b.HasOne("FlightoUs.Model.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FlightoUs.Model.Data.Lead", "Lead")
                        .WithMany()
                        .HasForeignKey("Lead_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Lead");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.Remarks", b =>
                {
                    b.HasOne("FlightoUs.Model.Data.Lead", "Lead")
                        .WithMany("Remarks")
                        .HasForeignKey("Lead_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FlightoUs.Model.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Lead");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.SalePost", b =>
                {
                    b.HasOne("FlightoUs.Model.Data.Lead", "Lead")
                        .WithMany()
                        .HasForeignKey("Lead_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FlightoUs.Model.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Lead");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.Ticket", b =>
                {
                    b.HasOne("FlightoUs.Model.Data.Lead", "Lead")
                        .WithMany("Tickets")
                        .HasForeignKey("Lead_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FlightoUs.Model.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Lead");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.Lead", b =>
                {
                    b.Navigation("Hotels");

                    b.Navigation("Remarks");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("FlightoUs.Model.Data.User", b =>
                {
                    b.Navigation("Leads");
                });
#pragma warning restore 612, 618
        }
    }
}
