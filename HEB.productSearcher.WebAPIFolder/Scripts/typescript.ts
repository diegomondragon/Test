class Product {
    public Id: number;
    public Description: string;
    public LastSold: Date;
    public ShelfLife: number;
    public Department: string;
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