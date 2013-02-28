using System;

namespace PaymentKiosk.Transactions.Utilities
{
    public static class InvoiceNumber
    {
        public static string New(string registrationNumber)
        {
            Random rand = new Random();
            int randNumber = rand.Next(9999);
            return registrationNumber + randNumber.ToString();
        }

    }
}
