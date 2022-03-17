using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Optimizely.Models.Blocks.Global;
using System.ComponentModel.DataAnnotations;

namespace Optimizely.Models.Config
{
    [ContentType(
        DisplayName = "Config Page", 
        GUID = "137a4558-d3ee-44c8-a6f8-b61e120cfd8d", 
        Description = "Page for holding the configuration for the site.")]
    public class ConfigPage : PageData
    {
        [Display(Name = "Header",
            Description = "This is the configuration for the Header.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual HeaderBlock HeaderBlock { get; set; }

        [Display(Name = "Footer",
            Description = "This is the configuration for the Footer.",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual FooterBlock FooterBlock { get; set; }
    }
}