using Optimizely.ViewModels.Pages.Base;

namespace Optimizely.ViewModels.Pages.Components
{
    public class HomepageViewModel : BasePageViewModel
    {
        public HomepageViewModel(){}

        public HomepageViewModel(BasePageViewModel baseModel)
        {
            Header = baseModel.Header;
            Footer = baseModel.Footer;
        }

        public string Title { get; set; }
    }
}
