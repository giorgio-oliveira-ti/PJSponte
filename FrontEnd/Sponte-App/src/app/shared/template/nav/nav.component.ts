import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  isCollapsed = true;
  navbar: boolean = true;
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  showMenu(): boolean {

   if(this.router.url == '/user/login' || this.router.url == '/user/registration' ){
   this.navbar = false;
   }else{
    this.navbar = true;
   }

    return this.navbar;
  }

}
