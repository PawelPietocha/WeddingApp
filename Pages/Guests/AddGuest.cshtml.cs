using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeddingApp.Core;
using WeddingApp.Data;

namespace WeddingApp
{
    public class AddGuestModel : PageModel
    {
        private readonly IUserData userData;

        [BindProperty]
        public  Guest Guest { get; set; }
        public AddGuestModel(IUserData userData)
        {
            this.userData = userData;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            Guest.WeddingNumber = userData.GetId();
            userData.AddGuest(Guest);
            return RedirectToPage("./GuestView");
        }
    }
}