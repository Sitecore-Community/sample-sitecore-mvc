using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Wrappers
{
    public class PageContextWrapper
    {
        PageContext _pageContext;

        public PageContextWrapper()
        {
            if (PageContext.CurrentOrNull != null)
            {
                _pageContext = PageContext.CurrentOrNull;
            }
        }

        private bool _isPageEditor;
        public bool IsPageEditor
        {
            get
            {
                if (_pageContext != null)
                {
                    _isPageEditor = Sitecore.Context.PageMode.IsPageEditor;
                }

                return _isPageEditor;
            }
            set
            {
                _isPageEditor = value;
            }
        }
        
    }
}
