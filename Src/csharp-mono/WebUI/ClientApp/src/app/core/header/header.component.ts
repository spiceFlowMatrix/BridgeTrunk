import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import Auth0Client from '@auth0/auth0-spa-js/dist/typings/Auth0Client';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

    constructor(private auth: AuthService) { }

    ngOnInit() { }
}
