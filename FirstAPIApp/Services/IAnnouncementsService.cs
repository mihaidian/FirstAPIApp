using FirstAPIApp.DTOs;

namespace FirstAPIApp.Services
{
    public interface IAnnouncementsService
    {
        public Task<IEnumerable<AnnouncementDTO>> GetAnnouncementsAsync();
        
    }
}
