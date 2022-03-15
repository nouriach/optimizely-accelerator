using MediatR;
using Optimizely.Models.Base;
using Optimizely.ViewModels.Blocks.Interfaces;
using System.Globalization;

namespace Optimizely.Mediator.Requests.Block
{
    public static class BlockRequest
    {
        public static BlockRequest<T> Create<T>(T block, CultureInfo language) where T : SiteBlockData
        {
            return new BlockRequest<T>(block, language);
        }
    }

    public class BlockRequest<T> : IRequest<ISiteBlockViewModel> where T : SiteBlockData
    {
        public BlockRequest(T block, CultureInfo language)
        {
            Block = block;
            Language = language;
        }

        public T Block { get; set; }
        public CultureInfo Language { get; set; }
    }
}
