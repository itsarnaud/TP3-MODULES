namespace Hotel.Housekeeping.Contracts;

public interface ICleaningNotifier
{
    void NotifyNewTasks(List<CleaningTask> tasks);
}
