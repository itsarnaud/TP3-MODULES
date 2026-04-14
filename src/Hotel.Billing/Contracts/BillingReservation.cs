namespace Hotel.Billing.Contracts;

public class BillingReservation
{
  public required string Id { get; set; }
  public required string GuestName { get; set; }
  public required string RoomId { get; set; }
  public BillingRoomType RoomType { get; set; }
  public int GuestCount { get; set; }
  public int Nights { get; set; }
}