import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl="http://localhost:5000/api";

  constructor(private http:HttpClient) { }

  getNalogList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/putninalog');
  }

  addNalog(val:any){
    return this.http.post(this.APIUrl+'/putninalog',val);
  }

  updateNalog(val:any){
    return this.http.put(this.APIUrl+'/putninalog',val);
  }

  deleteNalog(val:any){
    return this.http.delete(this.APIUrl+'/putninalog/'+val);
  }

  getPutnikList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/putnik');
  }

  addPutnik(val:any){
    return this.http.post(this.APIUrl+'/putnik',val);
  }

  updatePutnik(val:any){
    return this.http.put(this.APIUrl+'/putnik',val);
  }

  deletePutnik(val:any){
    return this.http.delete(this.APIUrl+'/putnik/'+val);
  }

  getAllPutniNalozi():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/putnik/PutnikoviNalozi');
  }


}
