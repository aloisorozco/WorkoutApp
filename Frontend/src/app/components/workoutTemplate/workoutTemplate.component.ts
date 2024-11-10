import { Component } from '@angular/core';
import { WorkoutTemplate } from '../../models/properties';
@Component({
  selector: 'app-workout-template',
  templateUrl: './workoutTemplate.component.html',
  styleUrls: ['./workoutTemplate.component.scss'],
})
export class workoutTemplate {

  constructor(
  ) {}

  async ngOnInit() {
  }

  ngOnDestroy() {
  }

 
  navigateToWorkoutTemplate(item: WorkoutTemplate): void {
  }

  calculateTotalExercises(workoutTemplate: WorkoutTemplate): number {
    return workoutTemplate.Exercises.length;
  }
}