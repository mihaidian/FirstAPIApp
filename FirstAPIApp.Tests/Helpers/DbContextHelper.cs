using FirstAPIApp.DataContext;
using FirstAPIApp.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIApp.Tests.Helpers
{
    public class DbContextHelper
    {
        public static ProgrammingClubDataContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ProgrammingClubDataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).
                UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).Options;

            var databaseContext = new ProgrammingClubDataContext(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }
        public static AnnouncementDTO AddAnnouncement(ProgrammingClubDataContext context, AnnouncementDTO announcement)
        {
            context.Add(announcement);
            context.SaveChangesAsync();
            context.Entry(announcement).State = EntityState.Detached;
            return announcement;
        }
    }
}
