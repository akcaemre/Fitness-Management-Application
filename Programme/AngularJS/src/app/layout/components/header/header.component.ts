import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
    constructor(private translate: TranslateService, public router: Router) { }
    ngOnInit() {}

    onLoggedout() {
        localStorage.removeItem('isLoggedin');
    }
}
