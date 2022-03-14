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
    public class HomepageController : BasePageController<Homepage>
    {
        public HomepageController(IMediator mediator, ILogger<HomepageController> logger) : base(mediator, logger){}
        public async Task<ActionResult> Index(Homepage currentPage, CancellationToken cancellationToken)
        {
            var model = new HomepageViewModel();
            try
            {
                model = await _mediator.Send(new PageRequest<Homepage>(currentPage, currentPage.Language), cancellationToken) as HomepageViewModel;
            }
            catch (Exception e)
            {
                _logger.LogError(nameof(Index), e, "Error HomepageController getting HomepageViewModel");
            }

            return View(model);
        }
    }
}
