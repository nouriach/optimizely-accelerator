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
    public class BasicContentPageController : BasePageController<BasicContentPage>
    {
        public BasicContentPageController(IMediator mediator, IProjectLogger<BasicContentPageController> logger) : base(mediator, logger){}

        public async Task<ActionResult> Index(BasicContentPage currentPage, CancellationToken cancellationToken)
        {
            var model = new BasicContentPageViewModel();

            try
            {
                model = await _mediator.Send(new PageRequest<BasicContentPage>(currentPage, currentPage.Language), cancellationToken) as BasicContentPageViewModel;
            }
            catch (Exception e)
            {
                _logger.LogError(nameof(Index), e, "Error BasicContentPageController getting BasicContentPageViewModel");
            }
            return View(model);
        }
    }
}
