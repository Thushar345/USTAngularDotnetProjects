import { Component, inject } from '@angular/core';
import { StudentService } from '../../service/student.service';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-update-student',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './update-student.component.html',
  styleUrl: './update-student.component.css'
})
export class UpdateStudentComponent {
  studentObj: any = {
    "studentId": 0,
    "studentName": "",
    "studentGrade": "",
    "studentRollNo": "",
    "isActive": true,
    "createdDate": "",
    "modifiedDate": ""
  };
  edo: any = {
    "studentId": 0,
    "studentName": "",
    "studentGrade": "",
    "studentRollNo": "",
    "isActive": true,
    "createdDate": "",
    "modifiedDate": ""
  };
  studentService = inject(StudentService)
  studentList: any[] = [];
  http = inject(HttpClient);
  ngOnInit(): void {
    this.loadStudents();
  }
  loadStudents(){
    this.studentService.getStudents().subscribe((res: any) => {
      this.studentList = res;
    })
  }


  editStudent(student: any) {
    this.studentObj = student // Create a copy of the selected student
    //this.edo =student;
  }

  updateStudent() {
    this.http.put("https://localhost:7088/api/TblStudents/"+this.studentObj.studentId, this.studentObj)
      .subscribe((res: any) => {
        if (this.studentObj!=res) {
          alert("Student Record Updated");
        } 
        else if(this.studentObj==res) {
          alert("Some problem in student update");
        }
      });
  }
  
}
