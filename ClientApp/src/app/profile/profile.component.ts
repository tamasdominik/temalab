import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../services/profile.service';
import { Profile } from '../models/profile/profile';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profile : Profile;

  constructor(private profileService : ProfileService, private router : Router) { }

  ngOnInit() {
    this.profileService.getProfile().subscribe(data => {
      this.profile = data;
  });
  }

  redirect(){
    this.router.navigate(['']);
  }

  editProfile(){
    this.profileService.editProfile(this.profile).subscribe(result => this.redirect());
  }

}
