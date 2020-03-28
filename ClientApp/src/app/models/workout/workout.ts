import { Exercise } from "../Exercise/exercise";

export class Workout {
    WorkoutID : number;
    WorkoutConnection_ID : number;
    Profile_ID : number;
    Name : string;
    Exercises : Exercise[];
    Counter : number;
}
