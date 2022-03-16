using Dept.Core.Constants;
using Optimizely.ViewModels.Blocks.Base;

namespace Optimizely.ViewModels.Global.Components
{
    public class LinkBlockViewModel : BaseBlockViewModel 
    {
        public override string ComponentName => ComponentNameConstants.Link;

        public string Name { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
    }
}
