using MediatR;
using Optimizely.ViewModels.Global.Components;
using System.Globalization;

namespace Optimizely.Mediator.Requests.Block
{
    public class HeaderRequest : IRequest<HeaderViewModel>
    {
        public HeaderRequest(CultureInfo language)
        {
            Language = language;

        }
        public CultureInfo Language { get; }
    }
}
