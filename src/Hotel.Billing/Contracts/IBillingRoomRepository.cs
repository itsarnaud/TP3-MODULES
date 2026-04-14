namespace Hotel.Billing.Contracts;

public interface IBillingRoomRepository
{
  BillingRoom? GetById(string id);
}