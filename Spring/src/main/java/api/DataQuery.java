	package api;

import java.util.ArrayList;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public class DataQuery
{
    private int PageNumber;
    private int PageSize;
    private List<Filter> FilterList;
    private List<Product> Result;
    private int Total;
    private int StartRow;
    private int EndRow;
    private String Filters;

    
    public void ProductDataQuery()
    {
        setFilterList(new ArrayList<Filter>());
        setResult(new ArrayList<Product>());
    }
	public int getPageNumber() {
		return PageNumber;
	}
	public void setPageNumber(int pageNumber) {
		PageNumber = pageNumber;
	}
	public int getPageSize() {
		return PageSize;
	}
	public void setPageSize(int pageSize) {
		PageSize = pageSize;
	}
	
	public int getTotal() {
		return Total;
	}
	public void setTotal(int total) {
		Total = total;
	}
	public int getStartRow() {
		return StartRow;
	}
	public void setStartRow(int startRow) {
		StartRow = startRow;
	}
	public int getEndRow() {
		return EndRow;
	}
	public void setEndRow(int endRow) {
		EndRow = endRow;
	}

	public List<Filter> getFilterList() {
		FilterList = new ArrayList<Filter>();
		if(Filters != null && !Filters.isEmpty()) {
			String[] filterRows;
			filterRows = Filters.split(",");
			for(String filterRow: filterRows) {
				String[] filterParts = filterRow.split("~");
				Filter newFilter = new Filter(filterParts[0],filterParts[1],filterParts[2]);
				FilterList.add(newFilter);
			}
		}
		return FilterList;
	}
	public void setFilterList(List<Filter> filterList) {
		FilterList = filterList;
	}

	public List<Product> getResult() {
		return Result;
	}
	public void setResult(List<Product> result) {
		Result = result;
	}
	public String getFilters() {
		return Filters;
	}
	public void setFilters(String filters) {
		Filters = filters;
	}
 
}