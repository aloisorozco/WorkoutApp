import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WorkoutTemplateService {

  private workoutTemplates: Object[] = [{
    id: 123,
    name: "upper 1",
    exercises: [
      "bench press",
      "bicep curls"
    ]
  }];
  getWorkoutTemplates(): Object[] {
    return this.workoutTemplates;
  }
  addWorkoutTemplate(newWorkoutTemplate: Object) {
    this.workoutTemplates.push(newWorkoutTemplate);
  }

  constructor() { }
}
