namespace Hotel.Billing.Contracts;

public interface IBillingService
{
  Invoice GetInvoice(string reservationId);
}