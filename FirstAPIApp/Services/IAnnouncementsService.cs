using FirstAPIApp.DTOs;
using FirstAPIApp.DTOs.CreateUpdateObjects;

namespace FirstAPIApp.Services
{
    public interface IAnnouncementsService
    {
        public Task<IEnumerable<AnnouncementDTO>> GetAnnouncementsAsync();
        public Task<AnnouncementDTO> GetAnnouncementByIdAsync(Guid id);
        public Task CreateAnnouncementAsync(AnnouncementDTO newAnnouncement);
        public Task<CreateUpdateAnnouncement> UpdateAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement);
        public Task<CreateUpdateAnnouncement> UpdatePartiallyAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement);
        public Task<bool> DeleteAnnouncementAsync(Guid id);
    }
}
