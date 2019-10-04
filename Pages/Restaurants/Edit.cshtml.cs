using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private  IRestaurantData restaurantData;
        private IHtmlHelper htmlHelper;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cusinis   { get; set; }
        public EditModel(IRestaurantData restaurantData , IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper; 
        }
        public IActionResult OnGet(int?  Id)
        {
            Cusinis = htmlHelper.GetEnumSelectList<CuisineType>();
            if (Id.HasValue)
                Restaurant = restaurantData.GetById(Id.Value);
            else
                Restaurant = new Restaurant();
            if (Restaurant == null)
                return RedirectToPage("../Shared/NotFound");
            return Page();
        }
        public IActionResult OnPost()
        {
                Cusinis = htmlHelper.GetEnumSelectList<CuisineType>();
            if (ModelState.IsValid)
            {
                if (Restaurant.Id == 0)
                {
                    restaurantData.Add(Restaurant); 

                }
                else
                {
                    restaurantData.Update(Restaurant);
                }
                    restaurantData.Commit();
            return RedirectToPage("./Details", new {Id=Restaurant.Id});
            }
            return Page(); 
        }
    }
}