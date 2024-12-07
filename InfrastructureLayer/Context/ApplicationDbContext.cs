using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int,
                            IdentityUserClaim<int>, UserRole,
                            IdentityUserLogin<int>, IdentityRoleClaim<int>,
                            IdentityUserToken<int>>
    {


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Remove the UserRole table
            modelBuilder.Ignore<UserRole>();
            modelBuilder.Ignore<IdentityUserToken<int>>();
            //  modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");

            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            modelBuilder.Entity<UserRefreshToken>().ToTable("UserRefreshTokens");



            //modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");

            //modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");



        }
    }
}
