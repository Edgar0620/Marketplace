using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class ClassifiedAd
    {
        public ClassifiedAdId Id { get; private set; }
        private UserId _ownerId;

        public ClassifiedAd(ClassifiedAdId id, UserId owerId)
        {
            Id = id;
            _ownerId = owerId;
        }

        public void CreateClassifiedAd(ClassifiedAdId id, UserId owerId)
        {
            var classifiedAd=new ClassifiedAd(id, owerId);
            // store the entity somehow
        }

        public void SetTitle(string title)=> _title=title;

        public void UpdateText(string text)=> _text=text;

        public void UpdatePrice(decimal price)=> _price=price;

        private string _title;
        private string _text;
        private decimal _price;
    }
}
