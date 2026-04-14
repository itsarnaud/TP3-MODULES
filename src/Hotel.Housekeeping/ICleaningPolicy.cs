using Hotel.Housekeeping.Contracts;

namespace Hotel.Housekeeping;

internal interface ICleaningPolicy
{
    List<CleaningTask> GenerateTasks(HousekeepingReservation reservation);
}

internal class StandardCleaningPolicy : ICleaningPolicy
{
    public List<CleaningTask> GenerateTasks(HousekeepingReservation reservation)
    {
        var tasks = new List<CleaningTask>();

        var current = reservation.CheckIn.AddDays(3);
        while (current < reservation.CheckOut)
        {
            tasks.Add(new CleaningTask
            {
                RoomId = reservation.RoomId,
                Date = current,
                Type = "LinenChange",
                ReservationId = reservation.Id
            });
            current = current.AddDays(3);
        }

        tasks.Add(new CleaningTask
        {
            RoomId = reservation.RoomId,
            Date = reservation.CheckOut,
            Type = "Departure",
            ReservationId = reservation.Id
        });

        return tasks;
    }
}

internal class VipCleaningPolicy : ICleaningPolicy
{
    public List<CleaningTask> GenerateTasks(HousekeepingReservation reservation)
    {
        var tasks = new List<CleaningTask>();

        for (var day = reservation.CheckIn.AddDays(1); day < reservation.CheckOut; day = day.AddDays(1))
        {
            tasks.Add(new CleaningTask
            {
                RoomId = reservation.RoomId,
                Date = day,
                Type = "VipCleaning",
                ReservationId = reservation.Id
            });
        }

        tasks.Add(new CleaningTask
        {
            RoomId = reservation.RoomId,
            Date = reservation.CheckOut,
            Type = "Departure",
            ReservationId = reservation.Id
        });

        return tasks;
    }
}
