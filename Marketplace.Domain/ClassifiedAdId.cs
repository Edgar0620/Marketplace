using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class ClassifiedAdId:ValueObject
    {
        private Guid _value;

        public ClassifiedAdId (Guid value)
        {
            if (value == default)
            {
                throw new ArgumentException("Classified Ad id cannot be empty", nameof(value));
            }
            _value = value;
        }

        public static implicit operator Guid(ClassifiedAdId self)=>self._value;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _value;
        }
    }
}
