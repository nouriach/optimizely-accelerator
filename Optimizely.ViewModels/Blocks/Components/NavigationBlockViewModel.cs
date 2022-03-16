
using Dept.Core.Constants;
using EPiServer.Core;
using Optimizely.ViewModels.Blocks.Base;
using System.Collections.Generic;

namespace Optimizely.ViewModels.Blocks.Components
{
    public class NavigationBlockViewModel : BaseBlockViewModel
    {
        public override string ComponentName => ComponentNameConstants.Navigation;
        public string Heading { get; set; }
        public NavigationItem Homepage { get; set; }
    }

    public class NavigationItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public PageData PageData { get; set; }
    }
}
