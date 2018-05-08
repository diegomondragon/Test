using Microsoft.Extensions.Configuration;
using ProductSearcher.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ProductSearcher.DataAccess
{
    public class ProductsDataDataAccess : IProductsDataDataAccess
    {
        private const string CONNECTION_STRING_NAME = "dbConnectionString";
        private string _connectionString;
        public static IConfiguration Configuration { get; set; }
        public string connectionString
        {
            get
            {
                try
                {
                    IConfigurationBuilder builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json");

                    Configuration = builder.Build();

                    _connectionString = Configuration["ConnectionStrings:" + CONNECTION_STRING_NAME];
                    return _connectionString;
                }
                catch { throw new ArgumentNullException("Connection string Not found!"); };
            }
            private set { }
        }
        public ProductsDataDataAccess()
        {
        }
        public ProductDataQuery GetProducts(ProductDataQuery dataQuery)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string filterString = GetFiltersAsString(dataQuery.Filters);
                    string queryTotalProducts = SqlConstants.PRODUCTS_SELECT_QUERY_COUNT;
                    if (!string.IsNullOrEmpty(filterString))
                        queryTotalProducts += SqlConstants.WHERE + filterString;


                    SqlCommand cmdTotalProducts = new SqlCommand(queryTotalProducts, conn);
                    cmdTotalProducts.Parameters.AddRange(GetFilterParameters());
                    conn.Open();

                    Int32 count = Convert.ToInt32(cmdTotalProducts.ExecuteScalar());

                    cmdTotalProducts.Dispose();

                    dataQuery.Total = count;

                    string queryProducts = SqlConstants.PRODUCTS_SELECT_QUERY_OPEN;

                    if (!string.IsNullOrEmpty(filterString))
                        queryProducts += SqlConstants.WHERE + filterString;

                    queryProducts += SqlConstants.PRODUCTS_SELECT_QUERY_CLOSE;

                    SqlCommand cmdProducts = new SqlCommand(queryProducts, conn);

                    cmdProducts.Parameters.Add(new SqlParameter(SqlConstants.ROW_START_PARAMETER_NAME, SqlDbType.Int));
                    cmdProducts.Parameters[SqlConstants.ROW_START_PARAMETER_NAME].Value = dataQuery.StartRow;

                    cmdProducts.Parameters.Add(new SqlParameter(SqlConstants.ROW_END_PARAMETER_NAME, SqlDbType.Int));
                    cmdProducts.Parameters[SqlConstants.ROW_END_PARAMETER_NAME].Value = dataQuery.EndRow;

                    cmdProducts.Parameters.AddRange(GetFilterParameters());

                    List<Product> productList = new List<Product>();


                    using (SqlDataReader reader = cmdProducts.ExecuteReader())
                    {
                        int idOrdinal = reader.GetOrdinal("Id");
                        int descriptionOrdinal = reader.GetOrdinal("Description");
                        int lastSoldOrdinal = reader.GetOrdinal("LastSold");
                        int shelfLifeOrdinal = reader.GetOrdinal("ShelfLife");
                        int departmentOrdinal = reader.GetOrdinal("Department");
                        int priceOrdinal = reader.GetOrdinal("Price");
                        int unitOrdinal = reader.GetOrdinal("Unit");
                        int xForOrdinal = reader.GetOrdinal("xFor");
                        int costOrdinal = reader.GetOrdinal("Cost");

                        while (reader.Read())
                        {
                            productList.Add(new Product()
                            {
                                Id = (int)reader.GetInt32(idOrdinal),
                                Description = !reader.IsDBNull(descriptionOrdinal) ? reader.GetString(descriptionOrdinal) : string.Empty,
                                LastSold = reader.GetDateTime(lastSoldOrdinal),
                                ShelfLife = !reader.IsDBNull(shelfLifeOrdinal) ? reader.GetInt64(shelfLifeOrdinal) : 0,
                                Department = !reader.IsDBNull(departmentOrdinal) ? reader.GetString(departmentOrdinal) : string.Empty,
                                Price = !reader.IsDBNull(priceOrdinal) ? reader.GetDouble(priceOrdinal) : 0,
                                Unit = !reader.IsDBNull(unitOrdinal) ? reader.GetString(unitOrdinal) : string.Empty,
                                XFor = !reader.IsDBNull(xForOrdinal) ? reader.GetInt32(xForOrdinal) : 0,
                                Cost = !reader.IsDBNull(costOrdinal) ? reader.GetDouble(costOrdinal) : 0
                            });
                        }
                    }
                    dataQuery.Result = productList;
                }
            }
            catch (Exception Ex)
            {
                //TODO: Log to file for make easy debbuging
                throw;
            }

            return dataQuery;
        }

        private Array GetFilterParameters()
        {
            throw new NotImplementedException();
        }

        private string GetFiltersAsString(IList<Filter> filters)
        {
            throw new NotImplementedException();
        }

        public ProductDataQuery GetProducts()
        {
            return GetProducts(new ProductDataQuery());
        }    
    }
}
