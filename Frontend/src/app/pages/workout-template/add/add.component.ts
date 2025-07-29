import { ChangeDetectionStrategy, Input, Component, Output, EventEmitter } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';

import { WorkoutTemplateService } from '../../../services/workout-template.service';
import { WorkoutTemplate } from '../../../models/properties';

@Component({
  selector: 'add-workout-template',
  templateUrl: './add.component.html',
  styleUrl: './add.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AddWorkoutTemplateComponent {
  form: FormGroup = new FormGroup({
    name: new FormControl(''),
    exercises: new FormArray([new FormControl('')]),
  });

  name: string;
  exercise: string;

  get exercises() {
    return this.form.controls["exercises"] as FormArray;
  }

  getExercise(index: number): FormControl {
    return this.exercises.controls[index] as FormControl
  }

  addExercise() {
    this.form.markAllAsTouched();
    const control = new FormControl('');
    this.exercises.push(control);
  }

  removeExercise(index: number) {
    this.exercises.removeAt(index);
  }

  submit() {
    console.log(this.form)
    if (this.form.valid) {
      console.log(JSON.stringify(this.form.value))
      this.workoutTemplateService.addWorkoutTemplate(this.form.value)
    } else {
      console.log(this.form.errors)
    }
  }
  @Input() error: string | null;

  @Output() submitEM = new EventEmitter();

  constructor(private workoutTemplateService: WorkoutTemplateService) {

  }
}
