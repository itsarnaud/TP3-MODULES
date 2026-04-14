namespace Hotel.Housekeeping.Contracts;

public interface IHousekeepingReservationRepository
{
  List<HousekeepingReservation> GetByDateRange(DateTime from, DateTime to);
}