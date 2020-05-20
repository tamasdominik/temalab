import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Profile } from '../models/profile/profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  private profileURL : string;

  constructor(private http : HttpClient) { 
    this.profileURL="/api/Profiles";
  }

  public getProfile(): Observable<Profile>{
    return this.http.get<Profile>(this.profileURL);
  }

  public editProfile(profile : Profile) : Observable<any>{
    return this.http.put(this.profileURL, profile);

  }


}
