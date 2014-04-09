using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sitecore.MVC.Presentation
{
    public interface IPageContext
    {
        IItem Current { get; }
        bool IsPageEditor { get; }
    }
}
