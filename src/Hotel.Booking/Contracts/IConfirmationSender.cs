namespace Hotel.Booking.Contracts;

public interface IConfirmationSender
{
    void SendBookingConfirmation(string email, string guestName, string reservationId,
        DateTime checkIn, DateTime checkOut, string roomId);
}
