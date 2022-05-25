using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class InvalidEntityStateException :Exception
    {
        public InvalidEntityStateException(Object entity,string message):base($"Entuty {entity.GetType().Name} state change rejected, {message}")
        {

        }
    }
}
