import { Component, OnInit } from '@angular/core';
import { Ranglist } from '../models/ranglist/ranglist';
import { RanglistService } from '../services/ranglist.service';

@Component({
  selector: 'app-ranglist',
  templateUrl: './ranglist.component.html',
  styleUrls: ['./ranglist.component.css']
})
export class RanglistComponent implements OnInit {

  ranglist : Ranglist[];
  constructor(private ranglistService : RanglistService) { }

  ngOnInit() {
    this.ranglistService.getAllRanks().subscribe(data => {this.ranglist = data;})
  }

}
