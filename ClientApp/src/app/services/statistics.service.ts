import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Statistics } from '../models/Statistics/statistics';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {

  private statisticsURL : string;

  constructor(private http : HttpClient) {
    this.statisticsURL = "https://localhost:44319/api/Statistics";
   }

   public findAll(): Observable<Statistics[]>{
    return this.http.get<Statistics[]>(this.statisticsURL);
  }
}
