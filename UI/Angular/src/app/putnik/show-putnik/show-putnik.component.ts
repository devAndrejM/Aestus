import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-show-putnik',
  templateUrl: './show-putnik.component.html',
  styleUrls: ['./show-putnik.component.css']
})
export class ShowPutnikComponent implements OnInit {

  constructor(private service:SharedService) { }

  PutnikList:any=[];
  
  ModalTitle!: string ;
ActivateAddEditPutnikComp:boolean=false;
putnik:any;

  ngOnInit(): void {
    this.refreshPutnikList();
  }

  addClick()
{
this.putnik={
  PutnikId:0,
  Ime:"",
  Prezime:"",
  PutniNalogList:""
}

this.ModalTitle="Novi Putnik";
this.ActivateAddEditPutnikComp=true;
}

editClick(item: any){
  this.putnik=item;
  this.ModalTitle="Uredi Putnika";
  this.ActivateAddEditPutnikComp=true;
}

deleteClick(item:any){
  if(confirm('Are you sure?')){
    this.service.deletePutnik(item.PutnikId).subscribe(data=>{
      alert(data.toString());
      this.refreshPutnikList();
    })
  }
}

closeClick(){
  this.ActivateAddEditPutnikComp=false;
  this.refreshPutnikList();
}

  refreshPutnikList(){
    this.service.getPutnikList().subscribe(data=>{
      this.PutnikList=data;
    });
  }
}

