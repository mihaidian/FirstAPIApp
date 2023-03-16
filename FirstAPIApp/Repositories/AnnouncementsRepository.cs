using FirstAPIApp.DTOs;
using FirstAPIApp.DataContext;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIApp.Repositories
{
    public class AnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        //const ->compile time -> asignata valoarea cand declaram
        //readonly -> runtime time -> asignam valoarea in constructor
        public AnnouncementsRepository(ProgrammingClubDataContext  context)
        {
        _context= context;
        }

        public async Task<IEnumerable<AnnouncementDTO>> GetAnnouncementsAsync()
        {
            return await _context.Announcements.ToListAsync();
        }
    }
}
