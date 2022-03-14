using Optimizely.ViewModels.Pages.Base;

namespace Optimizely.ViewModels.Pages.Components
{
    public class HomepageViewModel : BasePageViewModel
    {
        public HomepageViewModel(){}

        public HomepageViewModel(BasePageViewModel baseModel)
        {
            // set BasePageViewModel values here
        }

        public string Title { get; set; }
    }
}
