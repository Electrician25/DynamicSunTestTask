using DynamicSunTestTask.Data;
using Microsoft.EntityFrameworkCore;

namespace DynamicSunTestTask.Extensions
{
	public static class WebApplicationBuilderExtentions
	{
		public static WebApplicationBuilder AddApplicationContext(this WebApplicationBuilder builder)
		{
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
			builder.Services.AddDbContext<ApplicationContext>(options
					=> options.UseNpgsql(connectionString));

			return builder;
		}
	}
}