import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../services/profile.service';
import { Profile } from '../models/profile/profile';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profile : Profile;

  constructor(private profileService : ProfileService) { }

  ngOnInit() {
    this.profileService.getProfile().subscribe(data => {
      this.profile = data;
  });
  }

  editProfile(){
    this.profileService.editProfile(this.profile).subscribe();
  }

}
