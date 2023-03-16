using FirstAPIApp.DTOs;

namespace FirstAPIApp.Repositories
{
    public interface IAnnouncementsRepository
    {
        public Task<IEnumerable<AnnouncementDTO>> GetAnnouncementsAsync();
    }
}
