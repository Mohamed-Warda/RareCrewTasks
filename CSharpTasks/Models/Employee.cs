using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTasks.Models
{
    public class Employee
    {
    public string Id { get; set; }
    public string EmployeeName { get; set; }
    public DateTime StarTimeUtc { get; set; }
    public DateTime EndTimeUtc { get; set; }
    public string EntryNotes { get; set; }

        // used '?' because DeletedOn can have null values
        public DateTime? DeletedOn { get; set; }

    public TimeSpan GetTotalTimeWorked()
    {
         // just to check if the values are valid dates
        if (DateTime.TryParse(StarTimeUtc.ToString(), out DateTime startTime) && DateTime.TryParse(EndTimeUtc.ToString(), out DateTime endTime))
        {
                TimeSpan totalTime = endTime - startTime;

                return totalTime;
         }
            //if the parse fails just return 0:0:0
            return new TimeSpan(0, 0, 0);
        }
    }



  }

