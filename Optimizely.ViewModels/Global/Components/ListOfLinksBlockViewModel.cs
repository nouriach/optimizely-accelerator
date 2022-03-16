using Dept.Core.Constants;
using Optimizely.ViewModels.Blocks.Base;
using System.Collections.Generic;

namespace Optimizely.ViewModels.Global.Components
{
    public class ListOfLinksBlockViewModel : BaseBlockViewModel
    {
        public override string ComponentName => ComponentNameConstants.ListOfLinks;
        public IList<LinkBlockViewModel> Links { get; set; }
    }
}
