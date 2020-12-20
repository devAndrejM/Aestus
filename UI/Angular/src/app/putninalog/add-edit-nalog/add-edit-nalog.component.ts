import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
@Component({
  selector: 'app-add-edit-nalog',
  templateUrl: './add-edit-nalog.component.html',
  styleUrls: ['./add-edit-nalog.component.css']
})
export class AddEditNalogComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() putninalog:any;
  PutniNalogId: string | undefined;
  Polazak: string | undefined;
  Povratak: string | undefined;
  RazlogPutovanja: string | undefined;
  BrojPutnika: string | undefined;
  Putnici: string | undefined;
  Polaziste: string | undefined;
  Odrediste: string | undefined;
  Prijevoz: string | undefined;  
  RegistracijaVozila: string | undefined;
  Komentar: string | undefined;
  Email: string | undefined;
  
  

  ngOnInit(): void {
    this.PutniNalogId=this.putninalog.PutniNalogId;
    this.Polazak=this.putninalog.Polazak;
    this.Povratak=this.putninalog.Povratak;
    this.RazlogPutovanja=this.putninalog.RazlogPutovanja;
    this.BrojPutnika=this.putninalog.BrojPutnika;
    this.Putnici=this.putninalog.Putnici;
    this.Polaziste=this.putninalog.Polaziste;
    this.Odrediste=this.putninalog.Odrediste;
    this.Prijevoz=this.putninalog.Prijevoz;
    this.RegistracijaVozila=this.putninalog.RegistracijaVozila;
    this.Komentar=this.putninalog.Komentar;
    this.Email=this.putninalog.Email;
  }

  addPutniNalog(){
var val = {PutniNalogId:this.PutniNalogId,
  Polazak:this.Polazak,
    Povratak:this.Povratak,
    RazlogPutovanja:this.RazlogPutovanja,
    BrojPutnika:this.BrojPutnika,
    Putnici:this.Putnici,
    Polaziste:this.Polaziste,
    Odrediste:this.Odrediste,
    Prijevoz:this.Prijevoz,
    RegistracijaVozila:this.RegistracijaVozila,
    Komentar:this.Komentar,
    Email:this.Email
}
this.service.addNalog(val).subscribe(res=>alert(res.toString()));
  }

  updatePutniNalog(){
    var val = {PutniNalogId:this.PutniNalogId,
      Polazak:this.Polazak,
        Povratak:this.Povratak,
        RazlogPutovanja:this.RazlogPutovanja,
        BrojPutnika:this.BrojPutnika,
        Putnici:this.Putnici,
        Polaziste:this.Polaziste,
        Odrediste:this.Odrediste,
        Prijevoz:this.Prijevoz,
        RegistracijaVozila:this.RegistracijaVozila,
    Komentar:this.Komentar,
    Email:this.Email
    }
    this.service.updateNalog(val).subscribe(res=>alert(res.toString()));

    
  }
}



