import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'add-workout-template',
  templateUrl: './add.component.html',
  styleUrl: './add.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AddWorkoutTemplateComponent {
}
