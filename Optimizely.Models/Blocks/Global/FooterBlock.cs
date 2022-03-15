using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Optimizely.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Optimizely.Models.Blocks.Global
{
    [ContentType(DisplayName = "Footer Block", GUID = "27517c95-e5c4-46ec-b54d-8a8a3a8e1aef", Description = "")]
    public class FooterBlock : SiteBlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Footer",
            Description = "This is a Footer Block",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Title { get; set; }

    }
}