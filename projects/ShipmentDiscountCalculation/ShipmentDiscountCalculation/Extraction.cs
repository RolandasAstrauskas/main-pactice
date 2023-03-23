using ShipmentDiscountCalculation.Interface;
using ShipmentDiscountCalculation.Model;
using ShipmentDiscountCalculation.Rules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ShipmentDiscountCalculation
{  

    internal class Extraction : IExtraction
    {
        private List<ShippingPrice> shippingPrices;
        private DiscountRules discountRules;

        public bool TryCalculatePricesWithDiscount(string input, out string output)
        {
            output = string.Empty;

            TryExtractInput(input, out List<Shipment> shipments);

            TryCalculatePrices(shipments, out List<Shipment> shipmentsWithPrice);

            return true;
        }

        private void TryCalculatePrices(List<Shipment> shipments, out List<Shipment> shipmentsWithPrice)
        {
            shipmentsWithPrice = new List<Shipment>();

            decimal lowestPrice = shippingPrices.OrderBy(x => x.PriceBySize[discountRules.PriceMatchingSize]).First().PriceBySize[discountRules.PriceMatchingSize];

            foreach (Shipment shipment in shipments)
            {
                foreach (ShippingPrice shippingPrice in shippingPrices)
                {
                    if (shipment.ShipmentCompany.Equals(shippingPrice.Company, StringComparison.OrdinalIgnoreCase))
                    {
                        shipment.Price = shippingPrice.PriceBySize[shipment.Size];
                        shipment.Discount = shipment.ShipmentCompany.Equals(discountRules.PriceMatchingCompany, StringComparison.OrdinalIgnoreCase)
                            && shipment.Size.Equals(discountRules.PriceMatchingSize) ? shipment.Price - lowestPrice : 0;
                        shipmentsWithPrice.Add(shipment);
                    }
                }                
            }
        }

        private void TryExtractInput(string input, out List<Shipment> shipments)
        {
            shipments = new List<Shipment>();

            string[] lines = input.Split(
                 new string[] { Environment.NewLine },
                 StringSplitOptions.None
             );

            foreach (string single in lines)
            {
                string[] splited = single.Split(' ');

                Shipment shipment = new Shipment();
                shipment.Date = DateTime.ParseExact(splited[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);

                if (char.TryParse(splited[1], out char size))
                {
                    shipment.Size = size;
                    shipment.ShipmentCompany = splited[2];
                    shipments.Add(shipment);

                    continue;
                }

                shipment.ShipmentCompany = splited[1];
                shipments.Add(shipment);
            }
        }

        public void SetDefaultCompaniesPrices()
        {
            shippingPrices = new List<ShippingPrice>();

            shippingPrices.Add(new ShippingPrice
            {
                Company = "LP",
                PriceBySize = new Dictionary<char, decimal> { ['S'] = 1.50M, ['M'] = 4.90M, ['L'] = 6.90M }
            });

            shippingPrices.Add(new ShippingPrice
            {
                Company = "MR",
                PriceBySize = new Dictionary<char, decimal> { ['S'] = 2, ['M'] = 3, ['L'] = 4 }
            });
        }

        public void SetDefaultDiscountRules()
        {
            discountRules = new DiscountRules
            {
                FreeDaysPerMonth = 1,
                FreeDeliveryCompany = "LP",
                PriceMatchingCompany = "LP",
                PriceMatchingSize = 'S',
                MaxAccumulatedDiscounts = 10
            };           
        }
    }
}
