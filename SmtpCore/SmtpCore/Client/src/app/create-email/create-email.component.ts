import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import {DataService} from '../data.service';
import {Group} from '../models/group'

@Component({
  selector: 'app-create-email',
  templateUrl: './create-email.component.html',
  styleUrls: ['./create-email.component.css']
})
export class CreateEmailComponent implements OnInit {

  groups:Array<Group>;
  messageForm: FormGroup;
  submitted = false;
  success = false;

  constructor(private data: DataService,
    private formBuilder: FormBuilder) { 
    
    this.messageForm = this.formBuilder.group({
      title: ['', Validators.required],
      body: ['', Validators.required]
    })
  }
  
  onSubmit() {
    console.log(this.messageForm);
    this.submitted = true;
    if (this.messageForm.invalid) {
      return;
    }
    this.success = true;
  }

  ngOnInit() {
    var test = this.data.getAllGroups()
    .subscribe(result => {
      debugger;
      var groups = result as Array<Group>;
      this.groups = groups;
    });
  }

}
