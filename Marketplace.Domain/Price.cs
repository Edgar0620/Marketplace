using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class Price :Money
    {
        
        
        public Price(decimal amount, string currency, ICurrencyLookup currencyLookup) : base(amount,currency,currencyLookup)
        {
            if (amount < 0)
            {
                if (amount == default)
                {
                    throw new ArgumentException("Price cannot be negative", nameof(amount));
                }
            }
        }

        internal Price(decimal amount, string currencyCode) : base(amount, new CurrencyDetails { CurrencyCode = currencyCode }) { }

        public static Price FromDecimal(decimal amount, string currency, ICurrencyLookup currencyLookup)=>new Price(amount, currency, currencyLookup);
    }
}
