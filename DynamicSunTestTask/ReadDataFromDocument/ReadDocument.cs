using DynamicSunTestTask.CrudServices;
using DynamicSunTestTask.Data;
using DynamicSunTestTask.Entites;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

public class ReadDocument
{
    private readonly WheatherColumnsCrud _wheatherColumnsCrud;
    private readonly ApplicationContext _applicationContext;
    public ReadDocument(WheatherColumnsCrud wheatherColumnsCrud, ApplicationContext applicationContext)
    {
        _wheatherColumnsCrud = wheatherColumnsCrud;
        _applicationContext = applicationContext;
    }

    public async Task WriteExcelDocument(string fileName)
    {
        IWorkbook workbook;

        using (FileStream fileStream = new FileStream($"C:\\Users\\sosis\\Source\\Repos\\DynamicSunTestTask\\DynamicSunTestTask\\UploadedFiles\\{fileName}",
            FileMode.Open, FileAccess.Read))
        {
            workbook = new XSSFWorkbook(fileStream);
        }

        var resultString = new object?[13];
        var stringColumnLength = 12;

        int startIterationInddex = 4;
        int currentId = _applicationContext.WheatherColumns.Count();
        int month = 0;

        while (month < 12)
        {
            ISheet sheet = workbook.GetSheetAt(month);
            for (int i = startIterationInddex; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                for (int j = 0; j < stringColumnLength; j++)
                {
                    if (row.GetCell(j) is null)
                    {
                        resultString[j] = null;
                        continue;
                    }
                    if (row.GetCell(j).CellType is CellType.String)
                    {

                        var cellValue = row.GetCell(j).StringCellValue;
                        resultString[j] = cellValue;
                    }
                    else
                    {
                        var cellValue = row.GetCell(j).NumericCellValue;
                        resultString[j] = cellValue;
                    }
                }
                currentId++;
                var element = CreateElement(resultString, currentId);
                await _wheatherColumnsCrud.CreateNewColumnAsync(element);
            }
            month++;
        }
    }

    private WheatherColumn CreateElement(object[] cells, int currentId)
    {
        return new WheatherColumn()
        {
            Date = (string)cells[0],
            MoscowTime = (string)cells[1],
            Temperature = (double)cells[2],
            AirHumidity = (double)cells[3],
            DewPoint = (double)cells[4],
            Pressure = (double)cells[5],
            DirectionOfTheWind = (string)cells[6],
            WindSpeed = GetCorrectCell(cells[7]),
            Cloudy = GetCorrectCell(cells[8]),
            LowerCloudLimit = GetCorrectCell(cells[9]),
            HorizontalVisibility = GetCorrectCell(cells[10]),
            WeatherConditions = RealCondotion(cells[11]),
            Id = currentId
        };
    }

    private double? GetCorrectCell(object value)
    {
        return value.GetType().Name == "Double"
            ? (double?)value
            : null;
    }

    private string? RealCondotion(object value)
    {
        if (value is null) return null;
        if (value.GetType().Name == "Double")
        {
            return null;
        }
        return (string)value;
    }
}