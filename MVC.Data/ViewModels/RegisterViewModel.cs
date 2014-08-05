using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Data.Models;

namespace MVC.Data.ViewModels
{
    public class RegisterViewModel
    {
        public CustomerContact CustomerContactDetails { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
    }
}
