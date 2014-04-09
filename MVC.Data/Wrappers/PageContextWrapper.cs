using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.MVC.Presentation
{
    public class PageContextWrapper : IPageContext
    {
        public IItem Current
        {
            get
            {
                return new ItemWrapper(PageContext.CurrentOrNull.Item);
            }
        }

        public bool IsPageEditor
        {
            get
            {
                return Sitecore.Context.PageMode.IsPageEditor;
            }
        }
        
    }
}
