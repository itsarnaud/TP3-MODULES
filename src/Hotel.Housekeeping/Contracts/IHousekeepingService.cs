namespace Hotel.Housekeeping.Contracts;

public interface IHousekeepingService
{
    List<CleaningTask> GetSchedule(DateTime date);
    void NotifyHousekeeping(DateTime date);
}