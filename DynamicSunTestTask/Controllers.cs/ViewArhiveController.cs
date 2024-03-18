using DynamicSunTestTask.CrudServices;
using DynamicSunTestTask.Data;
using DynamicSunTestTask.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DynamicSunTestTask.Controllers.cs
{
    public class ViewArhiveController : Controller
    {
        private readonly ApplicationContext _ApplicationContext;

        public ViewArhiveController(ApplicationContext wheatherColumnsCrud)
        {
            _ApplicationContext = wheatherColumnsCrud;
        }

        public async Task<IActionResult> Arhive(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var columns = from s in _ApplicationContext.WheatherColumns select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                columns = columns.Where(s => s.Date.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Date":
                    columns = columns.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    columns = columns.OrderByDescending(s => s.Date);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<WheatherColumn>.CreateAsync(columns.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }
            var movie = _ApplicationContext.WheatherColumns.Find(id);
            if (movie == null)
            {
                throw new Exception();
            }
            return View(movie);
        }
    }
}