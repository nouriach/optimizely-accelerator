using Optimizely.ViewModels.Blocks.Base;

namespace Optimizely.ViewModels.Global.Components
{
    public class LinkBlockViewModel : BaseBlockViewModel 
    {
        // add component name constants
        public string Name { get; set; }
        public string Url { get; set; }
        public string LinkIcon { get; set; }
        public string Target { get; set; }
    }
}
