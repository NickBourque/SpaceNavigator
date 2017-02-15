using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardDIExample
{
    public class Visa : IChargeable
    {
        public void ChargeCard()
        {
            Console.WriteLine("Visa Card Charged!");
        }
    }
}
