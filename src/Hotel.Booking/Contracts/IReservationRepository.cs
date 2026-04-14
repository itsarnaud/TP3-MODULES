namespace Hotel.Booking.Contracts;

public interface IReservationRepository
{
    void Add(Reservation reservation);
    Reservation? GetById(string id);
    List<Reservation> GetAll();
    void Update(Reservation reservation);
}
