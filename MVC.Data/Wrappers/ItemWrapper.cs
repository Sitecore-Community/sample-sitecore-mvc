using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Wrappers
{
    public class ItemWrapper
    {
        public Item Item;
        public ItemWrapper(Item item)
        {
            Item = item;
        }

        public ItemWrapper()
        {
        }

        private string _displayName;
        public string DisplayName
        {
            get
            {
                if (Item != null)
                {
                    _displayName = Item.DisplayName;
                }
                return _displayName;
            }
            set
            {
                _displayName = value;
            }
        }

        private ID _templateID;
        public ID TemplateID
        {
            get
            {
                if (Item != null)
                {
                    _templateID = Item.TemplateID;
                }

                return _templateID;
            }
            set
            {
                _templateID = value;
            }
        }

        private FieldCollection _fields;
        public FieldCollection Fields
        {
            get
            {
                if (Item != null)
                {
                    _fields = Item.Fields;
                }

                return _fields;
            }
            set
            {
                _fields = value;
            }
        }
    }
}
