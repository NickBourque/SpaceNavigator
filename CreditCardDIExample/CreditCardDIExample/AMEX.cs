using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardDIExample
{
    public class AMEX : IChargeable
    {
        public void ChargeCard()
        {
            Console.WriteLine("AMEX Charged!");
        }
    }
}
