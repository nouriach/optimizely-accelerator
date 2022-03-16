using EPiServer.Web.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Optimizely.Core.Helpers;
using Optimizely.Interfaces;
using Optimizely.Mediator.Requests.Block;
using Optimizely.Models.Blocks.Global;
using Optimizely.ViewModels.Global.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optimizely.Web.Controllers.Blocks
{
    public class FooterBlockController : AsyncBlockComponent<FooterBlock>
    {
        private readonly IMediator _mediator;
        private readonly IProjectLogger<FooterBlockController> _logger;

        public FooterBlockController(IMediator mediator, IProjectLogger<FooterBlockController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        protected async override Task<IViewComponentResult> InvokeComponentAsync(FooterBlock currentContent)
        {
            var model = new FooterViewModel();
            try
            {
                model = await _mediator.Send(BlockRequest.Create(currentContent, currentContent.GetCultureInfoFromBlockLanguage()), default)
                    as FooterViewModel;
            }
            catch (Exception e)
            {
                _logger.LogError(nameof(Index), e, "ErrorFooterBlockController getting FooterViewModel");
            }
            return View("~/Views/Shared/JsonDisplay.cshtml", model);
        }
    }
}
