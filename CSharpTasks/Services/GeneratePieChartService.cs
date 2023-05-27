using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTasks.Services;

public class GeneratePieChartService
{


    // function that draw the pie chart and the image file size and properties
    public static Image DrawPieChart(Dictionary<string, TimeSpan> employeeData)
    {
        // Calculate the total working hours

        int totalHours = 0;
        foreach (var employee in employeeData)
        {
            totalHours += (int)employee.Value.TotalHours;
        }
        // Set up the pie chart parameters

        int imageWidth = 1000;
        int imageHeight = 800;
        int pieChartWidth = (int)(imageWidth * 0.7);
        int legendWidth = (int)(imageWidth * 0.3);
        int legendItemHeight = 30;
        int legendStartX = pieChartWidth + 80;
        int legendStartY = 30;
        Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple, Color.Yellow, Color.Cyan, Color.Magenta, Color.Lime, Color.Teal };

        // create a new bitmap for the pie chart image
        Bitmap pieChartImage = new Bitmap(imageWidth, imageHeight);

        // create a graphics object from the bitmap
        using (Graphics graphics = Graphics.FromImage(pieChartImage))
        {
            // set the background color
            graphics.Clear(Color.White);

            // calculate the start angle for drawing the pie chart
            float startAngle = 0f;
            int startAngleIndex = 0;

            // Iterate over the dictionary
            foreach (var kvp in employeeData)
            {
                string employeeName = kvp.Key;
                int workingHours = (int)kvp.Value.TotalHours;

                // calculate the percentage of the total time worked by the employee
                float percentage = (float)(workingHours / (double)totalHours * 360);

                // draw the title
                var titleFont = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
                var titleBrush = Brushes.Black;
                var titleStringFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Near
                };
                var titleRectangle = new Rectangle(0, 10, imageWidth, 30);
                graphics.DrawString("C# PieChart Task, By Mohamed Warda", titleFont, titleBrush, titleRectangle, titleStringFormat);
                // Draw the pie chart segment
                graphics.FillPie(new SolidBrush(colors[startAngleIndex % colors.Length]), new Rectangle(30, 70, pieChartWidth - 20, imageHeight - 100), startAngle, percentage);

                // update the start angle for the next segment
                startAngle += percentage;

                // increment the start angle index
                startAngleIndex++;

                // draw the legend
                Rectangle legendRect = new Rectangle(legendStartX, legendStartY + startAngleIndex * legendItemHeight, legendWidth, legendItemHeight);

                // Draw legend color box
                graphics.FillRectangle(new SolidBrush(colors[startAngleIndex % colors.Length]), legendRect.X, legendRect.Y, legendItemHeight, legendItemHeight);

                // draw legend text
                Rectangle legendTextRect = new Rectangle(legendRect.X + legendItemHeight + 5, legendRect.Y, legendRect.Width - legendItemHeight - 5, legendRect.Height);
                graphics.DrawString($"{employeeName} - {workingHours} hours", SystemFonts.DefaultFont, Brushes.Black, legendTextRect);
            }
        }

        return pieChartImage;
    }



    // function that generate the image file
    public static void GeneratePieChart(Dictionary<string, TimeSpan> EmpList)
    {


        // generate the pie chart image
        var pieChartImage = GeneratePieChartService.DrawPieChart(EmpList);

        // the file path for the pie chart image
        string imagePath = @"..\..\..\pie_chart.png";

        // save the IMG file with its path
        pieChartImage.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);



    }
}
