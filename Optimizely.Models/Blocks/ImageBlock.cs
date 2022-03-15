using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Optimizely.Models.Base;
using Optimizely.Models.Media;
using System.ComponentModel.DataAnnotations;

namespace Optimizely.Models.Blocks
{
    [ContentType(DisplayName = "Image Block", GUID = "1953948a-d53a-4edd-a033-6488fd31f72e", Description = "")]
    public class ImageBlock : SiteBlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Image",
            Description = "Add image",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference Image { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Image caption",
            Description = "Add image caption",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string Caption { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Description",
            Description = "Add description",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual XhtmlString Description { get; set; }
    }
}