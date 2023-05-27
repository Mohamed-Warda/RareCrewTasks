import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IEmployee } from '../_models/IEmployee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  baseUrl="https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ=="

  constructor(private http:HttpClient) { }


GetEmployees(){

   return this.http.get<IEmployee[]>(this.baseUrl)
    
  
}
}