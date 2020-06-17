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
    public class LoginModel : PageModel
    {
        private readonly IUserData userData;
        public new User User { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Login { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Password { get; set; }
        public string Message { get; set; }
        public LoginModel( IUserData userData)
        {
            this.userData = userData;
        }
        public void OnGet()
        {
            Message = userData.GetMessage();
            if (Message == null)
            {
                Message = string.Empty;
            }
        }
        public IActionResult OnPost()
        {
            User = userData.GetByLoginAndPassword2(Login, Password);
            if (User == null)
            {
                userData.SetMessage("Nie ma użytkownika o takim loginie i haśle, wprowadź poprawną konfigurację");
                userData.GetMessage();
                return RedirectToPage("./Login");
            }
            userData.SetId(User.Id);
            userData.ClearDeadline();
            userData.UpdateDeadline(User);
            userData.Commit();
            return RedirectToPage("/MainPage");
        }
    }
}