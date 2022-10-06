using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetoBarbershop.Domain.Models;
using NetoBarbershop.Domain.Models.Identity;

namespace NetoBarbershop.Repository.Contextos
{
    public class NetoBarbershopContext : IdentityDbContext<ApplicationUSER>
    {
        public NetoBarbershopContext(DbContextOptions<NetoBarbershopContext> options) : base(options) { }
        public DbSet<ServiceDone> ServicesDones { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ServiceDoneService> ServiceDoneServices { get; set; }
        public DbSet<ServiceDoneProduct> serviceDoneProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.Entity<IdentityRole>(UserRole =>
            //{
            //    UserRole.HasKey(ur => new { ur.UserId, ur.RoleId });

            //    UserRole.HasOne(ur => ur.Role)
            //   .WithMany(r => r.UserRoles)
            //   .HasForeignKey(ur => ur.RoleId)
            //   .IsRequired();

            //    UserRole.HasOne(ur => ur.applicationUSER)
            //   .WithMany(r => r.UserRoles)
            //   .HasForeignKey(ur => ur.UserId)
            //   .IsRequired();
            //});

            builder.Entity<ApplicationUSER>()
           .Property(e => e.Id)
           .ValueGeneratedOnAdd();

            builder.Entity<ApplicationUSER>()
            .HasMany(sd => sd.ServicesDones)
            .WithOne(sd => sd.Usuario)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUSER>()
           .HasMany(sd => sd.Tokens)
           .WithOne(sd => sd.Usuario)
           .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ServiceDone>()
           .HasMany(sd => sd.ServiceDoneServices)
           .WithOne(sd => sd.ServiceDone)
           .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ServiceDone>()
        .HasMany(sd => sd.ServiceDoneProducts)
        .WithOne(sd => sd.ServiceDone)
        .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}
