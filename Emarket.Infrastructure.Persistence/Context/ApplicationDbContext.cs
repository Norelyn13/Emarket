using Emarket.Core.Application.Helpers;
using Emarket.Core.Application.ViewModels.User;
using Emarket.Core.Domain.Common;
using Emarket.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Emarket.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext :DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private   UserVM user;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;

        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Ads> ads { get; set; }
        public DbSet<User> users { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            user = _httpContextAccessor.HttpContext.Session.Get<UserVM>("user");

            foreach (var entry in ChangeTracker.Entries< AuditableBaseEntity>())
            {
                switch (entry.State)
                {                 
                    case EntityState.Modified:
                        entry.Entity.Creadted = DateTime.Now;
                        entry.Entity.CreatedBy = user.FirstName;
                        break;
                    case EntityState.Added:
                        entry.Entity.Creadted = DateTime.Now;
                        entry.Entity.CreatedBy = user.FirstName;
                        break;                
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region Tables

            modelBuilder.Entity<Category>().ToTable("categories"); //display name in DataBase
            modelBuilder.Entity<Ads>().ToTable("ads");
            modelBuilder.Entity<User>().ToTable("users");

            #endregion

            #region constraint

            //Primary Key
            modelBuilder.Entity<Category>().HasKey(x => x.Id);
            modelBuilder.Entity<Ads>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasKey(x => x.Id);


            //Relationships

            modelBuilder.Entity<Category>()
            .HasMany<Ads>(categories => categories.Ads)
            .WithOne(ads => ads.Category)
            .HasForeignKey(ads => ads.CategoryId)
            .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
            .HasMany<Ads>(users => users.Ads)
            .WithOne(ads => ads.User)
            .HasForeignKey(ads => ads.UserId)
            .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            #endregion

            #region "Validation Required"

            #region "Categories"

            modelBuilder.Entity<Category>()
            .Property(categories => categories.Name)
            .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(categories => categories.Description)
                .IsRequired();

            #endregion
            #region "Ads"

            modelBuilder.Entity<Ads>()
            .Property(ads => ads.Name)
            .IsRequired();

            modelBuilder.Entity<Ads>()
                .Property(ads => ads.Description)
                .IsRequired();
         
            modelBuilder.Entity<Ads>()
             .Property(ads => ads.Price)
             .IsRequired();

            modelBuilder.Entity<Ads>()
             .Property(ads => ads.CategoryId)
             .IsRequired();
            #endregion

            #region Users

            modelBuilder.Entity<User>()
            .Property(users => users.FirstName)
            .IsRequired().HasMaxLength(100);

            modelBuilder.Entity<User>()
          .Property(users => users.LastName)
          .IsRequired().HasMaxLength(100);

            modelBuilder.Entity<User>()
          .Property(users => users.Username)
          .IsRequired().HasMaxLength(100);

            modelBuilder.Entity<User>()
          .Property(users => users.Password)
          .IsRequired();

            modelBuilder.Entity<User>()
          .Property(users => users.Phone)
          .IsRequired();

            modelBuilder.Entity<User>()
          .Property(users => users.Email)
          .IsRequired();

            #endregion



            #endregion
        }
    }

}
