import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../../Service/user-service';
import { Router } from '@angular/router';
import { UserAddModel } from '../../Model/user-add-model';

@Component({
  imports: [ReactiveFormsModule],
  selector: 'register-page',
  templateUrl: './register-page.component.html',
  styleUrl: './register-page.component.css',
})
export class RegisterPageComponent {
  constructor(private userService: UserService, private router: Router) {}

  url = '';

  registerForm = new FormGroup({
    username: new FormControl(''),
    fullname: new FormControl(''),
    password: new FormControl(''),
    imageData: new FormControl(''),
  });

  show(event: any) {
    let file = event.target.files[0];

    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = (e) => {
      if (e.target) {
        this.url = e.target.result as string;
      }
    };
  }

  register() {
    let request: UserAddModel = {
      fullname: this.registerForm.value.fullname as string,
      username: this.registerForm.value.username as string,
      password: this.registerForm.value.password as string,
      imageData: this.url,
    };

    this.userService.PostRegister(request).subscribe((res) => {
      if (res.success) {
        this.router.navigate(['login']);
      } else {
        alert(res.errorMessage);
      }
    });
  }
}
