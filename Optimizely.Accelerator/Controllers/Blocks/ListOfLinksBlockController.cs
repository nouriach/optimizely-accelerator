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
    public class ListOfLinksBlockController : AsyncBlockComponent<ListOfLinksBlock>
    {
        private readonly IMediator _mediator;
        private readonly IProjectLogger<ListOfLinksBlockController> _logger;

        public ListOfLinksBlockController(IMediator mediator, IProjectLogger<ListOfLinksBlockController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        protected async override Task<IViewComponentResult> InvokeComponentAsync(ListOfLinksBlock currentContent)
        {
            var model = new ListOfLinksBlockViewModel();

            try
            {
                model = await _mediator.Send(BlockRequest.Create(currentContent, currentContent.GetCultureInfoFromBlockLanguage()), default)
                    as ListOfLinksBlockViewModel;
            }
            catch (Exception e)
            {

                _logger.LogError(nameof(Index), e, "Error ListOfLinksBlockController getting ListOfLinksBlockViewModel");
            }

            return View("~/Views/Shared/JsonDisplay.cshtml", model);
        }
    }
}
