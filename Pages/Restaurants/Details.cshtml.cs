using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }
        public DetailsModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData; 
        }
        public IActionResult OnGet(int Id)
        {
            Restaurant = restaurantData.GetById(Id);
            if (Restaurant == null)
                return RedirectToPage("../Shared/NotFound");
            return Page();
        }
    }
}