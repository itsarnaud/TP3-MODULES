using Hotel.Booking.Contracts;
using Hotel.Housekeeping.Contracts;

namespace Hotel.Infrastructure;

public class EmailSender : IConfirmationSender, ICleaningNotifier
{
    public void SendBookingConfirmation(string email, string guestName, string reservationId,
        DateTime checkIn, DateTime checkOut, string roomId)
    {
        Console.WriteLine($"  [EMAIL] To: {email}");
        Console.WriteLine($"    Booking confirmed for {guestName}");
        Console.WriteLine($"    Reservation: {reservationId} | Room: {roomId}");
        Console.WriteLine($"    {checkIn:d} → {checkOut:d}");
    }

    public void NotifyNewTasks(List<CleaningTask> tasks)
    {
        Console.WriteLine("  [EMAIL] Housekeeping notified of new tasks:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"    - {task.Type} in room {task.RoomId} (Res: {task.ReservationId}) on {task.Date:d}");
        }
    }
}
