using EPiServer.Core;
using MediatR;
using Optimizely.ViewModels.Blocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizely.Mediator.Requests.Block
{
    public class BlockRequest<T> : IRequest<ISiteBlockViewModel> where T : BlockData
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
