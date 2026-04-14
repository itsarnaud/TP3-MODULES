namespace Hotel.Booking.Contracts;

public interface IBookingService
{
  Reservation CreateReservation(string guestName, RoomType roomType,
    DateTime checkIn, DateTime checkOut, int guestCount,
    string email, string phone, string cancellationPolicy = "Flexible");
  void CheckIn(string reservationId);
  void CheckOut(string reservationId);
}