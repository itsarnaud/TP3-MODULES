namespace Hotel.Billing.Contracts;

public interface IBillingReservationRepository
{
  BillingReservation? GetById(string Id);
}