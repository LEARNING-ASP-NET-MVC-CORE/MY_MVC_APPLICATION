using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Filters
{
	public class LocalizationPipeline
	{
		public LocalizationPipeline() : base()
		{
		}

		public void Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder applicationBuilder)
		{
			var supportedCultures = new[]
			{
				new System.Globalization.CultureInfo("fa-IR"),
				new System.Globalization.CultureInfo("en-US"),
			};

			var options = new Microsoft.AspNetCore.Builder.RequestLocalizationOptions
			{
				DefaultRequestCulture =
					new Microsoft.AspNetCore.Localization.RequestCulture(culture: "en-US", uiCulture: "en-US"),

				SupportedCultures = supportedCultures,

				SupportedUICultures = supportedCultures

			};

			// Install-Package Microsoft.AspNetCore.Localization.Routing
			// https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/controllers/filters/sample

			options.RequestCultureProviders =
				new[]
				{
					new Microsoft.AspNetCore.Localization.Routing.RouteDataRequestCultureProvider() { Options = options }
				};

			applicationBuilder.UseRequestLocalization(options);
		}
	}
}
