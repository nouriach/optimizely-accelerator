using Optimizely.ViewModels.Global.Components;
using Optimizely.ViewModels.Pages.Interfaces;

namespace Optimizely.ViewModels.Pages.Base
{
    public class BasePageViewModel : ISitePageViewModel
    {
        public HeaderViewModel Header { get; set; }
        public FooterViewModel Footer { get; set; }
    }
}
