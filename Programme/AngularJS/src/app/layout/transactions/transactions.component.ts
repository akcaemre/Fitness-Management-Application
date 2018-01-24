import { Component, OnInit, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { Input } from '@angular/compiler/src/core';

@Component({
    selector: 'app-transactions',
    templateUrl: './transactions.component.html',
    styleUrls: ['./transactions.component.scss']
})
export class TransactionComponent implements OnInit {    
    private readUrl : string = "http://localhost:1337/readTrans";

    constructor(private http : Http) { }

    ngOnInit() {
        this.getTransactions();
    }

    getTransactions(){
        var i = 1;

		this.http.get(this.readUrl).subscribe(res =>{
            res.json().map(e => {
            document.getElementById('myTable').getElementsByTagName('tbody')[0].innerHTML += 
                "<tr class=\" " + (e.Typ == "Auslagerung" ? "table-danger" : "table-success") +" \">"
                + "<th scope=\"row\">" + i + "</th>"
                + "<td>" + e.Name + "</td>"
                + "<td>" + e.Produkt + "</td>"
                + "<td>" + e.Menge + "</td>"
                + "<td>" + e.Einheit + "</td>"
                + "<td>" + e.PreisProEinheit + "</td>"
                + "<td>" + e.Gesamtpreis + "</td>"
                + "<td>" + e.Währung + "</td>"
                + "<td>" + e.Datum + "</td>"
                + "</tr>";
                i++;
                console.log(e);
            })});
    }
}
