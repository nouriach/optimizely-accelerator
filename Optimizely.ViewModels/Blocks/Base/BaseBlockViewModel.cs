using Optimizely.ViewModels.Blocks.Interfaces;

namespace Optimizely.ViewModels.Blocks.Base
{
    public class BaseBlockViewModel : ISiteBlockViewModel
    {
        public virtual string ComponentName { get; set; }
    }
}
