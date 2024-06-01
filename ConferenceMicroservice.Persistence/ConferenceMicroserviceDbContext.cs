using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceMicroservice.Persistence
{
    public class ConferenceMicroserviceDbContext : DbContext
    {
        public DbSet<ConferenceEntity> Conferences { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<OrganizationDivisionEntity> Divisions { get; set; }

        public DbSet<ChatEntity> Chats { get; set; }
        public DbSet<MessageEntity> Messages { get;set; }

        public DbSet<PartyEntity> Parties { get; set; }
        public DbSet<UserConferenceEntity> UserConferences { get; set; }
    }
}
