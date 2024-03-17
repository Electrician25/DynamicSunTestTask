using DynamicSunTestTask.CrudServices;
using DynamicSunTestTask.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DynamicSunTestTask.Controllers.cs
{
    [Route("/api/")]
    [ApiController]
    public class WheatherColumnsController : ControllerBase
    {
        private readonly WheatherColumnsCrud _WheatherColumnsCrud;

        public WheatherColumnsController(WheatherColumnsCrud wheatherColumnsCrud)
        {
            _WheatherColumnsCrud = wheatherColumnsCrud;
        }

        [HttpGet]
        [Route("getAllColumns")]
        async public Task<WheatherColumn[]> GetAllAsync()
        {
            return await _WheatherColumnsCrud.GetAllColumnsAsync();
        }

        [HttpGet]
        [Route("getColumnById/{id}")]
        async public Task<WheatherColumn> GetByIdAsync(int id)
        {
            return await _WheatherColumnsCrud.GetColumnByIdAsync(id);
        }

        [HttpPost]
        [Route("addNewColumn")]
        async public Task<WheatherColumn> CreateColumnAsync(WheatherColumn wheatherColumnEntity)
        {
            return await _WheatherColumnsCrud.CreateNewColumnAsync(wheatherColumnEntity);
        }

        [HttpDelete]
        [Route("deleteColumn")]
        public WheatherColumn DeleteColumnAsync(int id)
        {
            return _WheatherColumnsCrud.DeleteColumn(id);
        }
    }
}