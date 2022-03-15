using EPiServer.Core;
using Optimizely.ViewModels.Blocks.Components;

namespace Optimizely.Interfaces
{
    public interface INavigationService
    {
        NavigationItem GetHomepage();
    }
}
