import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WorkoutTemplate } from '../models/properties';

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
  getWorkoutTemplates(): Observable<WorkoutTemplate[]> {
    return this.http.get<WorkoutTemplate[]>('/api/workoutTemplate');
  }
  addWorkoutTemplate(newWorkoutTemplate: Object) {
    this.workoutTemplates.push(newWorkoutTemplate);
  }

  constructor(
    private http: HttpClient) { }
}
