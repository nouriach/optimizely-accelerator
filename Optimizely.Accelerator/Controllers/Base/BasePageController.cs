using EPiServer.Core;
using EPiServer.Web.Mvc;
using Optimizely.Accelerator.Interfaces;
using System;

namespace Optimizely.Accelerator.Web.Controllers.Base
{
    public class BasePageController<T> : PageController<T> where T : PageData
    {
        private readonly ILogger _logger;

        public BasePageController(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
