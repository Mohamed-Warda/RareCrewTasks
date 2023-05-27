import { Component, OnInit } from '@angular/core';
import{IEmployee} from '../_models/IEmployee'
import { EmployeeService } from '../_services/Employee.service';
@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {


  EmployeeList :any;
  //used to check if the data is loaded before sending it to the pieChart Component
  dataLoaded:boolean=false;

  constructor(private employeeService:EmployeeService){

  }

  ngOnInit() {

    
  
    // get the data from the service
    this.employeeService.GetEmployees().subscribe(
      value => {
      this.EmployeesWorkingHours(value);
      this.dataLoaded = true;
    },
    error => {
      console.error(error);
    },
    () => {
      console.log('completed');
    })
    }


    // fuction to calc the working hours for each employee
    EmployeesWorkingHours(Employees :IEmployee[]){
      
      const employees: IEmployee[] = Employees;
      
      const employeeWithHours: { [key: string]: number } = {};
      
      for (const emp of employees) {
        const employee = emp.EmployeeName;
        const startDate = new Date(emp.StarTimeUtc);
        const endDate = new Date(emp.EndTimeUtc);
        const timeDiff = endDate.getTime() - startDate.getTime();
        const totalHours = timeDiff / (1000 * 60 * 60);
      
        if (employee in employeeWithHours) {
          employeeWithHours[employee] += totalHours;
        } else {
          employeeWithHours[employee] = totalHours;
        }
      }
          // convert object to an array of key value pairs
          const sortedEmployeesArray = Object.entries(employeeWithHours);

          // sort the array  in a Descending order
          sortedEmployeesArray.sort((a, b) => b[1] - a[1]);

         
          this.EmployeeList=sortedEmployeesArray;

    }
  

    // fuction to remove the fraction
    floorValue(value: any): number {
      return Math.floor(value);
    }

}
