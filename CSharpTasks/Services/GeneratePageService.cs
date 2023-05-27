using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTasks.Services
{
    public static class GeneratePageService
    {

        // function that build the table structure with the employee data
        public static string HtmlPageStructure(Dictionary<string, TimeSpan> employees)
        {
            string html = "<html><head>    <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ\" crossorigin=\"anonymous\"><style>    .navbar {background-color: #333;overflow: hidden;}.navbar-title {color: #f2f2f2;font-size: 20px; padding: 14px 16px; text-decoration: none; } table { border-collapse: collapse; } th, td { border: 1px solid black; padding: 8px; } tr.less-than-100 { background-color: #ffcccc; }" +
                "</style></head><body>  <div class=\"navbar\">      <a href=\"#\" class=\"navbar-title\">C# Task: Employees Table By Mohamed Warda</a>\r\n    </div>";

            html += " <div class=\"container\"><div class=\"row justify-content-center\">\r\n <div class=\"col-md-8\">";
            html += "<table  class=\"table table-bordered\"><tr  class=\"text-bg-dark p-3\"><th class=\" text-center\" >Employee Name</th><th class=\" text-center\" >Total Hours Worked</th></tr>";

            // loop for every employee and add it to the table
            foreach ( var employee in employees)
            {
                 
                 string rowClass = employee.Value.TotalHours < 100 ? "less-than-100" : "";

                html += $"<tr class = '{rowClass}'><td class=\" text-center\">{employee.Key}</td>  <td class=\" text-center\">{(int)employee.Value.TotalHours} hrs</td></tr>";
            }

            html += "</table> </div>\r\n        </div>\r\n    </div></body></html>";
            return html;
        }


     


        // function that generate the html with its path
        public static void GenerateHtmlPage(Dictionary<string, TimeSpan> EmpList)
        {
          

            // Generate HTML with employees list
            string html = GeneratePageService.HtmlPageStructure(EmpList);


            // The file path for the HTML page
            string htmlPath = @"..\..\..\employees.html";
            // Save the HTML file with its path
            GeneratePageService.SaveHtmlPage(html, htmlPath);


        }


        //function that save the file
        public static void SaveHtmlPage(string html, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(html);
            }
        }

    }
}
