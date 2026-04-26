import { Routes } from '@angular/router';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { AddEditStudentComponent } from './Pages/add-edit-student/add-edit-student.component';

export const routes: Routes = [
    {path:'', component :DashboardComponent  },
    {path: 'AddEdit' , component: AddEditStudentComponent}

];
