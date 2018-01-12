import { Component, OnInit, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../router.animations';
import { Http } from '@angular/http';
import { Input } from '@angular/compiler/src/core';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    animations: [routerTransition()]
})
export class LoginComponent implements OnInit {
    private postLoginUrl = "http://localhost:1337/user";
    private email : string = "";
    private password : string = "";
    private alerts: Array<any> = [];

    constructor(public router: Router, private http : Http) { 
        this.alerts.push({
            id: 1,
            type: 'danger',
            message: 'Login failed.',
        });
    }

    ngOnInit() {}

    public closeAlert(alert: any) {
        const index: number = this.alerts.indexOf(alert);
        this.alerts.splice(index, 1);
    }
    
    onLoggedin() {
        var error = null;

        if(this.email == "" || this.password == "") {
            this.setError((this.email == "" ? "E-Mail " : "") +
            (this.email == "" && this.password == "" ? "und " : "")
            + (this.password == "" ? "Passwort" : "") + " ist leer!");
        } else {
            this.getLoginData().map(res => res.json()).subscribe(
                (data) => localStorage.setItem('isLoggedin', 'true'),
                (err) => this.setError(err));
        }
    }

    setError(msg) {
        this.alerts[0].message = msg;
        document.getElementById("AppAlert").hidden = false;
    }
    getLoginData() {
         return this.http.post(this.postLoginUrl, {
			"email" : this.email,
            "passwort" : this.password
		});
    }
}
