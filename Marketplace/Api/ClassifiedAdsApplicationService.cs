using Marketplace.Domain;
using static Marketplace.Contracts.ClassifiedAds;
namespace Marketplace.Api
{
    public class ClassifiedAdsApplicationService: IApplicationService
    {
        private readonly IEntityStore _store;
        private ICurrencyLookup _currencyLookup;

        public ClassifiedAdsApplicationService(
            IEntityStore store,
            ICurrencyLookup currencyLookup)
        {
            _store=store;
            _currencyLookup=currencyLookup;
        }

        public async Task Handle(object command)
        {
            ClassifiedAd classifiedAd;
            switch(command)
            {
                case V1.Create cmd:
                    if (await _store.Exists<ClassifiedAd>(cmd.Id.ToString()))
                        throw new InvalidOperationException($"Entity with id {cmd.Id} already exists");
                    classifiedAd = new ClassifiedAd(
                        new ClassifiedAdId(cmd.Id),
                        new UserId(cmd.Id));
                    await _store.Save(classifiedAd);

                    break;
                default:
                    throw new InvalidOperationException(
                        $"Command type {command.GetType().FullName} is unknown");
            }
        }
    }
}
