import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WorkoutTemplate } from '../models/properties';

@Injectable({
  providedIn: 'root'
})
export class WorkoutTemplateService {

  private workoutTemplates: WorkoutTemplate[] = [];

  getWorkoutTemplates(): Observable<WorkoutTemplate[]> {
    return this.http.get<WorkoutTemplate[]>('/api/workoutTemplate');
  }

  addWorkoutTemplate(newWorkoutTemplate: WorkoutTemplate) {
    console.log("hello : " + JSON.stringify(newWorkoutTemplate))
    this.http.post('/api/workoutTemplate', newWorkoutTemplate).subscribe(() => this.workoutTemplates.push(newWorkoutTemplate));
  }

  editWorkoutTemplate(newWorkoutTemplate: WorkoutTemplate) {
    this.http.patch('/api/workoutTemplate', newWorkoutTemplate);
    this.workoutTemplates.map((workoutTemplate) => {
      if (workoutTemplate.id === newWorkoutTemplate.id) {
        return newWorkoutTemplate
      }
      return workoutTemplate
    });
  }

  deleteWorkoutTemplate(workoutTemplateId: string) {
    this.http.delete(`/api/workoutTemplate/${workoutTemplateId}`);
    this.workoutTemplates = this.workoutTemplates.filter(workoutTemplate => workoutTemplate.id !== workoutTemplateId);
  }

  constructor(
    private http: HttpClient) { }
}
