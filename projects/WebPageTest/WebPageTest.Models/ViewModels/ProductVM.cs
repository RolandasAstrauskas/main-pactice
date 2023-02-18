using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebPageTest.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> CoverList { get; set; }      
    }
}
