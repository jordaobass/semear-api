using Microsoft.EntityFrameworkCore;
using SemearApi.Entities;

namespace SemearApi.Repository.Configuration
{
    public partial class AppContext : DbContext
    {

        public AppContext()
        {
        }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        
        public virtual DbSet<User> user { get; set; }
        public virtual DbSet<Learn> learn { get; set; }
        public virtual DbSet<Careers> careers { get; set; }
        public virtual DbSet<Intructs> intructs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);  
            modelBuilder.Entity<Learn>()
                .HasKey(u => u.Id);  
            modelBuilder.Entity<Careers>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Intructs>()
                .HasKey(u => u.Id);  
            
            modelBuilder.Entity<UserLearn>()
                .HasKey(userLearn => new { userLearn.UserId, userLearn.LearnId });  
       
            modelBuilder.Entity<UserLearn>()
                .HasOne(userLearn => userLearn.User)
                .WithMany(user => user.UserLearn)
                .HasForeignKey(bc => bc.UserId);  
         
            modelBuilder.Entity<UserLearn>()
                .HasOne(userLearn => userLearn.Learn)
                .WithMany(c => c.UserLearn)
                .HasForeignKey(userLearn => userLearn.LearnId);
            
            //UserCareers
            modelBuilder.Entity<UserCareers>()
                .HasKey(userCareers => new { userCareers.UserId, userCareers.CareersId });  
       
            modelBuilder.Entity<UserCareers>()
                .HasOne(userCareers => userCareers.User)
                .WithMany(user => user.UserCareers)
                .HasForeignKey(bc => bc.UserId);  
         
            modelBuilder.Entity<UserCareers>()
                .HasOne(userCareers => userCareers.Careers)
                .WithMany(c => c.UserCareers)
                .HasForeignKey(userCareers => userCareers.CareersId);
            
            ///UserIntructs
            modelBuilder.Entity<UserIntructs>()
                .HasKey(userIntructs => new { userIntructs.UserId, userIntructs.IntructsId });  
       
            modelBuilder.Entity<UserIntructs>()
                .HasOne(userIntructs => userIntructs.User)
                .WithMany(user => user.UserIntructs)
                .HasForeignKey(bc => bc.UserId);  
         
            modelBuilder.Entity<UserIntructs>()
                .HasOne(userIntructs => userIntructs.Intructs)
                .WithMany(c => c.UserIntructs)
                .HasForeignKey(userIntructs => userIntructs.IntructsId);
            
            
            
            
        }
      


   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        
 
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}