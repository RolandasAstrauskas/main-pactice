namespace ShipmentDiscountCalculation.Interface
{
    internal interface IExtraction
    {
        bool TryCalculatePricesWithDiscount(string input, out string output);
        void SetDefaultCompaniesPrices();
        void SetDefaultDiscountRules();
    }
}
