using DynamicSunTestTask.Extensions;
using ProCodeGuide.Samples.FileUpload.Interfaces;
using ProCodeGuide.Samples.FileUpload.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddRouting();

builder.AddApplicationContext();

builder.Services.AddTransient<IBufferedFileUploadService, BufferedFileUploadLocalService>();

builder.Services.AddControllers();

builder.Services.AddCategoryCrudServices();

var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();