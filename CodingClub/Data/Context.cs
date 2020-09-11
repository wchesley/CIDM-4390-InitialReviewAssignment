using System; 
using Microsoft.EntityFrameworkCore;

namespace CodingClub.Data
{
    public class CodingClubContext : DbContext
    {
        public CodingClubContext(
            DbContextOptions<CodingClubContext> options)
            : base(options)
            {
            }
            public DbSet<CodingClub.Modles.ClubMember> ClubMember {get; set; }
            public DbSet<CodingClub.Modles.Content> Content {get; set; }
            public DbSet<CodingClub.Modles.Teams> Teams {get; set; }
    }
}