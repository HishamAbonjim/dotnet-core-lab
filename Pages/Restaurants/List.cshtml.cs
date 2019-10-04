using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public string Title { get; set; } 
        public ListModel(IConfiguration  config, IRestaurantData restaurantData )
        {
            this.config = config;
            this.restaurantData = restaurantData; 
        }
        public void OnGet()
        {
           
            Title = config["Message"];
            Restaurants = restaurantData.GetByName(SearchTerm);
            ;
        } 
    }
}