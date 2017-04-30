using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MY_MVC_APPLICATION
{
	public class Startup : object
	{
		public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
		{
			var builder =
				new Microsoft.Extensions.Configuration.ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public Microsoft.Extensions.Configuration.IConfigurationRoot Configuration
		{
			get;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			// **************************************************
			// Add framework services.
			//services.AddMvc(); // Default

			//services.AddMvc(options =>
			//	options.Filters.Add(new Infrastructure.Attributes.Filters.SecurityActionFilterAttribute())
			//);

			services.AddMvc(options =>
			{
				options.Filters.Add
					(typeof(Infrastructure.Filters.SecurityActionFilterAttribute));
			});
			// **************************************************

			// **************************************************
			// https://docs.microsoft.com/en-us/aspnet/core/security/cors

			// دستور ذیل ظاهرا کار نمی‌کند
			//services.Configure<Microsoft.AspNetCore.Mvc.MvcOptions>(options =>
			//{
			//	options.Filters.Add
			//		(new Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
			//});

			//services.AddCors(options =>
			//{
			//	options.AddPolicy(name: "AllowSpecificOrigin",
			//		configurePolicy: builder => builder.WithOrigins("http://localhost:3000", "http://www.IranainExperts.ir"));
			//});

			//services.AddCors(options =>
			//{
			//	options.AddPolicy(name: "AllowSpecificOrigin",
			//		configurePolicy: builder => builder.AllowAnyOrigin());
			//});

			//services.AddCors(options =>
			//{
			//	options.AddPolicy(name: "AllowSpecificOrigin",
			//		configurePolicy: builder =>
			//		builder
			//		.WithOrigins("http://localhost:3000")
			//		.AllowAnyMethod());
			//});

			//services.AddCors(options =>
			//{
			//	options.AddPolicy(name: "AllowSpecificOrigin",
			//		configurePolicy: builder =>
			//		builder
			//		.WithOrigins("http://localhost:3000")
			//		.WithHeaders("accept", "content-type", "origin", "x-custom-header"));
			//});

			//services.AddCors(options =>
			//{
			//	options.AddPolicy(name: "AllowSpecificOrigin",
			//		configurePolicy: builder =>
			//		builder
			//		.WithOrigins("http://localhost:3000")
			//		.AllowAnyHeader());
			//});

			services.AddCors(options =>
			{
				options.AddPolicy(name: "AllowSpecificOrigin",
					configurePolicy: builder =>
					builder
					.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowAnyOrigin()
					.AllowCredentials()
					);
			});
			// **************************************************
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure
			(Microsoft.AspNetCore.Builder.IApplicationBuilder app,
			Microsoft.AspNetCore.Hosting.IHostingEnvironment env,
			Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug(minLevel: LogLevel.Trace);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			// **************************************************
			// Note:
			// نکته مهم آن است که محل نوشتن دستور ذیل بسیار
			// اهمیت دارد، اگر بعد از دستور بعدی نوشته شود، عمل نمی‌کند
			// Note: For all Actions of Controllers
			app.UseCors("AllowSpecificOrigin");
			// **************************************************

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{culture=fa-IR}/{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
