using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Optimizely.Models.Base;
using Optimizely.Models.Config;
using System;
using System.ComponentModel.DataAnnotations;

namespace Optimizely.Models.Pages
{
    [ContentType(DisplayName = "Homepage", GUID = "d208b010-72b8-49ec-82a2-54032315eb67", Description = "")]
    public class Homepage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "###.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Title { get; set; }

        [Display(Name = "Config Page",
            Description = "Link to the Configuration Page.",
            GroupName = SystemTabNames.Settings,
            Order = 200)]
        [AllowedTypes(typeof(ConfigPage))]
        public virtual ContentReference ConfigPage { get; set; }
    }
}