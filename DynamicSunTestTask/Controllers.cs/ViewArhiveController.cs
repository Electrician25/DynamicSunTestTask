using DynamicSunTestTask.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DynamicSunTestTask.Controllers.cs
{
    public class ViewArhiveController : Controller
    {
        private readonly ApplicationContext _WheatherColumnsCrud;

        public ViewArhiveController(ApplicationContext wheatherColumnsCrud)
        {
            _WheatherColumnsCrud = wheatherColumnsCrud;
        }

        public ActionResult Arhive()
        {
            return View(_WheatherColumnsCrud.WheatherColumns.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }
            var movie = _WheatherColumnsCrud.WheatherColumns.Find(id);
            if (movie == null)
            {
                throw new Exception();
            }
            return View(movie);
        }
    }
}
