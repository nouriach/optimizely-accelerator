using EPiServer.Core;
using Optimizely.ViewModels.Pages.Base;

namespace Optimizely.ViewModels.Pages.Components
{
    public class BasicContentPageViewModel : BasePageViewModel
    {
        public BasicContentPageViewModel(){}
        public BasicContentPageViewModel(BasePageViewModel baseModel)
        {
            Header = baseModel.Header;
            Footer = baseModel.Footer;
        }
        public string Title { get; set; }
        public string MainBody { get; set; }
        public ContentArea MainRegion { get; set; }
    }
}
