using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WeddingApp.Data;

namespace WeddingApp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IUserData userData;
        public PrivacyModel(ILogger<PrivacyModel> logger, IUserData userData)
        {
            _logger = logger;
            this.userData = userData;
        }
        public void OnGet()
        {
        }
    }
}
