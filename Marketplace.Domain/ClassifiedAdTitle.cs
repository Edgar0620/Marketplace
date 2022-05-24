using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class ClassifiedAdTitle : ValueObject
    {
        public static ClassifiedAdTitle FromString(string title) => new ClassifiedAdTitle(title);

        public static ClassifiedAdTitle FromHtml(string htmlTitle)
        {
            var supportTagsRelpaced = htmlTitle
                .Replace("<i>", "*")
                .Replace("</i>", "*")
                .Replace("<b>", "*")
                .Replace("</b>", "*");
            return new ClassifiedAdTitle(Regex.Replace(supportTagsRelpaced,"<.*?>",string.Empty));

        }

        private readonly string _value;

        public ClassifiedAdTitle(string value)
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
