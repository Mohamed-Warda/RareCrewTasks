import { Component, Input, OnInit } from '@angular/core';
import { ApexChart, ApexDataLabels, ApexNonAxisChartSeries, ApexTitleSubtitle } from 'ng-apexcharts';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements OnInit {
  // pieChart labels
  chartLabels:string[]=[];
    // pieChart values
  chartSeries:number[]=[] ;
  //data from the parent component
  @Input() pieChartData :any;
  constructor() { }

  ngOnInit(): void {
    // function to draw the pieChart
    this.drawPieChart();
  }

  drawPieChart(){
  
    // loop over the array of employees and put their data to the pieChart
    this.pieChartData.forEach((element:any) => {
      this.chartLabels.push( element[0])
     
      this.chartSeries.push( this.floorValue( element[1]))
    });
     
    }
    
    

    //pieChart configuration
      chartDetails: ApexChart = {
        type: 'pie',
        toolbar: {
          show: true
        }
      };
    
     
    
    
      chartTitle: ApexTitleSubtitle = {
        text: 'Employees Hours PieChart',
        align: 'center'
      };
    
      chartDataLabels: ApexDataLabels = {
        enabled: true
      };


      // fuction to remove the fraction
      floorValue(value: any): number {
        return Math.floor(value);
      }
  
}
