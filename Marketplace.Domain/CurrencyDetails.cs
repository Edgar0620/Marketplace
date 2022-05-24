using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Framework;
namespace Marketplace.Domain
{
    public interface ICurrencyLookup
    {
        CurrencyDetails FindCurrency(string currencyCode);
    }
    public class CurrencyDetails:ValueObject
    {
        public string CurrencyCode { get; set; }
        public bool InUse { get; set; }
        public int DecimalPlaces { get; set; }

        public static CurrencyDetails None=new CurrencyDetails { InUse = false };

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CurrencyCode;
            yield return InUse;
            yield return DecimalPlaces;
        }
    }
}
