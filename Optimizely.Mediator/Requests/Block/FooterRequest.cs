using EPiServer.Core;
using MediatR;
using Optimizely.ViewModels.Global.Components;
using System.Globalization;

namespace Optimizely.Mediator.Requests.Block
{
    public class FooterRequest : IRequest<FooterViewModel>
    {
        public FooterRequest(CultureInfo language, PageData currentPage)
        {
            Language = language;
            CurrentPage = currentPage;
        }
        public CultureInfo Language { get; }
        public PageData CurrentPage { get; }
    }
}
