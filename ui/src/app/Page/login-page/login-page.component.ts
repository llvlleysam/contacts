import { Component } from "@angular/core";
import { FormControl, FormGroup, ReactiveFormsModule } from "@angular/forms";
import { UserLoginModel } from "../../Model/user-login-model";
import { UserService } from "../../Service/user-service";
import { Router, RouterLink } from "@angular/router";

@Component({
    imports:[ReactiveFormsModule,RouterLink],
    selector: "login-page",
    templateUrl: "./login-page.component.html",
    styleUrl: "./login-page.component.css"
})

export class LoginPageComponent {
    constructor(private userService : UserService ,private router: Router){}

    loginform = new FormGroup({
        username : new FormControl(""),
        password : new FormControl("")
    })

    login(){

        let request:UserLoginModel={
            username : this.loginform.value.username as string ,
            password : this.loginform.value.password as string
        }

        this.userService.PostLogin(request).subscribe((res)=>{
            if(res.success){
                sessionStorage.setItem("userid" , res.data.toString())
                this.router.navigate(["profile"])
            }else{
                alert(res.errorMessage)
            }
        })
    }
}