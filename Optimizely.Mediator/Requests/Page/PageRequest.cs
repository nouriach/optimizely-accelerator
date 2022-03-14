using EPiServer.Core;
using MediatR;
using Optimizely.ViewModels.Pages.Interfaces;
using System.Globalization;

namespace Optimizely.Mediator.Requests.Page
{
    public class PageRequest<T> : IRequest<ISitePageViewModel> where T : IContent
    {
        public PageRequest(T page, CultureInfo language)
        {
            Page = page;
            Language = language;
        }

        public T Page { get; set; }
        public CultureInfo Language { get; set; }
    }
}
