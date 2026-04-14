namespace Hotel.Billing.Contracts;

public enum BillingRoomType
{
  Standard,
  Suite,
  Family
}

public class BillingRoom
{
  public required string Id { get; set; }
  public BillingRoomType Type { get; set; }
  public decimal BasePrice { get; set; }
}