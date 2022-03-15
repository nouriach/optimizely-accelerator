using MediatR;
using Microsoft.AspNetCore.Mvc;
using Optimizely.Accelerator.Web.Controllers.Base;
using Optimizely.Interfaces;
using Optimizely.Mediator.Requests.Page;
using Optimizely.Models.Pages;
using Optimizely.ViewModels.Pages.Components;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optimizely.Web.Controllers.Pages
{
    public class BasicTwoColumnContentPageController : BasePageController<BasicTwoColumnContentPage>
    {
        public BasicTwoColumnContentPageController(IMediator mediator, ILogger<BasicTwoColumnContentPageController> logger) : base(mediator, logger) {} 
        public async Task<ActionResult> Index(BasicTwoColumnContentPage currentPage, CancellationToken cancellationToken)
        {
            var model = new BasicTwoColumnContentPageViewModel();
            try
            {
                model = await _mediator.Send(new PageRequest<BasicTwoColumnContentPage>(currentPage, currentPage.Language), cancellationToken) as BasicTwoColumnContentPageViewModel;
            }
            catch (Exception e)
            {
                _logger.LogError(nameof(Index), e, "Error BasicTwoColumnContentPageController getting BasicTwoColumnContentPageViewModel");
            }
            return View(model);
        }
    }
}
