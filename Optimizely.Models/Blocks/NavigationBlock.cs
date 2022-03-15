using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Optimizely.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Optimizely.Models.Blocks
{
    [ContentType(DisplayName = "Navigation Block", GUID = "7c42cfa0-7cdb-49eb-8f8f-0f3b67f641be", Description = "")]
    public class NavigationBlock : SiteBlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Add Heading for page",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Heading { get; set; }
    }
}