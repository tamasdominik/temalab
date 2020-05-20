import { Exercise } from "../Exercise/exercise";

export class Workout {
    id : number;
    workoutName : string;
    exercise : Exercise[];

    constructor(wn : string){
        this.workoutName = wn;
        this.exercise = [];
    }
}
