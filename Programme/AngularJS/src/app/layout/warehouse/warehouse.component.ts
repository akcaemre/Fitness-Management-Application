import { Component, OnInit, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { Http } from '@angular/http';
import { Response } from '@angular/http/src/static_response';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'app-warehouses',
    templateUrl: './warehouse.component.html',
    styleUrls: ['./warehouse.component.scss']
})

export class WarehouseComponent implements OnInit {
    selectedRow : Number = 0;
    setClickedRow : Function;
    rowCount: number;
    readURL: string = "http://localhost:1337/readWarehouse";
    public Lagereintrag: Observable<Array<any>>;

    constructor(private http: Http){
        this.Lagereintrag = this.setItems();
        this.setClickedRow = function(index){
            this.selectedRow = index;
        }
    };

    ngOnInit() { }
    
    setItems() {
        return this.http.get(this.readURL)
        .map((res:Response) => res.json());
    }
}