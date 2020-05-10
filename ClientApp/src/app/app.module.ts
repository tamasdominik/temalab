import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { ProfileComponent } from './profile/profile.component';
import { WorkoutsComponent } from './workouts/workouts.component';
import { RanglistComponent } from './ranglist/ranglist.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { combineAll } from 'rxjs/operators';
import { MilestonesComponent } from './milestones/milestones.component';
import { AddNewWorkoutComponent } from './add-new-workout/add-new-workout.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProfileComponent,
    WorkoutsComponent,
    RanglistComponent,
    StatisticsComponent,
    MilestonesComponent,
    AddNewWorkoutComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'profile', component: ProfileComponent, canActivate: [AuthorizeGuard]},
      { path: 'workouts/new', component: AddNewWorkoutComponent, canActivate: [AuthorizeGuard]},
      { path: 'workouts', component: WorkoutsComponent, canActivate: [AuthorizeGuard] },
      { path: 'statistics', component: StatisticsComponent, canActivate: [AuthorizeGuard]},
      { path: 'ranglist', component: RanglistComponent, canActivate: [AuthorizeGuard]},
      { path: 'milestones', component: MilestonesComponent, canActivate: [AuthorizeGuard]},
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
