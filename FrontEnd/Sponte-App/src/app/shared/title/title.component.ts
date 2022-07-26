import { Component, OnInit,Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.css']
})
export class TitleComponent implements OnInit {
@Input() titulo: string | undefined ;
@Input() iconCless: string | undefined ;
@Input() subTitulo: string | undefined ;
@Input() botaolista = false ;
@Input() botaoLink: string | undefined;

  constructor(private router: Router) { }

  ngOnInit() {}

  listar(): void {
    this.router.navigate([this.botaoLink]);
  }
}

