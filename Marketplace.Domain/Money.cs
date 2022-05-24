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

        public static Money FromDecimal(decimal amount,string currency, ICurrencyLookup currencyLookup) =>new Money(amount,currency,currencyLookup);
        public static Money FromString(string amount, string currency, ICurrencyLookup currencyLookup) => new Money(decimal.Parse(amount), currency, currencyLookup);

        protected Money(decimal amount,string currencyCode, ICurrencyLookup currencyLookup)
        {
            if (string.IsNullOrEmpty(currencyCode))
            {
                throw new ArgumentException(nameof(amount), "");
            }
            var currency = currencyLookup.FindCurrency(currencyCode);
            if (!currency.InUse)
            {
                throw new ArgumentException(nameof(currency), "");
            }

            if (decimal.Round(amount,currency.DecimalPlaces)!=amount)
            {
                throw new ArgumentException(nameof(amount), "");
            }
            Amount = amount;
            Currency = currency;
        }

        private Money(decimal amount, CurrencyDetails currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public Money(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; }
        public CurrencyDetails Currency { get; }

        public Money Add(Money summand) 
        {
            if (Currency != summand.Currency)
            {
                throw new CurrencyMismatchException("不同幣值不能比較");
            }
            return new Money(Amount+ summand.Amount,Currency);
        }
        public Money Subtract(Money summand)
        {
            if (Currency != summand.Currency)
            {
                throw new CurrencyMismatchException("不同幣值不能比較");
            }
            return new Money(Amount - summand.Amount, Currency);
        }
        public static Money operator +(Money summand1,Money summand2)=>summand1.Add(summand2);
        public static Money operator -(Money minuend,Money subtrahend)=> minuend.Subtract(subtrahend);

        public override string ToString() => $"{Currency.CurrencyCode} {Amount}";

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
