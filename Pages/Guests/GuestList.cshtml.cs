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
    public class GuestListModel : PageModel
    {
        public IEnumerable<Guest> Guests { get; set; }
        private readonly IUserData userData;
        [BindProperty]
        public Guest Guest {set; get; }
        public GuestListModel(IUserData userData)
        {
            this.userData = userData;
        }
        public void OnGet()
        {
           int i = userData.GetId();
            Guests = userData.GetGuestsByWeddingNumber(i);
        }
    }
}