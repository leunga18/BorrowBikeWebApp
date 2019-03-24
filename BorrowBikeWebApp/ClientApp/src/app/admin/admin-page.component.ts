import { Component, OnInit, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { BikeListComponent } from '../bike-list/bike-list.component';


@Component({ templateUrl: 'admin-page.component.html' })
export class AdminPageComponent implements OnInit{
  loginForm: FormGroup;
  loading = false;
  returnUrl: string;
  admins: Admin[];
  bikes: Bike[];
  baseUrl: string;
  loggedIn = false;
  users: User[];

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.http.get<Admin[]>('api/Admins').subscribe(result => {
      this.admins = result;
    }, error => console.error(error));

    this.http.get<Bike[]>('api/Bikes').subscribe(result => {
      this.bikes = result;
    }, error => console.error(error));

    this.http.get<User[]>('api/Users').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
    
  }
  
  onSubmit() {

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    for (let admin of this.admins) {
      if (admin.username == this.loginForm.controls.username.value && admin.password == this.loginForm.controls.password.value) {
        this.loggedIn = true;
      }
    }
    if (!this.loggedIn) {
      window.alert("Incorrect Login. Please try again")
    }
   
  }

  findUser(userId): string {
    for (let user of this.users) {
      if (user.id == userId) {
        return user.name;
      }
    }
  }


}

interface Admin {
  username: string;
  password: string;
}

interface User {
  Id: number;
  Name: string;
}
