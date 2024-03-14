using DynamicSunTestTask.CrudServices;
using DynamicSunTestTask.Entites;
using Microsoft.AspNetCore.Mvc;

namespace DynamicSunTestTask.Controllers.cs
{
	[ApiController]
	[Route("/api/{controller}")]
	public class WheatherColumnsControllers : ControllerBase
	{
		private readonly WheatherColumnsCrud _WheatherColumnsCrud;

		public WheatherColumnsControllers(WheatherColumnsCrud wheatherColumnsCrud)
		{
			_WheatherColumnsCrud = wheatherColumnsCrud;
		}

		[HttpGet]
		[Route("addAllColumns")]
		async public Task<WheatherColumnEntity[]> GetAllAsync()
		{
			return await _WheatherColumnsCrud.GetAllColumnsAsync();
		}

		[HttpGet]
		[Route("getColumnById/{id}")]
		async public Task<WheatherColumnEntity> GetByIdAsync(int id)
		{
			return await _WheatherColumnsCrud.GetColumnByIdAsync(id);
		}

		[HttpPost]
		[Route("addNewColumn")]
		async public Task<WheatherColumnEntity> CreateColumnAsync(WheatherColumnEntity wheatherColumnEntity)
		{
			return await _WheatherColumnsCrud.CreateNewColumnAsync(wheatherColumnEntity);
		}

		[HttpPut]
		[Route("updateColumn")]
		async public Task<WheatherColumnEntity> UpdateColumnAsync(WheatherColumnEntity wheatherColumnEntity)
		{
			return await _WheatherColumnsCrud.UpdateColumnAsync(wheatherColumnEntity);
		}

		[HttpDelete]
		[Route("deleteColumn")]
		public WheatherColumnEntity DeleteColumnAsync(int id)
		{
			return _WheatherColumnsCrud.DeleteColumn(id);
		}
	}
}