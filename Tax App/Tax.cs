using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Created by Ryan Doiron (doir0008@algonquinlive.com)
 *
 */
namespace Tax_App
{
    class Tax
    {
        public string purchasePrice;
        public string taxAmount;
        public string totalAmount;

        // init the Tax obj and variables
        public Tax()
        {
            purchasePrice = string.Empty;
            taxAmount = string.Empty;
            totalAmount = string.Empty;
        }

        // Calculate taxes method
        public void Calculate(string price, string salesTax)
        {
            double numericPrice = 0.0;
            double numericTax = 0.0;
            double numericTotal = 0.0;
            double numericTotalTax = 0.0;
            bool success = false;

            // Parse the incoming string, removing the $ and if successful set to true
            success = double.TryParse(price.Replace('$', ' '), out numericPrice);
            // If parsed string is good, we proceed
            if(success)
            {
                // Parse the incoming string and if successful set to true
                success = double.TryParse(salesTax, out numericTax);
                // If parsed string is good, we proceed
                if (success)
                {
                    // perform tax calcs
                    numericTotalTax = numericPrice * numericTax;
                    numericTotal = numericTotalTax + numericPrice;
                    // set text values formatted to currency strings
                    purchasePrice = numericPrice.ToString("c");
                    taxAmount = numericTotalTax.ToString("c");
                    totalAmount = numericTotal.ToString("c");
                }
            }
        }
    }
}
