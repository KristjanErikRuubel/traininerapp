using System;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Team> Teams { get; set; }       
        public DbSet<Training> Trainings { get; set; }
        
        public DbSet<NotificationAnswer> NotificationAnswers { get; set; }
        public DbSet<UserInTraining> UsersInTrainings { get; set; }
        public DbSet<TrainingPlace> TrainingPlaces { get; set; }
        public DbSet<PlayerPosition> PlayerPositions { get; set; }
        
        public DbSet<TrainingInBill> TrainingInBills { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}