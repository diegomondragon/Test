import { Component, OnInit,EventEmitter, Input, OnChanges, SimpleChange, Output } from '@angular/core';

class SearchParameters{
  public description: string;
  public lastSoldFrom: Date;
  public lastSoldTo: Date;
  public shelfLifeFrom: Number;
  public shelfLifeTo: Number;
  public departmentId: Number;
  public priceFrom: Number;
  public priceTo: Number;
  public unitId: Number;
  public xFor: Number;
  public costFrom: Number;
  public costTo: Number;
  constructor() {
    this.unitId = 0;
    this.departmentId = 0;
  }
}

@Component({
  selector: 'app-products-filter',
  templateUrl: './products-filter.component.html',
  styleUrls: ['./products-filter.component.css']
})


export class ProductsFilterComponent implements OnInit {
  @Output() searchQueryChanged = new EventEmitter<string>();

  searchModel = new SearchParameters();

  constructor() { }

  ngOnInit() {
    this.searchQueryChanged.emit(convertParamentersToQueryString(this.searchModel));    
  }

  onClickSearshBtn(event: any) {
    let evtMsg = event ? ' Event target is ' + event.target.tagName  : '';
    console.log(this.searchModel);
    this.searchQueryChanged.emit(convertParamentersToQueryString(this.searchModel));
  }

  onClickResetBtn(event: any) {
    this.searchModel = new SearchParameters();
    this.searchQueryChanged.emit(convertParamentersToQueryString(this.searchModel));
  }  
}

function convertParamentersToQueryString(searchModel:SearchParameters) : string {
   let result = "";
    if(searchModel.description){    
      result = "Description~Contains~" + searchModel.description + ",";
    }

    if(searchModel.lastSoldFrom){    
      result += "lastSold~GreatherEqualThan~" + searchModel.lastSoldFrom + ",";    
    }

    if(searchModel.lastSoldTo){    
      result += "lastSold~LessEqualThan~" + searchModel.lastSoldTo + ",";
    }

    if(searchModel.shelfLifeFrom){
      result += "shelfLife~GreatherEqualThan~" + searchModel.shelfLifeFrom + ",";    
    }
    if(searchModel.shelfLifeTo){
      result += "shelfLife~LessEqualThan~" + searchModel.shelfLifeTo + ",";    
    }

    if(searchModel.departmentId > 0)
    {
      result += "departmentId~Equal~" + searchModel.departmentId + ",";
    }

    if(searchModel.priceFrom){    
      result += "price~GreatherEqualThan~" + searchModel.priceFrom + ",";    
    }

    if(searchModel.priceTo){    
      result += "price~LessEqualThan~" + searchModel.priceTo + ",";
    }

    if(searchModel.unitId > 0){    
      result += "unitId~Equal~" + searchModel.unitId + ",";
    }

    if(searchModel.costFrom){    
      result += "cost~GreatherEqualThan~" + searchModel.costFrom + ",";
    }

    if(searchModel.costTo){    
      result += "cost~LessEqualThan~" + searchModel.costTo + ",";    
    }

    if(result){
      result = "&Filters=" + result;
    }
  return result;
}