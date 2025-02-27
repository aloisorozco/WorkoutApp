import { Component } from '@angular/core';
import { WorkoutTemplateService } from '../../services/workout-template.service';

@Component({
  selector: 'app-workout-template',
  templateUrl: './workout-template.component.html',
  styleUrl: './workout-template.component.scss'
})
export class WorkoutTemplateComponent {
  workoutTemplates: Object[];

  constructor(private workoutTemplateService: WorkoutTemplateService) {
    this.workoutTemplates = workoutTemplateService.getWorkoutTemplates();
  }

}
