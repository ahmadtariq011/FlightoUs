using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Recipt> Recipts { get; set; }

        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<Remarks> Remarks { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<SalePost> SalePosts { get; set; }
        public virtual DbSet<CashBook> CashBooks { get; set; }
        public virtual DbSet<AirpotCodes> AirpotCodes { get; set; }
        public virtual DbSet<Refund> Refunds { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfiguration.ConnectionString, options => options.EnableRetryOnFailure());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);

            builder.Entity<Hotel>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Lead>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Remarks>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Ticket>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<User>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Recipt>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder.Entity<SalePost>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder.Entity<CashBook>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder.Entity<AirpotCodes>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder.Entity<Refund>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}