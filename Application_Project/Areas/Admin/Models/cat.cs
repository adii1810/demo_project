using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application_Project.Areas.Admin.Models
{
    public class cat
    {
        public Main category { get; set; }
    }

    public enum Main
    {
        Food = 0,
        Beverage = 1,
        Desert = 2
    }
}
