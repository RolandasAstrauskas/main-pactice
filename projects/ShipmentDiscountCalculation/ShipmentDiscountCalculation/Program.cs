using System;
using System.IO;

namespace ShipmentDiscountCalculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // string input = Console.In.ReadToEnd();      


              string input = "2015-02-01 S MR\r\n" +
                                "2015-02-02 S MR\r\n" +
                                "2015-02-03 L LP\r\n" +
                                "2015-02-05 S LP\r\n" +
                                "2015-02-06 S MR\r\n" +
                                "2015-02-06 L LP\r\n" +
                                "2015-02-07 L MR\r\n" +
                                "2015-02-08 M MR\r\n" +
                                "2015-02-09 L LP\r\n" +
                                "2015-02-10 L LP\r\n" +
                                "2015-02-10 S MR\r\n" +
                                "2015-02-10 S MR\r\n" +
                                "2015-02-11 L LP\r\n" +
                                "2015-02-12 M MR\r\n" +
                                "2015-02-13 M LP\r\n" +
                                "2015-02-15 S MR\r\n" +
                                "2015-02-17 L LP\r\n" +
                                "2015-02-17 S MR\r\n" +
                                "2015-02-24 L LP\r\n" +
                                "2015-02-28 CUSPS\r\n" +
                                "2015-03-01 S MR";

            Extraction extraction = new Extraction();
            extraction.SetDefaultCompaniesPrices();
            extraction.SetDefaultDiscountRules();

            if (extraction.TryCalculatePricesWithDiscount(input, out string calculatedPrices))
            {
                Console.Write(calculatedPrices);
            }

            Console.Write("Prices were extracted wrong");
        }
    }
}
