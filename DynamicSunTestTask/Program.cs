using DynamicSunTestTask.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting();
builder.AddApplicationContext();
builder.Services.AddControllers();
builder.Services.AddCategoryCrudServices();
var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.Run();