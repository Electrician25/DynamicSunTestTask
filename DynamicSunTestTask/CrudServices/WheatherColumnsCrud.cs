using DynamicSunTestTask.Data;
using DynamicSunTestTask.Entites;
using Microsoft.EntityFrameworkCore;

namespace DynamicSunTestTask.CrudServices
{
    public class WheatherColumnsCrud
    {
        private readonly ApplicationContext applicationContext;

        public WheatherColumnsCrud(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        async public Task<WheatherColumnEntity[]> GetAllColumnsAsync()
        {
            return await applicationContext.WheatherColumnsEntitis
                .ToArrayAsync()
                ?? throw new Exception("Columns not found!");
        }

        async public Task<WheatherColumnEntity> GetColumnByIdAsync(int id)
        {
            return await applicationContext.WheatherColumnsEntitis
                .FirstOrDefaultAsync(columnId => columnId.Id == id)
                ?? throw new Exception("Column by id not found!");
        }

        async public Task<WheatherColumnEntity> CreateNewColumnAsync(WheatherColumnEntity newColumn)
        {
            if (newColumn == null)
                throw new Exception("New column not found!");

            await applicationContext.WheatherColumnsEntitis
                .AddAsync(newColumn);
            applicationContext.SaveChanges();

            return newColumn;
        }

        public WheatherColumnEntity DeleteColumn(int id)
        {
            var column = applicationContext.WheatherColumnsEntitis
                .FirstOrDefault(columnId => columnId.Id == id)
                ?? throw new Exception("For delete column not found");

            applicationContext.Remove(column);
            applicationContext.SaveChanges();

            return column;
        }

        async public Task<WheatherColumnEntity> UpdateColumnAsync(WheatherColumnEntity newColumn)
        {
            if (newColumn == null)
                throw new Exception("For update column is not find!");

            var column = await applicationContext.WheatherColumnsEntitis
                .FirstOrDefaultAsync(id => id.Id == newColumn.Id)
                ?? throw new Exception("For update column is not find");

            newColumn.Date = column.Date;
            newColumn.Cloudy = column.Cloudy;
            newColumn.Pressure = column.Pressure;
            newColumn.DewPoint = column.DewPoint;
            newColumn.WindSpeed = column.WindSpeed;
            newColumn.MoskowTime = column.MoskowTime;
            newColumn.Temperature = column.Temperature;
            newColumn.AirHumidity = column.AirHumidity;
            newColumn.LowerCloudLimit = column.LowerCloudLimit;
            newColumn.WeatherConditions = column.WeatherConditions;
            newColumn.DirectionOfTheWind = column.DirectionOfTheWind;
            newColumn.HorizontalVisibility = column.HorizontalVisibility;

            return newColumn;
        }
    }
}