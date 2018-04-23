import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { DataTablesModule } from 'angular-datatables';


import { AppComponent } from './app.component';
import { ResultsGridComponent } from './results-grid/results-grid.component';
import { HttpModule } from '@angular/http'
import { HttpClient, HttpClientModule } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';


import { ProductsFilterComponent } from './products-filter/products-filter.component';
import { NgbdDatepickerRange } from './ngbd-datepicker-range/ngbd-datepicker-range.component';


@NgModule({
  declarations: [
    AppComponent,
    ResultsGridComponent,
    ProductsFilterComponent, 
    NgbdDatepickerRange
  ],
  imports: [
    BrowserModule,
    DataTablesModule,
    HttpModule,
    HttpClientModule,
    FormsModule,
    NgbModule.forRoot()
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
