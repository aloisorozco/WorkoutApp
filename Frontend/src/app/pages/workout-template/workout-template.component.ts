import { Component } from '@angular/core';
import { WorkoutTemplateService } from '../../services/workout-template.service';
import { WorkoutTemplate } from '../../models/properties';

@Component({
  selector: 'app-workout-template',
  templateUrl: './workout-template.component.html',
  styleUrl: './workout-template.component.scss'
})
export class WorkoutTemplateComponent {
  workoutTemplates: WorkoutTemplate[] = [];

  constructor(private workoutTemplateService: WorkoutTemplateService) {
    workoutTemplateService.getWorkoutTemplates().subscribe(
      (workoutTemplates) => {
        console.log(JSON.stringify(workoutTemplates))
        this.workoutTemplates = workoutTemplates
      },
      (error: any) => {
        console.log(error)
      }
    );
  }
}
