using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Course.Pages.Shared
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost(string element)
        {
            switch (element)
            {
                case PropertyConstants.City:

                    break;
            }
        }
    }
}
