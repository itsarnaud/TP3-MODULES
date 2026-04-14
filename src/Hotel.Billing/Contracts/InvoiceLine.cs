namespace Hotel.Billing.Contracts;

public class InvoiceLine
{
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
