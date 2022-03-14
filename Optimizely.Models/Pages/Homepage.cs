using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Optimizely.Models.Base;
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

    }
}