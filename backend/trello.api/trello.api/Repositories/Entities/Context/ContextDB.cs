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
        }
        /*
            Comandos migrations
            dotnet ef migrations add NomeMigracao
            dotnet ef database update
        */
    }
}