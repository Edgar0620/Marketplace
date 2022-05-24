using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class Money : ValueObject
    {
        private const string DefaultCurrency = "EUR";

        public static Money FromDecimal(decimal amount)=>new Money(amount);
        public static Money FromString(string amount) => new Money(decimal.Parse(amount));

        protected Money(decimal amount,string currencyCode="EUR")
        {
            if (decimal.Round(amount,2)!=amount)
            {
                throw new ArgumentException(nameof(amount), "Amount cannot have more than two decimals");
            }
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public decimal Amount { get; }
        public string CurrencyCode { get; }

        public Money Add(Money summand) 
        {
            if (CurrencyCode!=summand.CurrencyCode)
            {
                throw new CurrencyMismatchException("不同幣值不能比較");
            }
            return new Money(Amount+ summand.Amount);
        }
        public Money Subtract(Money summand)
        {
            if (CurrencyCode != summand.CurrencyCode)
            {
                throw new CurrencyMismatchException("不同幣值不能比較");
            }
            return new Money(Amount - summand.Amount);
        }
        public static Money operator +(Money summand1,Money summand2)=>summand1.Add(summand2);
        public static Money operator -(Money minuend,Money subtrahend)=> minuend.Subtract(subtrahend);
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Amount;
        }
    }

    public class CurrencyMismatchException:Exception
    {
        public CurrencyMismatchException(string message):base(message)
        {

        }
    }

}
