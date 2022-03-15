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
    public class LinkBlockController : AsyncBlockComponent<LinkBlock>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LinkBlockController> _logger;

        public LinkBlockController(IMediator mediator, ILogger<LinkBlockController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        protected async override Task<IViewComponentResult> InvokeComponentAsync(LinkBlock currentContent)
        {
            var model = new LinkBlockViewModel();

            try
            {
                var request = BlockRequest.Create(currentContent, currentContent.GetCultureInfoFromBlockLanguage());
                model = await _mediator.Send(request, default)
                    as LinkBlockViewModel;
            }
            catch (Exception e)
            {

                _logger.LogError(nameof(Index), e, "Error LinkBlockController getting LinkBlockViewModel");
            }

            return View(model);
        }
    }
}
