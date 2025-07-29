import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { UserComponent } from './pages/user/user.component';
import { WorkoutComponent } from './pages/workout/workout.component';
import { WorkoutTemplateComponent } from './pages/workout-template/workout-template.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';


export const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
    },
    { path: 'user', component: UserComponent },
    { path: 'workout', component: WorkoutComponent },
    { path: 'workoutTemplate', component: WorkoutTemplateComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule { }
