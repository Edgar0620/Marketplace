using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Marketplace.Contracts;
using static Marketplace.Contracts.ClassifiedAds;

namespace Marketplace.Api
{
    [Route("/ad")]
    [ApiController]
    public class ClassifiedAdsCommandsApiController : ControllerBase
    {
        private readonly ClassifiedAdsApplicationService _applicationService;

        public ClassifiedAdsCommandsApiController(
            ClassifiedAdsApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(V1.Create request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("name")]
        [HttpPut]
        public async Task<IActionResult> Put(V1.SerTitle request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("text")]
        [HttpPut]
        public async Task<IActionResult> Put(V1.UpdateText request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("text")]
        [HttpPut]
        public async Task<IActionResult> Put(V1.UpdatePrice request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("publish")]
        [HttpPut]
        public async Task<IActionResult> Put(V1.RequestToPublish request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }
    }
}
