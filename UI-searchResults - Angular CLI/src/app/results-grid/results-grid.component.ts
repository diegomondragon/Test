import { AfterViewInit, Component, OnInit, Input, OnChanges, SimpleChange, ViewChild } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs/Subject';


class Product {
  public Id: number;
  public Description: string;
  public LastSold: Date;
  public ShelfLife: number;
  public DepartmentId: number;
  public Price: number;
  public Unit: string;
  public XFor: number;
  public Cost: number;
}

class ProductDataQuery {
  public PageNumber: number;
  public PageSize: number;
  public Result: Product[];
  public Total: number;    
}
@Component({
  selector: 'app-results-grid',
  templateUrl: './results-grid.component.html',
  styleUrls: ['./results-grid.component.css']
})
export class ResultsGridComponent implements OnInit, OnChanges, AfterViewInit {
  @Input() searchQuery;

  @ViewChild(DataTableDirective)
  datatableElement: DataTableDirective;

  dtTrigger: Subject<any> = new Subject<any>();


  dtOptions: DataTables.Settings = {};
  products: Product[];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    const that = this;

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 2,
      serverSide: true,
      processing: true,
      ordering:  false,
      searching: false,
      lengthMenu: [ 2, 5, 10, 50, 100 ],
      ajax: (dataTablesParameters: any, callback) => {
        that.http
          .get<ProductDataQuery>(
            'http://diegom-webapi.azurewebsites.net/api/products'  + getQueryString(dataTablesParameters)  + this.searchQuery,
             {}
          ).subscribe(resp => {
            that.products = resp.Result;
            
            callback({
              recordsTotal: resp.Total,
              recordsFiltered: resp.Total,
              data: []
            });
          });
      },
      columns: [{ data: 'Id' }, 
                { data: 'Description' }, 
                { data: 'LastSold' },
                { data: 'ShelfLife' }, 
                { data: 'Department' }, 
                { data: 'Price' },
                { data: 'Unit' }, 
                { data: 'XFor' }, 
                { data: 'Cost' }]
    };
  }  

  ngOnChanges(changes: {[propKey: string]: SimpleChange}): void {
    console.log("Changes!! " + this.searchQuery);
    this.datatableElement.dtInstance.then((dtInstance: DataTables.Api) => {
      dtInstance.destroy();
      this.dtTrigger.next();
    });
  }
  
  ngAfterViewInit(): void {
    this.dtTrigger.next();
  }
}

function  getQueryString(dataTablesParameters: any):string {
  var PageNumber = 1;
  if(dataTablesParameters.start > 0)
    var PageNumber = ((dataTablesParameters.start)/dataTablesParameters.length) + 1;
    return "?PageNumber=" + PageNumber + "&PageSize=" + dataTablesParameters.length;
}
