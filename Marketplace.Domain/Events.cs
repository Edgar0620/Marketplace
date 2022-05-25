using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public static class Events
    {
        public class ClassifiedAdCreated
        {
            public ClassifiedAdId Id { get; set; }
            public UserId OwnerId { get; set; }
        }

        public class ClassifiedAdTitleChanged
        {
            public ClassifiedAdId Id { get; set; }
            public ClassifiedAdTitle Title { get; set; }
        }
        public class ClassifiedAdTextUpdated
        {
            public ClassifiedAdId Id { get; set; }
            public ClassifiedAdText Text { get; set; }
        }
        public class ClassifiedAdPriceUpdated
        {
            public ClassifiedAdId Id { get; set; }
            public decimal Price { get; set; }
            public string CurrencyCode { get; set; }
        }

        public class ClassifiedAdSentForReview
        {
            public ClassifiedAdId Id { get; set; }
        }
    }
}
