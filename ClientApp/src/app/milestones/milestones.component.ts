import { Component, OnInit } from '@angular/core';
import { StatisticsService} from '../services/statistics.service';
import { MilestoneService} from '../services/milestone.service';
import { Statistics } from '../models/Statistics/statistics';
import { Milestone } from '../models/Milestone/milestone';
import { ParseError } from '@angular/compiler';

@Component({
  selector: 'app-milestones',
  templateUrl: './milestones.component.html',
  styleUrls: ['./milestones.component.css']
})
export class MilestonesComponent implements OnInit {
  Milestones : Milestone[]
  Statistics : Statistics[]
  Percentages : number [] = []
  PictureSources : string [] = ["assets/img/Pushup.jpg","assets/img/situp.jpg","assets/img/biceps.jpg","assets/img/chestfly.jpg",
  "assets/img/deadlift.jpg","assets/img/squat.jpg","assets/img/pullup.jpeg","assets/img/roadrunner.jpg","assets/img/ironlady.jpg"]

  constructor(private StatisticsService : StatisticsService, private MilestoneService : MilestoneService) { }

  ngOnInit() {
    // this.Milestones = []
    // this.Statistics = []
    // this.StatisticsService.findAll().subscribe(data => {
    //   this.Statistics = data
    // })
    this.MilestoneService.findAll().subscribe(data =>{
      this.Milestones = data
    })
    // console.log(this.Milestones)
    // console.log(this.Statistics)
   
    // this.ParseData()
  }
  // ParseData(Milestones : Milestone[], StatList : Statistics []){
    // if (Milestones == undefined) {
    //   console.log("ms üres")
    //   return;
    // }

    // if (StatList == undefined) {
    //   console.log("sl üres")
    //   return;
    // }
    // console.log(Milestones)
  //   console.log(StatList)
  //   for (let i = 0; i < Milestones.length; i++){
  //     for (let j = 0; i < StatList.length, j++;){
  //       if (Milestones[i].name === StatList[j].name ) {
  //         let percentage = 100*(StatList[j].counter / Milestones[i].goal)
  //         if (percentage > 100) percentage = 100
  //         console.log(percentage)
  //         this.Percentages.push(percentage)
  //       }
  //     }
  //   }
  // }
  // GetWidth(index : number){
  //   let p : number = this.Percentages[index]
  //   return "width:${p}%"
  // }
  // GetPercentage(index : number){
  //   return this.Percentages[index]
  // }
}
