using Hotel.Billing.Contracts;

namespace Hotel.Billing;

internal class BillingService : IBillingService
{
    private readonly InvoiceGenerator _invoiceGenerator;
    private readonly IBillingReservationRepository _reservationRepo;

    public BillingService(
        InvoiceGenerator invoiceGenerator,
        IBillingReservationRepository reservationRepo)
    {
        _invoiceGenerator = invoiceGenerator;
        _reservationRepo = reservationRepo;
    }

    public Invoice GetInvoice(string reservationId)
    {
        var reservation = _reservationRepo.GetById(reservationId)
            ?? throw new Exception($"Reservation {reservationId} not found");

        return _invoiceGenerator.Generate(reservation);
    }
}
