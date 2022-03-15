using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Optimizely.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Optimizely.Models.Blocks.Global
{
    [ContentType(DisplayName = "List Of Links Block", GUID = "ed9a6bef-927c-4fb0-83bd-9041305e21a3", Description = "")]
    public class ListOfLinksBlock : SiteBlockData
    {
        [CultureSpecific]
        [Required]
        [Display(
            Name = "Links",
            Description = "Add a collection of Links to a single field",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [AllowedTypes(new[] { typeof(LinkBlock) })]
        public virtual IList<ContentReference> Links { get; set; }
    }
}