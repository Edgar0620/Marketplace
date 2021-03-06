using Marketplace.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class UserId:ValueObject
    {
        private readonly Guid _value;

        public UserId (Guid value)
        {
            if (value == default)
            {
                throw new ArgumentException("User id cannot be empty", nameof(value));
            }

            _value = value;
        }

        public static implicit operator Guid(UserId self) => self._value;
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _value;
        }
    }
}
