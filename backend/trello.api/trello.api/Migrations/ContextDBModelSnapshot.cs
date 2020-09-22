﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using trello.api.Repositories.Entities.Context;

namespace trello.api.Migrations
{
    [DbContext(typeof(ContextDB))]
    partial class ContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("trello.api.Repositories.Entities.Models.CheckEntityModel", b =>
                {
                    b.Property<int>("CheckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<int?>("TaskEntityModelTaskId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("CheckId");

                    b.HasIndex("TaskEntityModelTaskId");

                    b.ToTable("Check");
                });

            modelBuilder.Entity("trello.api.Repositories.Entities.Models.PaintingEntityModel", b =>
                {
                    b.Property<int>("PaintingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaintingId");

                    b.ToTable("Painting");
                });

            modelBuilder.Entity("trello.api.Repositories.Entities.Models.PanelEntityModel", b =>
                {
                    b.Property<int>("PanelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaintingId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PanelId");

                    b.HasIndex("PaintingId");

                    b.ToTable("Panel");
                });

            modelBuilder.Entity("trello.api.Repositories.Entities.Models.TaskEntityModel", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateFinished")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estimated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PanelId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("PanelId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("trello.api.Repositories.Entities.Models.TaskUserEntityModel", b =>
                {
                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TaskId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskUser");
                });

            modelBuilder.Entity("trello.api.Repositories.Entities.Models.UserEntityModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("trello.api.Repositories.Entities.Models.CheckEntityModel", b =>
                {
                    b.HasOne("trello.api.Repositories.Entities.Models.TaskEntityModel", null)
                        .WithMany("Check")
                        .HasForeignKey("TaskEntityModelTaskId");
                });

            modelBuilder.Entity("trello.api.Repositories.Entities.Models.PanelEntityModel", b =>
                {
                    b.HasOne("trello.api.Repositories.Entities.Models.PaintingEntityModel", "Painting")
                        .WithMany("Panel")
                        .HasForeignKey("PaintingId");
                });

            modelBuilder.Entity("trello.api.Repositories.Entities.Models.TaskEntityModel", b =>
                {
                    b.HasOne("trello.api.Repositories.Entities.Models.PanelEntityModel", "Panel")
                        .WithMany("Task")
                        .HasForeignKey("PanelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("trello.api.Repositories.Entities.Models.TaskUserEntityModel", b =>
                {
                    b.HasOne("trello.api.Repositories.Entities.Models.TaskEntityModel", "Task")
                        .WithMany("TaskUser")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("trello.api.Repositories.Entities.Models.UserEntityModel", "User")
                        .WithMany("TaskUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
