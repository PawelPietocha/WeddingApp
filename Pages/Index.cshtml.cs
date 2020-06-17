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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserData userData;

        public IndexModel(ILogger<IndexModel> logger, IUserData userData)
        {
            _logger = logger;
            this.userData = userData;
        }

        public void OnGet()
        {
            userData.SetMessage(string.Empty);
        }
    }
}
