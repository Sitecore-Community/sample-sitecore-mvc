using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Data.Items
{
    // TODO: Add an interface
    public class ItemWrapper : IItem
    {
        public ItemWrapper(Item item)
        {
            Item = item;
        }

        public ItemWrapper()
        {
        }

        public Item Item { get; set; }

        public string DisplayName
        {
            get
            {
                return Item.DisplayName;
            }
        }

        public ID TemplateID
        {
            get
            {
                return Item.TemplateID;
            }
        }
    }
}
