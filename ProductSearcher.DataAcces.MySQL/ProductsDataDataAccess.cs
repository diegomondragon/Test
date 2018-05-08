using Microsoft.Extensions.Configuration;
using ProductSearcher.Model;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using ProductSearcher.Common;
using System.Linq;

namespace ProductSearcher.DataAcces.MySQL
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

        public ProductDataQuery GetProducts(ProductDataQuery dataQuery)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string filterString = dataQuery.GetFiltersAsString();
                    string queryTotalProducts = SqlConstants.PRODUCTS_SELECT_QUERY_COUNT;
                    if (!string.IsNullOrEmpty(filterString))
                        queryTotalProducts += SqlConstants.WHERE + filterString;


                    MySqlCommand cmdTotalProducts = new MySqlCommand(queryTotalProducts, conn);
                    cmdTotalProducts.Parameters.AddRange(GetFilterParameters(dataQuery.Filters));
                    conn.Open();

                    Int32 count = Convert.ToInt32(cmdTotalProducts.ExecuteScalar());

                    cmdTotalProducts.Dispose();

                    dataQuery.Total = count;

                    string queryProducts = SqlConstants.PRODUCTS_SELECT_QUERY_OPEN;

                    if (!string.IsNullOrEmpty(filterString))
                        queryProducts += SqlConstants.WHERE + filterString;

                    queryProducts += SqlConstants.PRODUCTS_SELECT_QUERY_CLOSE;

                    MySqlCommand cmdProducts = new MySqlCommand(queryProducts, conn);

                    cmdProducts.Parameters.Add(new MySqlParameter(SqlConstants.ROW_START_PARAMETER_NAME, MySqlDbType.Int16));
                    cmdProducts.Parameters[SqlConstants.ROW_START_PARAMETER_NAME].Value = dataQuery.StartRow;

                    cmdProducts.Parameters.Add(new MySqlParameter(SqlConstants.ROW_END_PARAMETER_NAME, MySqlDbType.Int16));
                    cmdProducts.Parameters[SqlConstants.ROW_END_PARAMETER_NAME].Value = dataQuery.EndRow;

                    cmdProducts.Parameters.AddRange(GetFilterParameters(dataQuery.Filters));

                    List<Product> productList = new List<Product>();


                    using (MySqlDataReader reader = cmdProducts.ExecuteReader())
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

        public ProductDataQuery GetProducts()
        {
            throw new NotImplementedException();
        }

        public MySqlParameter[] GetFilterParameters(IList<Filter> filters)
        {
            List<MySqlParameter> sqlParameterList = new List<MySqlParameter>();

            foreach (KeyValuePair<string, ColumnType> column in ProductColumns.Columns)
            {
                List<Filter> columnFilters = filters.Where(x => column.Key.Equals(x.ColumnName, StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(x.Value)).ToList();
                int parameterIndex = 1;

                foreach (Filter filter in columnFilters)
                {
                    if (!string.IsNullOrEmpty(filter.Value))
                    {
                        ColumnType columnType = ProductColumns.Columns.Where(x => x.Key.ToLower() == filter.ColumnName.ToLower()).FirstOrDefault().Value;
                        switch (columnType)
                        {
                            case ColumnType.Date:
                                sqlParameterList.Add(new MySqlParameter("@" + @filter.ColumnName + parameterIndex, MySqlDbType.Date) { Value = Convert.ToDateTime(filter.Value) });
                                break;
                            case ColumnType.String:
                                sqlParameterList.Add(new MySqlParameter("@" + @filter.ColumnName + parameterIndex, MySqlDbType.VarChar) { Value = filter.Value });
                                break;
                            case ColumnType.Number:
                                sqlParameterList.Add(new MySqlParameter("@" + @filter.ColumnName + parameterIndex, MySqlDbType.Float) { Value = filter.Value });
                                break;

                        }
                    }
                    parameterIndex++;
                }
            }

            return sqlParameterList.ToArray();

        }


    }
}
