using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AMS.Models
{
    public class LoanDropDownVM
    {
        public IEnumerable<SelectListItem> CustomerList { get; set; }
    }
}
