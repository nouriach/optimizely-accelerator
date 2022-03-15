using Optimizely.ViewModels.Blocks.Base;
using System.Collections.Generic;

namespace Optimizely.ViewModels.Global.Components
{
    public class ListOfLinksBlockViewModel : BaseBlockViewModel
    {
        public IList<LinkBlockViewModel> Links { get; set; }
    }
}
