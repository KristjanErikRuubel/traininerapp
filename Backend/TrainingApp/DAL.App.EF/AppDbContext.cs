using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        
        private IUserNameProvider _userNameProvider;
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Team> Teams { get; set; }       
        public DbSet<Training> Trainings { get; set; }
        
        public DbSet<NotificationAnswer> NotificationAnswers { get; set; }

        public DbSet<UserInTraining> UsersInTrainings { get; set; }

        public DbSet<TrainingPlace> TrainingPlaces { get; set; }
        public DbSet<UserRoleInTeam> UserRoleInTeams { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options,  IUserNameProvider userNameProvider) : base(options)
        {
            _userNameProvider = userNameProvider;
        }
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<Notification>()
        //         .HasOne(b => b.NotificationAnswer)
        //         .WithOne(i => i.Notification)
        //         .HasForeignKey<NotificationAnswer>(b => b.NotificationId);
        //   
        //     builder.Entity<AppUser>()
        //         .HasOne(b => b.Team)
        //         .WithMany(i => i.Users);
        //
        //     base.OnModelCreating(builder);
        // }
        
        // private void SaveChangesMetadataUpdate()
        // {
        //     // update the state of ef tracked objects
        //     ChangeTracker.DetectChanges();
        //     
        //     var markedAsAdded = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
        //     foreach (var entityEntry in markedAsAdded)
        //     {
        //         if (!(entityEntry.Entity is IDomainEntityMetadata entityWithMetaData)) continue;
        //
        //         entityWithMetaData.CreatedAt = DateTime.Now;
        //         entityWithMetaData.CreatedBy = _userNameProvider.CurrentUserName;
        //         entityWithMetaData.ChangedAt = entityWithMetaData.CreatedAt;
        //         entityWithMetaData.ChangedBy = entityWithMetaData.CreatedBy;
        //     }
        //
        //     var markedAsModified = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
        //     foreach (var entityEntry in markedAsModified)
        //     {
        //         // check for IDomainEntityMetadata
        //         if (!(entityEntry.Entity is IDomainEntityMetadata entityWithMetaData)) continue;
        //
        //         entityWithMetaData.ChangedAt = DateTime.Now;
        //         entityWithMetaData.ChangedBy = _userNameProvider.CurrentUserName;
        //
        //         // do not let changes on these properties get into generated db sentences - db keeps old values
        //         entityEntry.Property(nameof(entityWithMetaData.CreatedAt)).IsModified = false;
        //         entityEntry.Property(nameof(entityWithMetaData.CreatedBy)).IsModified = false;
        //     }
        // }
        //
        // public override int SaveChanges()
        // {
        //     SaveChangesMetadataUpdate();
        //     return base.SaveChanges();
        // }
        //
        // public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        // {
        //     SaveChangesMetadataUpdate();
        //     return base.SaveChangesAsync(cancellationToken);
        // }
        
    }
}