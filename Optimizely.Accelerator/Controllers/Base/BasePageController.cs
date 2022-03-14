using EPiServer.Core;
using EPiServer.Web.Mvc;
using MediatR;
using Optimizely.Interfaces;
using System;

namespace Optimizely.Accelerator.Web.Controllers.Base
{
    public class BasePageController<T> : PageController<T> where T : PageData
    {
        protected readonly ILogger _logger;
        protected readonly IMediator _mediator;

        public BasePageController(IMediator mediator, ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        internal void JsonDebugCheck()
        {
            if (Request != null && Request.Query["debug"] == "serverjson")
            {
                _logger.LogDebug(nameof(Index), "Enabling JSON");

                ViewBag.DebugJson = "serverjson";
            }
        }
    }
}
