using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class ClassifiedAdText : ValueObject
    {
        public static ClassifiedAdText FromString(string title) => new ClassifiedAdText(title);

        public static ClassifiedAdText FromHtml(string htmlTitle)
        {
            var supportTagsRelpaced = htmlTitle
                .Replace("<i>", "*")
                .Replace("</i>", "*")
                .Replace("<b>", "*")
                .Replace("</b>", "*");
            return new ClassifiedAdText(Regex.Replace(supportTagsRelpaced,"<.*?>",string.Empty));

        }

        private readonly string _value;

        public ClassifiedAdText(string value)
        {
            if (value.Length>100)
            {
                throw new ArgumentException("Title cannot be longer that 100 characters", nameof(value));
            }

            _value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _value;
        }
    }
}
