using EFMigration.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFMigration.Data.Data
{
    public class IntegrationLogContext : DbContext
    {
        public IntegrationLogContext(DbContextOptions<IntegrationLogContext> options)
          : base(options)
        { }

        public virtual DbSet<StaticContent> StaticContents { get; set; }
        public virtual DbSet<DynamicContent> DynamicContents { get; set; }
        public virtual DbSet<StaticContentDetail> StaticContentDetails { get; set; }
        public virtual DbSet<DynamicContentDetail> DynamicContentDetails { get; set; }
        public virtual DbSet<PullDynamicContent> PullDynamicContents { get; set; }
        public virtual DbSet<PullDynamicContentDetail> PullDynamicContentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateIntegrationLogModel(modelBuilder);
        }

        private void CreateIntegrationLogModel(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StaticContent>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.EntityId).IsRequired();
                entity.Property(e => e.Status).IsRequired();
            });
            modelBuilder.Entity<StaticContentDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasOne(e => e.Static)
                    .WithMany(e => e.StaticDetails)
                    .HasForeignKey(e => e.MasterId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.Channel).IsRequired();
                entity.Property(e => e.Status).IsRequired();
            });

            modelBuilder.Entity<DynamicContent>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.EntityId).IsRequired();
            });
            modelBuilder.Entity<DynamicContentDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasOne(e => e.Dynamic)
                    .WithMany(e => e.DynamicDetails)
                    .HasForeignKey(e => e.MasterId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.Channel).IsRequired();
                entity.Property(e => e.Status).IsRequired();
            });

            //modelBuilder.Entity<PullDynamicContent>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();
            //    entity.Property(e => e.Content).IsRequired();
            //    entity.Property(e => e.Status).IsRequired();
            //    entity.Property(e => e.EntityId).IsRequired();
            //});
            //modelBuilder.Entity<DynamicContentDetail>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();
            //    entity.HasOne(e => e.Dynamic)
            //        .WithMany(e => e.DynamicDetails)
            //        .HasForeignKey(e => e.MasterId)
            //        .OnDelete(DeleteBehavior.Restrict);
            //    entity.Property(e => e.Channel).IsRequired();
            //    entity.Property(e => e.Status).IsRequired();
            //});
        }
    }
}