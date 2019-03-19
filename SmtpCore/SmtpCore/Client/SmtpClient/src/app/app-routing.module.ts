import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EmailsComponent } from './emails/emails.component';
import { CreateEmailComponent } from './create-email/create-email.component';
import { GroupsUsersComponent } from './groups-users/groups-users.component';
import { UsersComponent } from './users/users.component';





const routes: Routes = [
  { path: '', component: EmailsComponent },
  { path: 'create-emails', component: CreateEmailComponent },
  { path: 'groups-users', component: GroupsUsersComponent },
  { path: 'users', component: UsersComponent },
  { path: '**', redirectTo: '' },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
