namespace ShipmentDiscountCalculation.Interface
{
    internal interface IExtraction
    {
        bool TryReadInput(object input);
        bool TryReadDefaultRules();
    }
}
