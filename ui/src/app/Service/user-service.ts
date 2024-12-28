import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ResultModel } from "../Model/result-model";
import { UserLoginModel } from "../Model/user-login-model";
import { UserProfileModel } from "../Model/user-profile-model";
import { UserAddModel } from "../Model/user-add-model";

@Injectable({providedIn: 'root'})

export class UserService {
    constructor(private http: HttpClient){}

    PostLogin(request:UserLoginModel){
        const url = "http://localhost:56705/user/login"
        return this.http.post<ResultModel<number>>(url,request)
    }

    PostRegister(request:UserAddModel){
        const url = "http://localhost:56705/user/register"
        return this.http.post<ResultModel<number>>(url,request)
    }

    GetProfile(userid : number){
        const url = `http://localhost:56705/user/profile?userid=${userid}`
        return this.http.get<ResultModel<UserProfileModel>>(url)
    }
}