using Dept.Core.SelectionFactories;
using EPiServer;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using Optimizely.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Optimizely.Models.Blocks.Global
{
    [ContentType(DisplayName = "Link Block", GUID = "9972d160-e716-47dd-a701-989aa2612f99", Description = "")]
    public class LinkBlock : SiteBlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Text",
            Description = "Link text",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Name { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Url",
            Description = "Url",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual Url Url { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Link Target",
            Description = "Set the Target destination for the link",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        [SelectOne(SelectionFactoryType = typeof(LinkTargetSelectionFactory))]
        public virtual string Target { get; set; }
    }
}