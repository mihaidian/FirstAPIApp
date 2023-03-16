using FirstAPIApp.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIApp.DataContext
{
    public class ProgrammingClubDataContext : DbContext
    {
        public ProgrammingClubDataContext(DbContextOptions<ProgrammingClubDataContext> options) : base(options) { }

public DbSet<AnnouncementDTO> Announcements { get; set; }

    }
}
