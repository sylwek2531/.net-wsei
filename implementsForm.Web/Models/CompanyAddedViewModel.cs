using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementsForm.Web.Models
{
    public class CompanyAddedViewModel
    {
        public int NumberOfCharsInName { get; set; }

        public int NumberOfCharsInDescription { get; set; }

        public bool IsHidden { get; set; }
    }
}
