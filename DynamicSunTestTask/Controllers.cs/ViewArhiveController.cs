using DynamicSunTestTask.CrudServices;
using DynamicSunTestTask.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DynamicSunTestTask.Controllers.cs
{
    public class ViewArhiveController : Controller
    {
        private readonly WheatherColumnsCrud _WheatherColumnsCrud;

        public ViewArhiveController(WheatherColumnsCrud wheatherColumnsCrud)
        {
            _WheatherColumnsCrud = wheatherColumnsCrud;
        }

        public IActionResult Arhive() => View();

        [HttpGet]
        public async Task<WheatherColumn[]> GetAllAsync()
        {
            return await _WheatherColumnsCrud.GetAllColumnsAsync();
        }
    }
}
