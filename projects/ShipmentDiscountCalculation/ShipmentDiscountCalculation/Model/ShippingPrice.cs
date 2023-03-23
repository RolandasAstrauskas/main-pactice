using System.Collections.Generic;

namespace ShipmentDiscountCalculation.Model
{
    internal class ShippingPrice
    {
        public string Company { get; set; }
        public Dictionary<char, decimal> PriceBySize { get; set; }
    }
}
