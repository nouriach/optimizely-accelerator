using EPiServer;
using Optimizely.Interfaces;
using Optimizely.Models.Blocks.Global;
using Optimizely.Models.Config;
using System;

namespace Optimizely.Services.Content
{
    public class ConfigService : IConfigService
    {
        private readonly IProjectLogger<ConfigService> _logger;
        private readonly ISiteSettings _siteSettings;
        private readonly IContentLoader _contentLoader;

        private ConfigPage _configPage;

        public ConfigService(IProjectLogger<ConfigService> logger, ISiteSettings siteSettings,
            IContentLoader contentLoader)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _siteSettings = siteSettings ?? throw new ArgumentNullException(nameof(siteSettings));
            _contentLoader = contentLoader ?? throw new ArgumentNullException(nameof(contentLoader));
        }
        public HeaderBlock Header => ConfigPage?.HeaderBlock;
        public FooterBlock Footer => ConfigPage?.FooterBlock;

        private ConfigPage ConfigPage
        {
            get
            {
                if (_configPage == null)
                {
                    _configPage = GetConfigPage();
                }

                return _configPage;
            }
        }

        private ConfigPage GetConfigPage()
        {
            var configPageReference = _siteSettings.ConfigurationPage;

            if (configPageReference == null)
            {
                _logger.LogError(nameof(GetConfigPage), $"Error no Config Page Set");
                return null;
            }

            var configPage = _contentLoader.Get<ConfigPage>(configPageReference);

            if (configPage == null)
            {
                _logger.LogError(nameof(GetConfigPage), $"Error Loading the Config for the site from Optimizely {configPageReference}");
            }

            return configPage;
        }
    }
}
