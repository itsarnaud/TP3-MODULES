using Hotel.Billing.Contracts;

namespace Hotel.Billing;

internal interface IPricingStrategy
{
    decimal CalculateNightRate(BillingRoom room);
}

internal class StandardPricingStrategy : IPricingStrategy
{
    public decimal CalculateNightRate(BillingRoom room) => room.BasePrice;
}

internal class SuitePricingStrategy : IPricingStrategy
{
    public decimal CalculateNightRate(BillingRoom room) => room.BasePrice * 1.2m;
}

internal class FamilyPricingStrategy : IPricingStrategy
{
    public decimal CalculateNightRate(BillingRoom room) => room.BasePrice * 0.9m;
}

internal class PricingStrategyFactory
{
    public IPricingStrategy Create(BillingRoomType roomType) => roomType switch
    {
        BillingRoomType.Standard => new StandardPricingStrategy(),
        BillingRoomType.Suite => new SuitePricingStrategy(),
        BillingRoomType.Family => new FamilyPricingStrategy(),
        _ => new StandardPricingStrategy()
    };
}
