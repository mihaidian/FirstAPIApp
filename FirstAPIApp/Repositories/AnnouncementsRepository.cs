using FirstAPIApp.DTOs;
using FirstAPIApp.DataContext;
using Microsoft.EntityFrameworkCore;
using FirstAPIApp.DTOs.CreateUpdateObjects;
using AutoMapper;

namespace FirstAPIApp.Repositories
{
    public class AnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        private readonly IMapper _mapper;
        //const ->compile time -> asignata valoarea cand declaram
        //readonly -> runtime time -> asignam valoarea in constructor
        public AnnouncementsRepository(ProgrammingClubDataContext  context,IMapper mapper)
        {
        _context= context;
            _mapper= mapper;
        }

        public async Task<IEnumerable<AnnouncementDTO>> GetAnnouncementsAsync()
        {
            return await _context.Announcements.ToListAsync();
        }
        public async Task<AnnouncementDTO> GetAnnouncementByIdAsync(Guid id)
        {
            return await _context.Announcements.SingleOrDefaultAsync(a => a.IdAnnouncement == id);
        }
        public async Task CreateAnnouncementAsync(AnnouncementDTO announcement)
        {
            announcement.IdAnnouncement=Guid.NewGuid();
            _context.Announcements.Add(announcement);
            await _context.SaveChangesAsync();
        }
        public async Task<CreateUpdateAnnouncement> UpdateAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement)
        {
            
            if (!await ExistAnnouncementAsync(id))
            {
                return null;
            }
            //annoucement.EventDate=announcementUpdate.EventDate;
            //annoucement.Text=announcementUpdate.Text;
            //annoucement.Title=announcementUpdate.Title;
            //annoucement.ValidFrom=announcementUpdate.ValidFrom;
            //annoucement.ValidTo=announcementUpdate.ValidTo;
            //annoucement.Tags=announcementUpdate.Tags;

            var updatedAnnouncement=_mapper.Map<AnnouncementDTO>(announcement);
            updatedAnnouncement.IdAnnouncement = id;
            _context.Update(updatedAnnouncement);
            await _context.SaveChangesAsync();
            return announcement;
        }
        private async Task<bool> ExistAnnouncementAsync(Guid id)
        {
            return await _context.Announcements.CountAsync(a => a.IdAnnouncement == id) > 0;
        }
        public async Task <CreateUpdateAnnouncement> UpdatePartiallyAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement)
        {
            var announcementFromDb=await GetAnnouncementByIdAsync(id);
            if(announcementFromDb==null)
            {
                return null;
            }
            if(!string.IsNullOrEmpty(announcement.Title)&& announcement.Title != announcementFromDb.Title) 
            {
announcementFromDb.Title=announcement.Title;
            }
            if (!string.IsNullOrEmpty(announcement.Text) && announcement.Text != announcementFromDb.Text)
            {
                announcementFromDb.Text = announcement.Text;
            }
            if(announcement.ValidFrom.HasValue && announcement.ValidFrom != announcementFromDb.ValidFrom) 
            {
                announcementFromDb.ValidFrom = announcement.ValidFrom;
            }
            if (announcement.ValidTo.HasValue && announcement.ValidTo != announcementFromDb.ValidTo)
            {
                announcementFromDb.ValidTo = announcement.ValidTo;
            }
            if (!string.IsNullOrEmpty(announcement.Tags) && announcement.Tags != announcementFromDb.Tags)
            {
                announcementFromDb.Tags = announcement.Tags;
            }
            if (announcement.EventDate.HasValue && announcement.EventDate != announcementFromDb.EventDate)
            {
                announcementFromDb.EventDate = announcement.EventDate;
            }
            _context.Announcements.Update(announcementFromDb);
            await _context.SaveChangesAsync();
            return announcement;
        }
     public async Task<bool> DeleteAnnouncementAsync(Guid id)
        {
            AnnouncementDTO announcement = await GetAnnouncementByIdAsync(id);
            if (announcement == null) { return false; }
            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
