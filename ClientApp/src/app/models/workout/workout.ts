import { Exercise } from "../Exercise/exercise";

export class Workout {
    id : string;
    workoutName : string;
    exercise : Exercise[];

    constructor(wn : string){
        this.workoutName = wn;
        this.exercise = [];
    }
}
