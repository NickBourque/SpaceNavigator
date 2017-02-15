using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardDIExample
{
    public class Shopper
    {
        private IChargeable card; 

        public Shopper(IChargeable card)
        {
            this.card = card;
        }


        public void MakePayment()
        {
            card.ChargeCard();
        }
    }
}
