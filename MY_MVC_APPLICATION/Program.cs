using Microsoft.AspNetCore.Hosting;

namespace MY_MVC_APPLICATION
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			var host =
				new Microsoft.AspNetCore.Hosting.WebHostBuilder()
				.UseKestrel()
				.UseContentRoot(System.IO.Directory.GetCurrentDirectory())
				.UseIISIntegration()
				.UseStartup<Startup>()
				.UseApplicationInsights()
				.Build();

			host.Run();
		}
	}
}
