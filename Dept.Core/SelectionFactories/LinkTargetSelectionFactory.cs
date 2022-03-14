using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;

namespace Dept.Core.SelectionFactories
{
    public class LinkTargetSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new List<SelectItem>
            {
                new() {Text = "Same Tab", Value = "_self"},
                new() {Text = "New Tab", Value = "blank"},
            };
        }
    }
}
