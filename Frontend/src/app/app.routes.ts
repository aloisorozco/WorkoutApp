import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { UserComponent } from './pages/user/user.component';
import { WorkoutComponent } from './pages/workout/workout.component';


export const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
    },
    { path: 'user', component: UserComponent },
    { path: 'workout', component: WorkoutComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule { }
