package api;


import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ProductController {
	@GetMapping("/api/product")
    public DataQuery product(DataQuery dataQuery) {    	
        return dataQuery;
    }
}
