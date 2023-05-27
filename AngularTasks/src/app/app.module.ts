import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {  HttpClientModule } from '@angular/common/http';
import { NgApexchartsModule } from 'ng-apexcharts';
import { TableComponent } from './table/table.component';
import { PieChartComponent } from './pie-chart/pie-chart.component';

@NgModule({
  declarations: [
    AppComponent,
    TableComponent,
    PieChartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgApexchartsModule,

    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
