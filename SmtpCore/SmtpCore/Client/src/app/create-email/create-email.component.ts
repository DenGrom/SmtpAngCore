import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms'
import {DataService} from '../data.service';
import {Group} from '../models/group';


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
  selectedGroup:Group = new Group();
  groupControl:Group = new Group();
  body:string;
  title:string;

  constructor(private data: DataService,
    private formBuilder: FormBuilder) { 
    
      this.messageForm = new FormGroup({
        body: new FormControl(),
        title: new FormControl(),
        groupControl: new FormControl()
     });
  }
  selectGroup(groupId) { 
    this.groupControl = null;
    for (var i = 0; i < this.groups.length; i++)
    {
      if (this.groups[i].id == groupId) {
        this.groupControl = this.groups[i];
      }
    }
}

  onSubmit() {
    var values =  this.messageForm.getRawValue();
    debugger;
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
      var groups = result as Array<Group>;
      if(groups.length > 0)
      {
        this.groupControl = groups[0];
      }
      this.groups = groups;

      this.messageForm = this.formBuilder.group({
        title: ['', Validators.required],
        body: ['', Validators.required],
        groupControl: ['', Validators.required]
        
      })
    });

  }

}
