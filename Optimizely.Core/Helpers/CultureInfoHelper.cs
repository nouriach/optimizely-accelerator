using EPiServer.Core;
using System.Globalization;

namespace Optimizely.Core.Helpers
{
    public static class CultureInfoHelper
    {
        public static CultureInfo GetCultureInfoFromBlockLanguage(this BlockData currentBlock)
        {
            return new CultureInfo(currentBlock.Property.LanguageBranch);
        }
    }
}
