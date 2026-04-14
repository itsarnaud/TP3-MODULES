using Hotel.Booking.Contracts;
using Hotel.Billing.Contracts;

namespace Hotel.Infrastructure;

public class InMemoryRoomStore : IRoomRepository, IBillingRoomRepository
{
    private readonly List<Room> _rooms = new()
    {
        new Room { Id = "101", Type = RoomType.Standard, Capacity = 2, BasePrice = 80m },
        new Room { Id = "102", Type = RoomType.Standard, Capacity = 2, BasePrice = 80m },
        new Room { Id = "201", Type = RoomType.Suite, Capacity = 4, BasePrice = 200m },
        new Room { Id = "301", Type = RoomType.Family, Capacity = 6, BasePrice = 120m }
    };

    public Room? GetById(string id) => _rooms.FirstOrDefault(r => r.Id == id);
    
    public List<Room> GetAvailable(DateTime checkIn, DateTime checkOut, List<Reservation> existingReservations)
    {
        var overlapping = existingReservations
            .Where(r => r.Status != "Cancelled" && r.CheckIn < checkOut && r.CheckOut > checkIn)
            .Select(r => r.RoomId)
            .ToHashSet();

        return _rooms.Where(r => !overlapping.Contains(r.Id)).ToList();
    }

    BillingRoom? IBillingRoomRepository.GetById(string id)
    {
        var room = _rooms.FirstOrDefault(r => r.Id == id);
        if (room == null) return null;

        return new BillingRoom
        {
            Id = room.Id,
            Type = Enum.Parse<BillingRoomType>(room.Type.ToString()),
            BasePrice = room.BasePrice
        };
    }
}
