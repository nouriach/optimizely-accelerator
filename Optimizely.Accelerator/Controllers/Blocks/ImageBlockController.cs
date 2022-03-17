using EPiServer.Web.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Optimizely.Core.Helpers;
using Optimizely.Interfaces;
using Optimizely.Mediator.Requests.Block;
using Optimizely.Models.Blocks;
using Optimizely.ViewModels.Blocks.Components;
using System;
using System.Threading.Tasks;

namespace Optimizely.Web.Controllers.Blocks
{
    public class ImageBlockController : AsyncBlockComponent<ImageBlock>
    {
        private readonly IMediator _mediator;
        private readonly IProjectLogger<ImageBlockController> _logger;

        public ImageBlockController(IMediator mediator, IProjectLogger<ImageBlockController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        protected async override Task<IViewComponentResult> InvokeComponentAsync(ImageBlock currentContent)
        {
            var model = new ImageBlockViewModel();
            try
            {
                model = await _mediator.Send(BlockRequest.Create(currentContent, currentContent.GetCultureInfoFromBlockLanguage()), default) as ImageBlockViewModel;
            }
            catch (Exception e)
            {

                _logger.LogError(nameof(Index), e, "Error ImageBlockController getting ImageBlockViewModel");
            }
            return View("~/Views/Shared/JsonDisplay.cshtml", model);
        }
    }
}
