
using CSharpTasks.Services;
using CSharpTasksp.Data;



namespace CSharpTasks;

internal class Program
{
    static void Main(string[] args)
    {
        //Get the date from the end point and calculate the total working hours for every employee
        Dictionary<string, TimeSpan> EmpList = APIData.PrepareEmployeesData();

        // Create html page with employees data
        GeneratePageService.GenerateHtmlPage(EmpList);

        // Draw pie chart with employees data
        GeneratePieChartService.GeneratePieChart(EmpList);

        Console.WriteLine("HTML page and Pie chart image generated and saved in the project folder");
    }
}