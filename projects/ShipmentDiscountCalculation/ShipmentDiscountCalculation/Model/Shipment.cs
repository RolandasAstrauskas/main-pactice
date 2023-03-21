using System;

namespace ShipmentDiscountCalculation.Model
{
    internal class Shipment
    {
        public DateTime Date { get; set; }
        public char Size { get; set; }
        public string ShipmentCompany { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
