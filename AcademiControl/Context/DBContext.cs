using AcademiControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiControl.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.ProjectOwner); // Relacionamento: Projeto tem um dono (Staff)
                entity.HasMany(e => e.Activities); // Relacionamento: Projeto tem um dono (Staff)
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Owner);
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Owner);

                entity.HasMany(e => e.Staff); // Relacionamento: Atividade tem vários funcionários (Staff)

            });

            // Aqui você pode adicionar outras configurações de relacionamento entre as entidades, se necessário

            base.OnModelCreating(modelBuilder);
        }

    }
}
