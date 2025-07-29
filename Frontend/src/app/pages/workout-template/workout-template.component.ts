import { ChangeDetectionStrategy, Component, inject } from '@angular/core';

import { MatDialog } from '@angular/material/dialog';

import { WorkoutTemplateService } from '../../services/workout-template.service';
import { WorkoutTemplate } from '../../models/properties';
import { AddWorkoutTemplateComponent } from './add/add.component';

@Component({
  selector: 'app-workout-template',
  templateUrl: './workout-template.component.html',
  styleUrl: './workout-template.component.scss'
})
export class WorkoutTemplateComponent {
  workoutTemplates: WorkoutTemplate[] = [];
  readonly dialog = inject(MatDialog);

  openAddDialog() {
    const dialogRef = this.dialog.open(AddWorkoutTemplateComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  constructor(private workoutTemplateService: WorkoutTemplateService) {
    workoutTemplateService.getWorkoutTemplates().subscribe(
      (workoutTemplates) => {
        console.log(workoutTemplates)
        this.workoutTemplates = workoutTemplates
      },
      (error: any) => {
        console.log(error)
      }
    );
  }
}
