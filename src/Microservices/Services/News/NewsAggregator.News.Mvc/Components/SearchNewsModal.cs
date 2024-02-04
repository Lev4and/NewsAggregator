using Microsoft.AspNetCore.Mvc;

namespace NewsAggregator.News.Mvc.Components
{
    public class SearchNewsModal : ViewComponent
    {
        public SearchNewsModal()
        {
            
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
