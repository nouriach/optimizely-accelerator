using EPiServer.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dept.Core.Attributes
{
    public class MinAndMaxElementsAttribute : ValidationAttribute
    {
        private readonly int _minimumLimit;
        private readonly int _maximumLimit;
        public MinAndMaxElementsAttribute(int minLimit, int maxLimit)
        {
            _minimumLimit = minLimit;
            _maximumLimit = maxLimit;
        }
        public override bool IsValid(object value)
        {
            return ValidateProperty(value as IList<ContentReference>);
        }
        private bool ValidateProperty(IList<ContentReference> item)
        {
            return item == null ||
                item.Count >= _minimumLimit && item.Count <= _maximumLimit;
        }
    }
}
