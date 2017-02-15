using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardDIExample
{
    public class MasterCard : IChargeable
    {
        public void ChargeCard()
        {
            Console.WriteLine("MasterCard Charged!");
        }
    }
}
