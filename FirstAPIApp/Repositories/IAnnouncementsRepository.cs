using FirstAPIApp.DTOs;
using FirstAPIApp.DTOs.CreateUpdateObjects;

namespace FirstAPIApp.Repositories
{
    public interface IAnnouncementsRepository
    {
        public Task<IEnumerable<AnnouncementDTO>> GetAnnouncementsAsync();
        public Task<AnnouncementDTO> GetAnnouncementByIdAsync(Guid id);
        public Task CreateAnnouncementAsync(AnnouncementDTO announcement);
        public Task <CreateUpdateAnnouncement> UpdateAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement);
        public Task<CreateUpdateAnnouncement> UpdatePartiallyAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement);
        public Task<bool> DeleteAnnouncementAsync(Guid id);
    }
}
