using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace Optimizely.Models.Media
{
    [ContentType(GUID = "98975083-8A6C-4A1E-A2BE-8AF060814D39")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,png")]
    public class ImageFile : ImageData
    {
    }
}
