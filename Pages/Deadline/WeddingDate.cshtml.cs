using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeddingApp.Core;
using WeddingApp.Data;

namespace WeddingApp.Pages.Deadlines
{
    public class WeddingDateModel : PageModel
    {
        
        private readonly IUserData userData;
        [BindProperty]
        public  User User { set; get; }
        
        public WeddingDateModel( IUserData userData)
        {
            this.userData = userData;
        }
        public void OnGet()
        {
            int i = userData.GetId();
            User = userData.GetUserById(i);
        }
        public IActionResult OnPost()
        {
            userData.UpdateDeadline(User);
            userData.Commit();
            return RedirectToPage("/MainPage");
        }
    }
}