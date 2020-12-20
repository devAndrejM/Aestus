import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-show-nalog',
  templateUrl: './show-nalog.component.html',
  styleUrls: ['./show-nalog.component.css']
})
export class ShowNalogComponent implements OnInit {

  constructor(private service:SharedService) { }

  PutniNalogList:any=[];
  
  ModalTitle: string | undefined ;
ActivateAddEditNalogComp:boolean=false;
putninalog:any;

PutniNalogIdFilter:string="";
PutniciFilter:string="";
PolazisteFilter:string="";
OdredisteFilter:string="";
PutniNalogListNoFilter:any=[];

  ngOnInit(): void {
    this.refreshPutniNalogList();
  }

  addClick()
{
this.putninalog={
  PutniNalogId:0,
  Polazak:"",
  Povratak:"",
  RazlogPutovanja:"",
  BrojPutnika:0,
  Putnici:"",
  Polaziste:"",
  Odrediste:"",
  Prijevoz:"",
  RegistracijaVozila:"",
  Komentar:"",
  Email:""  
}

this.ModalTitle="Novi Zahtjev";
this.ActivateAddEditNalogComp=true;
}

editClick(item: any){
  this.putninalog=item;
  this.ModalTitle="Uredi Nalog";
  this.ActivateAddEditNalogComp=true;
}

deleteClick(item:any){
  if(confirm('Are you sure?')){
    this.service.deleteNalog(item.PutniNalogId).subscribe(data=>{
      alert(data.toString());
      this.refreshPutniNalogList();
    })
  }
}

closeClick(){
  this.ActivateAddEditNalogComp=false;
  this.refreshPutniNalogList();
}

  refreshPutniNalogList(){
    this.service.getNalogList().subscribe(data=>{
      this.PutniNalogList=data;
      this.PutniNalogListNoFilter=data;
    });
  }

  FilterFn(){
    var PutniNalogIdFilter = this.PutniNalogIdFilter;
    var PutniciFilter = this.PutniciFilter;
    var PolazisteFilter = this.PolazisteFilter;
    var OdredisteFilter = this.OdredisteFilter;

    this.PutniNalogList = this.PutniNalogListNoFilter.filter(function (el: { PutniNalogId: { toString: () => string; }; Putnici: { toString: () => string; }; Polaziste: { toString: () => string; }; Odrediste: { toString: () => string; }; }){
      return el.PutniNalogId.toString().toLowerCase().includes(
        PutniNalogIdFilter.toString().trim().toLowerCase()
        )&&
        el.Putnici.toString().toLowerCase().includes(
          PutniciFilter.toString().trim().toLowerCase()
        )&&
        el.Polaziste.toString().toLowerCase().includes(
          PolazisteFilter.toString().trim().toLowerCase()
        )&&
        el.Odrediste.toString().toLowerCase().includes(
          OdredisteFilter.toString().trim().toLowerCase()
        )
    });
  }

  sortResult(prop: string | number,asc: any){
    this.PutniNalogList = this.PutniNalogListNoFilter.sort(function(a: { [x: string]: number; },b: { [x: string]: number; }){
      if(asc){
        return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }
}
