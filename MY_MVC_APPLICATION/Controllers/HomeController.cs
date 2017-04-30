namespace MY_MVC_APPLICATION.Controllers
{
	public class HomeController : Infrastructure.BaseController
	{
		public Microsoft.AspNetCore.Mvc.IActionResult Index()
		{
			return (View());
		}

		[Microsoft.AspNetCore.Mvc.Route("{culture}/[controller]/[action]")]
		[Microsoft.AspNetCore.Mvc.MiddlewareFilter(typeof(Infrastructure.Filters.LocalizationPipeline))]
		public Microsoft.AspNetCore.Mvc.IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return (View());
		}

		public Microsoft.AspNetCore.Mvc.IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return (View());
		}

		public Microsoft.AspNetCore.Mvc.IActionResult Error()
		{
			return (View());
		}
	}
}
