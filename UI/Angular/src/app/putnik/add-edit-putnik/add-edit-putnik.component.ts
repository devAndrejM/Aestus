import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-putnik',
  templateUrl: './add-edit-putnik.component.html',
  styleUrls: ['./add-edit-putnik.component.css']
})
export class AddEditPutnikComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() putnik:any;
  PutnikId: string | undefined;
  Ime: string | undefined;
 Prezime: string | undefined;

  PutniNalogList:any=[];
  
  
  

  ngOnInit(): void {
    this.loadPutniNalogList();
    this.PutnikId=this.putnik.PutnikId;
    this.Ime=this.putnik.Ime;
    this.Prezime=this.putnik.Prezime;
    
  }

  loadPutniNalogList(){
    this.service.getAllPutniNalozi().subscribe((data:any)=>{
      this.PutniNalogList=data;

      this.PutnikId=this.PutnikId;
      this.Ime=this.Ime;
    this.Prezime=this.Prezime;
    });
}

  addPutnik(){
var val = {PutnikId:this.PutnikId,
  Ime:this.Ime,
    Prezime:this.Prezime   
}
this.service.addPutnik(val).subscribe(res=>alert(res.toString()));
  }

  updatePutnik(){
    var val = {PutnikId:this.PutnikId,
      Ime:this.Ime,
    Prezime:this.Prezime  
    }
    this.service.updatePutnik(val).subscribe(res=>alert(res.toString()));

    
  }
}



