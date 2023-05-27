using CSharpTasks.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CSharpTasksp.Data
{
    public   class APIData
    {
        // function to get the date from the end point
        public static List<Employee> GetEmployeesFromApi()
        {
            string apiUrl = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(apiUrl);
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(json);

                return employees;
            }
        } 
        

        // function that take the employees data and calculated the total hours for every employee
        public static Dictionary<string, TimeSpan> PrepareEmployeesData()
        {
            List<Employee> employees = APIData.GetEmployeesFromApi();

            Dictionary<string, TimeSpan> EmpList = new Dictionary<string, TimeSpan>();



            foreach (Employee emp in employees)
            {
                // if the employee name already in the dictionary just add the hours
                if (EmpList.ContainsKey(emp.EmployeeName ?? "No Name"))
                {
                    EmpList[emp.EmployeeName ?? "No Name"] += emp.GetTotalTimeWorked();
                }
                // else add the employee

                else
                {
                    EmpList.Add(emp.EmployeeName ?? "No Name", emp.GetTotalTimeWorked());
                }

            }
            // order the data Ascending 
            var orderedDictionary = EmpList.OrderBy(pair => pair.Value);
            EmpList = orderedDictionary.ToDictionary(pair => pair.Key, pair => pair.Value);

            return EmpList;
        }


    }
}
