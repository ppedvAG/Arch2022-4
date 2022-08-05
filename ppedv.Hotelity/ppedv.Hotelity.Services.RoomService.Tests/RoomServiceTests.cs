using FluentAssertions;
using Moq;
using ppedv.Hotelity.Model.Contracts.Infrastructure;
using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Services.RoomService.Tests
{
    public class RoomServiceTests
    {
        [Fact]
        public void GetAvailableRooms_3_rooms_1_is_booked_results_2_rooms_moq()
        {
            var repoMock = new Mock<IRepository<Zimmer>>();
            repoMock.Setup(x => x.Query()).Returns(() =>
            {
                var r1 = new Zimmer();
                var r2 = new Zimmer();
                var r3 = new Zimmer();

                r2.Buchung.Add(new Buchung() { Buchungsdatum = DateTime.Now });
                return new[] { r1, r2, r3 }.AsQueryable();
            });

            var uowMock = new Mock<IMainRepository>();
            uowMock.Setup(x => x.GetRepo<Zimmer>()).Returns(() => repoMock.Object);

            var roomService = new RoomService(uowMock.Object);

            var result = roomService.GetAvailableRooms(DateTime.Now);

            result.Should().HaveCount(2);
        }
    }
}