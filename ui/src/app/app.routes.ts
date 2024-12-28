import { Routes } from '@angular/router';
import { LoginPageComponent } from './Page/login-page/login-page.component';
import { ProfilePageComponent } from './Page/profile-page/profile-page.component';
import { RegisterPageComponent } from './Page/register-page/register-page.component';

export const routes: Routes = [
    {path:'login' , component:LoginPageComponent},
    {path:'profile' , component:ProfilePageComponent},
    {path:'register' , component:RegisterPageComponent}
];
