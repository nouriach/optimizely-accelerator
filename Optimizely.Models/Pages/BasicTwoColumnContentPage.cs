using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Optimizely.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Optimizely.Models.Pages
{
    [ContentType(DisplayName = "Basic Two Column Content Page", GUID = "34fd9558-20ad-4515-8585-a31ae617afbd", Description = "")]
    public class BasicTwoColumnContentPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "###.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
            Name = "Main Content Region for the Right Column",
            Description = "###",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual ContentArea RightColumn { get; set; }

        [Display(
            Name = "Main Content Region for the Left Column",
            Description = "###",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual ContentArea LeftColumn { get; set; }
    }
}