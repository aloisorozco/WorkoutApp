import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatExpansionModule } from '@angular/material/expansion';

import { AppRoutingModule } from './app.routes';

import { HeaderComponent } from './components/header/header.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { WorkoutTemplateComponent } from './pages/workout-template/workout-template.component';
import { AddWorkoutTemplateComponent } from './pages/workout-template/add/add.component';
import { DeleteWorkoutTemplateComponent } from './pages/workout-template/delete/delete.component';
import { EditWorkoutTemplateComponent } from './pages/workout-template/edit/edit.component';
import { AddWorkoutComponent } from './pages/workout/add/add.component';
import { EditWorkoutComponent } from './pages/workout/edit/edit.component';
import { DeleteWorkoutComponent } from './pages/workout/delete/delete.component';

import { WorkoutTemplateService } from './services/workout-template.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    RegisterComponent,
    WorkoutTemplateComponent,
    AddWorkoutTemplateComponent,
    DeleteWorkoutTemplateComponent,
    EditWorkoutTemplateComponent,
    AddWorkoutComponent,
    EditWorkoutComponent,
    DeleteWorkoutComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule,
    MatMenuModule,
    MatIconModule,
    MatToolbarModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatListModule,
    MatExpansionModule
  ],
  providers: [
    WorkoutTemplateService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }