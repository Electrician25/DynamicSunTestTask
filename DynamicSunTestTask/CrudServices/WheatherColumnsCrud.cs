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

        public async Task<WheatherColumn[]> GetAllColumnsAsync()
        {
            return await applicationContext.WheatherColumns
                .ToArrayAsync()
                ?? throw new Exception("Columns not found!");
        }

        public async Task<WheatherColumn> GetColumnByIdAsync(int id)
        {
            return await applicationContext.WheatherColumns
                .FirstOrDefaultAsync(columnId => columnId.Id == id)
                ?? throw new Exception("Column by id not found!");
        }

        public async Task<WheatherColumn> CreateNewColumnAsync(WheatherColumn newColumn)
        {
            if (newColumn == null)
                throw new Exception("New column not found!");

            await applicationContext.WheatherColumns
                .AddAsync(newColumn);
            applicationContext.SaveChanges();

            return newColumn;
        }

        public WheatherColumn DeleteColumn(int id)
        {
            var column = applicationContext.WheatherColumns
                .FirstOrDefault(columnId => columnId.Id == id)
                ?? throw new Exception("For delete column not found");

            applicationContext.Remove(column);
            applicationContext.SaveChanges();

            return column;
        }
    }
}