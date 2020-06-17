using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using WeddingApp.Core;
using WeddingApp.Data;

namespace WeddingApp
{
    public class WeddingHallsListModel : PageModel
    {
        
        private readonly IWeddingHallData weddingHallData;
        public IEnumerable<WeddingHall> WeddingHalls { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchByName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchByLocation {get; set;}
        public WeddingHallsListModel(IWeddingHallData weddingHallData)
        {
            this.weddingHallData = weddingHallData;
        }
        public void OnGet()
        {
            if(SearchByName==null)
            {
                WeddingHalls = weddingHallData.GetWeddingHallByLocation(SearchByLocation);
            }
            if(SearchByLocation==null)
            {
                WeddingHalls = weddingHallData.GetWeddingHallByName(SearchByName);
            }
        }
    }
}