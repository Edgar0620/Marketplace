﻿using Marketplace;
using Marketplace.Domain;

namespace Marketplace
{
    public class CreateClassifiedAdHandle : IHandleCommand<Contracts.ClassifiedAds.V1.Create>
    {
        private readonly IEntityStore _store;

        public CreateClassifiedAdHandle(IEntityStore store) => _store = store;

        public Task Handle(Contracts.ClassifiedAds.V1.Create command)
        {
            var classifiedAd = new ClassifiedAd(new ClassifiedAdId(command.Id), new UserId(command.OwnerId));

            return _store.Save(classifiedAd);
        }
    }
}
