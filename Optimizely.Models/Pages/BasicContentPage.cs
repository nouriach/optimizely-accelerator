using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Optimizely.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Optimizely.Models.Pages
{
    [ContentType(DisplayName = "Basic Content Page", GUID = "5fa89d06-5ef4-4692-b117-edc26374bac0", Description = "")]
    public class BasicContentPage : SitePageData
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

        [CultureSpecific]
        [Display(
            Name = "Main Content Region",
            Description = "###",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual  ContentArea MainRegion { get; set; }
    }
}