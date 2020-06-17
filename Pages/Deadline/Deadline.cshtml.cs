using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using WeddingApp.Core;
using WeddingApp.Data;

namespace WeddingApp.Pages.Deadlines
{
    public class DeadlineModel : PageModel
    {
        
        private readonly IUserData userData;

        [BindProperty]
        public new User User { set; get; }
        public Deadline1 Deadline { get; set; }

        public DeadlineModel(  IUserData userData)
        {
            this.userData = userData;
        }
        public void OnGet()
        {
            int i = userData.GetId();
            User = userData.GetUserById(i);
            Deadline = userData.GetDeadline();
            
        }
        }
    }
