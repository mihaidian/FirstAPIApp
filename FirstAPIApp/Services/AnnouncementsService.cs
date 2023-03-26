using FirstAPIApp.DTOs;
using FirstAPIApp.DTOs.CreateUpdateObjects;
using FirstAPIApp.Helpers;
using FirstAPIApp.Repositories;

namespace FirstAPIApp.Services
{
    public class AnnouncementsService:IAnnouncementsService
    {
        private readonly IAnnouncementsRepository _repository;
        public AnnouncementsService(IAnnouncementsRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<AnnouncementDTO>> GetAnnouncementsAsync()
        {
            return await _repository.GetAnnouncementsAsync();
        }
        public async Task<AnnouncementDTO> GetAnnouncementByIdAsync(Guid id)
        {
            return await _repository.GetAnnouncementByIdAsync(id);
        }
        public async Task CreateAnnouncementAsync(AnnouncementDTO announcement)
        {
            ValidationFunctions.ExceptionsWhenDateIsNotValid(announcement.ValidFrom, announcement.ValidTo);
            await _repository.CreateAnnouncementAsync(announcement);

        }
        public async Task<CreateUpdateAnnouncement> UpdateAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement)
        {
            ValidationFunctions.ExceptionsWhenDateIsNotValid(announcement.ValidFrom, announcement.ValidTo);
            return await _repository.UpdateAnnouncementAsync(id, announcement);

        }
        public async Task<CreateUpdateAnnouncement> UpdatePartiallyAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement)
        {
            ValidationFunctions.ExceptionsWhenDateIsNotValid(announcement.ValidFrom, announcement.ValidTo);
            return await _repository.UpdatePartiallyAnnouncementAsync(id, announcement);

        }
        public async Task<bool> DeleteAnnouncementAsync(Guid id)
        {
            return await _repository.DeleteAnnouncementAsync(id);
        }
    }
}
