using EPiServer;
using EPiServer.Core;
using Optimizely.Interfaces;
using Optimizely.Models.Pages;
using System;

namespace Optimizely.Services.Content
{
    public class SiteSettings : ISiteSettings
    {
        private readonly IProjectLogger<SiteSettings> _logger;
        private readonly IContentLoader _contentLoader;

        private readonly Homepage _startPage;

        public SiteSettings(IProjectLogger<SiteSettings> logger, IContentLoader contentLoader)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _contentLoader = contentLoader ?? throw new ArgumentNullException(nameof(contentLoader));

            //Load in the Start Page for the Config Page
            _startPage = GetStartPage();
        }
        public PageReference ConfigurationPage => _startPage?.ConfigPage?.ToPageReference();

        public PageReference StartPageReference
        {
            get
            {
                if (ContentReference.IsNullOrEmpty(ContentReference.StartPage))
                    return null;
                return ContentReference.StartPage;
            }
        }

        private Homepage GetStartPage()
        {
            var startPage = _contentLoader.Get<Homepage>(ContentReference.StartPage);

            if (startPage == null)
            {
                _logger.LogError(nameof(StartPageReference), "Error Getting the Start page for the site.");
            }

            return startPage;
        }

    }
}
