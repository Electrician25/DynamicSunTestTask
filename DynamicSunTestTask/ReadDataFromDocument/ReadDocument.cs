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

    async public void WriteExcelDocument()
    {
        IWorkbook workbook;
        using (FileStream fileStream = new FileStream("C:\\Users\\sosis\\Source\\Repos\\DynamicSunTestTask\\DynamicSunTestTask\\UploadedFiles\\moskva_2012.xlsx",
            FileMode.Open, FileAccess.Read))
        {
            workbook = new XSSFWorkbook(fileStream);
        }

        ISheet sheet = workbook.GetSheetAt(0);

        var table = new WheatherColumnEntity();
        var resultArray = new object[12];
        for (int i = 4; i < 12; i++)
        {
            IRow row = sheet.GetRow(i);
            for (int j = 0; j < 12; j++)
            {
                try
                {
                    var cellValue = row.GetCell(j).StringCellValue;
                    resultArray[j] = cellValue;
                }

                catch (Exception ex)
                {
                    var cellValue = row.GetCell(j).NumericCellValue;
                    resultArray[j] = cellValue;
                }
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            var element = CreateElement(resultArray, table);
            await _wheatherColumnsCrud.CreateNewColumnAsync(element);
        }
    }

    private WheatherColumnEntity CreateElement(object[] cells, WheatherColumnEntity table)
    {
        table.Date = (int)cells[0];
        table.MoskowTime = (string)cells[1];
        table.Temperature = (double)cells[2];
        table.AirHumidity = (double)cells[3];
        table.DewPoint = (double)cells[4];
        table.Pressure = (int)cells[5];
        table.DirectionOfTheWind = (string)cells[6];
        table.WindSpeed = (string)cells[7];
        table.Cloudy = (int)cells[8];
        table.lowerCloudLimit = (int)cells[9];
        table.HorizontalVisibility = (int)cells[10];
        table.WeatherConditions = (string)cells[11];

        return table;
    }
}