using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.Filters
{
	//public class SecurityActionFilterAttribute : IActionFilter
	public class SecurityActionFilterAttribute : Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
	{
		public SecurityActionFilterAttribute() : base()
		{
		}

		public override Task OnActionExecutionAsync
			(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			return (base.OnActionExecutionAsync(context, next));
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);
		}

		public override void OnActionExecuted(ActionExecutedContext context)
		{
			base.OnActionExecuted(context);
		}

		public override Task OnResultExecutionAsync
			(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			return (base.OnResultExecutionAsync(context, next));
		}

		public override void OnResultExecuting(ResultExecutingContext context)
		{
			base.OnResultExecuting(context);
		}

		public override void OnResultExecuted(ResultExecutedContext context)
		{
			base.OnResultExecuted(context);
		}
	}
}
