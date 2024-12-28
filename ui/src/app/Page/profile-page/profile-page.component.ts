import { Component, OnInit } from "@angular/core";
import { UserService } from "../../Service/user-service";
import { NgIf } from "@angular/common";

@Component({
    imports: [NgIf],
    selector: "profile-page",
    templateUrl: "./profile-page.component.html",
    styleUrl: "./profile-page.component.css"
})

export class ProfilePageComponent implements OnInit {
    constructor(private userService: UserService) {}

    username = "";
    fullname = "";
    avatar = "";
    isLoading = true;

    ngOnInit() {
        let userId = parseInt(sessionStorage.getItem("userid")!);
        this.userService.GetProfile(userId).subscribe((res) => {
            this.username = res.data.username;
            this.fullname = res.data.fullname;
            this.avatar = res.data.avatar;
            this.isLoading = false;
        });
    }
}
