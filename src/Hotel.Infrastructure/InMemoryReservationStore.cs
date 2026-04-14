using Hotel.Booking.Contracts;
using Hotel.Billing.Contracts;
using Hotel.Housekeeping.Contracts;

namespace Hotel.Infrastructure;

public class InMemoryReservationStore : IReservationRepository, IBillingReservationRepository, IHousekeepingReservationRepository
{
    private readonly Dictionary<string, Reservation> _store = new();
    public void Add(Reservation reservation) => _store[reservation.Id] = reservation;
    Reservation? IReservationRepository.GetById(string id) => _store.GetValueOrDefault(id);
    public List<Reservation> GetAll() => _store.Values.ToList();
    public void Update(Reservation reservation) => _store[reservation.Id] = reservation;
    BillingReservation? IBillingReservationRepository.GetById(string id)
    {
        var reservation = _store.GetValueOrDefault(id);
        if (reservation == null) return null;

        return new BillingReservation
        {
            Id = reservation.Id,
            GuestName = reservation.GuestName,
            RoomId = reservation.RoomId,
            RoomType = Enum.Parse<BillingRoomType>(reservation.RoomType.ToString()),
            GuestCount = reservation.GuestCount,
            Nights = (reservation.CheckOut - reservation.CheckIn).Days
        };
    }

    public List<HousekeepingReservation> GetByDateRange(DateTime from, DateTime to)
    {
        var reservations = _store.Values.Where(r => r.Status != "Cancelled" && r.CheckIn < to && r.CheckOut > from).ToList();
        
        return reservations.Select(reservation => new HousekeepingReservation
        {
            Id = reservation.Id,
            RoomId = reservation.RoomId,
            RoomType = Enum.Parse<HousekeepingRoomType>(reservation.RoomType.ToString()),
            CheckIn = reservation.CheckIn,
            CheckOut = reservation.CheckOut,
            Status = reservation.Status
        }).ToList();
    }
}
