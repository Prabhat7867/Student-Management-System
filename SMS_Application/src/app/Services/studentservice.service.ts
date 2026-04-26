import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from '../Interfaces/Student';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentserviceService { 

  private ApiURL :string =  'https://localhost:7011/api/Student';
  constructor(private http:HttpClient) { }

  Students: Student[] = [{
    id: 1,
    name: 'Prabhat',
    standard: 12,
    email: 'Prabhat@gmail.com',
    fathersName: '',
    dob: '2000/04/24',
    mobno: ''
  },
  {
    id:2,
    name: 'Sumit',
    standard: 12,
    email: 'Sumit@gmail.com',
    fathersName: '',
    dob: '2000/04/23',
    mobno: ''
   }
]

getStudents(): Observable<Student[]>{
  // return of(this.Students);
  return this.http.get<Student[]>(this.ApiURL)
}


}
