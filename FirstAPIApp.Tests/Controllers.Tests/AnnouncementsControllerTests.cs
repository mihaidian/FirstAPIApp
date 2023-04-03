using AutoMapper;
using FirstAPIApp.Controllers;
using FirstAPIApp.DataContext;
using FirstAPIApp.DTOs;
using FirstAPIApp.Helpers;
using FirstAPIApp.Repositories;
using FirstAPIApp.Services;
using FirstAPIApp.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace FirstAPIApp.Tests.Controllers.Tests
{
    public class AnnouncementsControllerTests
    {
        private readonly AnnouncementsRepository _repository;
        private readonly ProgrammingClubDataContext _context;
        private readonly AnnouncementsService _service;
        private readonly Mock<ILogger<AnnouncementsController>> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AnnouncementsController _controller;
        public AnnouncementsControllerTests() 
        {
            _context = DbContextHelper.GetContext();
            _mockLogger= new Mock<ILogger<AnnouncementsController>>();
            _mockMapper= new Mock<IMapper>();
            _repository=new AnnouncementsRepository( _context, _mockMapper.Object);
            _service = new AnnouncementsService(_repository);
            _controller=new AnnouncementsController(_service, _mockLogger.Object);
        }
        [Fact]
         public async Task GetAll_Should_Return_OK()
        {
            //Arrange
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
            AnnouncementDTO a2 = new()
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
            
            var announcements = await _repository.GetAnnouncementsAsync();
            //Act
            var result = await _controller.GetAllAsync();

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetAll_Should_Return_NoContent()
        {
            //Act
            ObjectResult result =(ObjectResult) await _controller.GetAllAsync();

            //Assert
            Assert.Equal(204, result.StatusCode);
            Assert.Equal(ErrorMessagesEnum.NoElementFound, result.Value);
        }
    }
}
