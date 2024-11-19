import { Routes } from '@angular/router';
import { AddStudentComponent } from './components/add-student/add-student.component';
import { StudentDetailsComponent } from './components/student-details/student-details.component';
import { StudentListComponent } from './components/student-list/student-list.component';
import { DeleteStudentComponent } from './components/delete-student/delete-student.component';
import { UpdateStudentComponent } from './components/update-student/update-student.component';

export const routes: Routes = [
    {
        path: "add-student", component:AddStudentComponent
    },
    {
        path: "student-list", component:StudentListComponent
    },
    {
        path: "student-details", component:StudentDetailsComponent
    },
    {
        path: "delete-student", component: DeleteStudentComponent
    },
    {
        path: "update-student", component: UpdateStudentComponent
    }
];
