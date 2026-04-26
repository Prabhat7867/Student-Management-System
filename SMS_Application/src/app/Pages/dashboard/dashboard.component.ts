import { Component } from '@angular/core';
import { StudentserviceService } from '../../Services/studentservice.service';
import { Student } from '../../Interfaces/Student';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {

  students$!: Observable<Student[]>;

  constructor(private studentservice:StudentserviceService){}


  ngOnInit(){
    this.getAllStudents();
  }
  
 getAllStudents()
 {
    this.students$ = this.studentservice.getStudents();
 }

}
