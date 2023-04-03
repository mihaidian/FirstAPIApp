using FirstAPIApp.DataContext;
using FirstAPIApp.DTOs;
using FirstAPIApp.Repositories;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;

namespace FirstAPIApp.Tests.Repository.Tests
{
    public class AnnouncementsRepositoryTests
    {
        private readonly AnnouncementsRepository _repository;
        private readonly ProgrammingClubDataContext _context;
        public AnnouncementsRepositoryTests() 
        {
            _context = Helpers.DbContextHelper.GetContext();
            _repository=new AnnouncementsRepository( _context,null);
        }
        [Fact]
        public async Task GetAllAnnouncementsAsync_OK()
        {
            //Arrange
            AnnouncementDTO a1 = new ()
            {
                IdAnnouncement = Guid.NewGuid(),
                ValidFrom = DateTime.Now,
                ValidTo = DateTime.Now.AddDays(14),
                EventDate = DateTime.Now.AddDays(15),
                Tags = "announcement 1",
                Text = "announcement 1",
                Title = "Web API Conference"
            };
            AnnouncementDTO a2 = new ()
            {
                IdAnnouncement = Guid.NewGuid(),
                ValidFrom = DateTime.Now,
                ValidTo = DateTime.Now.AddDays(14),
                EventDate = DateTime.Now.AddDays(15),
                Tags = "announcement 1",
                Text = "announcement 1",
                Title = "Web API Conference"
            };
            Helpers.DbContextHelper.AddAnnouncement(_context, a1);
            Helpers.DbContextHelper.AddAnnouncement(_context, a2);
            //Act
            var announcements = await _repository.GetAnnouncementsAsync();

            //Assert
            Assert.Equal(2, announcements.Count());
        }
        [Fact]
        public async Task GetAnnouncementAsync_WithoutData()
        {
            //act
            var announcements=await _repository.GetAnnouncementsAsync();

            //assert
            Assert.NotNull(announcements);
            Assert.Empty(announcements);
        }
        [Fact]
        public async Task GetAnnouncementById_OK()
        {
            //arrange
            AnnouncementDTO a1 = new()
            {
                IdAnnouncement = Guid.NewGuid(),
                ValidFrom = DateTime.Now,
                ValidTo = DateTime.Now.AddDays(14),
                EventDate = DateTime.Now.AddDays(15),
                Tags = "announcement 1",
                Text = "announcement 1",
                Title = "Web API Conference"
            };
            Helpers.DbContextHelper.AddAnnouncement(_context, a1);
            //act
            var result = await _repository.GetAnnouncementByIdAsync((Guid)a1.IdAnnouncement);
            Assert.NotNull(result);
            Assert.Equal(a1.Tags,  result.Tags);
            Assert.Equal(a1.Text, result.Text);
            Assert.Equal(a1.Title, result.Title);
            Assert.Equal(a1.ValidTo, result.ValidTo);
            Assert.Equal(a1.ValidFrom,  result.ValidFrom);

        }
        [Fact]
        public async Task GetAnnouncementById_WhenNotExists()
        {
            //act
            var result = await _repository.GetAnnouncementByIdAsync(Guid.Empty);
            Assert.Null(result);
        }
        [Fact]
        public async Task DeleteAnnouncementAsync_NotOK()
        {
  
            //act
            var result = await _repository.DeleteAnnouncementAsync(Guid.NewGuid());
            //assert
            Assert.False(result);
        }
    }
}
