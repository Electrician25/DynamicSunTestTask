using DynamicSunTestTask.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddApplicationContext();
builder.Services.AddCategoryCrudServices();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseRouting();
app.Run();