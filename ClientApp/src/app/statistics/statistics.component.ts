import { Component, OnInit } from '@angular/core';
import { Statistics } from '../models/Statistics/statistics';
import { StatisticsService } from '../services/statistics.service';


@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {

  statistics: Statistics[];
  constructor(private statisticsService: StatisticsService) { }

  ngOnInit() {
    this.statisticsService.findAll().subscribe(data => {
      this.statistics = data;
    })
  }

}