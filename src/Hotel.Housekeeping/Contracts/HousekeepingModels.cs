namespace Hotel.Housekeeping.Contracts;

public enum HousekeepingRoomType
{
  Standard,
  Suite,
  Family
}

public class HousekeepingReservation
{
  public required string Id { get; set; }
  public required string RoomId { get; set; }
  public HousekeepingRoomType RoomType { get; set; }
  public DateTime CheckIn { get; set; }
  public DateTime CheckOut { get; set; }
  public required string Status { get; set; }
}