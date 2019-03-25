import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }
  getAllGroups() {
    var group = this.http.get('http://localhost:49327/api/group');
    return group;
  }
}
