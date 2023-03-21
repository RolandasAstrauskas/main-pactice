namespace ShipmentDiscountCalculation.Rules
{
    internal class DiscountRules
    {
        public decimal MaxAccumulatedDiscounts { get; set; }
        public string PriceMatchingSize { get; set; }
        public int FreeDaysPerMonth { get; set; }
        public int FreeDeliveryDompany { get; set; }
    }
}