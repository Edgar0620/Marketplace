using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class ClassifiedAdTitle : ValueObject
    {
        public static ClassifiedAdTitle FromString(string title)
        {
            CheckVaildity(title);
            return new ClassifiedAdTitle(title);
        }

        public static ClassifiedAdTitle FromHtml(string htmlTitle)
        {
            var supportTagsRelpaced = htmlTitle
                .Replace("<i>", "*")
                .Replace("</i>", "*")
                .Replace("<b>", "*")
                .Replace("</b>", "*");

            var value = Regex.Replace(supportTagsRelpaced, "<.*?>", string.Empty);
            CheckVaildity(value);

            return new ClassifiedAdTitle(value);

        }

        public string Value { get; }

        internal ClassifiedAdTitle(string value)=>Value = value;

        public static implicit operator string(ClassifiedAdTitle titel) => titel.Value;

        private static void CheckVaildity(string value)
        {
            if (value.Length > 100)
            {
                throw new ArgumentException("Title cannot be longer that 100 characters", nameof(value));
            }
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
