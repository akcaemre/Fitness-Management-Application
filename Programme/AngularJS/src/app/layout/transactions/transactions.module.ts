import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TransactionRoutingModule } from './transactions-routing.module';
import { TransactionComponent } from './transactions.component';

@NgModule({
    imports: [
        CommonModule, 
        TransactionRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        NgbModule.forRoot()
    ],
    declarations: [
        TransactionComponent
    ]
})
export class TransactionModule {}
