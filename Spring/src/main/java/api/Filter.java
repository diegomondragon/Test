package api;

public class Filter {
	 private FilterType FilterType;
	 private String ColumnName;
	 private String Value;

	public Filter(String string, String string2, String string3) {
		this.ColumnName = string;
		this.FilterType =   api.FilterType.valueOf(string2);
		this.Value = string3;		
	}

	public FilterType getFilterType() {
		return FilterType;
	}

	public void setFilterType(FilterType filterType) {
		FilterType = filterType;
	}

	public String getValue() {
		return Value;
	}

	public void setValue(String value) {
		Value = value;
	}

	public String getColumnName() {
		return ColumnName;
	}

	public void setColumnName(String columnName) {
		ColumnName = columnName;
	}

}
