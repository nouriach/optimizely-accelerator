using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Optimizely.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Optimizely.Models.Blocks.Global
{
    [ContentType(DisplayName = "Header Block", GUID = "1a00db8a-9096-421d-bc4d-9e46bf6593ed", Description = "")]
    public class HeaderBlock : SiteBlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Header",
            Description = "This is a Header Block",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Title { get; set; }
    }
}