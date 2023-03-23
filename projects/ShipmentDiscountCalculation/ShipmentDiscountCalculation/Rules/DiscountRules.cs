namespace ShipmentDiscountCalculation.Rules
{
    internal class DiscountRules
    {
        public decimal MaxAccumulatedDiscounts { get; set; }
        public string PriceMatchingCompany { get; set; }
        public char PriceMatchingSize { get; set; }
        public int FreeDaysPerMonth { get; set; }
        public string FreeDeliveryCompany { get; set; }
    }
}