﻿using HEB.ProductSearch.Model;
using HEB.ProductSearcher.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HEB.productSearcher.WebAPI.ModelBinders
{
    public class ProductDataQueryModelBinder : IModelBinder
    {
        static ProductDataQueryModelBinder()
        {

        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(ProductDataQuery))
            {
                return Task.CompletedTask;
            }

            try
            {
                var model = (ProductDataQuery)bindingContext.Model ?? new ProductDataQuery();

                int pageNumber;
                int pageSize;
                IList<Filter> filters = new List<Filter>();

                int.TryParse(GetValue(bindingContext, string.Empty, "PageNumber"), out pageNumber);
                int.TryParse(GetValue(bindingContext, string.Empty, "PageSize"), out pageSize);

                string stringFilters = GetValue(bindingContext, string.Empty, "Filters");
                string[] stringFilterArray;
                if (stringFilters != null)
                {
                    stringFilterArray = stringFilters.Split(',');

                    foreach (string stringFilter in stringFilterArray)
                    {
                        if (!string.IsNullOrWhiteSpace(stringFilter))
                        {
                            string[] filterInfo = stringFilter.Split('~');
                            FilterType filterType;
                            Enum.TryParse(filterInfo[1], false, out filterType);

                            if (filterType != FilterType.Undefined)
                            {
                                if (filterInfo.Length == 3)
                                    filters.Add(new Filter() { ColumnName = filterInfo[0], FilterType = filterType, Value = filterInfo[2] });
                            }
                            else
                            {
                                throw new NotImplementedException();
                            }
                        }
                    }
                }
                model.Filters = filters;
                model.PageNumber = pageNumber;
                model.PageSize = pageSize;               
                
                bindingContext.Result = ModelBindingResult.Success(model);

                return Task.CompletedTask;
            }
            catch (System.Exception Ex)
            {
                throw new InvalidOperationException("Error trying to read filters in your query, please verify ");
            }
        }

      

        private string GetValue(ModelBindingContext context, string prefix, string key)
        {
            var result = context.ValueProvider.GetValue(prefix + key); // <4>
            return result == null ? null : result.FirstValue;
        }



    }
}