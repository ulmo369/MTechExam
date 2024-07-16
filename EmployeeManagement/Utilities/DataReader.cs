using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

public class CsvDataReader
{
    public List<Employee> ReadEmployeesFromCsv(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            return csv.GetRecords<Employee>().ToList();
        }
    }
}
