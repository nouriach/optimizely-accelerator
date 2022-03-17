using EPiServer.Core;
using Optimizely.ViewModels.Pages.Base;

namespace Optimizely.ViewModels.Pages.Components
{
    public class BasicTwoColumnContentPageViewModel : BasePageViewModel
    {
        public BasicTwoColumnContentPageViewModel(){}
        public BasicTwoColumnContentPageViewModel(BasePageViewModel baseModel)
        {
            Header = baseModel.Header;
            Footer = baseModel.Footer;
        }

        public string Title { get; set; }
        public string MainBody { get; set; }
        public ContentArea LeftColumn { get; set; }
        public ContentArea RightColumn { get; set; }

    }
}
