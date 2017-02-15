using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardDIExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Shopper shopper = new Shopper(new AMEX());
            shopper.MakePayment();
            Console.Read();
        }
    }
}
