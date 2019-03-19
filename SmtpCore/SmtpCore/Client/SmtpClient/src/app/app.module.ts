import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmailsComponent } from './emails/emails.component';
import { CreateEmailComponent } from './create-email/create-email.component';
import { UsersComponent } from './users/users.component';
import { GroupsUsersComponent } from './groups-users/groups-users.component';

@NgModule({
  declarations: [
    AppComponent,
    EmailsComponent,
    CreateEmailComponent,
    UsersComponent,
    GroupsUsersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    { provide: APP_BASE_HREF, useValue : '/' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
