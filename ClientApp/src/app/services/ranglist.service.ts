import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ranglist } from '../models/ranglist/ranglist';

@Injectable({
  providedIn: 'root'
})
export class RanglistService {

  private ranglistURL : string;

  constructor(private http : HttpClient) {
    this.ranglistURL = "https://localhost:44319/api/Ranglist";
   }

   public getAllRanks(): Observable<Ranglist[]>{
     return this.http.get<Ranglist[]>(this.ranglistURL);
   }
}
