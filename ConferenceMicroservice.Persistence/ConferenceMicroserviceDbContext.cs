using ConferenceMicroservice.Persistence.Configurations;
using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceMicroservice.Persistence
{
    public class ConferenceMicroserviceDbContext(DbContextOptions<ConferenceMicroserviceDbContext> options) 
        : DbContext(options)
    {
        public DbSet<ConferenceEntity> Conferences { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<OrganizationDivisionEntity> Divisions { get; set; }
        public DbSet<ChatEntity> Chats { get; set; }
        public DbSet<MessageEntity> Messages { get;set; }

        public DbSet<PartyEntity> Parties { get; set; }
        public DbSet<UserConferenceEntity> UserConferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new ConferenceConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new PartyConfiguration());
            modelBuilder.ApplyConfiguration(new UserConferenceConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationDivisionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
