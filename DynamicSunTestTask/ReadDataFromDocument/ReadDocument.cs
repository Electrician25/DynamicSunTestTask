using DynamicSunTestTask.CrudServices;
using DynamicSunTestTask.Entites;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

public class ReadDocument
{
    private readonly WheatherColumnsCrud _wheatherColumnsCrud;

    public ReadDocument(WheatherColumnsCrud wheatherColumnsCrud)
    {
        _wheatherColumnsCrud = wheatherColumnsCrud;
    }

    async public void WriteExcelDocument(string fileName)
    {
        IWorkbook workbook;

        using (FileStream fileStream = new FileStream($"C:\\Users\\sosis\\Source\\Repos\\DynamicSunTestTask\\DynamicSunTestTask\\UploadedFiles\\{fileName}",
            FileMode.Open, FileAccess.Read))
        {
            workbook = new XSSFWorkbook(fileStream);
        }

        ISheet sheet = workbook.GetSheetAt(0);

        var newEntity = new WheatherColumnEntity();
        var resultString = new object[13];
        for (int i = 4; i < 12; i++)
        {
            IRow row = sheet.GetRow(i);
            for (int j = 0; j < 12; j++)
            {
                try
                {
                    var cellValue = row.GetCell(j).StringCellValue;
                    resultString[j] = cellValue;
                }

                catch (Exception ex)
                {
                    var cellValue = row.GetCell(j).NumericCellValue;
                    resultString[j] = cellValue;
                }
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            var element = CreateElement(resultString, newEntity);
            await _wheatherColumnsCrud.CreateNewColumnAsync(element);
        }
    }

    private WheatherColumnEntity CreateElement(object[] cells, WheatherColumnEntity table)
    {
        table.Date = (string)cells[0];
        table.MoskowTime = (string)cells[1];
        table.Temperature = (double)cells[2];
        table.AirHumidity = (double)cells[3];
        table.DewPoint = (double)cells[4];
        table.Pressure = (double)cells[5];
        table.DirectionOfTheWind = (string)cells[6];
        table.WindSpeed = (double)cells[7];
        table.Cloudy = (double)cells[8];
        table.LowerCloudLimit = (double)cells[9];
        table.HorizontalVisibility = (int)cells[10];
        table.WeatherConditions = (string)cells[11];
        cells[12] = table.Id + 1;
        table.Id = (int)cells[12];

        return table;
    }
}