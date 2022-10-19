using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AMS.Utility
{
    public static class Helper
    {

        //Priority
        public static string Personal = "personal";
        public static string Home = "home";
        public static string Vehicle = "vehicle";

        public static List<SelectListItem> GetLoanTypeDropDown()
        {
            return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.Personal,Text=Helper.Personal},
                    new SelectListItem{Value=Helper.Home,Text=Helper.Home},
                    new SelectListItem{Value=Helper.Vehicle,Text=Helper.Vehicle},
                };
        }


    }
}
