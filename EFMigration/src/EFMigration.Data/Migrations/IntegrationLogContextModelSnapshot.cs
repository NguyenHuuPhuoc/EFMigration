﻿// <auto-generated />
using System;
using EFMigration.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFMigration.Data.Migrations
{
    [DbContext(typeof(IntegrationLogContext))]
    partial class IntegrationLogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFMigration.Data.Entities.DynamicContent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("EntityId")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<short>("Status");

                    b.Property<string>("Type");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("DynamicContents");
                });

            modelBuilder.Entity("EFMigration.Data.Entities.DynamicContentDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Channel")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("LastError");

                    b.Property<long>("MasterId");

                    b.Property<short?>("RetriedCount");

                    b.Property<short>("Status");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("MasterId");

                    b.ToTable("DynamicContentDetails");
                });

            modelBuilder.Entity("EFMigration.Data.Entities.PullDynamicContent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ChangedDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("HotelId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("RateId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("PullDynamicContents");
                });

            modelBuilder.Entity("EFMigration.Data.Entities.PullDynamicContentDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ChangedDate");

                    b.Property<string>("ChannelCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("HotelId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("PullDynamicContentDetails");
                });

            modelBuilder.Entity("EFMigration.Data.Entities.StaticContent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("ContentPush");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("EntityId")
                        .IsRequired();

                    b.Property<short>("Status");

                    b.Property<short>("Type");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("StaticContents");
                });

            modelBuilder.Entity("EFMigration.Data.Entities.StaticContentDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Channel")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("LastError");

                    b.Property<long>("MasterId");

                    b.Property<short?>("RetriedCount");

                    b.Property<short>("Status");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("MasterId");

                    b.ToTable("StaticContentDetails");
                });

            modelBuilder.Entity("EFMigration.Data.Entities.DynamicContentDetail", b =>
                {
                    b.HasOne("EFMigration.Data.Entities.DynamicContent", "Dynamic")
                        .WithMany("DynamicDetails")
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EFMigration.Data.Entities.StaticContentDetail", b =>
                {
                    b.HasOne("EFMigration.Data.Entities.StaticContent", "Static")
                        .WithMany("StaticDetails")
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
