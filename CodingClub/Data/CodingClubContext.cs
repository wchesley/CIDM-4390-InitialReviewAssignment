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
            public DbSet<ClubMember> ClubMember {get; set; }
            public DbSet<Content> Content {get; set; }
            public DbSet<Teams> Teams {get; set; }

    }
}