using EPiServer.Web.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Optimizely.Core.Helpers;
using Optimizely.Interfaces;
using Optimizely.Mediator.Requests.Block;
using Optimizely.Models.Blocks.Global;
using Optimizely.ViewModels.Global.Components;
using System;
using System.Threading.Tasks;

namespace Optimizely.Web.Controllers.Blocks
{
    public class HeaderBlockController : AsyncBlockComponent<HeaderBlock>
    {
        private readonly IMediator _mediator;
        private readonly IProjectLogger<HeaderBlockController> _logger;

        public HeaderBlockController(IMediator mediator, IProjectLogger<HeaderBlockController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        protected async override Task<IViewComponentResult> InvokeComponentAsync(HeaderBlock currentContent)
        {
            var model = new HeaderViewModel();
            try
            {
                model = await _mediator.Send(BlockRequest.Create(currentContent, currentContent.GetCultureInfoFromBlockLanguage()), default)
                    as HeaderViewModel;
            }
            catch (Exception e)
            {
                _logger.LogError(nameof(Index), e, "Error HeaderBlockController getting HeaderViewModel");
            }
            return View("~/Views/Shared/JsonDisplay.cshtml", model);
        }
    }
}
