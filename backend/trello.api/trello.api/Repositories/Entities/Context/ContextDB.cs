using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Repositories.Entities.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB()
        {
        }
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }

        public DbSet<PaintingEntityModel> Paitings { get; set; }
        public DbSet<PanelEntityModel> Panels { get; set; }
        public DbSet<TaskEntityModel> Task { get; set; }
        public DbSet<UserEntityModel> User { get; set; }
        public DbSet<CheckEntityModel> Check { get; set; }
        public DbSet<TaskCheckEntityModel> TaskCheck { get; set; }
        public DbSet<TaskUserEntityModel> TaskUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaintingEntityModel>()
                .ToTable("Painting")
                .HasKey(x => x.PaintingId);

            modelBuilder.Entity<PanelEntityModel>()
                .ToTable("Panel")
                .HasKey(x => x.PanelId);

            modelBuilder.Entity<TaskEntityModel>()
                .ToTable("Task")
                .HasKey(x => x.TaskId);

            modelBuilder.Entity<UserEntityModel>()
                .ToTable("User")
                .HasKey(x => x.UserId);
            
            modelBuilder.Entity<CheckEntityModel>()
                .ToTable("Check")
                .HasKey(x => x.CheckId);
            
            modelBuilder.Entity<TaskUserEntityModel>()
                .HasKey(x => new { x.TaskId, x.UserId });

            modelBuilder.Entity<TaskCheckEntityModel>()
                .HasKey(e => new { e.TaskId, e.CheckId });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-AV7L5CR\MICRO;Database=Trello;Integrated Security=True");
        }

        /*
            Comandos migrations
            dotnet ef migrations add NomeMigracao
            dotnet ef database update
        */
    }
}