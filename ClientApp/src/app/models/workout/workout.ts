import { Exercise } from "../Exercise/exercise";

export class Workout {
    workoutName : string;
    exercises : Exercise[];

    constructor(wn : string){
        this.workoutName = wn;
        this.exercises = [];
    }
}
