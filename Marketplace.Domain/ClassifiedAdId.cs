using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class ClassifiedAdId:ValueObject
    {
        private readonly Guid _value;

        public ClassifiedAdId (Guid value)
        {
            if (value == default)
            {
                throw new ArgumentException("Classified Ad id cannot be empty", nameof(value));
            }
            _value = value;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _value;
        }
    }
}
