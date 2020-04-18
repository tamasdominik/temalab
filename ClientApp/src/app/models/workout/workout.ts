import { Exercise } from "../Exercise/exercise";

export class Workout {
    workoutName : string;
    exercise : Exercise[];

    constructor(wn : string){
        this.workoutName = wn;
        this.exercise = [];
    }
}
