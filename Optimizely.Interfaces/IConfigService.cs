
using Optimizely.Models.Blocks.Global;

namespace Optimizely.Interfaces
{
    public interface IConfigService
    {
        HeaderBlock Header { get; }
        FooterBlock Footer { get; }
    }
}
